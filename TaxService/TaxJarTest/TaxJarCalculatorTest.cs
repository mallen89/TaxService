using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxCalculatorInterface;
using TaxJar;

namespace TaxJarTest
{
    [TestClass]
    public class TaxJarCalculatorTests
    {
        [TestMethod]
        public void GetTaxRateWithTaxJarCalculator()
        {
            TaxJarCalculator taxJarCalculator = new TaxJarCalculator();

            double combinedRate = taxJarCalculator.GetTaxRateByLocation(77429);

            Assert.AreEqual(0.0825, combinedRate);
        }

        [TestMethod]
        public void GetSalesTaxWithTaxJarCalculator()
        {
            TaxJarCalculator taxJarCalculator = new TaxJarCalculator();

            double amountToCollect = taxJarCalculator.CacluclateTaxForOrder(15.0f, 5.0f, new Address { Country = "US", State = "TX", Zip = "77429", City = "Cypress", Street = "15306 Thistle Rock Ln" },
                                                            new Address { Country = "US", State = "TX", Zip = "77429", City = "Cypress", Street = "17018 Lost Cypress Dr" });

            Assert.AreEqual(1.65, amountToCollect);
        }

    }
}
