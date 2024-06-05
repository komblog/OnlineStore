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

		[HttpPost]
		public IActionResult Create(Category obj)
		{
			if (ModelState.IsValid)
			{
				_db.Category.Add(obj);
				_db.SaveChanges();
				TempData["success"] = "Category created successfully";
				return RedirectToAction("Index");
			}
			return View();
		}

		public IActionResult Edit(int? CategoryId)
		{
			if (CategoryId == null || CategoryId == 0)
			{
				return NotFound();
			}

			Category? category = _db.Category.FirstOrDefault(x => x.CategoryId == CategoryId);
			if (category == null)
			{
				return NotFound();
			}

			return View(category);
		}

		[HttpPost]
		public IActionResult Edit(Category category)
		{
			if (ModelState.IsValid)
			{
				_db.Category.Update(category);
				_db.SaveChanges();
				TempData["success"] = "Category updated successfully";
				return RedirectToAction("Index");
			}
			return View();
		}

		public IActionResult Delete(int? CategoryId)
		{
			if (CategoryId == null || CategoryId == 0)
			{
				return NotFound();
			}

			Category? category = _db.Category.Where(x => x.CategoryId == CategoryId).FirstOrDefault();
			if (category == null)
			{
				return NotFound();
			}
			return View(category);
		}

		[HttpPost]
		public IActionResult Delete(Category category)
		{
			Category? categoryToDelete = _db.Category.FirstOrDefault(x=> x.CategoryId ==category.CategoryId);
			if (categoryToDelete == null)
			{
				return NotFound();
			}
			_db.Category.Remove(categoryToDelete);
			_db.SaveChanges();
			TempData["success"] = "Category deleted successfully";
			return RedirectToAction("Index");
		}
	}
}