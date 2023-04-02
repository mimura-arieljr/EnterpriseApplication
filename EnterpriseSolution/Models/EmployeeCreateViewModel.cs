using System;
using System.ComponentModel.DataAnnotations;
using Enterprise.Entity;

namespace EnterpriseSolution.Models
{
	public class EmployeeCreateViewModel
	{
        public int Id { get; set; }

        [Required(ErrorMessage = "Employee number is required."),RegularExpression(@"^[A-Z]{3,3}[0-9]{3}$",ErrorMessage ="Pattern must be like the placeholder."), Display(Name ="Employee Number")]
        public string EmployeeNo { get; set; }

        [Required(ErrorMessage = "First name is required."),RegularExpression(@"^[A-Z][a-zA-Z""\s-.]*$", ErrorMessage ="Invalid input. Avoid special characters."), StringLength(50), Display(Name ="First Name")]
        public string FirstName { get; set; }

        [StringLength(50), Display(Name ="Middle Name"), RegularExpression(@"^[A-Z][a-zA-Z""\s-.]*$", ErrorMessage = "Invalid input. Avoid special characters.")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage ="Last name is required."), StringLength(50), Display(Name ="Last Name"), RegularExpression(@"^[A-Z][a-zA-Z0-9 ""\s-.]*$", ErrorMessage = "Invalid input. Avoid special characters.")]
        public string LastName { get; set; } 

        public string FullName
        { get
            {
                return FirstName + " " + (string.IsNullOrEmpty(MiddleName) ? " " : (" " + (char?)(MiddleName[0]) + ".").ToUpper()) + " " + LastName;
            }
        }

        public string Gender { get; set; }

        [Display(Name ="Photo")]
        public IFormFile ImageURL { get; set; }

        [Display(Name ="Phone number"), RegularExpression(@"^[0-9]{11}$", ErrorMessage = "Invalid input.")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Date), Display(Name ="Date of Birth")]
        public DateTime DOB { get; set; }

        [DataType(DataType.Date), Display(Name = "Date Joined")]
        public DateTime DateJoined { get; set; } = DateTime.UtcNow;

        [Required(ErrorMessage ="Job role is required"), StringLength(100), RegularExpression(@"^[A-Za-z \s.-]*$",ErrorMessage ="Invalid input.")]
        public string Designation { get; set; }

        [DataType(DataType.EmailAddress), Display(Name ="Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage ="SSS number is required."), StringLength(50), Display(Name ="SSS number")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage ="SSS number must consist of exactly 10 digits.")]
        public string SSSNo { get; set; }

        [Required(ErrorMessage = "PhilHealth number is required."), StringLength(50), Display(Name = "PhilHealth number")]
        [RegularExpression(@"^[0-9]{12}$", ErrorMessage = "PhilHealth number must consist of exactly 12 digits.")]
        public string PhilHealthNo { get; set; }

        [Required(ErrorMessage = "Pag-Ibig number is required."), StringLength(50), Display(Name = "Pag-Ibig number")]
        [RegularExpression(@"^[0-9]{12}$", ErrorMessage = "Pag-Ibig number must consist of exactly 12 digits.")]
        public string PagIbigNo { get; set; }

        [Display(Name = "Payment Method")]
        public PaymentMethod PaymentMethod { get; set; }

        [Display(Name ="PhilHealth/Pag-Ibig loan?")]
        public Loan Loan { get; set; }

        [Display(Name ="Union member?")]
        public UnionMember UnionMember { get; set; }

        [Required, StringLength(150)]
        public string Address { get; set; }

        [Required, StringLength(50)]
        public string City { get; set; }

        [Required, StringLength(50), Display(Name ="ZIP code")]
        public string PostalCode { get; set; }
    }
}

