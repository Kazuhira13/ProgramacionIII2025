using System.ComponentModel.DataAnnotations;

namespace Clase11.Entities
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [RegularExpression("\\d{4}-\\d{2}-\\d{4,5}")]
        public string Code { get; set; }
        [MinLength(2)]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public string CreatedBy { get; set; } = string.Empty;

    }
}
