using MCC73MVC.Context;
using MCC73MVC.Models;

namespace MCC73MVC.Repositories.Data
{
    public class DepartmentRepositories : GeneralRepository<Department, int>
    {
        public DepartmentRepositories(MyContext context) : base(context)
        {
        }
    }
}
