using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HRManagmentBO.Models
{

    [Table("Employee")]
    public class Employee
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Id { get; set; }
        public String FName { get; set; }
        public String MName { get; set; }
        public String LName { get; set; }
        public DateTime DOB { get; set; }
        public String MobileNo { get; set; }
        public Decimal Salary { get; set; }
        public Decimal PositionID { get; set; }
        public Decimal DepartmentID { get; set; }

        public String Status { get; set; }
    }

    [Table("EmployeePosition")]
    public class EmployeePosition
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Id { get; set; }
        public String Description { get; set; }
    }
}