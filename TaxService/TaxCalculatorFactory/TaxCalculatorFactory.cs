using TaxCalculatorInterface;
using TaxJar;

namespace TaxCalcFactory
{
    public static class TaxCalculatorFactory
    {
        public static ITaxCalculator GetTaxCalculator(TaxCalculatorEnum TaxCalculatorEnum)
        {
            switch (TaxCalculatorEnum)
            {
                case TaxCalculatorEnum.TaxJar:
                    return new TaxJarCalculator();

                default:
                    return null;
            }
        }
    }
}
