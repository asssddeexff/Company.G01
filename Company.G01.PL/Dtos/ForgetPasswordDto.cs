using System.ComponentModel.DataAnnotations;

namespace Company.G01.PL.Dtos
{
    public class ForgetPasswordDto
    {
        [EmailAddress]
        [Required(ErrorMessage="Email Is Requerid")]

        public string Email { get; set; }
    }
}
