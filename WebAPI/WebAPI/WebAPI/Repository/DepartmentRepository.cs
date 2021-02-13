using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public class DepartmentRepository
    {
        private string Connstr = string.Empty;

        public DepartmentRepository()
        {
            Connstr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        }

        //Get all Department in a list
        public List<Department> GetDepartmentListFromDB()
        {
            List<Department> list = new List<Department>();
            SqlConnection cnn = new SqlConnection(Connstr);
            SqlCommand cmd = new SqlCommand();

            try
            {
                if ((cnn.State == ConnectionState.Open))
                {
                    cnn.Close();
                }
                cnn.Open();
                if (cnn.State == ConnectionState.Open)
                {
                    cmd.CommandText = "select ID,Name,Description,Status from Department order by Name asc";
                    cmd.Connection = cnn;

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.HasRows && dr.Read())
                    {
                        Department merchantList = new Department();
                        merchantList.Id = Convert.ToInt32(dr["Id"]);
                        merchantList.Name = dr["Name"].ToString();
                        merchantList.Description = dr["Description"].ToString();
                        merchantList.Status = dr["Status"].ToString();
                        
                        list.Add(merchantList);
                    }
                }
                cnn.Close();
                return list;
            }
            catch (Exception)
            {
                cnn.Close();
                return list;
            }
        }

    }
}