﻿using System;
using Enterprise.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnterpriseSolution.Models
{
    public class PaymentRecordIndexViewModel
    {

        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [Display(Name ="Name")]
        public string FullName { get; set; }

        [Display(Name = "Pay Date")]
        public DateTime PayDate { get; set; }

        [Display(Name = "Month")]
        public string PayMonth { get; set; }

        public int TaxYearId { get; set; }

        public int TaxYear { get; set; }

        public string Year { get; set; }

        [Display(Name = "Total Earnings")]
        public decimal TotalEarnings { get; set; }

        [Display(Name = "Total Deductions")]
        public decimal TotalDeductions { get; set; }

        [Display(Name = "Net Payment")]
        public decimal NetPayment { get; set; }
    }
}

