using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Projects.ViewComponents.Default
{
    public class _CardProjects : ViewComponent
    {
        ProjectManager projectManager = new projectManager(new EfProjectDal());

        public IViewComponentResult Invoke()
        {
            var values = projectManager.TGetList();
            return View(values);
        }
    }
}
