using System.ComponentModel.DataAnnotations;
using Microsoft.Build.Framework;

namespace Company.G01.PL.Dtos
{
    public class SignUpDto
    {
       // [Required(ErrorMessage="UserName Is Requerid")]
        public string UserName { get; set; }
        //[Required(ErrorMessage="FirstName Is Requerid")]
        public string FirstName { get; set; }
        //[Required(ErrorMessage="LastName Is Requerid")]
        public string LastName { get; set; }
        [EmailAddress]
        //[Required(ErrorMessage="Email Is Requerid")]

        public string Email { get; set; }
       // [Required(ErrorMessage = "Password Is Requerid")]
        [DataType(DataType.Password)]   //*******
        public string Password { get; set; }
        [DataType(DataType.Password)]   //*******
      //  [Required(ErrorMessage="ConfirmPassword Is Requerid")]
        [Compare(nameof(Password),ErrorMessage ="Confirm Password does not Match The Password !!")]
        public string ConfirmPassword { get; set; }
        public bool IsAgree { get; set; }   

    }
}
