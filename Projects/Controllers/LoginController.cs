using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Projects.Models;

namespace Projects.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> signInManager;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Default");
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterViewModel p)
        {
            AppUser appuser = new AppUser()
            {
                Name = p.Name,
                Surname = p.Surname,
                Email = p.Mail,
                UserName = p.Username,

            };
            if (p.Password == p.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(appuser, p.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(p);
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(LoginModel lmodel)
        {
            // Find user by username
            var user = await _userManager.FindByNameAsync(lmodel.UserName);
            if (user == null)
            {
                // User not found, add error to model state
                ModelState.AddModelError(string.Empty, "Kullanıcı bulunamadı.");
                return View(lmodel);
            }

            // Sign in user
            var result = await signInManager.PasswordSignInAsync(
                lmodel.UserName, lmodel.Password, true, lockoutOnFailure: true);

            if (result.Succeeded)
            {
				var roles = await _userManager.GetRolesAsync(user);

				if (roles.Contains("Admin"))
				{
					return RedirectToAction("Index", "Home", new { area = "Admin" });
				}
				
				else
				{
					return RedirectToAction("Index", "Default"); // Varsayılan yönlendirme
				}
			}
            else if (result.IsLockedOut)
            {
                // User is locked out
                ModelState.AddModelError(string.Empty, "Hesap kilitlenmiş. Lütfen daha sonra tekrar deneyin.");
                return View(lmodel);
            }
            else if (result.IsNotAllowed)
            {
                // User is not allowed to sign in
                ModelState.AddModelError(string.Empty, "Giriş izni yok.");
                return View(lmodel);
            }
            else
            {
                // Password is incorrect
                ModelState.AddModelError(string.Empty, "Geçersiz şifre.");
                return View(lmodel);
            }
        }

    }
}
