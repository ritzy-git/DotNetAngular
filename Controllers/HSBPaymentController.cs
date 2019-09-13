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
    
    public class HSBPayment : Controller
    {

        DalHSBPayments objDAL;
        private HttpStatusCode  code ;

        ResponseData response = new ResponseData();
        public HSBPayment()
        {
            objDAL = new DalHSBPayments();
            code = HttpStatusCode.OK;
        }
        [Route("getPayments")]
        [HttpGet]
        public IActionResult Getpaymentdetails()
        {
           response.Data =  objDAL.getpayments();

            
           return StatusCode((int)code,response);

            
        }
        [Route("AddPayment")]
        [HttpPost]
        public ResponseData AddAccountDetails([FromBody]PaymentDetails act)
        {
            response =  objDAL.AddPayments(act);
            
           return response;
        }
        

        
    }
}
