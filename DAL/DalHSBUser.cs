using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using HSBank.DTO;


namespace HSBank.DAL
{
    public class DalHSBUser
    {
        readonly HSBContext db;
        ResponseData response;
        public DalHSBUser()
        {
            db = new HSBContext();
        }
        public ResponseData getusers()
        {
            try{
                var records = db.UserMaster.ToList();
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
        public string AddUser(UserMaster user)
        {
            try
            {
                db.UserMaster.Add(user);
                db.SaveChanges();
                return CustomMessage.DataSaved;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteUser(int id)
        {
            try
            {
                UserMaster obj = db.UserMaster.Find(id);
                db.UserMaster.Remove(obj);
                return CustomMessage.DataDeleted;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}