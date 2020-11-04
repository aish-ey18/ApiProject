using ApiFramework.Services.Attributes.Methods;
using ApiFramework.Services.Attributes.Parameters;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiFramework.Api.Rootsite.Groups
{
    [RestMethod(Method.GET)]
    [Path("api/v1/Group")]
    class GetGroup
    {
        [Body("pageNumber")]
        public int pageNumber { get; set; }

        [Body("pageSize")]
        public int pageSize { get; set; }
    }

    [RestMethod(Method.POST)]
    [Path("api/v1/Group")]
    class PostGroup
    {
        [Header("Content-Type")]
        public string ContentType { get; set; }

        [Body("id")]
        public string Id { get; set; }

        [Body("groupName")]
        public string groupName { get; set; }

        [Body("description")]
        public string description { get; set; }

        [Body("actionTemplateId")]
        public string actionTemplateId { get; set; }

        [Body("userRoles")]
        public List<string> userRoles { get; set; }

        [Body("ownerId")]
        public string ownerId { get; set; }
    }

    [RestMethod(Method.PUT)]
    [Path("api/v1/Group")]
    class PutGroup
    {
        [Header("Content-Type")]
        public string ContentType { get; set; }

        [Body("id")]
        public string Id { get; set; }

        [Body("groupName")]
        public string groupName { get; set; }

        [Body("description")]
        public string description { get; set; }

        [Body("actionTemplateId")]
        public string actionTemplateId { get; set; }

        [Body("userRoles")]
        public List<string> userRoles { get; set; }

        [Body("ownerId")]
        public string ownerId { get; set; }
    }

    [RestMethod(Method.GET)]
    [Path("api/v1/Group/Validate")]
    class GetGroupValidation
    {
        [Body("groupName")]
        public string groupName { get; set; }
    }

    [RestMethod(Method.DELETE)]
    [Path("api/v1/Group/{id}")]
    class DeleteGroupById
    {
        [Path("id")]
        public string Id { get; set; }
    }

    [RestMethod(Method.GET)]
    [Path("api/v1/Group/{id}")]
    class GetGroupById
    {
        [Path("id")]
        public string Id { get; set; }
    }

}