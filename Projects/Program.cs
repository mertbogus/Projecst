using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;

internal class Program
{
	private static void Main(string[] args)
	{
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
        builder.Services.AddControllersWithViews().AddControllersAsServices();
        builder.Services.AddDbContext<Context>();
        builder.Services.AddIdentity<AppUser, IdentityRole<int>>().AddEntityFrameworkStores<Context>();
        builder.Services.AddControllersWithViews();
        builder.Services.AddAutoMapper(typeof(Program)); // Program sýnýfý yerine Profil sýnýfýnýzý ekleyin
        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
        });
        builder.Services.ConfigureApplicationCookie(options =>
        {
            options.AccessDeniedPath = "/Account/AccessDenied";
        });
        

        var app = builder.Build();
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseAuthentication();
        app.UseRouting();

        app.UseAuthorization();
        app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Default}/{action=Index}/{id?}");

        app.Run();


    }

}