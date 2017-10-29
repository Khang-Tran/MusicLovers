using System.ComponentModel.DataAnnotations;

namespace MusicLovers.Core.ViewModel.Account
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}