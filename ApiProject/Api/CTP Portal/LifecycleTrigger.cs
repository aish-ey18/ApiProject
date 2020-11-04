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
     Payload:
        Offering Name
        LifecycleControlName
        DeploymentID
        Defined parameters for lifecycle control

    Response:
        Trigger Lifecycle Control 
      Messages:
        1) Happy Path 
         "Ok. Lifecycle currently running. ID from dbo.Svclifecyclemgmtrequests [ID]"
        2) Failure Scenarios 
        No Offering Name exists: "Error: No Offering exists under provided name"
        No lifecycle control exists within Offering Name: "Error:  No lifecycle controls exists with provided name under selected Offering"
        DID does not exist: "Error: DID not registered in CT Portal"
        DID not related to Offering : "Error:  DID is related to a different offering than the one provided"
        DID under different version, lifecycle non-existing: "Error:  Lifecycle control does not exist under offering version associated to DID"
        DID is different status than ProvisioningCompleted: "Error:  DID is not elligible to perform this lifecycle action"
        Missing Parameters from lifecycle defined form : "Error:  Parameter XXXXX missing from mandatory requirements"
        Parameter data type validation: "Error:  Parameter XXXXX data type does not match with provided values"
    */
    [RestMethod(Method.POST)]
    [Path("Services/Vsts/TriggerServiceInstance")]
    class PostLifeCycleTrigger
    {
        [Header("Content-Type")]
        public string ContentType { get; set; }

        [Body("OfferingName")]
        public string OfferingName { get; set; }

        [Body("LifecycleControlName")]
        public string LifecycleControlName { get; set; }

        [Body("Parameters")]
        public Dictionary<string, string> Parameters { get; set; }
    }
}
