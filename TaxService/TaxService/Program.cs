using System;
using TaxCalcFactory;
using TaxCalculatorInterface;

namespace TaxServiceProj
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TaxService service = new TaxService(TaxCalculatorFactory.GetTaxCalculator(TaxCalculatorEnum.TaxJar));
            
            Console.ReadLine();
        }
    }
}
