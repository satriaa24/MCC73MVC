using MCC73MVC.Repositories.Data;
using Microsoft.AspNetCore.Mvc;

namespace MCC73MVC.Controllers
{
    public class AccountRoleController : Controller
    {
        private EmployeeRepositories _repo;
        private DepartmentRepositories _department;

        public IActionResult Index()
        {
            return View();
        }
    }
}
