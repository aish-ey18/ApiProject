using ApiFramework.Services.Attributes.Methods;
using ApiFramework.Services.Attributes.Parameters;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiFramework.Api.Rootsite.Roles
{
    [RestMethod(Method.GET)]
    [Path("api/v1/Role/GetAll")]
    class GetAllRoles
    {

    }

    [RestMethod(Method.GET)]
    [Path("api/v1/Role")]
    class GetRole
    {
        [Body("pageNumber")]
        public int pageNumber { get; set; }

        [Body("pageSize")]
        public int pageSize { get; set; }
    }

    [RestMethod(Method.POST)]
    [Path("api/v1/Role")]
    class PostRole
    {
        [Header("Content-Type")]
        public string ContentType { get; set; }

        [Body("id")]
        public string Id { get; set; }

        [Body("name")]
        public string name { get; set; }

        [Body("isActionRole")]
        public bool isActionRole { get; set; }

        [Body("description")]
        public string description { get; set; }

        [Body("enabled")]
        public bool enabled { get; set; }

        [Body("actions")]
        public List<string> actions { get; set; }
    }

    [RestMethod(Method.PUT)]
    [Path("api/v1/Role")]
    class PutRole
    {
        [Header("Content-Type")]
        public string ContentType { get; set; }

        [Body("id")]
        public string Id { get; set; }

        [Body("name")]
        public string name { get; set; }

        [Body("isActionRole")]
        public bool isActionRole { get; set; }

        [Body("description")]
        public string description { get; set; }

        [Body("enabled")]
        public bool enabled { get; set; }

        [Body("actions")]
        public List<string> actions { get; set; }
    }

    [RestMethod(Method.GET)]
    [Path("api/v1/Role/{id}")]
    class GetRoleById
    {
        [Path("id")]
        public string Id { get; set; }
    }

    [RestMethod(Method.GET)]
    [Path("api/v1/Role/Validate")]
    class GetRoleValidation
    {
        [Body("roleName")]
        public string roleName { get; set; }
    }
}