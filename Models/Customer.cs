using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DelsProject.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Use letters only")]
        public string Name { get; set; }
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required]
        
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Enter a Valid Age")]
        [Range(1, 100, ErrorMessage = "Invalid age")]
        public int Age { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Enter a Valid Number")]
        [StringLength(maximumLength: 10, MinimumLength= 10, ErrorMessage = "Phone number should consists 10 digits only")]
        [Display(Name = "Mobile Number")]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        public bool IsVerified { get; set; }
    }
}
