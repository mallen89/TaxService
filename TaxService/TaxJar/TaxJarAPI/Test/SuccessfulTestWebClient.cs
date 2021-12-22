using System.Net;
using TaxJar.TaxJarAPI.WebClients;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("TaxJarTest")]
namespace TaxJar.TaxJarAPI.Test
{
    internal class SuccessfulTestWebClient : IWebClient
    {
        public WebHeaderCollection Headers { get; set; }

        internal SuccessfulTestWebClient()
        {
            Headers = new WebHeaderCollection();
            Headers.Add("APIKEY", "123456");
            Headers.Add("Content-Type", "application/json");
        }

        public string DownloadString(string Address)
        {
            return "{\"rate\":{\"city\":\"HOUSTON\",\"city_rate\":\"0.01\",\"combined_district_rate\":\"0.01\",\"combined_rate\":\"0.0825\",\"country\":\"US\",\"country_rate\":\"0.0\",\"county\":\"HARRIS\",\"county_rate\":\"0.0\",\"freight_taxable\":true,\"state\":\"TX\",\"state_rate\":\"0.0625\",\"zip\":\"77429\"}}";
        }

        public string UploadString(string Address, string Data)
        {
            return "{\"tax\":{\"amount_to_collect\":0.41,\"breakdown\":{\"city_tax_collectable\":0.0,\"city_tax_rate\":0.0,\"city_taxable_amount\":0.0,\"combined_tax_rate\":0.0825,\"county_tax_collectable\":0.0,\"county_tax_rate\":0.0,\"county_taxable_amount\":0.0,\"line_items\":[{\"city_amount\":0.0,\"city_tax_rate\":0.0,\"city_taxable_amount\":0.0,\"combined_tax_rate\":0.0825,\"county_amount\":0.0,\"county_tax_rate\":0.0,\"county_taxable_amount\":0.0,\"id\":\"1\",\"special_district_amount\":0.0,\"special_district_taxable_amount\":0.0,\"special_tax_rate\":0.02,\"state_amount\":0.0,\"state_sales_tax_rate\":0.0625,\"state_taxable_amount\":0.0,\"tax_collectable\":0.0,\"taxable_amount\":0.0}],\"shipping\":{\"city_amount\":0.0,\"city_tax_rate\":0.0,\"city_taxable_amount\":0.0,\"combined_tax_rate\":0.0825,\"county_amount\":0.0,\"county_tax_rate\":0.0,\"county_taxable_amount\":0.0,\"special_district_amount\":0.1,\"special_tax_rate\":0.02,\"special_taxable_amount\":5.0,\"state_amount\":0.31,\"state_sales_tax_rate\":0.0625,\"state_taxable_amount\":5.0,\"tax_collectable\":0.41,\"taxable_amount\":5.0},\"special_district_tax_collectable\":0.1,\"special_district_taxable_amount\":5.0,\"special_tax_rate\":0.02,\"state_tax_collectable\":0.31,\"state_tax_rate\":0.0625,\"state_taxable_amount\":5.0,\"tax_collectable\":0.41,\"taxable_amount\":5.0},\"freight_taxable\":true,\"has_nexus\":true,\"jurisdictions\":{\"city\":\"UNINCORPORATED\",\"country\":\"US\",\"county\":\"HARRIS\",\"state\":\"TX\"},\"order_total_amount\":5.0,\"rate\":0.0825,\"shipping\":5.0,\"tax_source\":\"destination\",\"taxable_amount\":5.0}}";
        }
    }
}
