using System.Data.Entity;
using System.Data.Entity.SqlServer;


namespace HRManagmentBO
{
    public class MyDbConfiguration : DbConfiguration
    {
        public MyDbConfiguration()
        {
            this.SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
        }



    }
}