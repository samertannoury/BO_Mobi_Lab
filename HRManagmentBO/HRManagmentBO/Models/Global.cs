using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRManagmentBO.Models
{

    public class RestAPIRequest
    {
        public string methodType { get; set; }
        public string URL { get; set; }
        public string contentType { get; set; }
        public string body { get; set; }
        public Dictionary<string, string> headers { get; set; }
        public string response { get; set; }
        public string httpStatus { get; set; }
        public bool requireAuthorization { get; set; }
    }

    public class APIResponse
    {
        public int RespCode { get; set; }
        public string RespDesc { get; set; }
        public string Json { get; set; }
    }

}