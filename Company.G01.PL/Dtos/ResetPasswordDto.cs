using System.ComponentModel.DataAnnotations;

namespace Company.G01.PL.Dtos
{
    public class ResetPasswordDto
    {
        [Required(ErrorMessage = "Password Is Requerid")]
        [DataType(DataType.Password)]   //*******
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "ConfirmPassword Is Requerid")]
        [DataType(DataType.Password)]   //*******
        
        [Compare(nameof(NewPassword), ErrorMessage = "Confirm Password does not Match The Password !!")]
        public string ConfirmPassword { get; set; }
    }
}
