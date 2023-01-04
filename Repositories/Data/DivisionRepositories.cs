using MCC73MVC.Context;
using MCC73MVC.Models;

namespace MCC73MVC.Repositories.Data
{
    public class DivisionRepositories : GeneralRepository<Division, int>
    {
        public DivisionRepositories(MyContext context) : base(context)
        {
        }
    }
}
