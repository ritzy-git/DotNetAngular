using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using HSBank.DTO;
using System.Net;

namespace HSBank.DAL
{
    public class DalHSBLogin
    {
        readonly HSBContext db;
        
        public DalHSBLogin()
        {
            db = new HSBContext();
           
        }
        
        
        
        public ResponseData ValidateUser(Login user)
        {
             EncryptDecrypt objEncDec = new EncryptDecrypt();
            try{
                ResponseData response = new ResponseData();
                AccountDetails act = new AccountDetails();
                var result = db.UserMaster.Where(x => x.UserName == user.username && x.Password == user.password).FirstOrDefault();
                LoginOutput output = new LoginOutput();
                if(result != null)
                {
                    output.status = "True";
                    IQueryable<AccountDetails> output1 = db.AccountDetails.Where(x => x.Name == user.username);
                     output.AccountId = output1.Select(x => x.AccountId).FirstOrDefault();
                    response.Data = output;
                    return response;
                }

                else
                {
                    output.status = "False";
                    response.Data = output;
                    response.Message = CustomMessage.InvalidCreds;
                    response.Code = (int)HttpStatusCode.BadRequest;

                return response;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public string DeleteAccountDetails(int id)
        {
            try{
                AccountDetails obj = db.AccountDetails.Find(id);
                db.AccountDetails.Remove(obj);
                return CustomMessage.DataDeleted;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}