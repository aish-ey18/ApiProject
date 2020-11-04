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
        LifeCycleMgmtRequestId (from dbo.ProvisionRequests [LifeCycleMgmtRequestId])
 
        Response
        Lifecyle Status (from dbo.ProvisionRequests [Status])
     */
    [RestMethod(Method.GET)]
    [Path("Services/Vsts/GetLifeCycleRequestStatus")]
    class GetLifecycleStatus
    {
        [Body("lifeCycleMgmtRequestId")]
        public string lifeCycleMgmtRequestId { get; set; }
    }
}
