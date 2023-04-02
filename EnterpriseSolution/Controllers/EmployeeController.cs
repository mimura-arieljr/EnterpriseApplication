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
					Loan = model.Loan,
					Address = model.Address,
					City = model.City,
					PhoneNumber = model.PhoneNumber,
					Designation = model.Designation,
					PostalCode = model.PostalCode
				};

				if(model.ImageURL != null && model.ImageURL.Length > 0)
				{
					employee.ImageURL = GetDBImageURL(model);
				}
				await _employeeService.CreateAsync(employee);
				return RedirectToAction(nameof (Index));
			}
			return View();
		}

		[HttpGet]
		public IActionResult Edit(int Id)
		{
			var employee = _employeeService.GetById(Id);
			if (!DoesEmployeeExists(employee)) { return NotFound(); }
			var model = new EmployeeEditViewModel()
			{
				Id = employee.Id,
				EmployeeNo = employee.EmployeeNo,
				MiddleName = employee.MiddleName,
                FirstName =	employee.FirstName,
                LastName = employee.LastName,
                Gender = employee.Gender,
                Email = employee.Email,
                DOB = employee.DOB,
                DateJoined = employee.DateJoined,
                SSSNo = employee.SSSNo,
                UnionMember = employee.UnionMember,
                PaymentMethod = employee.PaymentMethod,
                Loan = employee.Loan,
                Address = employee.Address,
                City = employee.City,
                PhoneNumber = employee.PhoneNumber,
                Designation = employee.Designation,
                PostalCode = employee.PostalCode
            };
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(EmployeeEditViewModel model)
		{
			if (ModelState.IsValid)
			{
				var employee = _employeeService.GetById(model.Id);
                if (!DoesEmployeeExists(employee)) { return NotFound(); }
                employee.EmployeeNo = model.EmployeeNo;
				employee.FirstName = model.FirstName;
				employee.MiddleName = model.MiddleName;
				employee.LastName = model.LastName;
				employee.Gender = model.Gender;
				employee.Email = model.Email;
				employee.DOB = model.DOB;
				employee.DateJoined = model.DateJoined;
				employee.Address = model.Address;
				employee.City = model.City;
				employee.Designation = model.Designation;
				employee.PaymentMethod = model.PaymentMethod;
				employee.SSSNo = model.SSSNo;
				employee.Loan = model.Loan;
				employee.UnionMember = model.UnionMember;
				employee.PostalCode = model.PostalCode;
				employee.PhoneNumber = model.PhoneNumber;

				if (model.ImageURL != null && model.ImageURL.Length > 0)
				{
					var createModel = new EmployeeCreateViewModel();
					createModel.ImageURL = model.ImageURL;
					employee.ImageURL = GetDBImageURL(createModel);
				}
				_employeeService.UpdateAsync(employee);
				return RedirectToAction(nameof(Index));
			}
			return View();
		}

		[HttpGet]
		public IActionResult Detail(int Id)
		{
			var employee = _employeeService.GetById(Id);
            if (!DoesEmployeeExists(employee)) { return NotFound(); }
            var model = new EmployeeDetailViewModel()
			{
				Id = employee.Id,
				EmployeeNo = employee.EmployeeNo,
				ImageURL = employee.ImageURL,
				FullName = employee.FullName,
				Gender = employee.Gender,
				Email = employee.Email,
				DOB = employee.DOB,
				DateJoined = employee.DateJoined,
				SSSNo = employee.SSSNo,
				UnionMember = employee.UnionMember,
				PaymentMethod = employee.PaymentMethod,
				Loan = employee.Loan,
				Address = employee.Address,
				City = employee.City,
				PhoneNumber = employee.PhoneNumber,
				Designation = employee.Designation,
				PostalCode = employee.PostalCode
			};
			return View(model);
		}

		[HttpGet]
		public IActionResult Delete(int Id)
		{
			var employee = _employeeService.GetById(Id);
            if (!DoesEmployeeExists(employee)) { return NotFound(); }
			var model = new EmployeeDeleteViewModel()
			{
				Id = employee.Id,
				FullName = employee.FullName
			};
            return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(EmployeeDeleteViewModel model)
		{
			if (ModelState.IsValid)
			{
				await _employeeService.Delete(model.Id);
				return RedirectToAction(nameof(Index));
			}
			return View();
		}


		// Class exclusive methods
		private bool DoesEmployeeExists(Employee employee)
		{
			if(employee != null)
			{
				return true;
			}
			return false;
		}

        private string GetDBImageURL(EmployeeCreateViewModel model)
        {
            var uploadDir = @"images/employee";
			//var fileName = Path.GetFileNameWithoutExtension(model.ImageURL.FileName);
			var fileName = model.FirstName;
            var extension = Path.GetExtension(model.ImageURL.FileName);
            var webRootPath = _hostingEnvironment.WebRootPath;
            fileName = DateTime.UtcNow.ToString("yyyyMMdd") + fileName + extension;

            var path = Path.Combine(webRootPath, uploadDir, fileName);
            model.ImageURL.CopyToAsync(new FileStream(path, FileMode.Create));
            var dbImageURL = "/" + uploadDir + "/" + fileName;

            return (dbImageURL);
        }
    }
}

 