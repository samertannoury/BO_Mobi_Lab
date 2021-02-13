using HRManagmentBO.Models;
using System.Data.Entity;

namespace HRManagmentBO
{
    [DbConfigurationType(typeof(MyDbConfiguration))]

    public class DataContext : DbContext
    {


        //public DbSet<Transactions> MTransactions { get; set; }
        public DbSet<BOProfiles> MBOProfiles { get; set; }
        public DbSet<BOUserProfiles> MBOUserProfiles { get; set; }
        public DbSet<BOProfileFunctions> MBOProfileFunctions { get; set; }

        public DbSet<BOUsers> MBOUsers { get; set; }

        public DbSet<Department> MDepartment { get; set; }


        public DbSet<EmployeePosition> MEmployeePosition { get; set; }
    public DbSet<Employee> MEmployee { get; set; }

            

    }
}