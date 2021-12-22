using System.Net;
using TaxJar.TaxJarAPI.WebClients;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("TaxJarTest")]
namespace TaxJar.TaxJarAPI.Test
{
    internal class EmptyResponseTestWebClient : IWebClient
    {
        public WebHeaderCollection Headers { get; set; }

        internal EmptyResponseTestWebClient()
        {
            Headers = new WebHeaderCollection();
            Headers.Add("APIKEY", "123456");
        }

        public string DownloadString(string Address)
        {
            return "{}";
        }

        public string UploadString(string Address, string Data)
        {
            return "{}";
        }
    }
}
