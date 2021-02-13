using HRManagmentBO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRManagmentBO.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        DataContext db = new DataContext();
        Functions function = new Functions();
        string WebAPIURL= System.Configuration.ConfigurationManager.AppSettings["WebAPIURL"];
        public ActionResult Department()
        {

            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                BOUsers user = (BOUsers)Session["User"];

                if (!function.HasPermission(2, user) && !function.HasPermission(3, user) && !function.HasPermission(4, user) && !function.HasPermission(5, user))
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            return View();
        }




        public JsonResult GetDepartments(List<string> Statuslst)
        {
            Functions function = new Functions();
            BOUsers user = new BOUsers();
            Boolean EditPermission = false;
            Boolean AddPermission = false;
            Boolean DeletePermission = false;
            List<Department> Departmentlst = new List<Department>();
            try
            {

                if (Session["User"] == null)
                {
                    return Json(new { flag = "-3", text = "Session Timed Out", URL = Url.Action("Login", "Account") });
                }
                else
                {
                    user = (BOUsers)Session["User"];
                    Session["User"] = user;
                }

                string status = "";
                if (Statuslst == null || Statuslst.Count() == 0)
                {
                    Statuslst.Add("Active");
                }
               
                RestAPIRequest API = new RestAPIRequest();
                API.requireAuthorization = true;
                API.URL = String.Concat(WebAPIURL, "GetDepartmentList");
                API.body = "";
                API.methodType = "POST";
                API.contentType = "application/x-www-form-urlencoded";
                function.callWebServices(ref API);

                APIResponse res = function.deserializeJSON< APIResponse > (API.response);

                Departmentlst = function.deserializeJSON <List<Department>>(res.Json);


                Departmentlst = Departmentlst.Where(o => Statuslst.Contains(o.Status)).ToList();
                if (function.HasPermission(3, user))
                {
                AddPermission = true;
                }
                if (function.HasPermission(4, user))
                {
                EditPermission = true;
                }
                if (function.HasPermission(5, user))
                {
                   DeletePermission = true;
                }
                return Json(new { flag = "1", Departmentlst = Departmentlst, AddPermission= AddPermission,EditPermission = EditPermission, DeletePermission = DeletePermission });
                
            }
            catch (Exception ex)
            {
              
                return Json(new { flag = "-1", text = "An error has occurred!" });
            }
        }





        public JsonResult UpdateDepartment(Department doDepartment)
        {
            Functions function = new Functions();
            DataContext db = new DataContext();
            BOUsers user = new BOUsers();
            try
            {
                if (Session["User"] == null)
                {
                    return Json(new { flag = "-3", text = "Session Timed Out", URL = Url.Action("Login", "Account") });
                }
                else
                {
                    user = (BOUsers)Session["User"];
                    Session["User"] = user;
                }
                if (!function.HasPermission(4, user))
                {
                    return Json(new
                    {
                        flag = "-4",
                        text = "You do not have permission to add"
                    });
                }

                Department CurrentDepartment = db.MDepartment.Where(o => o.Id == doDepartment.Id).FirstOrDefault();
                CurrentDepartment.Name = doDepartment.Name;
                CurrentDepartment.Description = doDepartment.Description;
                CurrentDepartment.Status = doDepartment.Status;
                CurrentDepartment.DateModified= DateTime.Now;
                db.SaveChanges();

                return Json(new { flag = "1", text ="Department successfuly updated"});

            }
            catch (Exception ex)
            {
       
                return Json(new { flag = "-1", text = "An error has occurred" });
            }

        }



        public JsonResult AddDepartment(Department doDepartment)
        {
            Functions function = new Functions();
            DataContext db = new DataContext();
            BOUsers user = new BOUsers();
            try
            {
                if (Session["User"] == null)
                {
                    return Json(new { flag = "-3", text = "Session Timed Out", URL = Url.Action("Login", "Account") });
                }
                else
                {
                    user = (BOUsers)Session["User"];
                    Session["User"] = user;
                }
                if (!function.HasPermission(3, user))
                {
                    return Json(new
                    {
                        flag = "-4",
                        text = "You do not have permission to add"
                    });
                }

                Department CurrentDepartment = db.MDepartment.Where(o => o.Name.ToUpper() == doDepartment.Name.ToUpper() ).FirstOrDefault();
                if (CurrentDepartment!=null)
                {
                    return Json(new
                    {
                        flag = "-4",
                        text = "Name already used"
                    });
                }
    
                Department newDepartment = new Department();
                newDepartment.Name = doDepartment.Name;
                newDepartment.Description = doDepartment.Description;
                newDepartment.Status ="Active";
                newDepartment.DateCreated = DateTime.Now;
                db.MDepartment.Add(newDepartment);

                return Json(new { flag = "1", text = "Department successfuly added" });

            }
            catch (Exception ex)
            {

                return Json(new { flag = "-1", text = "An error has occurred" });
            }

        }


        public JsonResult DeleteDepartment(int Id)
        {
            Functions function = new Functions();
            DataContext db = new DataContext();
            BOUsers user = new BOUsers();
            try
            {
                if (Session["User"] == null)
                {
                    return Json(new { flag = "-3", text = "Session Timed Out", URL = Url.Action("Login", "Account") });
                }
                else
                {
                    user = (BOUsers)Session["User"];
                    Session["User"] = user;
                }
                if (!function.HasPermission(5, user))
                {
                    return Json(new
                    {
                        flag = "-4",
                        text = "You do not have permission to add"
                    });
                }

                Department CurrentDepartment = db.MDepartment.Where(o => o.Id == Id).FirstOrDefault();
                CurrentDepartment.Status = "Inactive";
                CurrentDepartment.DateModified = DateTime.Now;
                db.SaveChanges();

                return Json(new { flag = "1", text = "Department successfuly deleted" });

            }
            catch (Exception ex)
            {

                return Json(new { flag = "-1", text = "An error has occurred" });
            }

        }

    }
}