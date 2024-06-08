using BookStore.Data;
using BookStore.Models;
using BookStore.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class CategoriesController : Controller
    {

        private readonly ApplicationDbContext context;

        public CategoriesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var categories = context.categories.ToList();
            return View("Index", categories);
        }

        [HttpGet]
        public IActionResult Create() {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(CategoryVM categoryvm)
        {
            if (!ModelState.IsValid)
            {
                return View("Create");
            }
            var category = new Category
            {
                Name = categoryvm.Name
            };
            context.categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Edit(CategoryVM categoryvm)
        {
            var category = context.categories.Find(categoryvm.Id);
            if(category is  null)
            {
                return Content("Error");
            }

            category.Name = categoryvm.Name;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
