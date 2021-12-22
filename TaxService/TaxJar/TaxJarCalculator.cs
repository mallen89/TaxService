using System;
using TaxCalculatorInterface;
using TaxJar.TaxJarAPI;
using TaxJar.TaxJarAPI.Requests;
using TaxJar.TaxJarAPI.Responses;
using TaxJar.TaxJarAPI.WebClients;

namespace TaxJar
{
    public class TaxJarCalculator : ITaxCalculator
    {
        private TaxJarClient taxJarClient;

        public TaxJarCalculator()
        {

        }
        
        public double CacluclateTaxForOrder(float OrderAmount, float ShippingAmount, Address FromAddress, Address ToAddress)
        {
            taxJarClient = new TaxJarClient(new SystemWebClientFactory());

            TaxesRequest taxesRequest = new TaxesRequest();
            taxesRequest.amount = OrderAmount;
            taxesRequest.shipping = ShippingAmount;

            taxesRequest.from_country = FromAddress.Country;
            taxesRequest.from_state = FromAddress.State;
            taxesRequest.from_city = FromAddress.City;
            taxesRequest.from_zip = FromAddress.Zip;
            taxesRequest.from_street = FromAddress.Street;

            taxesRequest.to_country = ToAddress.Country;
            taxesRequest.to_state = ToAddress.State;
            taxesRequest.to_city = ToAddress.City;
            taxesRequest.to_zip = ToAddress.Zip;
            taxesRequest.to_street = ToAddress.Street;

            TaxesResponse taxesResponse = taxJarClient.GetSalesTax(taxesRequest);

            return Math.Round(taxesResponse.tax.amount_to_collect,2);
        }

        public double GetTaxRateByLocation(int ZipCode)
        {
            taxJarClient = new TaxJarClient(new SystemWebClientFactory());
            RatesResponse ratesResponse = taxJarClient.GetTaxRate(ZipCode); 

            return Convert.ToDouble(ratesResponse.rate.combined_rate);
        }
    }
}
