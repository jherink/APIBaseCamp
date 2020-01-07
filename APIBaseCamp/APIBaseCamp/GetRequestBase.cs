using System;
using System.Collections.Generic;
using System.Text;

namespace APIBaseCamp
{
    public abstract class GetRequestBase : RequestBase
    {
        public GetRequestBase( string baseUrl ) : base( baseUrl )
        {
        }

        public override void Make()
        {
            var client = base.CreateClient();

            var baseURI = GetRequestUri();

            var response = client.GetAsync( baseURI ).Result;

            EnsureSuccess( response );

            // Interpret
            InterpretResponse( response.Headers, response.Content );
        }
    }
}
