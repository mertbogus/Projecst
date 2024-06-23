using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Concrete
{
    public class Context: IdentityDbContext<AppUser, IdentityRole<int>, int>
	{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-FUO4J03; database=ProjectsDB; integrated security=true; TrustServerCertificate=true");
        }

        public DbSet<Category> Categorys { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<SubCategory> SubCategorys { get; set; }
        public DbSet<ProjectNew> ProjectNew { get; set; }
        public DbSet<Section> Section { get; set; }
        public DbSet<SectionDetail> SectionDetail { get; set; }
    }
}
