using System.ComponentModel.DataAnnotations;

namespace UmbracoEC.ViewModels
{
    public class QuestionFormViewModel
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is requierd")]
        public string Name { get; set; } = null!;

        [Display(Name = "E-mail address")]
        [Required(ErrorMessage = "Email is requierd")]
        [RegularExpression(@"^(([^<>()[\]\\.,;:\s@\""]+(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$", ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = null!;

        [Display(Name = "Question")]
        [Required(ErrorMessage = "Question is requierd")]
        public string Question { get; set; } = null!;
    }
}
