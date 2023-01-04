using MCC73MVC.Context;
using MCC73MVC.Models;

namespace MCC73MVC.Repositories.Data
{
    public class EmployeeRepositories : GeneralRepository<Employee, string>
    {
        public EmployeeRepositories(MyContext context) : base(context)
        {
        }
    }
}
