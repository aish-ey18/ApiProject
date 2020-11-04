using ApiFramework.Services.Attributes.Methods;
using ApiFramework.Services.Attributes.Parameters;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiFramework.Api.Rootsite.Users
{
    [RestMethod(Method.GET)]
    [Path("api/v1/user")]
    class GetUser
    {
        [Body("pageNumber")]
        public int pageNumber { get; set; }

        [Body("pageSize")]
        public int pageSize { get; set; }
    }

    [RestMethod(Method.GET)]
    [Path("api/v1/user/{id}")]
    class GetUserById
    {
        [Path("id")]
        public string Id { get; set; }
    }

    [RestMethod(Method.GET)]
    [Path("api/v1/user/SearchInAd")]
    class GetUsersSearch
    {
        [Body("searchTerm")]
        public string searchTerm { get; set; }

        [Body("limit")]
        public int limit { get; set; }
        
    }

    [RestMethod(Method.POST)]
    [Path("api/v1/user")]
    class PostUser
    {
        [Header("Content-Type")]
        public string ContentType { get; set; }
    }

    [RestMethod(Method.PUT)]
    [Path("api/v1/user")]
    class PutUser
    {
       
    }
}