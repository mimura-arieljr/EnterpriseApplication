using System;
using System.ComponentModel.DataAnnotations;

namespace EnterpriseSolution.Models
{
	public class EmployeeCreateViewModel
	{
        public int Id { get; set; }

        [Required(ErrorMessage = "Employee number is required."),RegularExpression(@"^[A-Z]{3,3}[0-9]{3}$")]
        public string EmployeeNo { get; set; }

        [Required(ErrorMessage = "First name is required."),RegularExpression(@"^[A-Z][a-zA-Z""/s-]*$"), StringLength(50)]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        public string FullName { get; set; }

        public string Gender { get; set; }

        public string ImageURL { get; set; }

        public DateTime DOB { get; set; }

        public DateTime DateJoined { get; set; }

        public string Designation { get; set; }

        [Required, MaxLength(50)]
        public string SSSNo { get; set; }

        [Required, MaxLength(150)]
        public string Address { get; set; }

        [Required, MaxLength(50)]
        public string City { get; set; }

        [Required, MaxLength(50)]
        public string PostalCode { get; set; }
    }
}

