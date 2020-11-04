using RestSharp;
using ApiFramework.Services.Attributes.Methods;
using ApiFramework.Services.Attributes.Parameters;


namespace ApiFramework.Api.Discussions
{
    [RestMethod(Method.POST)]
    [Path("{resourceid}/oauth2/token")]
    public class PostDiscussions
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
}
