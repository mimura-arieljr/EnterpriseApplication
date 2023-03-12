using System;
using Enterprise.Entity;
using System.ComponentModel.DataAnnotations;

namespace EnterpriseSolution.Models
{
	public class EmployeeEditViewModel
	{
        public int Id { get; set; }

        [Required(ErrorMessage = "Employee number is required."), RegularExpression(@"^[A-Z]{3,3}[0-9]{3}$")]
        public string EmployeeNo { get; set; }

        [Required(ErrorMessage = "First name is required."), RegularExpression(@"^[A-Z][a-zA-Z""/s-]*$"), StringLength(50), Display(Name = "First name")]
        public string FirstName { get; set; }

        [StringLength(50), Display(Name = "Middle name")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Last name is required."), StringLength(50), Display(Name = "Last name"), RegularExpression(@"^[A-Z][a-zA-Z""/s-]*$")]
        public string LastName { get; set; }

        public string Gender { get; set; }

        [Display(Name = "Photo")]
        public IFormFile ImageURL { get; set; }

        [Display(Name = "Phone number"), RegularExpression(@"^[0-9]{11}$")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Date), Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }

        [DataType(DataType.Date), Display(Name = "Date Joined")]
        public DateTime DateJoined { get; set; }

        [Required(ErrorMessage = "Job role is required"), StringLength(100)]
        public string Designation { get; set; }

        [DataType(DataType.EmailAddress), Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required, StringLength(50), Display(Name = "SSS number"), RegularExpression(@"^[0-9]{9}$")]
        public string SSSNo { get; set; }

        [Display(Name = "Payment Method")]
        public PaymentMethod PaymentMethod { get; set; }

        [Display(Name = "Student loan?")]
        public StudentLoan StudentLoan { get; set; }

        [Display(Name = "Union member?")]
        public UnionMember UnionMember { get; set; }

        [Required, StringLength(150)]
        public string Address { get; set; }

        [Required, StringLength(50)]
        public string City { get; set; }

        [Required, StringLength(50), Display(Name = "ZIP code")]
        public string PostalCode { get; set; }
    }
}

