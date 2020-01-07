using System.Net.Http;
using System.Net.Http.Headers;

namespace APIBaseCamp
{
    public interface IHttpRequestInjector
    {
        void Inject( HttpRequestHeaders headers );

        HttpContent FormContent( object payload );
    }
}
