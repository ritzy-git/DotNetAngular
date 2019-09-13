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
    public class DalHSBPayments
    {
        readonly HSBContext db;
        ResponseData response = null;
        public DalHSBPayments()
        {
            db = new HSBContext();
        }
        public ResponseData getpayments()
        {
            try{
                var records = db.PaymentDetails.ToList();
                response = new ResponseData();
                if(records.Count > 0)
                    response.Data = records;
                 
                else 
                response.Message = CustomMessage.NoData;

                return response;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public ResponseData AddPayments(PaymentDetails payment)
        {
            try{
                 response = new ResponseData();
                     
                AccountDetails act ;
               act =  db.AccountDetails.Find(payment.AccountId);
              int currentMonth = DateTime.Now.Month;

                IQueryable<PaymentDetails> objPayments = db.PaymentDetails.Where(x => x.AccountId == payment.AccountId && payment.TransactionDate.Value.Month == currentMonth);
                int usedLimit = objPayments.Select(x => x.TransactionAmount.Value).Sum();
                if (usedLimit + payment.TransactionAmount <= act.MontlyCl)
                {
                    db.PaymentDetails.Add(payment);
                    db.SaveChanges();
                    response.Message =  CustomMessage.Paid;
                    response.Code = (int)HttpStatusCode.OK;
                }
                else
                {
                    response.Message = CustomMessage.NoBalance;
                    response.Code = (int)HttpStatusCode.BadRequest;
                }
                return response;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        
    }
}