using TaxCalculatorInterface;

namespace TaxJar.TaxJarAPI.WebClients
{
    public class SystemWebClientFactory : IWebClientFactory
    {
        public IWebClient Create()
        {
            return new SystemWebClient();
        }
    }
}
