using System;
namespace Enterprise.Services.Implementations
{
    public class TaxComputationService : ITaxComputationService
    {
        public decimal GetTaxDeduction(decimal totalPay)
        {
            decimal taxRate;
            decimal taxAmount;

            switch (totalPay)
            {
                case decimal pay when pay <= 20833:
                    taxRate = 0.1m;
                    taxAmount = totalPay * taxRate;
                    break;

                case decimal pay when pay <= 33332:
                    taxRate = 0.15m;
                    taxAmount = taxRate * (totalPay - 20833);
                    break;

                case decimal pay when pay <= 66666:
                    taxRate = 0.2m;
                    taxAmount = 1875 + (taxRate * (totalPay - 33333));
                    break;

                case decimal pay when pay <= 166666:
                    taxRate = 0.25m;
                    taxAmount = 8541.8m + (taxRate * (totalPay - 66667));
                    break;

                case decimal pay when pay <= 666666:
                    taxRate = 0.3m;
                    taxAmount = 33541.8m + (taxRate * (totalPay - 166667));
                    break;

                default:
                    taxRate = 0.35m;
                    taxAmount = 183541.8m + (taxRate * (totalPay - 666667));
                    break;
            }

            return taxAmount;
        }

    }
}

