﻿using System;
namespace EnterpriseSolution.Models
{
	public class EmployeeIndexViewModel
	{
		public int Id { get; set; }

		public string EmployeeNo { get; set; }

		public string FullName { get; set; }

		public string Gender { get; set; }

		public string ImageURL { get; set; }

		public DateTime DateJoined { get; set; }

		public string Designation { get; set; }

		public string EmployeeCity { get; set; }
	}
}

