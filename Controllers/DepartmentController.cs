using MCC73MVC.Models;
using MCC73MVC.Repositories.Data;
using Microsoft.AspNetCore.Mvc;

namespace MCC73MVC.Controllers
{
    public class DepartmentController : Controller
    {
        private DepartmentRepositories _repo;
        private DivisionRepositories _division;

        public DepartmentController(DepartmentRepositories repo, DivisionRepositories division)
        {
            _repo = repo;
            _division = division;   
        }

        //menarik data department dari db
        public IActionResult Index()
        {
            var result = _repo.Get();
            var div = _division.Get();

            return View(result);
        }

        // GET - CREATE
        public IActionResult Create()
        {
            var result = _division.Get();
            ViewBag.Division = result;
            return View();
        }

        // POST - CREATE
        [HttpPost]
        public IActionResult Create(Department department)
        {
            var result = _repo.Insert(department);
            if (result > 0)
            {
                return RedirectToAction("Index", "Department");
            }
            return View();
        }

        // GET BY ID (Method GET - DETAILS)
        public IActionResult Details(int Id)
        {
            var result = _repo.Get(Id);
            var div = _division.Get(Id);

            return View(result);
        }

        //GET Edit
        public IActionResult Edit(int id)
        {
            var result = _repo.Get(id);
            var div = _division.Get();

            ViewBag.Division = div;
            return View(result);
        }

        //POST Edit
        [HttpPost]
        public IActionResult Update(Department department)
        {
            var result = _repo.Update(department);
            if (result == 0)
            {
                return View();
            }
            return RedirectToAction("Index", "Department");

        }
        //GET - Delete
		public IActionResult Delete(int id)
		{
            var result = _repo.Get(id);
            var div = _division.Get(id);
            ViewBag.Division = div;

            return View(result);
        }

		// POST - Delete
		[HttpPost]
		public IActionResult Hapus(int DepartmentId)
		{
			var result = _repo.Delete(DepartmentId);
            if (result == 0)
            {
                return View();
            }
            return RedirectToAction("Index", "Department");
        }

    }
}