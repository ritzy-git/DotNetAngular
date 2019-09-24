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
    public class DalHSBAccounts
    {
        readonly HSBContext db;
        ResponseData response;
        
        public DalHSBAccounts()
        {
            db = new HSBContext();
        }
        
        public ResponseData Get()

        {
             var records = db.AccountDetails.ToList();
                response = new ResponseData();
                if(records.Count > 0)
                    response.Data = records;
                 
                else 
                response.Message = CustomMessage.NoData;

                return response;
             
        }
        public ResponseData getaccountdetails(account id)
        {
            ResponseData response = new ResponseData();
            try{
                var records = db.AccountDetails.Where(X=> X.AccountId == id.id).ToList();
                if (records.Count > 0)
                {

                    var jsonresult = (from ad in db.AccountDetails
                                      from pd in db.PaymentDetails
                                      where pd.AccountId == ad.AccountId
                                      select new
                                      {
                                          TransDate = pd.TransactionDate,
                                          TransAmt = pd.TransactionAmount,
                                          ActID = pd.AccountId,
                                          AName = ad.Name,
                                          MonthlyCL = ad.MontlyCl

                                      }).ToList();
                    response.Data = jsonresult.Where(x => x.ActID == id.id).ToList();
                    response.Code = (int)HttpStatusCode.OK;
                }


                else
                {
                    response.Message = CustomMessage.NoData;
                    response.Code = (int)HttpStatusCode.BadRequest;
                }
                return response;
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        
        public ResponseData AddAccountDetails(AccountDetails act)
        {
            ResponseData response = new ResponseData();
            try{
                var validation = db.AccountDetails.Where(x => x.Name.ToLower() == act.Name.ToLower());
                if(validation.Count() > 0)
                {
                    response.Message = CustomMessage.SameAct;
                    response.Code = (int)HttpStatusCode.BadRequest;
                    return response;
                }
                if(act.MontlyCl==0)
                {

                    response.Message = CustomMessage.MinAmt;
                    response.Code = (int)HttpStatusCode.BadRequest;
                    return response;
                }
                db.AccountDetails.Add(act);
                db.SaveChanges();
                 response.Message = CustomMessage.DataSaved;
                response.Code = (int)HttpStatusCode.OK;
                return response;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public ResponseData DeleteAccountDetails(int id)
        {
            ResponseData response = new ResponseData();
            try{
                AccountDetails obj = db.AccountDetails.Find(id);
                db.AccountDetails.Remove(obj);
                response.Message = CustomMessage.DataDeleted;
                response.Code = (int)HttpStatusCode.OK;
                return response;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}