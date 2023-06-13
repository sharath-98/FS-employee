using System.ComponentModel.DataAnnotations;

namespace FullstackAPI.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        [Required]
        public long Salary { get; set; }
        [Required]
        public string Dept { get; set; }
    }
}
