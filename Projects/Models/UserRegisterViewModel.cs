using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Globalization;


namespace Projects.Models
{
	public class UserRegisterViewModel


	{
		[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen Adınızı Giriniz")]
		public string Name { get; set; }

		[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen Soyadınızı Giriniz")]
		public string Surname { get; set; }

		[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen Kullanıcı Adınızı Giriniz")]
		public string Username { get; set; }

		[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen Mail Giriniz")]
		public string Mail { get; set; }

		[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen Şifrenizi Giriniz")]
		public string Password { get; set; }

		[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen Şifrenizi Tekrar Giriniz")]
		[Compare("Password", ErrorMessage="Şifreler Aynı Değil")]
		public string ConfirmPassword { get; set; }
	}
}
