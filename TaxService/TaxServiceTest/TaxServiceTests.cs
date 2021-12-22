using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxCalcFactory;
using TaxCalculatorInterface;
using TaxServiceProj;

namespace TaxServiceTest
{
    [TestClass]
    public class TaxServiceTests
    {
        [TestMethod]
        public void TaxServiceTestWithNullTaxCalculatorGetTaxRateByLocation()
        {
            TaxService testTaxService = new TaxService(TaxCalculatorFactory.GetTaxCalculator(TaxCalculatorEnum.Other));

            double testTaxRate = testTaxService.GetTheTaxRateByLocation(77429);

            Assert.AreEqual(0, testTaxRate);
        }

        [TestMethod]
        public void TaxServiceTestWithTaxJarTaxCalculatorGetTaxRateByLocation()
        {
            TaxService testTaxService = new TaxService(TaxCalculatorFactory.GetTaxCalculator(TaxCalculatorEnum.TaxJar));

            double testTaxRate = testTaxService.GetTheTaxRateByLocation(77429);

            Assert.AreEqual(0.0825, testTaxRate);
        }

        [TestMethod]
        public void TaxServiceTestWithNullTaxCalculatorCalculateTaxForAnOrder()
        {
            TaxService testTaxService = new TaxService(TaxCalculatorFactory.GetTaxCalculator(TaxCalculatorEnum.Other));

            double taxForAnOrder = testTaxService.CalculateTaxesForAnOrder(15.0f, 5.0f, new Address { Country = "US", State = "TX", Zip = "77429", City = "Cypress", Street = "15306 Thistle Rock Ln" },
                                                            new Address { Country = "US", State = "TX", Zip = "77429", City = "Cypress", Street = "17018 Lost Cypress Dr" });

            Assert.AreEqual(0, taxForAnOrder);
        }

        [TestMethod]
        public void TaxServiceTestWithTaxJarTaxCalculatorCalculateTaxForAnOrder()
        {
            TaxService testTaxService = new TaxService(TaxCalculatorFactory.GetTaxCalculator(TaxCalculatorEnum.TaxJar));

            double taxForAnOrder = testTaxService.CalculateTaxesForAnOrder(15.0f, 5.0f, new Address { Country = "US", State = "TX", Zip = "77429", City = "Cypress", Street = "15306 Thistle Rock Ln" },
                                                            new Address { Country = "US", State = "TX", Zip = "77429", City = "Cypress", Street = "17018 Lost Cypress Dr" });

            Assert.AreEqual(1.65, taxForAnOrder);
        }
    }
}
