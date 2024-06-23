using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Projects.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-posta")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Ad")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Soyad")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public IEnumerable<AppUser> Users { get; set; } // Kullanıcı listesini ekledik

    }
    public class UserRolesViewModel
    {
        public int UserId { get; set; }
        public List<IdentityRole<int>> Roles { get; set; }
        public IList<string> UserRoles { get; set; }
    }
}
