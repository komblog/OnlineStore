using Microsoft.AspNetCore.Mvc;
using OnlineStore.Data;
using OnlineStore.Models;

namespace OnlineStore.Controllers
{
	public class CategoryController : Controller
	{
		private ApplicationDbContext _db;
		public CategoryController(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			List<Category> categories = _db.Category.ToList();
			return View(categories);
		}

		public IActionResult Create()
		{
			return View();
		}
	}
}
