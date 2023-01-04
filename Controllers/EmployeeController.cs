using MCC73MVC.Models;
using MCC73MVC.Repositories.Data;
using Microsoft.AspNetCore.Mvc;

namespace MCC73MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeRepositories _repo;
        private DepartmentRepositories _department;

        public EmployeeController(EmployeeRepositories repo, DepartmentRepositories department)
        {
            _repo = repo;
            _department = department;
        }
        public IActionResult Index()
        {
            var result = _repo.Get();
            var dep = _department.Get();
            ViewBag.Department = dep;
            return View(result);
        }
        // GET - CREATE
        public IActionResult Create()
        {
            var result = _department.Get();
            ViewBag.Department = result;
            return View();
        }

        // POST - CREATE
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            var result = _repo.Insert(employee);
            if (result > 0)
            {
                return RedirectToAction("Index", "Employee");
            }
            return View();
        }
        // GET BY ID (Method GET - DETAILS)
        public IActionResult Details(string id)
        {
            var result = _repo.Get(id);
            var div = _department.Get(int.Parse(id));

            return View(result);
        }

        //GET Edit
        public IActionResult Edit(string id)
        {
            var result = _repo.Get(id);
            var div = _department.Get();

            ViewBag.Department = div;
            return View(result);
        }

        //POST Edit
        [HttpPost]
        public IActionResult Update(Employee employee)
        {
            var result = _repo.Update(employee);
            if (result == 0)
            {
                return View();
            }
            return RedirectToAction("Index", "Employee");

        }
        //GET - Delete
        public IActionResult Delete(string NIK)
        {
            var result = _repo.Get(NIK);
            var div = _department.Get(int.Parse(NIK));
            ViewBag.Division = div;

            return View(result);
        }

        // POST - Delete
        [HttpPost]
        public IActionResult Hapus(string id)
        {
            var result = _repo.Delete(id);
            if (result == 0)
            {
                return View();
            }
            return RedirectToAction("Index", "Employee");
        }

    }
}
