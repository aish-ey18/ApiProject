using ApiFramework.Services.Attributes.Methods;
using ApiFramework.Services.Attributes.Parameters;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiFramework.Api.Catalog
{
    [RestMethod(Method.POST)]
    [Path("Services/Vsts/TriggerServiceInstance")]
    class PostAutomationTrigger
    {
        [Header("Content-Type")]
        public string ContentType { get; set; }

        [Body("RequestingUser")]
        public string RequestingUser { get; set; }

        [Body("ProjectName")]
        public string ProjectName { get; set; }
        
        [Body("ProjectTeamMembers")]
        public string[] ProjectTeamMembers { get; set; }
        
        [Body("EngagementCode")]
        public string EngagementCode { get; set; }

        [Body("Sponsor")]
        public string Sponsor { get; set; }

        [Body("ServiceLine")]
        public string ServiceLine { get; set; }

        [Body("ServiceInstanceName")]
        public string ServiceInstanceName { get; set; }

        [Body("OfferingName")]
        public string OfferingName { get; set; }

        [Body("Location")]
        public string Location { get; set; }

        [Body("Environment")]
        public string Environment { get; set; }

        [Body("Parameters")]
        public Dictionary<string,string> Parameters { get; set; }
    }

    [RestMethod(Method.GET)]
    [Path("Services/Vsts/TriggerServiceInstance")]
    class GetAutomationTrigger
    {
        [Header("Content-Type")]
        public string ContentType { get; set; }
    }

    [RestMethod(Method.PUT)]
    [Path("Services/Vsts/TriggerServiceInstance")]
    class PutAutomationTrigger
    {
        [Header("Content-Type")]
        public string ContentType { get; set; }
    }

    [RestMethod(Method.DELETE)]
    [Path("Services/Vsts/TriggerServiceInstance")]
    class DeleteAutomationTrigger
    {
        [Header("Content-Type")]
        public string ContentType { get; set; }
    }
}
