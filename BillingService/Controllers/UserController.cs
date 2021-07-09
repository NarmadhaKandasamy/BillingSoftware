using BillingService.ObjectModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        [Route("CheckUserLogin")]
        public ActionResult CheckUserLogin([FromBody] LoginUser loginUser)
        {
            if (loginUser == null)
                return NotFound();

            if(loginUser.UserName =="kar.mks@gmail.com" && loginUser.PassWord=="12345")
            {
                return Ok(loginUser.UserName);
            }
            else
            {
                return NotFound();
            }            
        }
    }
}
