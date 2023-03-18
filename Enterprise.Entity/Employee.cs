using System;
using System.ComponentModel.DataAnnotations;

namespace Enterprise.Entity
{
	public class Employee
	{
		public int Id { get; set; }

		[Required]
		public string EmployeeNo { get; set; }

		[Required, MaxLength(50)]
		public string FirstName { get; set; }

		public string? MiddleName { get; set; }

		[Required, MaxLength(50)]
		public string LastName { get; set; }

		public string FullName { get; set; }

		public string Gender { get; set; }

		public string ImageURL { get; set; }

		public string Email { get; set; }

		public string PhoneNumber { get; set; }

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

		public IEnumerable<PaymentRecord> PaymentRecords { get; set; }

		public PaymentMethod PaymentMethod { get; set; }

		public StudentLoan StudentLoan { get; set; }

		public UnionMember UnionMember { get; set; }
	}
}

