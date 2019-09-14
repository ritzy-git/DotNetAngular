using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HSBank.DTO;
using HSBank.DAL;
using System.Net;
using System.Data;

namespace HSBUser.Controllers
{
    
    public class HSBReportController : Controller
    {

        GenerateReport objReport;
        
        
        public HSBReportController()
        {
            objReport = new GenerateReport();
           
        }
        [Route("getBestPerformer")]
        [HttpPost]
        public ResponseData GetUserDetails([FromBody]BestPerformer best)
        {
            List<Output> lst = new List<Output>();
            ResponseData response = new ResponseData();
            DataSet dstable =  objReport.BestPerformer(best);   
            if(dstable != null && dstable.Tables.Count>0) {
                DataTable table ;
                table = dstable.Tables[1];
                if(table != null && table.Rows.Count > 0)
                {
                    foreach(DataRow dr in table.Rows)
                    {
                        Output objout = new Output();
                        objout.accntID = Convert.ToInt32(dr["AccountId"]);
                        objout.userName = Convert.ToString(dr["Name"]);
                        objout.percentage = Convert.ToInt32(dr["Percentage"]);
                            lst.Add(objout);

                    }
                    
                    response.Data = lst.ToList();
                }
                
            }         
           return response;

            
        }
        

        
    }
}
