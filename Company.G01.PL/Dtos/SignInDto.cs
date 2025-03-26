using System.ComponentModel.DataAnnotations;

namespace Company.G01.PL.Dtos
{
    public class SignInDto
    {
        [EmailAddress]
        [Required(ErrorMessage="Email Is Requerid")]

        public string Email { get; set; }


         [Required(ErrorMessage = "Password Is Requerid")]
        [DataType(DataType.Password)]   //*******
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
