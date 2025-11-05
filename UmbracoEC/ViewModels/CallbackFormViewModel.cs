using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace UmbracoEC.ViewModels
{
    public class CallbackFormViewModel
    {
        [Required(ErrorMessage = "Name is requierd")]
        [Display(Name = "Name")]
        public string Name { get; set; } = null!;

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email is requierd")]
        [RegularExpression(@"^(([^<>()[\]\\.,;:\s@\""]+(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$", ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = null!;

        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Phone is requierd")]
        public string Phone { get; set; } = null!;

        [Required(ErrorMessage = "Please select an option")]
        public string SelectedOption { get; set; } = null!;

        [BindNever]
        public IEnumerable<string> Options { get; set; } = [];

    }
}
