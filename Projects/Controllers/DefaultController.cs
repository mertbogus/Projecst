using AutoMapper;
using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using NuGet.Protocol;
using Projects.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Projects.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IMapper mapper;
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<DefaultController> _logger;
        ProjectNewManager projectManager = new ProjectNewManager(new EfProjectNewDal());
        SectionDetailManager sectionDetailManager = new SectionDetailManager(new EfSectionDetailDal());

        public DefaultController(IMapper mapper, IServiceProvider serviceProvider, ILogger<DefaultController> logger)
        {
            this.mapper = mapper;
            _serviceProvider = serviceProvider;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            await CreateRolesAndAdminUser();
            var projects = projectManager.TGetList().ToList();
            var userDto = mapper.Map<List<ProjectNewListModel>>(projects);
            return View(userDto);
        }
        public async Task<IActionResult> DetailProject(int id)
        {
            await CreateRolesAndAdminUser();
            var projects = projectManager.GetById(id);
            var userDto = mapper.Map<ProjectNewListModel>(projects);
            return View(userDto);
        }
        public async Task<IActionResult> Asd()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetSectionDetailById(int id)
        {
            var det = sectionDetailManager.GetById(id);
            return Json(det);
        }
        private async Task CreateRolesAndAdminUser()
        {
            var roleManager = _serviceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
            var userManager = _serviceProvider.GetRequiredService<UserManager<AppUser>>();

            string[] roleNames = { "Admin", "Default" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    _logger.LogInformation($"Creating role: {roleName}");
                    roleResult = await roleManager.CreateAsync(new IdentityRole<int>(roleName));
                    if (!roleResult.Succeeded)
                    {
                        _logger.LogError($"Failed to create role: {roleName}. Errors: {string.Join(", ", roleResult.Errors)}");
                    }
                }
            }

            // Create a super user who will maintain the web app
            var adminUser = new AppUser
            {
                UserName = "admin",
                Email = "admin@example.com",
                Name = "Admin",
                Surname = "User"
            };

            string adminPassword = "Admin@123";

            var user = await userManager.FindByEmailAsync("admin@example.com");

            if (user == null)
            {
                _logger.LogInformation("Creating admin user.");
                var createPowerUser = await userManager.CreateAsync(adminUser, adminPassword);
                if (createPowerUser.Succeeded)
                {
                    _logger.LogInformation("Assigning admin role to admin user.");
                    var result = await userManager.AddToRoleAsync(adminUser, "Admin");
                    if (!result.Succeeded)
                    {
                        _logger.LogError($"Failed to assign admin role to admin user. Errors: {string.Join(", ", result.Errors)}");
                    }
                }
                else
                {
                    _logger.LogError($"Failed to create admin user. Errors: {string.Join(", ", createPowerUser.Errors)}");
                }
            }
            else
            {
                _logger.LogInformation("Admin user already exists.");
            }
        }
    }
}
