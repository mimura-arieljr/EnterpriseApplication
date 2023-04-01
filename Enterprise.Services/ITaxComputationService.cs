using System;
namespace Enterprise.Services
{
	public interface ITaxComputationService
	{
		decimal GetTaxDeduction(decimal totalPay);
	}
}

