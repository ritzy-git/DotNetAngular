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
            database = Startup.ConnectionString;
            db = new HSBContext();
             
        }

        public DataSet BestPerformer (BestPerformer obj)
        {
            try{
                DataSet ds ;
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
                        ds = new DataSet();
                        adr.SelectCommand = cmd;
                        adr.Fill(ds);
                       // response.Data = ds;
                       // response.Code = (int)HttpStatusCode.OK;
                        return ds;
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
