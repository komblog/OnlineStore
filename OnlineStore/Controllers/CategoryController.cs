using Microsoft.AspNetCore.Mvc;
using Models;
using DataAccess.Repository.Interface;

namespace OnlineStore.Controllers
{
	public class CategoryController : Controller
	{
		private ICategoryRepository _categoryRepository;
		public CategoryController(ICategoryRepository db)
		{
            _categoryRepository = db;
		}
		public IActionResult Index()
		{
			List<Category> categories = _categoryRepository.GetAll().ToList();
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
				_categoryRepository.Add(obj);
				_categoryRepository.Save();
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

			Category? category = _categoryRepository.Get(x => x.CategoryId == CategoryId);
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
				_categoryRepository.Update(category);
				_categoryRepository.Save();
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

			Category? category = _categoryRepository.Get(x => x.CategoryId == CategoryId);
			if (category == null)
			{
				return NotFound();
			}
			return View(category);
		}

		[HttpPost]
		public IActionResult Delete(Category category)
		{
			Category? categoryToDelete = _categoryRepository.Get(x=> x.CategoryId ==category.CategoryId);
			if (categoryToDelete == null)
			{
				return NotFound();
			}
			_categoryRepository.Delete(categoryToDelete);
			_categoryRepository.Save();
			TempData["success"] = "Category deleted successfully";
			return RedirectToAction("Index");
		}
	}
}