using TaxJar.TaxJarAPI.WebClients;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("TaxJarTest")]
namespace TaxJar.TaxJarAPI.Test
{
    internal class TestWebClientFactory : IWebClientFactory
    {
        private TestClientEnums Type;

        internal TestWebClientFactory()
        {

        }

        internal TestWebClientFactory(TestClientEnums Type)
        {
            this.Type = Type;
        }
        public IWebClient Create()
        {
            switch (Type)
            {
                case TestClientEnums.Successful:
                    return new SuccessfulTestWebClient();
                case TestClientEnums.EmptyResponse:
                    return new EmptyResponseTestWebClient();
                default:
                    return new EmptyResponseTestWebClient();
            }
        }
    }

}
