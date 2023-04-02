using System;
using Enterprise.Entity;
using Enterprise.Persistence;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Enterprise.Services.Implementations
{
    public class PayComputationService : IPayComputationService
    {
        private readonly ApplicationDbContext _context;
        private decimal contractualEarnings;
        private decimal overtimeHours;

        public PayComputationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public decimal ContractualEarnings(decimal contractualHours, decimal hoursWorked, decimal hourlyRate)
        {
            if (contractualHours > hoursWorked)
            {
                contractualEarnings = hoursWorked * hourlyRate;
            }
            else
            {
                contractualEarnings = contractualHours * hourlyRate;
            }
            return contractualEarnings;
        }

        public async Task CreateAsync(PaymentRecord paymentRecord)
        {
            await _context.PaymentRecords.AddAsync(paymentRecord);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<PaymentRecord> GetAll() => _context.PaymentRecords.OrderBy(p => p.EmployeeId);

        public IEnumerable<SelectListItem> GetAlltaxYear()
        {
            var allTaxYear = _context.TaxYear.Select(taxYear => new SelectListItem
            {
                Text = taxYear.YearOfTax,
                Value = taxYear.TaxYearId.ToString()
            });
            return allTaxYear;
        }

        public PaymentRecord GetById(int id) =>
            _context.PaymentRecords.Where(p => p.Id == id).FirstOrDefault();

        public TaxYear GetTaxYearById(int id) =>
            _context.TaxYear.Where(year => year.TaxYearId == id).FirstOrDefault();
        

        public decimal NetPay(decimal totalEarnings, decimal totalDeduction) =>
            totalEarnings - totalDeduction;

        public decimal OvertimeEarnings(decimal overtimeRate, decimal overtimeHours) =>
            overtimeHours * overtimeRate;

        public decimal OvertimeHours(decimal hoursWorked, decimal contractualHours)
        {
            if(hoursWorked<=contractualHours)
            {
                overtimeHours = 0.00m;
            }
            else if(hoursWorked>contractualHours)
            {
                overtimeHours = hoursWorked - contractualHours;
            }
            return overtimeHours;
        }

        public decimal OvertimeRate(decimal hourlyRate) =>
            hourlyRate * 1.1m;


        public decimal TotalDeductions(decimal tax, decimal sss, decimal LoanPayment, decimal unionPayment) =>
            tax + sss + LoanPayment + unionPayment;

        public decimal TotalEarnings(decimal overtimeEarnings, decimal contractualEarnings) =>
            overtimeEarnings + contractualEarnings;
    }
}

