using MCC73MVC.Models;
using MCC73MVC.Repositories.Data;
using Microsoft.AspNetCore.Mvc;

namespace MCC73MVC.Controllers
{
	public class DivisionController : Controller
	{
		private DivisionRepositories _repo;

		public DivisionController(DivisionRepositories repo)
		{
			_repo = repo;
		}

		//menarik data division dari db
		public IActionResult Index()
		{
			var result = _repo.Get();

			return View(result);
		}

		// GET - CREATE
		public IActionResult Create()
		{
			return View();
		}

		// POST - CREATE
		[HttpPost]
		public IActionResult Create(Division division)
		{
			var result = _repo.Insert(division);
			if (result > 0)
			{
				return RedirectToAction("Index", "Division");
			}
			return View();
		}
        // GET BY ID (Method GET - DETAILS)
		public IActionResult Details (int Id)
		{
			var result = _repo.Get(Id);
			

			return View(result);
		}

		//GET Edit
		public IActionResult Edit(int id)
		{
			var result = _repo.Get(id);
			return View(result);
		}

		//POST Edit
		[HttpPost]
		public IActionResult Edit(Division division)
		{
			var result = _repo.Update(division);
			if (result == 0)
			{
                return View();
            }
            return RedirectToAction("Index", "Division");
        }

		//GET - Delete
		public IActionResult Delete(int id)
		{
			var result = _repo.Get(id);
			return View(result);
		}

		// POST - Delete
		[HttpPost]
		public IActionResult Hapus(int DivisionId)
		{
			var result = _repo.Delete(DivisionId);
            if (result == 0)
            {
                return View();
            }
            return RedirectToAction("Index", "Division");
        }
    }
}
