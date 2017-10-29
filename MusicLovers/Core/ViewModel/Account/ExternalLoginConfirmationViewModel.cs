using System.ComponentModel.DataAnnotations;

namespace MusicLovers.Core.ViewModel.Account
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}