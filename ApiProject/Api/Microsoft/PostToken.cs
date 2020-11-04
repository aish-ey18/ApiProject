using RestSharp;
using ApiFramework.Services.Attributes.Methods;
using ApiFramework.Services.Attributes.Parameters;


namespace ApiFramework.Api.Microsoft
{
    [RestMethod(Method.POST)]
    [Path("{resourceid}/oauth2/token")]
    public class PostToken
    {
        [Path("resourceid")]
        public string ResourceId { get; set; }

        [Header("Content-Type")]
        public string ContentType { get; set; }

        [Body("grant_type")]
        public string GrantType { get; set; }

        [Body("client_id")]
        public string ClientId { get; set; }

        [Body("client_secret")]
        public string ClientSecret { get; set; }

        [Body("resource")]
        public string Resource { get; set; }
    }

    [RestMethod(Method.GET)]
    [Path("/api/v1/cache/{cacheName}")]

    public class GetCache
    {
        [Path("cacheName")]
        public string cacheName { get; set; }

        [Header("Content-Type")]
        public string ContentType { get; set; }

        [Header("EYDX-CONTENT-SERVICE-API-KEY")]
        public string contentkey { get; set; }

        [Header("authorization")]
        public string authorization { get; set; }
    }
}
