    using System.Net;
    using HSBank.DAL;
    using HSBank.DTO;
    using Microsoft.AspNetCore.Mvc;

    namespace HSBUser.Controllers
    {

        public class HSBLoginController : Controller
        {

            DalHSBLogin objDAL;
            private HttpStatusCode  code ;
           // ResponseData response;
            public HSBLoginController()
            {
                objDAL = new DalHSBLogin();
                code = HttpStatusCode.OK;
            }
            [Route("Login")]
            [HttpPost]
            public ResponseData Login([FromBody]Login login)
            {
             ResponseData response = new ResponseData();
             response = objDAL.ValidateUser(login);
             return response;
            }
      
        }
    } 
