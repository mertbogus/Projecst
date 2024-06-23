using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Projects.Models;
using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;

namespace Projects.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminAuthorize]
    public class CategoriesController : Controller
    {
        private readonly CategoryManager categoryManager;
        private readonly IMapper mapper;

        public CategoriesController(IMapper mapper)
        {
            categoryManager = new CategoryManager(new EfCategoryDal());
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var categories = categoryManager.TGetList();
            var categoryVms = mapper.Map<IEnumerable<CategoryVm>>(categories);
            return View(categoryVms);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CategoryVm categoryVm)
        {
            if (ModelState.IsValid)
            {
                var category = mapper.Map<Category>(categoryVm);
                categoryManager.TAdd(category);
                return RedirectToAction("Index");
            }
            return View(categoryVm);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = categoryManager.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            var categoryVm = mapper.Map<CategoryVm>(category);
            return View(categoryVm);
        }

        [HttpPost]
        public IActionResult Edit(CategoryVm categoryVm)
        {
            if (ModelState.IsValid)
            {
                var category = mapper.Map<Category>(categoryVm);
                categoryManager.Update(category);
                return RedirectToAction("Index");
            }
            return View(categoryVm);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = categoryManager.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            var categoryVm = mapper.Map<CategoryVm>(category);
            return View(categoryVm);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            var category = categoryManager.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            categoryManager.TDelete(category);
            return RedirectToAction("Index");
        }
    }
}
