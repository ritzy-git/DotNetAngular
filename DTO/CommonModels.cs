using System;
using System.Net;
using Newtonsoft.Json;

namespace HSBank.DTO
{
    public class ResponseData
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Object Data;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorDesc;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int Code;
    }
    public static class CustomMessage
    {

        public static string InternalServerError = "Internal Server Error.Please Contact Administrator";


        public static string InvalidCreds = "Invalid Credentials";
        public static string NoData = "No record(s) found";
        public static string DataSaved = " record(s) saved successfully";
        public static string DataDeleted = "Record deleted successfully";
        public static string NoBalance = "Transaction cannot be processed, insufficient credit balance";
        public static string Paid = "Paid Successfully!";

    }
    public class BestPerformer
        {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
    public class Login
    {
        public string username { get; set; }
        public string password { get; set; }
    }
    public class LoginOutput
    {
        public string status { get; set; }
        public int AccountId { get; set; }
    }
    public class account
    {
        public int id{get;set;}
    }
    public class Output{
        public int accntID{get;set;}
        public string userName{get;set;}
        public int percentage{get;set;}
    }
}