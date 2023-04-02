﻿using System;
using Enterprise.Entity;

namespace EnterpriseSolution.Models
{
	public class EmployeeDetailViewModel
	{
        public int Id { get; set; }

        public string EmployeeNo { get; set; }

        public string FullName { get; set; }

        public string Gender { get; set; }

        public string ImageURL { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime DOB { get; set; }

        public DateTime DateJoined { get; set; }

        public string Designation { get; set; }

        public string SSSNo { get; set; }

        public string PhilHealthNo { get; set; }

        public string PagIbigNo { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public Loan Loan { get; set; }

        public UnionMember UnionMember { get; set; }

    }
}

