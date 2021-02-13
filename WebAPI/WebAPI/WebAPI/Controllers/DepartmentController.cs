using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    public class DepartmentController : ApiController
    {
        public DepartmentRepository repo;

        public DepartmentController()
        {
            repo = new DepartmentRepository();
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("GetDepartmentList")]
        public Response GetDepartmentList()
        {
            Response resp = new Response();

            List<Department> lstResp = new List<Department>();
            try
            {
                lstResp = repo.GetDepartmentListFromDB();

                if (lstResp == null || lstResp.Count == 0)
                {
                    resp.RespCode = 1;
                    resp.RespDesc = "Empty List";
                    return resp;
                }
                else
                {
                    resp.RespCode = 0;
                    resp.RespDesc = "Success";
                    resp.Json = JsonConvert.SerializeObject(lstResp);
                    return resp;
                }
            }
            catch (Exception)
            {
                resp.RespCode = 1;
                resp.RespDesc = "ERROR";
                return resp;

            }

        }
    }
}
