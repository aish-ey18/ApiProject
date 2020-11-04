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
    /*
     * Payload:
        ServiceRequestID (from dbo.ServiceRequests [ID]
 
       Response:
        Service Instance Status (Draft, In Progress, Submitted, Provisioning Completed, Provisioning Failed) (From dbo.ServiceRequests [status])
     */
    [RestMethod(Method.GET)]
    [Path("Services/Vsts/GetServiceInstanceStatus")]
    class GetServiceInstanceStatus
    {
        [Body("serviceInstanceId")]
        public string serviceInstanceId { get; set; }
    }
}
