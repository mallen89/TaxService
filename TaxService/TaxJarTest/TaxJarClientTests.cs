using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxCalculatorInterface;
using TaxJar.TaxJarAPI;
using TaxJar.TaxJarAPI.Requests;
using TaxJar.TaxJarAPI.Responses;
using TaxJar.TaxJarAPI.Test;

namespace TaxJarTest
{
    [TestClass]
    public class TaxJarClientTests
    {
        [TestMethod]
        public void GetTaxRateWithSuccessfulTestWebClient()
        {
            TaxJarClient taxJarClient = new TaxJarClient(new TestWebClientFactory(TestClientEnums.Successful));
            RatesResponse rateResponse = taxJarClient.GetTaxRate(77429);

            Assert.AreEqual(0.0825f, System.Convert.ToSingle(rateResponse.rate.combined_rate));
        }

        [TestMethod]
        public void GetTaxRateWithEmptyResponseTestWebClient()
        {
            TaxJarClient taxJarClient = new TaxJarClient(new TestWebClientFactory(TestClientEnums.EmptyResponse));
            RatesResponse rateResponse = taxJarClient.GetTaxRate(77429);

            Assert.AreEqual(null, rateResponse.rate);
        }

        [TestMethod]
        public void GetSalesTaxWithSuccessfulTestWebClient()
        {
            TaxJarClient taxJarClient = new TaxJarClient(new TestWebClientFactory(TestClientEnums.Successful));

            float OrderAmount = 15.0f;
            float ShippingAmount = 5.0f;
            Address FromAddress = new Address { Country = "US", State = "TX", Zip = "77429", City = "Cypress", Street = "15306 Thistle Rock Ln" };
            Address ToAddress = new Address { Country = "US", State = "TX", Zip = "77429", City = "Cypress", Street = "17018 Lost Cypress Dr" };

            TaxesRequest taxesRequestTest = new TaxesRequest();
            taxesRequestTest.amount = OrderAmount;
            taxesRequestTest.shipping = ShippingAmount;

            taxesRequestTest.from_country = FromAddress.Country;
            taxesRequestTest.from_state = FromAddress.State;
            taxesRequestTest.from_city = FromAddress.City;
            taxesRequestTest.from_zip = FromAddress.Zip;
            taxesRequestTest.from_street = FromAddress.Street;

            taxesRequestTest.to_country = ToAddress.Country;
            taxesRequestTest.to_state = ToAddress.State;
            taxesRequestTest.to_city = ToAddress.City;
            taxesRequestTest.to_zip = ToAddress.Zip;
            taxesRequestTest.to_street = ToAddress.Street;

            taxesRequestTest.line_items = new[] { new TaxJar.TaxJarAPI.Requests.Line_Items { } };

            TaxesResponse taxesResponse = taxJarClient.GetSalesTax(new TaxesRequest());

            Assert.AreEqual(0.41f, taxesResponse.tax.amount_to_collect);
        }

        [TestMethod]
        public void GetSalesTaxWithEmptyResponseTestWebClient()
        {
            TaxJarClient taxJarClient = new TaxJarClient(new TestWebClientFactory(TestClientEnums.EmptyResponse));
            TaxesResponse taxesResponse = taxJarClient.GetSalesTax(new TaxesRequest());

            Assert.AreEqual(null, taxesResponse.tax);
        }

    }
}
