using System.Net;

namespace TaxJar.TaxJarAPI.WebClients
{
    public interface IWebClient
    {
        WebHeaderCollection Headers { get; set; }
        string DownloadString(string Address);

        string UploadString(string Address, string Data);
    }
}
