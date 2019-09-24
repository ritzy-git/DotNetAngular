using System;
using HSBank.DTO;
using System.Data;
using MySql.Data.MySqlClient;
using System.Net;
using System.Globalization;

namespace HSBank.DAL
{
    public class GenerateReport
    {
        ResponseData response = null;
        readonly HSBContext db ;
       readonly string database;
        public GenerateReport()
        {
            EncryptDecrypt objEncDec = new EncryptDecrypt();
            database = objEncDec.Decryptdata(Startup.ConnectionString);
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
                    

                    cmd.Parameters.AddWithValue("@in_FromDate",obj.startDate.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@in_ToDate",obj.endDate.ToString("yyyy-MM-dd"));
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
