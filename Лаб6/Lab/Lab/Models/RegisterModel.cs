using System.ComponentModel.DataAnnotations;

namespace Lab.Models
{
    public class RegisterModel
    {
        [Required]
        [Display(Name = "Email адрес")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} должно быть по крайней мере {2} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        [Compare("Password", ErrorMessage = "Пароль и подтверждение пароля не совпадают.")]
        public string ConfirmPassword { get; set; }
    }
}