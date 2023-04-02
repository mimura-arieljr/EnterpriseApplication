using System;
namespace Enterprise.Services.Implementations
{
	public class SSSComputationService : ISSSComputationService
	{
        private decimal sssContribution;

        public decimal SSSContribution(decimal totalPay)
        {
            switch (totalPay)
            {
                case decimal pay when pay >= 29750:
                    sssContribution = 1350;
                    break;

                case decimal pay when pay < 29750:
                    sssContribution = 1327.5m; // Interval of PHP 23.5 difference per bracket
                    break;

                default:
                    sssContribution = 1305;
                    break;
            }
            return sssContribution;
        }
    }
}

