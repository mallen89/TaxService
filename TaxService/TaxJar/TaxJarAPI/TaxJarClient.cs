using System.Text.Json;
using TaxJar.TaxJarAPI.Requests;
using TaxJar.TaxJarAPI.Responses;
using TaxJar.TaxJarAPI.WebClients;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("UnitTests")]
namespace TaxJar.TaxJarAPI
{
    internal class TaxJarClient
    {
        private IWebClient webClient;

        internal TaxJarClient(IWebClientFactory WebClientFactory)
        {
            webClient = WebClientFactory.Create();
            webClient.Headers.Add("Authorization", "Bearer 5da2f821eee4035db4771edab942a4cc");
            webClient.Headers.Add("Content-Type" , "application/json");
        }

        internal RatesResponse GetTaxRate(int ZipCode)
        {
            string request = "https://api.taxjar.com/v2/rates/" + ZipCode;
            string jsonResponse = webClient.DownloadString(request);
            RatesResponse response = JsonSerializer.Deserialize<RatesResponse>(jsonResponse);

            return response;
        }

        internal TaxesResponse GetSalesTax(TaxesRequest Request)
        {
            string jsonRequest = JsonSerializer.Serialize<TaxesRequest>(Request);
            string jsonResponse = webClient.UploadString("https://api.taxjar.com/v2/taxes", jsonRequest);
            TaxesResponse taxesResponse = JsonSerializer.Deserialize<TaxesResponse>(jsonResponse);

            return taxesResponse;
        }
    }
}
