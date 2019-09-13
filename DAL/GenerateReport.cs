using System;
using HSBank.DTO;
using System.Data;
using MySql.Data.MySqlClient;
using System.Net;

namespace HSBank.DAL
{
    public class GenerateReport
    {
        ResponseData response = null;
        readonly HSBContext db ;
       readonly string database;
        public GenerateReport()
        {
            db = new HSBContext();
             
        }

        public ResponseData BestPerformer (BestPerformer obj)
        {
            try{
                DataSet ds = new DataSet();
                using(var con = new MySqlConnection (database))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("usp_BestPerformer",con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con ;
                    cmd.Parameters.AddWithValue("@in_FromDate",obj.startDate);
                    cmd.Parameters.AddWithValue("@in_ToDate",obj.startDate);
                    using(MySqlDataAdapter adr = new MySqlDataAdapter())
                    {
                        adr.SelectCommand = cmd;
                        adr.Fill(ds);
                        response.Data = ds;
                        response.Code = (int)HttpStatusCode.OK;
                        return response;
                    }


                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
