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
    
    public class HSBReportController : Controller
    {

        GenerateReport objReport;
        
        ResponseData response;
        public HSBReportController()
        {
            objReport = new GenerateReport();
           
        }
        [Route("getBestPerformer")]
        [HttpPost]
        public ResponseData GetUserDetails([FromBody]BestPerformer best)
        {
            response = new ResponseData();
         response.Data =  objReport.BestPerformer(best);
            
           return response;

            
        }
        

        
    }
}
