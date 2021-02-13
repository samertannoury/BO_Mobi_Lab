using HRManagmentBO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRManagmentBO.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        DataContext db = new DataContext();
        Functions function = new Functions();
        public ActionResult Employee()
        {

            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                BOUsers user = (BOUsers)Session["User"];

                if (!function.HasPermission(6, user) && !function.HasPermission(7, user) && !function.HasPermission(8, user) && !function.HasPermission(9, user))
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            return View();
        }




        public JsonResult GetEmployee(List<string> Statuslst)
        {
            Functions function = new Functions();
            BOUsers user = new BOUsers();
            Boolean EditPermission = false;
            Boolean AddPermission = false;
            Boolean DeletePermission = false;
            List<Employee> Employeelst = new List<Employee>();
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

                if (Statuslst == null || Statuslst.Count() == 0)
                {
                    Statuslst.Add("Active");
                }




                Employeelst = db.MEmployee.Where(o => Statuslst.Contains(o.Status)).ToList();
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
           
                List<EmployeePosition> EmployeePositionlst = function.getEmployeePosition();

                List<Department> Departmentlst = function.getDepartments();
            

                return Json(new { flag = "1", Employeelst = Employeelst, AddPermission = AddPermission, EditPermission = EditPermission, DeletePermission = DeletePermission, EmployeePositionlst= EmployeePositionlst, Departmentlst= Departmentlst });

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
                CurrentDepartment.DateModified = DateTime.Now;
                db.SaveChanges();

                return Json(new { flag = "1", text = "Department successfuly updated" });

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

                Department CurrentDepartment = db.MDepartment.Where(o => o.Name.ToUpper() == doDepartment.Name.ToUpper()).FirstOrDefault();
                if (CurrentDepartment != null)
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
                newDepartment.Status = "Active";
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