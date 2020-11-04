using ApiFramework.Services.Attributes.Methods;
using ApiFramework.Services.Attributes.Parameters;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiFramework.Api.EYDX_Discussion
{
    [RestMethod(Method.POST)]
    [Path("api/v1/discussions?userEmail=aishwarya.gupta4@in.ey.com")]
    class PostDiscussion
    {
        [Header("Content-Type")]
        public string ContentType { get; set; }

        [Header("EYDX-DISCUSSIONS-SERVICE-API-KEY")]
        public string ServiceKey { get; set; }

        //[Header("Authorization")]
        //public string authorization { get; set; }

        [Body("application/json")]
        public string body { get; set; }


        //[Body("title")]
        //public string title { get; set; }


        //[Body("tags")]
        //public string[] tags { get; set; }

    }

    [RestMethod(Method.PUT)]
    [Path("api/v1/discussions/{discussionGuid}?userEmail=aishwarya.gupta4@in.ey.com")]
    class PutDiscussion
    {
        [Path("discussionGuid")]
        public string DiscussionGuid { get; set; }

        [Header("Content-Type")]
        public string ContentType { get; set; }

        [Header("EYDX-DISCUSSIONS-SERVICE-API-KEY")]
        public string ServiceKey { get; set; }

        [Body("application/json")]
        public string body { get; set; }
    }

    [RestMethod(Method.GET)]
    [Path("api/v1/discussions?userEmail=aishwarya.gupta4@in.ey.com")]
    class GetDiscussion
    {
        [Header("EYDX-DISCUSSIONS-SERVICE-API-KEY")]
        public string ServiceKey { get; set; }
    }

    [RestMethod(Method.GET)]
    [Path("api/v1/discussions/{discussionGuid}?userEmail=aishwarya.gupta4@in.ey.com")]
    class GetDiscussionByID
    {
        [Path("discussionGuid")]
        public string DiscussionGuid { get; set; }

        [Header("EYDX-DISCUSSIONS-SERVICE-API-KEY")]
        public string ServiceKey { get; set; }
    }

    [RestMethod(Method.PATCH)]
    [Path("api/v1/discussions/{discussionGuid}?userEmail=aishwarya.gupta4@in.ey.com&isEditable={isEditable}&isHidden={isHidden}")]
    class PatchDiscussion
    {
        [Path("discussionGuid")]
        public string DiscussionGuid { get; set; }

        [Path("isEditable")]
        public Boolean isEditableFlag { get; set; }

        [Path("isHidden")]
        public Boolean isHiddenFlag { get; set; }

        [Header("EYDX-DISCUSSIONS-SERVICE-API-KEY")]
        public string ServiceKey { get; set; }
    }

    [RestMethod(Method.DELETE)]
    [Path("api/v1/discussions/{discussionGuid}?userEmail=aishwarya.gupta4@in.ey.com")]
    class DeleteDiscussion
    {
        [Path("discussionGuid")]
        public string DiscussionGuid { get; set; }

        [Header("EYDX-DISCUSSIONS-SERVICE-API-KEY")]
        public string ServiceKey { get; set; }
    }



}
