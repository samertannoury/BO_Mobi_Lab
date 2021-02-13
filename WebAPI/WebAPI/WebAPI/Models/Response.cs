using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Response
    {
        public int RespCode { get; set; }
        public string RespDesc { get; set; }
        public string Json { get; set; }
    }
}