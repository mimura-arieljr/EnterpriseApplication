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
        private readonly ISSSComputationService _sssComputationService;
        private readonly ITaxComputationService _taxComputationService;

        public PayController(IPayComputationService payComputationService, IEmployeeService employeeService, ISSSComputationService sssComputationService, ITaxComputationService taxComputationService)
        {
            _payComputationService = payComputationService;
            _employeeService = employeeService;
            _sssComputationService = sssComputationService;
            _taxComputationService = taxComputationService;
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PaymentRecordCreateViewModel model)
        {
            decimal overtimeHrs;
            decimal contractualEarnings;
            decimal overtimeEarnings;
            decimal totalEarnings;
            decimal taxContribution;
            decimal tax;
            decimal philHealthPagIbig;
            decimal loanContribution;
            decimal totalDeduction;

            if (ModelState.IsValid)
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
                    ContractualHours = model.ContractualHours,
                    OvertimeHours = overtimeHrs = _payComputationService.OvertimeHours(model.HoursWorked, model.ContractualHours),
                    ContractualEarnings = contractualEarnings = _payComputationService.ContractualEarnings(model.ContractualHours, model.HoursWorked, model.HourlyRate),
                    OvertimeEarnings = overtimeEarnings = _payComputationService.OvertimeEarnings(_payComputationService.OvertimeRate(model.HourlyRate), overtimeHrs),
                    TotalEarnings = totalEarnings = _payComputationService.TotalEarnings(overtimeEarnings, contractualEarnings),
                    Tax = tax = _taxComputationService.GetTaxDeduction(totalEarnings),
                    TaxContribution = taxContribution = _sssComputationService.SSSContribution(totalEarnings),
                    UnionFee = philHealthPagIbig = _employeeService.UnionFees(model.EmployeeId),
                    LoanContribution = loanContribution = _employeeService.LoanRepaymentAmount(model.EmployeeId, totalEarnings),
                    TotalDeductions = totalDeduction = _payComputationService.TotalDeductions(tax, taxContribution, philHealthPagIbig, loanContribution),
                    NetPayment = _payComputationService.NetPay(totalEarnings, totalDeduction)
                };
                await _payComputationService.CreateAsync(payRecord);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.employees = _employeeService.GetAllEmployeesForPayroll();
            ViewBag.TaxYears = _payComputationService.GetAlltaxYear();
            return View();
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var payRecord = _payComputationService.GetById(id);
            if(payRecord == null)
            {
                return NotFound();
            }
            var model = new PaymentRecordDetailViewModel()
            {
                Id = payRecord.Id,
                EmployeeId = payRecord.EmployeeId,
                Employee = payRecord.Employee,
                FullName = payRecord.FullName,
                SSSNo = payRecord.SSSNo,
                PayDate = payRecord.PayDate,
                PayMonth = payRecord.PayMonth,
                TaxYearId = payRecord.TaxYearId,
                TaxYear = payRecord.TaxYear,
                HourlyRate = payRecord.HourlyRate,
                HoursWorked = payRecord.HoursWorked,
                ContractualEarnings = payRecord.ContractualEarnings,
                ContractualHours = payRecord.ContractualHours,
                OvertimeEarnings = payRecord.OvertimeEarnings,
                Tax = payRecord.Tax,
                TaxContribution = payRecord.TaxContribution,
                UnionFee = payRecord.UnionFee,
                LoanContribution = payRecord.LoanContribution,
                TotalDeductions = payRecord.TotalDeductions,
                TotalEarnings = payRecord.TotalEarnings,
                NetPayment = payRecord.NetPayment
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Payslip(int id)
        {
            var payRecord = _payComputationService.GetById(id);
            if (payRecord == null)
            {
                return NotFound();
            }
            var model = new PaymentRecordDetailViewModel()
            {
                Id = payRecord.Id,
                EmployeeId = payRecord.EmployeeId,
                Employee = payRecord.Employee,
                FullName = payRecord.FullName,
                SSSNo = payRecord.SSSNo,
                PayDate = payRecord.PayDate,
                PayMonth = payRecord.PayMonth,
                TaxYearId = payRecord.TaxYearId,
                TaxYear = payRecord.TaxYear,
                HourlyRate = payRecord.HourlyRate,
                HoursWorked = payRecord.HoursWorked,
                ContractualEarnings = payRecord.ContractualEarnings,
                ContractualHours = payRecord.ContractualHours,
                OvertimeEarnings = payRecord.OvertimeEarnings,
                Tax = payRecord.Tax,
                TaxContribution = payRecord.TaxContribution,
                UnionFee = payRecord.UnionFee,
                LoanContribution = payRecord.LoanContribution,
                TotalDeductions = payRecord.TotalDeductions,
                TotalEarnings = payRecord.TotalEarnings,
                NetPayment = payRecord.NetPayment
            };
            return View(model);
        }
    }
}

