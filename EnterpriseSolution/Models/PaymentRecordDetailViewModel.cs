using System;
using Enterprise.Entity;
using System.ComponentModel.DataAnnotations;

namespace EnterpriseSolution.Models
{
	public class PaymentRecordDetailViewModel
	{
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [Display(Name = "Name")]
        public string FullName { get; set; }

        public string SSSNo { get; set; }

        public DateTime PayDate { get; set; }

        public string PayMonth { get; set; }

        public int TaxYearId { get; set; }

        public TaxYear TaxYear { get; set; }

        public string TaxCode { get; set; }

        public decimal HourlyRate { get; set; }

        public decimal HoursWorked { get; set; }

        public decimal ContractualHours { get; set; }

        public decimal ContractualEarnings { get; set; }

        public decimal OvertimeEarnings { get; set; }

        public decimal Tax { get; set; }

        public decimal TaxContribution { get; set; }

        public decimal? UnionFee { get; set; }

        public Nullable<decimal> LoanContribution { get; set; }

        public decimal TotalEarnings { get; set; }

        public decimal TotalDeductions { get; set; }

        public decimal NetPayment { get; set; }
    }
}

