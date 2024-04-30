using RichardSzalay.MockHttp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace desafioItau.test.Build
{
    internal class BuildHttpFactory
    {
        private BuildHttpFactory() { }

        public static IHttpClientFactory Build(string url, string conteudoJson, int statusCode = 200)
         => new HttpFactoryClienteMoc(url, conteudoJson, statusCode);



    }



    public class HttpFactoryClienteMoc : IHttpClientFactory
    {
        private readonly string _mediaType = @"application/json";
        private string url;
        private string contentJson;
        private int statusCode = 200;
        public HttpFactoryClienteMoc(string url, string contentJson, int statusCode = 200)
        {
            this.url = url;
            this.contentJson = contentJson;
            this.statusCode = statusCode;
        }


        public HttpClient CreateClient(string url)
        {
            var mockHttp = new MockHttpMessageHandler();
            if (string.IsNullOrEmpty(contentJson))
                mockHttp.When(url).Respond((HttpStatusCode)statusCode);
            else
                mockHttp.When(url).Respond((HttpStatusCode)statusCode, _mediaType, contentJson);

            return new HttpClient(mockHttp);
        }


    }

}
