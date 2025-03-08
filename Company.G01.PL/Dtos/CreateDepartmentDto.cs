using Microsoft.Build.Framework;

namespace Company.G01.PL.Dtos
{
    public class CreateDepartmentDto
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime CreateAt { get; set; }
    }
}
