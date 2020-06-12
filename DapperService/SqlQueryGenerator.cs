using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using BillingSoftware.DataAnnotation;


namespace BillingSoftware.DapperService
{
    public class SqlQueryGenerator<T> : IDisposable where T : class
    {
        public SqlQueryGenerator()
        {
            this.LoadEntityMetadata();
        }

        private void LoadEntityMetadata()
        {
            var entityType = typeof(T);

            var aliasAttribute = entityType.GetCustomAttribute<StoredAs>();
            var schemeAttribute = entityType.GetCustomAttribute<Scheme>();
            this.TableName = aliasAttribute != null ? aliasAttribute.Value : entityType.Name;
            this.Scheme = schemeAttribute != null ? schemeAttribute.Value : "dbo";

            //Load all the "primitive" entity properties
            IEnumerable<PropertyInfo> props = entityType.GetProperties().Where(p => p.PropertyType.IsValueType ||
                                                                                    p.PropertyType.Name.Equals("String", StringComparison.InvariantCultureIgnoreCase) ||
                                                                                    p.PropertyType.Name.Equals("Byte[]", StringComparison.InvariantCultureIgnoreCase));

            //Filter the non stored properties
            this.BaseProperties = props.Where(p => !p.GetCustomAttributes<Exclude>().Any()).Select(p => new PropertyMetadata(p));

            //Filter key properties
            this.KeyProperties = props.Where(p => p.GetCustomAttributes<PrimaryKey>().Any()).Select(p => new PropertyMetadata(p));

            //Use identity as key pattern
            var identityProperty = props.SingleOrDefault(p => p.GetCustomAttributes<PrimaryKey>().Any(k => k.Identity));
            this.IdentityProperty = identityProperty != null ? new PropertyMetadata(identityProperty) : null;         
        }

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public bool IsIdentity
        {
            get
            {
                return this.IdentityProperty != null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool LogicalDelete
        {
            get
            {
                return this.StatusProperty != null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string TableName { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string Scheme { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public PropertyMetadata IdentityProperty { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<PropertyMetadata> KeyProperties { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<PropertyMetadata> BaseProperties { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public PropertyMetadata StatusProperty { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public object LogicalDeleteValue { get; private set; }

        #endregion




        public virtual string GetInsert()
        {
            //Enumerate the entity properties
            //Identity property (if exists) has to be ignored
            IEnumerable<PropertyMetadata> properties = (this.IsIdentity ?
                                                        this.BaseProperties.Where(p => !p.Name.Equals(this.IdentityProperty.Name, StringComparison.InvariantCultureIgnoreCase)) :
                                                        this.BaseProperties).ToList();

            string columNames = string.Join(", ", properties.Select(p => string.Format("[{0}].[{1}]", this.TableName, p.ColumnName)));
            string values = string.Join(", ", properties.Select(p => string.Format("@{0}", p.Name)));

            var sqlBuilder = new StringBuilder();
            sqlBuilder.AppendFormat("INSERT INTO [{0}].[{1}] {2} {3} ",
                                    this.Scheme,
                                    this.TableName,
                                    string.IsNullOrEmpty(columNames) ? string.Empty : string.Format("({0})", columNames),
                                    string.IsNullOrEmpty(values) ? string.Empty : string.Format(" VALUES ({0})", values));

            //If the entity has an identity key, we create a new variable into the query in order to retrieve the generated id
            if (this.IsIdentity)
            {
                sqlBuilder.AppendLine("DECLARE @NEWID BIGINT");
                sqlBuilder.AppendLine("SET	@NEWID = SCOPE_IDENTITY()");
                sqlBuilder.AppendLine("SELECT @NEWID");
            }

            return sqlBuilder.ToString();
        }

        public virtual string GetUpdate()
        {
            var properties = this.BaseProperties.Where(p => !this.KeyProperties.Any(k => k.Name.Equals(p.Name, StringComparison.InvariantCultureIgnoreCase)));

            var sqlBuilder = new StringBuilder();
            sqlBuilder.AppendFormat("UPDATE [{0}].[{1}] SET {2} WHERE {3}",
                                    this.Scheme,
                                    this.TableName,
                                    string.Join(", ", properties.Select(p => string.Format("[{0}].[{1}] = @{2}", this.TableName, p.ColumnName, p.Name))),
                                    string.Join(" AND ", this.KeyProperties.Select(p => string.Format("[{0}].[{1}] = @{2}", this.TableName, p.ColumnName, p.Name))));

            return sqlBuilder.ToString();
        }

        public virtual string GetSelectAll()
        {
            return this.GetSelect(new { });
        }


        public virtual string GetSelect(object filters, int? rowCount = null)
        {
            //Projection function
            Func<PropertyMetadata, string> projectionFunction = (p) =>
            {
                if (!string.IsNullOrEmpty(p.Alias))
                    return string.Format("[{0}].[{1}] AS [{2}]", this.TableName, p.ColumnName, p.Name);

                return string.Format("[{0}].[{1}]", this.TableName, p.ColumnName);
            };

            var sqlBuilder = new StringBuilder();

            var rowLimitSql = string.Empty;

            if (rowCount.HasValue)
            {
                rowLimitSql = string.Format("TOP {0} ", rowCount);
            }

            sqlBuilder.AppendFormat("SELECT {0}{1} FROM [{2}].[{3}] WITH (NOLOCK)",
                                    rowLimitSql,
                                    string.Join(", ", this.BaseProperties.Select(projectionFunction)),
                                    this.Scheme,
                                    this.TableName
                                    );

            //Properties of the dynamic filters object
            var filterProperties = filters.GetType().GetProperties().Select(p => p.Name);
            bool containsFilter = (filterProperties != null && filterProperties.Any());

            if (containsFilter)
                sqlBuilder.AppendFormat(" WHERE {0} ", this.ToWhere(filterProperties, filters));

            //Evaluates if this repository implements logical delete
            if (this.LogicalDelete)
            {
                if (containsFilter)
                    sqlBuilder.AppendFormat(" AND [{0}].[{1}] != {2}",
                                            this.TableName,
                                            this.StatusProperty.Name,
                                            this.LogicalDeleteValue);
                else
                    sqlBuilder.AppendFormat(" WHERE [{0}].[{1}] != {2}",
                                            this.TableName,
                                            this.StatusProperty.Name,
                                            this.LogicalDeleteValue);
            }

            return sqlBuilder.ToString();
        }

        public virtual string GetDelete(object filters, int? rowCount = null)
        {
            var sqlBuilder = new StringBuilder();

            var rowLimitSql = string.Empty;
            sqlBuilder.AppendFormat("DELETE FROM [{0}].[{1}] WHERE ",
                                       this.Scheme,
                                       this.TableName);

            var filterProperties = filters.GetType().GetProperties().Select(p => p.Name);
            bool containsFilter = (filterProperties != null && filterProperties.Any());

            if (containsFilter)
                sqlBuilder.AppendFormat(" {0} ", this.ToWhere(filterProperties, filters));

            return sqlBuilder.ToString();
        }

        public virtual string GetDelete()
        {
            var sqlBuilder = new StringBuilder();

            if (!this.LogicalDelete)
            {
                sqlBuilder.AppendFormat("DELETE FROM [{0}].[{1}] WHERE {2}",
                                        this.Scheme,
                                        this.TableName,
                                        string.Join(" AND ", this.KeyProperties.Select(p => string.Format("[{0}].[{1}] = @{2}", this.TableName, p.ColumnName, p.Name))));

            }
            else
                sqlBuilder.AppendFormat("UPDATE [{0}].[{1}] SET {2} WHERE {3}",
                                    this.Scheme,
                                    this.TableName,
                                    string.Format("[{0}].[{1}] = {2}", this.TableName, this.StatusProperty.ColumnName, this.LogicalDeleteValue),
                                    string.Join(" AND ", this.KeyProperties.Select(p => string.Format("[{0}].[{1}] = @{2}", this.TableName, p.ColumnName, p.Name))));


            return sqlBuilder.ToString();
        }

        public virtual string ToWhere(IEnumerable<string> properties, object filters)
        {
            return string.Join(" AND ", properties.Select(p =>
            {

                var propertyMetadata = this.BaseProperties.FirstOrDefault(pm => pm.Name.Equals(p, StringComparison.InvariantCultureIgnoreCase));

                var columnName = p;
                var propertyName = p;

                if (propertyMetadata != null)   
                {
                    columnName = propertyMetadata.ColumnName;
                    propertyName = propertyMetadata.Name;
                }

                var prop = filters.GetType().GetProperty(propertyMetadata.Name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                var values = prop.GetValue(filters, null);

                if (values == null)
                {
                    return string.Format("[{0}].[{1}] IS NULL", this.TableName, columnName);
                }
                //else if ((values as IEnumerable) != null && !(values is string))
                //{
                //    return string.Format("[{0}].[{1}] IN @{2}", this.TableName, columnName, propertyName);
                //}
                else
                {
                    return string.Format("[{0}].[{1}] = @{2}", this.TableName, columnName, propertyName);
                }

            }));
        }



        public void Dispose()
        {
            //this.Dispose();
        }
    }
}
