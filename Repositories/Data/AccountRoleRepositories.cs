using MCC73MVC.Context;
using MCC73MVC.Models;

namespace MCC73MVC.Repositories.Data
{
    public class AccountRoleRepositories : GeneralRepository<AccountRole, int>
    {
        public AccountRoleRepositories(MyContext context) : base(context)
        {
        
        }
    }
}
