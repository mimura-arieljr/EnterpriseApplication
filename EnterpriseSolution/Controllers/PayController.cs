using System;
using Enterprise.Entity;
using Enterprise.Services;
using Enterprise.Services.Implementations;
using EnterpriseSolution.Models;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseSolution.Controllers
{
	public class PayController : Controller
	{
		private readonly IPayComputationService _payComputationService;
        private readonly IEmployeeService _employeeService;

		public PayController(IPayComputationService payComputationService, IEmployeeService employeeService)
		{
			_payComputationService = payComputationService;
            _employeeService = employeeService;
        }
        public IActionResult Index()
		{
            {
                var employee = _payComputationService.GetAll().Select(employee => new PaymentRecordIndexViewModel
                {
                    Id = employee.Id,
                    EmployeeId = employee.EmployeeId,
                    Employee = employee.Employee,
                    FullName = employee.FullName,
                    PayDate = employee.PayDate,
                    PayMonth = employee.PayMonth,
                    TaxYearId = employee.TaxYearId,
                    Year = _payComputationService.GetTaxYearById(employee.TaxYearId).YearOfTax,
                    TotalEarnings = employee.TotalEarnings,
                    TotalDeductions = employee.TotalDeductions,
                    NetPayment = employee.NetPayment

                }).ToList();
                return View(employee);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.employees = _employeeService.GetAllEmployeesForPayroll();
            ViewBag.TaxYears = _payComputationService.GetAlltaxYear();
            var model = new PaymentRecordCreateViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(PaymentRecordCreateViewModel model)
        {
            if(ModelState.IsValid)
            {
                var payRecord = new PaymentRecord()
                {
                    Id = model.Id,
                    EmployeeId = model.EmployeeId,
                    FullName = _employeeService.GetById(model.EmployeeId).FullName,
                    SSSNo = _employeeService.GetById(model.EmployeeId).SSSNo,
                    PayDate = model.PayDate,
                    PayMonth = model.PayMonth,
                    TaxYearId = model.TaxYearId,
                    HourlyRate = model.HourlyRate,
                    HoursWorked = model.HoursWorked,
                    ContractualHours = model.ContractualHours
                    
                };
            }
            return View();
        }
	}
}

