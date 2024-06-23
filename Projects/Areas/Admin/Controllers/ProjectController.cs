using AutoMapper;
using BusinessLayer.Concrete;
using DataAccesLayer.Abstract;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projects.Models;

namespace Projects.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminAuthorize] // Burada kullanılırsa tüm metotlara uygulanır.

    public class ProjectController : Controller
    {
        ProjectNewManager projectManager = new ProjectNewManager(new EfProjectNewDal());
        SectionManager sectionManager = new SectionManager(new EfSectionDal());
        SectionDetailManager sectionDetailManager = new SectionDetailManager(new EfSectionDetailDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;

        public ProjectController(IMapper mapper, UserManager<AppUser> userManager)
        {
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var projects = projectManager.TGetList().ToList();
            var userDto = mapper.Map<List<ProjectNewListModel>>(projects);
            return View(userDto);
        }

        public IActionResult Create()
        {
            ProjectNewListModel vm = new ProjectNewListModel();
            var categories = categoryManager.TGetList();
            ViewBag.Categories = categories.Select(c => new SelectListItem
            {
                Value = c.CategoryID.ToString(),
                Text = c.CategoryName
            }).ToList();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjectNewListModel project)
        {
            var categories = categoryManager.TGetList();
            ViewBag.Categories = categories.Select(c => new SelectListItem
            {
                Value = c.CategoryID.ToString(),
                Text = c.CategoryName
            }).ToList();
            var userId = userManager.GetUserId(User);
            var pr = mapper.Map<ProjectNew>(project);
            try
            {
                projectManager.TAdd(pr);
                return RedirectToAction(nameof(Index));

            }
            catch (Exception)
            {

                return View(project);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var categories = categoryManager.TGetList();

            ViewBag.Categories = categories.Select(c => new SelectListItem
            {
                Value = c.CategoryID.ToString(),
                Text = c.CategoryName
            }).ToList();
            var sections = sectionManager.GetByProjectId(id);
            var sectionDetails = sectionDetailManager.TGetList().ToList();
            ViewBag.Sections = mapper.Map<List<SectionModel>>(sections);
            ViewBag.SectionDetails = mapper.Map<List<SectionDetailModel>>(sectionDetails);
            var project = projectManager.GetById(id);

            var userDto = mapper.Map<ProjectNewListModel>(project);
            ProjectNewListModel vm = userDto;
            if (project == null)
            {
                return NotFound();
            }
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProjectNewListModel vm)
        {
            var categories = categoryManager.TGetList();

            ViewBag.Categories = categories.Select(c => new SelectListItem
            {
                Value = c.CategoryID.ToString(),
                Text = c.CategoryName
            }).ToList();
            projectManager.Update(mapper.Map<ProjectNew>(vm));
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var project = projectManager.GetById(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var delete = projectManager.GetById(id);
            projectManager.TDelete(delete);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> SectionDelete(int id)
        {
            var asd = sectionManager.GetById(id);
            sectionManager.TDelete(asd);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> deletesectiondetail(int id)
        {
            try
            {
                var asd = sectionDetailManager.GetById(id);
                sectionDetailManager.TDelete(asd);
                return Json(new { success = true });
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSection([FromForm] Section section)
        {
            try
            {
                sectionManager.TAdd(section);
                return Json(new { success = true });
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSectionDetail([FromForm] SectionDetail section)
        {
            try
            {
                sectionDetailManager.TAdd(section);
                return Json(new { success = true });
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }

        }
        [HttpPost]
       
        public async Task<IActionResult> UpdateSection([FromForm] Section section)
        {
            try
            {
                sectionManager.Update(section);
                return Json(new { success = true });
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }

        }
        [HttpPost]

        public async Task<IActionResult> UpdateSectionDetail([FromForm] SectionDetail section)
        {
            try
            {
                sectionDetailManager.Update(section);
                return Json(new { success = true });
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }

        }
        [HttpGet]
        public async Task<IActionResult> GetSection(int id)
        {
            var section = sectionManager.GetById(id);
            if (section == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                id = section.Id,
                name = section.Name,
                desc = section.Desc,
                projectNewId = section.ProjectNewId,
                orderNumber = section.OrderNumber
            });
        }
        [HttpGet]

        public async Task<IActionResult> GetDetailSection(int id)
        {
            var section = sectionDetailManager.GetById(id);
            if (section == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                id = section.Id,
                name = section.Name,
                desc = section.Desc,
                sectionId = section.SectionId,
                orderNumber = section.OrderNumber
            });
        }
        private async Task<bool> IsUserAdmin()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await userManager.GetUserAsync(User);
                var roles = await userManager.GetRolesAsync(user);

                // Kullanıcı "Admin" rolüne sahipse true döner
                return roles.Contains("Admin");
            }
            else
            {
                // Kullanıcı giriş yapmamışsa false döner
                return false;
            }
        }
    }
}
