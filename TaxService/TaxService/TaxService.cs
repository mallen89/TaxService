using TaxCalculatorInterface;

namespace TaxServiceProj
{
    public class TaxService
    {
        private ITaxCalculator TaxCalculator;

        public TaxService(ITaxCalculator TaxCalculator)
        {
            this.TaxCalculator = TaxCalculator;
        }

        public double GetTheTaxRateByLocation(int ZipCode)
        {
            if (TaxCalculator != null)
            {
                return TaxCalculator.GetTaxRateByLocation(ZipCode);
            }
            else
            {
                return 0;
            }
    
        }

        public double CalculateTaxesForAnOrder(float OrderAmount, float ShippingAmount, Address FromAddress, Address ToAddress)
        {
            if (TaxCalculator != null)
            {
                return TaxCalculator.CacluclateTaxForOrder(OrderAmount, ShippingAmount, FromAddress, ToAddress);
            }
            else
            {
                return 0;
            }
        }
    }
}
