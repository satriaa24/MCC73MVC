using MCC73MVC.Context;
using MCC73MVC.Models;

namespace MCC73MVC.Repositories.Data
{
    public class RoleRepositories : GeneralRepository<Role, int>
    {
        public RoleRepositories(MyContext context) : base(context)
        {
        }
    }
}
