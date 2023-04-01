using System;
using Enterprise.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Enterprise.Services
{
	public interface IPayComputationService
	{
		Task CreateAsync(PaymentRecord paymentRecord);

		PaymentRecord GetById(int id);

		IEnumerable<PaymentRecord> GetAll();

		IEnumerable<SelectListItem> GetAlltaxYear();

		decimal OvertimeHours(decimal hoursWorked, decimal contractualHours);

		decimal ContractualEarnings(decimal contractualHours, decimal hoursWorked, decimal hourlyRate);

		decimal OvertimeRate(decimal hourlyRate);

		decimal OvertimeEarnings(decimal overtimeRate, decimal overtimeHours);

		decimal TotalEarnings(decimal overtimeEarnings, decimal contractualEarnings);

		decimal TotalDeductions(decimal tax, decimal sss, decimal studentLoanPayment, decimal unionPayment);

		decimal NetPay(decimal totalEarnings, decimal totalDeduction);
	}
}

