using System;
using Enterprise.Entity;
using Enterprise.Services;
using EnterpriseSolution.Models;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseSolution.Controllers
{
	public class EmployeeController : Controller
	{
		private readonly IEmployeeService _employeeService;
		private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

		public EmployeeController(IEmployeeService employeeService, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
		{
			_employeeService = employeeService;
			_hostingEnvironment = hostingEnvironment;
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

		[HttpGet]
		public IActionResult Create()
		{
			var model = new EmployeeCreateViewModel();
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken] // Prevents cross-site request forgery attacks.
		public async Task<IActionResult> Create(EmployeeCreateViewModel model)
		{
			if (ModelState.IsValid)
			{
				var employee = new Employee
				{
					Id = model.Id,
					EmployeeNo = model.EmployeeNo,
					FirstName = model.FirstName,
					LastName = model.LastName,
					FullName = model.FullName,
					Gender = model.Gender,
					Email = model.Email,
					DOB = model.DOB,
					DateJoined = model.DateJoined,
					SSSNo = model.SSSNo,
					UnionMember = model.UnionMember,
					PaymentMethod = model.PaymentMethod,
					StudentLoan = model.StudentLoan,
					Address = model.Address,
					City = model.City,
					PhoneNumber = model.PhoneNumber,
					Designation = model.Designation,
					PostalCode = model.PostalCode
				};

				if(model.ImageURL != null && model.ImageURL.Length > 0)
				{
					var uploadDir = @"images/employee";
					var fileName = Path.GetFileNameWithoutExtension(model.ImageURL.FileName);
					var extension = Path.GetExtension(model.ImageURL.FileName);
					var webRootPath = _hostingEnvironment.WebRootPath;
					fileName = DateTime.UtcNow.ToString("yyyyMMdd") + fileName + extension;

					var path = Path.Combine(webRootPath, uploadDir, fileName);
					await model.ImageURL.CopyToAsync(new FileStream(path, FileMode.Create));
					employee.ImageURL = "/" + uploadDir + "/" + fileName;
				}
				await _employeeService.CreateAsync(employee);
				return RedirectToAction(nameof (Index));
			}
			return View();
		}
	}
}

 