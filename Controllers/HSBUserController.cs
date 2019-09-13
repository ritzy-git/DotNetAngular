using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HSBank.DTO;
using HSBank.DAL;
using System.Net;

namespace HSBUser.Controllers
{
    
    public class HSBUserController : Controller
    {

        DalHSBUser objDAL;
        private HttpStatusCode  code ;
        ResponseData response;
        public HSBUserController()
        {
            objDAL = new DalHSBUser();
            code = HttpStatusCode.OK;
        }
        [Route("getUser")]
        [HttpPost]
        public IActionResult GetUserDetails()
        {
          response.Data =  objDAL.getusers();
            
           return StatusCode((int)code,response);

            
        }
        [Route("AddUser")]
        [HttpPost]
        public string AddUserDetails([FromBody]UserMaster user)
        {
            response.Message =  objDAL.AddUser(user);
            return response.Message;
        }
         [Route("DeleteUser")]
        [HttpDelete]
        public ResponseData DeleteAccountDetails(int id)
        {
            response.Message =  objDAL.DeleteUser(id);
            return response;
        }

        
    }
}
