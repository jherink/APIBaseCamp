using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace APIBaseCamp
{
    public abstract class RequestBase : IRequest
    {
        protected readonly Uri BaseUrl;

        public RequestBase( string baseUrl )
        {
            if ( baseUrl[baseUrl.Length - 1] != '/' ) baseUrl = baseUrl + "/";
            BaseUrl = new Uri( baseUrl );
        }

        protected abstract IHttpRequestInjector GetHeaderInjector();

        protected abstract void InterpretResponse( HttpResponseHeaders headers,
                                                   HttpContent response );

        public abstract void Make();

        public virtual Task MakeAsync()
        {
            return Task.Run( Make );
        }

        protected HttpClient CreateClient()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri( BaseUrl.AbsoluteUri )
            };

            GetHeaderInjector().Inject( client.DefaultRequestHeaders );

            return client;
        }

        protected void EnsureSuccess( HttpResponseMessage response )
        {
            response.EnsureSuccessStatusCode();
        }

        protected abstract Uri GetRequestUri();
    }
}
