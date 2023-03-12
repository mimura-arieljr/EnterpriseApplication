using System;
using Enterprise.Services;
using EnterpriseSolution.Models;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseSolution.Controllers
{
	public class EmployeeController : Controller
	{
		private readonly IEmployeeService _employeeService;

		public EmployeeController(IEmployeeService employeeService)
		{
			_employeeService = employeeService;
		}

		public IActionResult Index()
		{
			var employee = _employeeService.GetAll().Select(employee => new EmployeeIndexViewModel
			{
				Id = employee.Id,
				FullName = employee.FullName,
				EmployeeNo = employee.EmployeeNo,
				Gender = employee.Gender,
				ImageURL = employee.ImageURL,
				Designation = employee.Designation,
				EmployeeCity = employee.City,
				DateJoined = employee.DateJoined
			}).ToList();
			return View(employee);
		}

		public IActionResult Create()
		{
			return View();
		}
	}
}

 