using System.ComponentModel.DataAnnotations;

namespace UmbracoEC.ViewModels
{
    public class SupportFormViewModel
    {
        [Display(Name = "E-mail address")]
        [Required(ErrorMessage = "Email is requierd")]
        [RegularExpression(@"^(([^<>()[\]\\.,;:\s@\""]+(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$", ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = null!;
    }
}
