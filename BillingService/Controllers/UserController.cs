using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using BillingService.ObjectModel;
using BillingSoftware.ClassModels;
using BillingService.BusinessServices;

namespace BillingService.Controllers
{
    [EnableCors("CROSPolicy")]
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {        
        [HttpPost]
        [Route("CheckUserLogin")]
        public ActionResult CheckUserLogin([FromBody] LoginUser loginUser)
        {
            if (loginUser == null)
                return NotFound();

            return Ok(Helper.ProcessLoginInfo(loginUser));
        }
     
        [HttpPost]
        [Route("newRegistration")]
        public ActionResult userRegistration([FromBody] NewUserRegister newUseRegister)
        {
            if (newUseRegister == null)
                return NotFound();
            newUseRegister.State = "1";
            newUseRegister.Country = "1";
            return Ok(RegisterHelper.NewUserRegisteration(newUseRegister));
        }
        
        [HttpPost]
        [Route("userActivation")]
        public ActionResult userActivation(string QueryParam)
        {
            
            return Ok();
        }
    }
}
