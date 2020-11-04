using ApiFramework.Services.Attributes.Methods;
using ApiFramework.Services.Attributes.Parameters;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiFramework.Api.Rootsite.GroupProfiles
{
    [RestMethod(Method.DELETE)]
    [Path("api/v1/ActionTemplate/{id}")]
    class DeleteGroupProfileById
    {
        [Path("id")]
        public string Id { get; set; }
    }

    [RestMethod(Method.GET)]
    [Path("api/v1/ActionTemplate/{id}")]
    class GetGroupProfileById
    {
        [Path("id")]
        public string Id { get; set; }
    }

    [RestMethod(Method.GET)]
    [Path("api/v1/ActionTemplates/GetAll")]
    class GetAllGroupProfiles
    {

    }

    [RestMethod(Method.GET)]
    [Path("api/v1/ActionTemplate")]
    class GetGroupProfiles
    {
        [Body("pageNumber")]
        public int pageNumber { get; set; }

        [Body("pageSize")]
        public int pageSize { get; set; }
    }

    [RestMethod(Method.POST)]
    [Path("api/v1/ActionTemplates")]
    class PostGroupProfile
    {
        [Header("Content-Type")]
        public string ContentType { get; set; }

        [Body("id")]
        public string Id { get; set; }

        [Body("name")]
        public string name { get; set; }

        [Body("description")]
        public string description { get; set; }

        [Body("usedByRoles")]
        public List<string> usedByRoles { get; set; }

        [Body("templateRoles")]
        public List<string> templateRoles { get; set; }
    }

    [RestMethod(Method.PUT)]
    [Path("api/v1/ActionTemplate")]
    class PutGroupProfile
    {
        [Header("Content-Type")]
        public string ContentType { get; set; }

        [Body("id")]
        public string Id { get; set; }

        [Body("name")]
        public string name { get; set; }

        [Body("description")]
        public string description { get; set; }

        [Body("usedByRoles")]
        public List<string> usedByRoles { get; set; }

        [Body("templateRoles")]
        public List<string> templateRoles { get; set; }
    }
}