using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HSBank.DTO;
using HSBank.DAL;
using System.Net;

namespace HSBAccount.Controllers
{
    
    public class HSBAccountController : Controller
    {

        DalHSBAccounts objDAL;
        private HttpStatusCode  code ;

        ResponseData response = new ResponseData();
        public HSBAccountController()
        {
            objDAL = new DalHSBAccounts();
            code = HttpStatusCode.OK;
        }
        [Route("getAccounts")]
        [HttpPost]
        public IActionResult Getaccountdets([FromBody]account oid)
        {
           response =  objDAL.getaccountdetails(oid);
            
           return StatusCode((int)code,response);

            
        }
        [Route("AddAccount")]
        [HttpPost]
        public ResponseData AddAccountDetails([FromBody]AccountDetails act)
        {
            response =  objDAL.AddAccountDetails(act);
            
           return response;
        }
        [Route("DeleteAccount")]
        [HttpDelete]
        public ResponseData DeleteAccountDetails(int id)
        {
            response =  objDAL.DeleteAccountDetails(id);
            
           return response;

            
        }

        
    }
}
