using MCC73MVC.Models;
using MCC73MVC.Repositories.Data;
using MCC73MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.Arm;

namespace MCC73MVC.Controllers
{


    public class AccountController : Controller
    {
        private AccountRepositories _repo;
        private EmployeeRepositories _employee;

        public AccountController(AccountRepositories repo, EmployeeRepositories employee)
        {
            _repo = repo;
            _employee = employee;
        }

        public IActionResult Index()
        {
            var result = _repo.Get();
            var emp = _employee.Get();
            ViewBag.Employee = emp;
            return View(result);
        }

        // GET - CREATE
        public IActionResult Create()
        {
            var result = _employee.Get();
            ViewBag.Employee = result;
            return View();
        }

        // POST - CREATE
        [HttpPost]
        public IActionResult Create(Account account)
        {
            var result = _repo.Insert(account);
            if (result > 0)
            {
                return RedirectToAction("Index", "Account");
            }
            return View();
        }

        // GET BY ID (Method GET - DETAILS)
        public IActionResult Details(string id)
        {
            var result = _repo.Get(id);
            var div = _employee.Get(id);

            return View(result);
        }

        //GET Edit
        public IActionResult Edit(string id)
        {
            var result = _repo.Get(id);
            var div = _employee.Get();

            ViewBag.Department = div;
            return View(result);
        }

        //POST Edit
        [HttpPost]
        public IActionResult Update(Account account)
        {
            var result = _repo.Update(account);
            if (result == 0)
            {
                return View();
            }
            return RedirectToAction("Index", "Account");

        }
        //GET - Delete
        public IActionResult Delete(string NIK)
        {
            var result = _repo.Get(NIK);
            var div = _employee.Get(NIK);
            ViewBag.Employee = div;

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
            return RedirectToAction("Index", "Account");
        }

        [HttpGet("/Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("/Login")]
        public IActionResult Login(LoginVM login)
        {
            var result = _repo.Login(login);
            if (result == 2)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.error = "Login Failed";
            return View();
        }

        [HttpGet("/Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("/Register")]
        public IActionResult Register(RegisterVM register)
        {
            var result = _repo.Register(register);
            if (result > 0)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
    }
}
