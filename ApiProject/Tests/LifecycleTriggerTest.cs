using ApiFramework.Api;
using ApiFramework.Api.Catalog;
using ApiFramework.Api.Microsoft;
using ApiFramework.Api.Rootsite.Users;
using ApiFramework.Models;
using ApiFramework.Services;
using ApiFramework.Tests.Common;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serialization.Json;
using System.Collections;
using System.Collections.Generic;

namespace ApiFramework.Tests
{
    public class LifecycleTriggerTests : BaseTest
    {

        [SetUp]
        public void Init()
        {
            RestClient = new RestAdapter(CTP_URL);
            serializer = new RestSerializer();
            //Authorize
            var access_token = "B~9!6RY6}*MFbDlPeNo7bHYLojM4I5xnYNgMe5YIDtJAeocLF";
            RestClient.Authorize(access_token);
        }

        public static IEnumerable<TestCaseData> InputParameterTestData
        {
            get
            {
                yield return new TestCaseData(
                    "agostina.fregossi@gds.ey.com",
                    "QA_PBI_1",
                    new string[] { "agostina.fregossi@gds.ey.com", "alfredo.a.lopez@gds.ey.com" },
                    "Global IT",
                    "My Power BI Test 1",
                    "Power BI Main - [EYGS][QA]",
                    "ussouthcentral",
                    "12345678",
                    "agostina.fregossi@gds.ey.com",
                    "Development",
                    new Dictionary<string, string>(){
                        {"var_PBIAppName" , "Power BI Test \"A1\"" },
                        {"var_CapacitySize", "A1"},
                        {"var_addToPortal", "YES"},
                        {"var_DeploySQLDB", "NO"},
                        {"var_skuName", ""},
                        {"var_dbName", ""},
                        {"var_DeployWebApp", "NO"},
                        {"var_skuCode", ""},
                        {"var_webAppName", ""},
                        {"var_DeployWebAppTemplate", ""},
                        {"var_dataOwnershipPattern", ""},
                        {"var_DeployStorageAccount", "NO"},
                        {"var_storageAccountAccessTier", ""},
                        {"var_DeployDataFactory", ""},
                        {"var_DeployDataLakeStore", ""},
                        {"var_DeployCosmosDb", ""},
                        {"var_defaultExperience", ""},
                        {"var_DeployFromMainOffering", "YES"}
                    });
            }
        }

        public static IEnumerable<TestCaseData> InputParameterTestDataWithEmptyValues
        {
            get
            {
                //Full
                //yield return new TestCaseData( "agostina.fregossi@gds.ey.com", "QA_PBI_1", new string[] { "agostina.fregossi@gds.ey.com", "alfredo.a.lopez@gds.ey.com" },"Global IT","My Power BI Test 1","Power BI Main - [EYGS][QA]","ussouthcentral", "12345678","agostina.fregossi@gds.ey.com","Development",new Dictionary<string, string>(){{"var_PBIAppName" , "Power BI Test \"A1\"" },{"var_CapacitySize", "A1"},{"var_addToPortal", "YES"},{"var_DeploySQLDB", "NO"},{"var_skuName", ""},{"var_dbName", ""},{"var_DeployWebApp", "NO"},{"var_skuCode", ""},{"var_webAppName", ""},{"var_DeployWebAppTemplate", ""},{"var_dataOwnershipPattern", ""},{"var_DeployStorageAccount", "NO"},{"var_storageAccountAccessTier", ""},{"var_DeployDataFactory", ""},{"var_DeployDataLakeStore", ""},{"var_DeployCosmosDb", ""},{"var_defaultExperience", ""},{"var_DeployFromMainOffering", "YES"}});
                //Empty ProyectName
                yield return new TestCaseData( "agostina.fregossi@gds.ey.com", "", new string[] { "agostina.fregossi@gds.ey.com", "alfredo.a.lopez@gds.ey.com" },"Global IT","My Power BI Test 1","Power BI Main - [EYGS][QA]","ussouthcentral", "12345678","agostina.fregossi@gds.ey.com","Development",new Dictionary<string, string>(){{"var_PBIAppName" , "Power BI Test \"A1\"" },{"var_CapacitySize", "A1"},{"var_addToPortal", "YES"},{"var_DeploySQLDB", "NO"},{"var_skuName", ""},{"var_dbName", ""},{"var_DeployWebApp", "NO"},{"var_skuCode", ""},{"var_webAppName", ""},{"var_DeployWebAppTemplate", ""},{"var_dataOwnershipPattern", ""},{"var_DeployStorageAccount", "NO"},{"var_storageAccountAccessTier", ""},{"var_DeployDataFactory", ""},{"var_DeployDataLakeStore", ""},{"var_DeployCosmosDb", ""},{"var_defaultExperience", ""},{"var_DeployFromMainOffering", "YES"}});
                //Empty ServiceInstanceName
                yield return new TestCaseData( "agostina.fregossi@gds.ey.com", "QA_PBI_1", new string[] { "agostina.fregossi@gds.ey.com", "alfredo.a.lopez@gds.ey.com" },"Global IT","","Power BI Main - [EYGS][QA]","ussouthcentral", "12345678","agostina.fregossi@gds.ey.com","Development",new Dictionary<string, string>(){{"var_PBIAppName" , "Power BI Test \"A1\"" },{"var_CapacitySize", "A1"},{"var_addToPortal", "YES"},{"var_DeploySQLDB", "NO"},{"var_skuName", ""},{"var_dbName", ""},{"var_DeployWebApp", "NO"},{"var_skuCode", ""},{"var_webAppName", ""},{"var_DeployWebAppTemplate", ""},{"var_dataOwnershipPattern", ""},{"var_DeployStorageAccount", "NO"},{"var_storageAccountAccessTier", ""},{"var_DeployDataFactory", ""},{"var_DeployDataLakeStore", ""},{"var_DeployCosmosDb", ""},{"var_defaultExperience", ""},{"var_DeployFromMainOffering", "YES"}});
                //Empty OfferingName
                yield return new TestCaseData( "agostina.fregossi@gds.ey.com", "QA_PBI_1", new string[] { "agostina.fregossi@gds.ey.com", "alfredo.a.lopez@gds.ey.com" },"Global IT","My Power BI Test 1","","ussouthcentral", "12345678","agostina.fregossi@gds.ey.com","Development",new Dictionary<string, string>(){{"var_PBIAppName" , "Power BI Test \"A1\"" },{"var_CapacitySize", "A1"},{"var_addToPortal", "YES"},{"var_DeploySQLDB", "NO"},{"var_skuName", ""},{"var_dbName", ""},{"var_DeployWebApp", "NO"},{"var_skuCode", ""},{"var_webAppName", ""},{"var_DeployWebAppTemplate", ""},{"var_dataOwnershipPattern", ""},{"var_DeployStorageAccount", "NO"},{"var_storageAccountAccessTier", ""},{"var_DeployDataFactory", ""},{"var_DeployDataLakeStore", ""},{"var_DeployCosmosDb", ""},{"var_defaultExperience", ""},{"var_DeployFromMainOffering", "YES"}});
                //Empty Location
                yield return new TestCaseData( "agostina.fregossi@gds.ey.com", "QA_PBI_1", new string[] { "agostina.fregossi@gds.ey.com", "alfredo.a.lopez@gds.ey.com" },"Global IT","My Power BI Test 1","Power BI Main - [EYGS][QA]","", "12345678","agostina.fregossi@gds.ey.com","Development",new Dictionary<string, string>(){{"var_PBIAppName" , "Power BI Test \"A1\"" },{"var_CapacitySize", "A1"},{"var_addToPortal", "YES"},{"var_DeploySQLDB", "NO"},{"var_skuName", ""},{"var_dbName", ""},{"var_DeployWebApp", "NO"},{"var_skuCode", ""},{"var_webAppName", ""},{"var_DeployWebAppTemplate", ""},{"var_dataOwnershipPattern", ""},{"var_DeployStorageAccount", "NO"},{"var_storageAccountAccessTier", ""},{"var_DeployDataFactory", ""},{"var_DeployDataLakeStore", ""},{"var_DeployCosmosDb", ""},{"var_defaultExperience", ""},{"var_DeployFromMainOffering", "YES"}});
                //Empty Environment
                yield return new TestCaseData( "agostina.fregossi@gds.ey.com", "QA_PBI_1", new string[] { "agostina.fregossi@gds.ey.com", "alfredo.a.lopez@gds.ey.com" },"Global IT","My Power BI Test 1","Power BI Main - [EYGS][QA]","ussouthcentral", "12345678","agostina.fregossi@gds.ey.com","",new Dictionary<string, string>(){{"var_PBIAppName" , "Power BI Test \"A1\"" },{"var_CapacitySize", "A1"},{"var_addToPortal", "YES"},{"var_DeploySQLDB", "NO"},{"var_skuName", ""},{"var_dbName", ""},{"var_DeployWebApp", "NO"},{"var_skuCode", ""},{"var_webAppName", ""},{"var_DeployWebAppTemplate", ""},{"var_dataOwnershipPattern", ""},{"var_DeployStorageAccount", "NO"},{"var_storageAccountAccessTier", ""},{"var_DeployDataFactory", ""},{"var_DeployDataLakeStore", ""},{"var_DeployCosmosDb", ""},{"var_defaultExperience", ""},{"var_DeployFromMainOffering", "YES"}});
                //Empty Parameters
                yield return new TestCaseData( "agostina.fregossi@gds.ey.com", "QA_PBI_1", new string[] { "agostina.fregossi@gds.ey.com", "alfredo.a.lopez@gds.ey.com" },"Global IT","My Power BI Test 1","Power BI Main - [EYGS][QA]","ussouthcentral", "12345678","agostina.fregossi@gds.ey.com","Development", new Dictionary<string, string>());

            }
        }

        [Test, TestCaseSource("InputParameterTestData")]
        public void PostAutomationTriggerTestResultOk(
            string RequestingUser,
            string ProjectName,
            string[] ProjectTeamMembers,
            string ServiceLine,
            string ServiceInstanceName,
            string OfferingName,
            string Location,
            string EngagementCode,
            string Sponsor,
            string Environment,
            Dictionary<string, string> Parameters)
        {
            PostAutomationTrigger request = new PostAutomationTrigger();
            request.RequestingUser = RequestingUser;
            request.ProjectName = ProjectName;
            request.ProjectTeamMembers = ProjectTeamMembers;
            request.ServiceLine = ServiceLine;
            request.ServiceInstanceName = ServiceInstanceName;
            request.OfferingName = OfferingName;
            request.Location = Location;
            request.EngagementCode = EngagementCode;
            request.Sponsor = Sponsor;
            request.Environment = Environment;
            request.Parameters = Parameters;
            request.ContentType = "application/json";

            IRestResponse response = RestClient.Create(request);

            Assert.That((int)response.StatusCode, Is.EqualTo(200), "Automation Trigger endpoint is not working properly");
        }

        //TC_US_731425_Verify endpoint cannot be reached with different method than POST
        [Test]
        public void GetAutomationTriggerTestResultFail()
        {
            IRestResponse response = RestClient.Create(new GetAutomationTrigger(){
                ContentType = "application/json",
            });

            Assert.That((int)response.StatusCode, Is.EqualTo(405), "Automation Trigger endpoint is not working properly");
        }
        [Test]
        public void PutAutomationTriggerTestResultFail()
        {
            IRestResponse response = RestClient.Create(new PutAutomationTrigger()
            {
                ContentType = "application/json",
            });

            Assert.That((int)response.StatusCode, Is.EqualTo(405), "Automation Trigger endpoint is not working properly");
        }
        [Test]
        public void DeleteAutomationTriggerTestResultFail()
        {
            IRestResponse response = RestClient.Create(new DeleteAutomationTrigger()
            {
                ContentType = "application/json",
            });

            Assert.That((int)response.StatusCode, Is.EqualTo(405), "Automation Trigger endpoint is not working properly");
        }

        //TC_US_731425_Verify endpoint cannot be reached with invalid token
        [Test]
        public void PostAutomationTriggerTestWithoutToken(){
            PostAutomationTrigger request = new PostAutomationTrigger();
            request.RequestingUser = "";
            request.ProjectName = "";
            request.ProjectTeamMembers = new string[] { };
            request.ServiceLine = "";
            request.ServiceInstanceName = "";
            request.OfferingName = "";
            request.Location = "";
            request.EngagementCode = "";
            request.Sponsor = "";
            request.Environment = "";
            request.Parameters = new Dictionary<string, string>() { };
            request.ContentType = "application/json";

            RestAdapter RestClientWithoutToken = new RestAdapter(CTP_URL);
            IRestResponse response = RestClientWithoutToken.Create(request);

            Assert.That((int)response.StatusCode, Is.EqualTo(401), "Automation Trigger endpoint is not working properly");
        }

        //TC_US_731425_Verify offering cannot be instantiated for an existing Project with ProyectName parameter empty
        //TC_US_731425_Verify offering cannot be instantiated for an existing Project with ServiceInstanceName parameter empty
        //TC_US_731425_Verify offering cannot be instantiated for an existing Project with OfferingName parameter empty
        //TC_US_731425_Verify offering cannot be instantiated for an existing Project with Location parameter empty
        //TC_US_731425_Verify offering cannot be instantiated for an existing Project with Enviroment parameter empty
        //TC_US_731425_Verify offering cannot be instantiated for an existing Project with Parameters dictionary empty
        [Test, TestCaseSource("InputParameterTestDataWithEmptyValues")]
        public void PostExistingProjectWithEmptyValues(
            string RequestingUser,
            string ProjectName,
            string[] ProjectTeamMembers,
            string ServiceLine,
            string ServiceInstanceName,
            string OfferingName,
            string Location,
            string EngagementCode,
            string Sponsor,
            string Environment,
            Dictionary<string, string> Parameters)
        {
            PostAutomationTrigger request = new PostAutomationTrigger();
            request.RequestingUser = RequestingUser;
            request.ProjectName = ProjectName;
            request.ProjectTeamMembers = ProjectTeamMembers;
            request.ServiceLine = ServiceLine;
            request.ServiceInstanceName = ServiceInstanceName;
            request.OfferingName = OfferingName;
            request.Location = Location;
            request.EngagementCode = EngagementCode;
            request.Sponsor = Sponsor;
            request.Environment = Environment;
            request.Parameters = Parameters;
            request.ContentType = "application/json";

            IRestResponse response = RestClient.Create(request);

            Assert.That((int)response.StatusCode, Is.EqualTo(400), "Automation Trigger endpoint is not working properly");
        }


        //TC_US_731425_Verify offering cannot be instantiated for an existing Project with unmatching OfferingName
        [Test]
        public void PostExistingProjectWithUnmatchingOfferingName(
            string RequestingUser,
            string ProjectName,
            string[] ProjectTeamMembers,
            string ServiceLine,
            string ServiceInstanceName,
            string OfferingName,
            string Location,
            string EngagementCode,
            string Sponsor,
            string Environment,
            Dictionary<string, string> Parameters)
        {
            PostAutomationTrigger request = new PostAutomationTrigger();
            request.RequestingUser = RequestingUser;
            request.ProjectName = ProjectName;
            request.ProjectTeamMembers = ProjectTeamMembers;
            request.ServiceLine = ServiceLine;
            request.ServiceInstanceName = ServiceInstanceName;
            request.OfferingName = OfferingName;
            request.Location = Location;
            request.EngagementCode = EngagementCode;
            request.Sponsor = Sponsor;
            request.Environment = Environment;
            request.Parameters = Parameters;
            request.ContentType = "application/json";

            IRestResponse response = RestClient.Create(request);

            Assert.That((int)response.StatusCode, Is.EqualTo(200), "Automation Trigger endpoint is not working properly");
        }

        //TC_US_731425_Verify offering cannot be instantiated for an existing Project with parameter ServiceInstanceName missing
        [Test]
        public void PostExistingProjectWithoutServiceInstanceName(
            string RequestingUser,
            string ProjectName,
            string[] ProjectTeamMembers,
            string ServiceLine,
            string ServiceInstanceName,
            string OfferingName,
            string Location,
            string EngagementCode,
            string Sponsor,
            string Environment,
            Dictionary<string, string> Parameters)
        {
            PostAutomationTrigger request = new PostAutomationTrigger();
            request.RequestingUser = RequestingUser;
            request.ProjectName = ProjectName;
            request.ProjectTeamMembers = ProjectTeamMembers;
            request.ServiceLine = ServiceLine;
            request.ServiceInstanceName = ServiceInstanceName;
            request.OfferingName = OfferingName;
            request.Location = Location;
            request.EngagementCode = EngagementCode;
            request.Sponsor = Sponsor;
            request.Environment = Environment;
            request.Parameters = Parameters;
            request.ContentType = "application/json";

            IRestResponse response = RestClient.Create(request);

            Assert.That((int)response.StatusCode, Is.EqualTo(200), "Automation Trigger endpoint is not working properly");
        }

        //TC_US_731425_Verify offering can be instantiated with an existing Project
        [Test]
        public void PostExistingProject(
            string RequestingUser,
            string ProjectName,
            string[] ProjectTeamMembers,
            string ServiceLine,
            string ServiceInstanceName,
            string OfferingName,
            string Location,
            string EngagementCode,
            string Sponsor,
            string Environment,
            Dictionary<string, string> Parameters)
        {
            PostAutomationTrigger request = new PostAutomationTrigger();
            request.RequestingUser = RequestingUser;
            request.ProjectName = ProjectName;
            request.ProjectTeamMembers = ProjectTeamMembers;
            request.ServiceLine = ServiceLine;
            request.ServiceInstanceName = ServiceInstanceName;
            request.OfferingName = OfferingName;
            request.Location = Location;
            request.EngagementCode = EngagementCode;
            request.Sponsor = Sponsor;
            request.Environment = Environment;
            request.Parameters = Parameters;
            request.ContentType = "application/json";

            IRestResponse response = RestClient.Create(request);

            Assert.That((int)response.StatusCode, Is.EqualTo(200), "Automation Trigger endpoint is not working properly");
        }

        //TC_US_731425_Verify offering can be instantiated for an existing Project with all Optionals Parameter empty
        [Test]
        public void PostExistingProjectWithAllOptionalsParametersEmpty(
            string RequestingUser,
            string ProjectName,
            string[] ProjectTeamMembers,
            string ServiceLine,
            string ServiceInstanceName,
            string OfferingName,
            string Location,
            string EngagementCode,
            string Sponsor,
            string Environment,
            Dictionary<string, string> Parameters)
        {
            PostAutomationTrigger request = new PostAutomationTrigger();
            request.RequestingUser = RequestingUser;
            request.ProjectName = ProjectName;
            request.ProjectTeamMembers = ProjectTeamMembers;
            request.ServiceLine = ServiceLine;
            request.ServiceInstanceName = ServiceInstanceName;
            request.OfferingName = OfferingName;
            request.Location = Location;
            request.EngagementCode = EngagementCode;
            request.Sponsor = Sponsor;
            request.Environment = Environment;
            request.Parameters = Parameters;
            request.ContentType = "application/json";

            IRestResponse response = RestClient.Create(request);

            Assert.That((int)response.StatusCode, Is.EqualTo(200), "Automation Trigger endpoint is not working properly");
        }

        //TC_US_731425_Verify offering can be instantiated for an existing Project with ProjectTeamMembers Parameters empty
        [Test]
        public void PostExistingProjectWithProjectTeamMembersEmpty(
            string RequestingUser,
            string ProjectName,
            string[] ProjectTeamMembers,
            string ServiceLine,
            string ServiceInstanceName,
            string OfferingName,
            string Location,
            string EngagementCode,
            string Sponsor,
            string Environment,
            Dictionary<string, string> Parameters)
        {
            PostAutomationTrigger request = new PostAutomationTrigger();
            request.RequestingUser = RequestingUser;
            request.ProjectName = ProjectName;
            request.ProjectTeamMembers = ProjectTeamMembers;
            request.ServiceLine = ServiceLine;
            request.ServiceInstanceName = ServiceInstanceName;
            request.OfferingName = OfferingName;
            request.Location = Location;
            request.EngagementCode = EngagementCode;
            request.Sponsor = Sponsor;
            request.Environment = Environment;
            request.Parameters = Parameters;
            request.ContentType = "application/json";

            IRestResponse response = RestClient.Create(request);

            Assert.That((int)response.StatusCode, Is.EqualTo(200), "Automation Trigger endpoint is not working properly");
        }

        //TC_US_731425_Verify offering can be instantiated for an existing Project with EngagementCode Parameter empty
        [Test]
        public void PostExistingProjectWithEngagementCodeEmpty(
            string RequestingUser,
            string ProjectName,
            string[] ProjectTeamMembers,
            string ServiceLine,
            string ServiceInstanceName,
            string OfferingName,
            string Location,
            string EngagementCode,
            string Sponsor,
            string Environment,
            Dictionary<string, string> Parameters)
        {
            PostAutomationTrigger request = new PostAutomationTrigger();
            request.RequestingUser = RequestingUser;
            request.ProjectName = ProjectName;
            request.ProjectTeamMembers = ProjectTeamMembers;
            request.ServiceLine = ServiceLine;
            request.ServiceInstanceName = ServiceInstanceName;
            request.OfferingName = OfferingName;
            request.Location = Location;
            request.EngagementCode = EngagementCode;
            request.Sponsor = Sponsor;
            request.Environment = Environment;
            request.Parameters = Parameters;
            request.ContentType = "application/json";

            IRestResponse response = RestClient.Create(request);

            Assert.That((int)response.StatusCode, Is.EqualTo(200), "Automation Trigger endpoint is not working properly");
        }

        //TC_US_731425_Verify offering can be instantiated for an existing Project with SponsorEmail Parameter empty
        [Test]
        public void PostExistingProjectWithSponsorEmailEmpty(
            string RequestingUser,
            string ProjectName,
            string[] ProjectTeamMembers,
            string ServiceLine,
            string ServiceInstanceName,
            string OfferingName,
            string Location,
            string EngagementCode,
            string Sponsor,
            string Environment,
            Dictionary<string, string> Parameters)
        {
            PostAutomationTrigger request = new PostAutomationTrigger();
            request.RequestingUser = RequestingUser;
            request.ProjectName = ProjectName;
            request.ProjectTeamMembers = ProjectTeamMembers;
            request.ServiceLine = ServiceLine;
            request.ServiceInstanceName = ServiceInstanceName;
            request.OfferingName = OfferingName;
            request.Location = Location;
            request.EngagementCode = EngagementCode;
            request.Sponsor = Sponsor;
            request.Environment = Environment;
            request.Parameters = Parameters;
            request.ContentType = "application/json";

            IRestResponse response = RestClient.Create(request);

            Assert.That((int)response.StatusCode, Is.EqualTo(200), "Automation Trigger endpoint is not working properly");
        }

        //TC_US_731425_Verify offering can be instantiated for an existing Project with ServiceLine Parameter empty
        [Test]
        public void PostExistingProjectWithServiceLineEmpty(
            string RequestingUser,
            string ProjectName,
            string[] ProjectTeamMembers,
            string ServiceLine,
            string ServiceInstanceName,
            string OfferingName,
            string Location,
            string EngagementCode,
            string Sponsor,
            string Environment,
            Dictionary<string, string> Parameters)
        {
            PostAutomationTrigger request = new PostAutomationTrigger();
            request.RequestingUser = RequestingUser;
            request.ProjectName = ProjectName;
            request.ProjectTeamMembers = ProjectTeamMembers;
            request.ServiceLine = ServiceLine;
            request.ServiceInstanceName = ServiceInstanceName;
            request.OfferingName = OfferingName;
            request.Location = Location;
            request.EngagementCode = EngagementCode;
            request.Sponsor = Sponsor;
            request.Environment = Environment;
            request.Parameters = Parameters;
            request.ContentType = "application/json";

            IRestResponse response = RestClient.Create(request);

            Assert.That((int)response.StatusCode, Is.EqualTo(200), "Automation Trigger endpoint is not working properly");
        }

        //TC_US_731425_Verify offering can be instantiated for an existing Project with any optional Parameter and no matching value
        [Test]
        public void PostExistingProjectWithAnyOptionalParameterAndNoMatchingValue(
            string RequestingUser,
            string ProjectName,
            string[] ProjectTeamMembers,
            string ServiceLine,
            string ServiceInstanceName,
            string OfferingName,
            string Location,
            string EngagementCode,
            string Sponsor,
            string Environment,
            Dictionary<string, string> Parameters)
        {
            PostAutomationTrigger request = new PostAutomationTrigger();
            request.RequestingUser = RequestingUser;
            request.ProjectName = ProjectName;
            request.ProjectTeamMembers = ProjectTeamMembers;
            request.ServiceLine = ServiceLine;
            request.ServiceInstanceName = ServiceInstanceName;
            request.OfferingName = OfferingName;
            request.Location = Location;
            request.EngagementCode = EngagementCode;
            request.Sponsor = Sponsor;
            request.Environment = Environment;
            request.Parameters = Parameters;
            request.ContentType = "application/json";

            IRestResponse response = RestClient.Create(request);

            Assert.That((int)response.StatusCode, Is.EqualTo(200), "Automation Trigger endpoint is not working properly");
        }

        //TC_US_731425_Verify offering can be instantiated with a non existing Project
        [Test]
        public void PostNonExistingProjectResultOk(
            string RequestingUser,
            string ProjectName,
            string[] ProjectTeamMembers,
            string ServiceLine,
            string ServiceInstanceName,
            string OfferingName,
            string Location,
            string EngagementCode,
            string Sponsor,
            string Environment,
            Dictionary<string, string> Parameters)
        {
            PostAutomationTrigger request = new PostAutomationTrigger();
            request.RequestingUser = RequestingUser;
            request.ProjectName = ProjectName;
            request.ProjectTeamMembers = ProjectTeamMembers;
            request.ServiceLine = ServiceLine;
            request.ServiceInstanceName = ServiceInstanceName;
            request.OfferingName = OfferingName;
            request.Location = Location;
            request.EngagementCode = EngagementCode;
            request.Sponsor = Sponsor;
            request.Environment = Environment;
            request.Parameters = Parameters;
            request.ContentType = "application/json";

            IRestResponse response = RestClient.Create(request);

            Assert.That((int)response.StatusCode, Is.EqualTo(200), "Automation Trigger endpoint is not working properly");
        }

        //TC_US_731425_Verify Parameter ProjectTeamMembers is mandatory when instatiating for a new Project
        [Test]
        public void PostNewProjectVerifyProjectTeamMembersIsMandatory(
            string RequestingUser,
            string ProjectName,
            string[] ProjectTeamMembers,
            string ServiceLine,
            string ServiceInstanceName,
            string OfferingName,
            string Location,
            string EngagementCode,
            string Sponsor,
            string Environment,
            Dictionary<string, string> Parameters)
        {
            PostAutomationTrigger request = new PostAutomationTrigger();
            request.RequestingUser = RequestingUser;
            request.ProjectName = ProjectName;
            request.ProjectTeamMembers = ProjectTeamMembers;
            request.ServiceLine = ServiceLine;
            request.ServiceInstanceName = ServiceInstanceName;
            request.OfferingName = OfferingName;
            request.Location = Location;
            request.EngagementCode = EngagementCode;
            request.Sponsor = Sponsor;
            request.Environment = Environment;
            request.Parameters = Parameters;
            request.ContentType = "application/json";

            IRestResponse response = RestClient.Create(request);

            Assert.That((int)response.StatusCode, Is.EqualTo(200), "Automation Trigger endpoint is not working properly");
        }

        //TC_US_731425_Verify Parameter EngagementCode is mandatory when instatiating for a new Project
        [Test]
        public void PostNewProjectVerifyEngagementCodeIsMandatory(
            string RequestingUser,
            string ProjectName,
            string[] ProjectTeamMembers,
            string ServiceLine,
            string ServiceInstanceName,
            string OfferingName,
            string Location,
            string EngagementCode,
            string Sponsor,
            string Environment,
            Dictionary<string, string> Parameters)
        {
            PostAutomationTrigger request = new PostAutomationTrigger();
            request.RequestingUser = RequestingUser;
            request.ProjectName = ProjectName;
            request.ProjectTeamMembers = ProjectTeamMembers;
            request.ServiceLine = ServiceLine;
            request.ServiceInstanceName = ServiceInstanceName;
            request.OfferingName = OfferingName;
            request.Location = Location;
            request.EngagementCode = EngagementCode;
            request.Sponsor = Sponsor;
            request.Environment = Environment;
            request.Parameters = Parameters;
            request.ContentType = "application/json";

            IRestResponse response = RestClient.Create(request);

            Assert.That((int)response.StatusCode, Is.EqualTo(200), "Automation Trigger endpoint is not working properly");
        }

        //TC_US_731425_Verify Parameter SponsorEmail is mandatory when instatiating for a new Project
        [Test]
        public void PostNewProjectVerifySponsorEmailIsMandatory(
            string RequestingUser,
            string ProjectName,
            string[] ProjectTeamMembers,
            string ServiceLine,
            string ServiceInstanceName,
            string OfferingName,
            string Location,
            string EngagementCode,
            string Sponsor,
            string Environment,
            Dictionary<string, string> Parameters)
        {
            PostAutomationTrigger request = new PostAutomationTrigger();
            request.RequestingUser = RequestingUser;
            request.ProjectName = ProjectName;
            request.ProjectTeamMembers = ProjectTeamMembers;
            request.ServiceLine = ServiceLine;
            request.ServiceInstanceName = ServiceInstanceName;
            request.OfferingName = OfferingName;
            request.Location = Location;
            request.EngagementCode = EngagementCode;
            request.Sponsor = Sponsor;
            request.Environment = Environment;
            request.Parameters = Parameters;
            request.ContentType = "application/json";

            IRestResponse response = RestClient.Create(request);

            Assert.That((int)response.StatusCode, Is.EqualTo(200), "Automation Trigger endpoint is not working properly");
        }

        //TC_US_731425_Verify Parameter ServiceLine is mandatory when instatiating for a new Project
        [Test]
        public void PostNewProjectVerifyServiceLineIsMandatory(
            string RequestingUser,
            string ProjectName,
            string[] ProjectTeamMembers,
            string ServiceLine,
            string ServiceInstanceName,
            string OfferingName,
            string Location,
            string EngagementCode,
            string Sponsor,
            string Environment,
            Dictionary<string, string> Parameters)
        {
            PostAutomationTrigger request = new PostAutomationTrigger();
            request.RequestingUser = RequestingUser;
            request.ProjectName = ProjectName;
            request.ProjectTeamMembers = ProjectTeamMembers;
            request.ServiceLine = ServiceLine;
            request.ServiceInstanceName = ServiceInstanceName;
            request.OfferingName = OfferingName;
            request.Location = Location;
            request.EngagementCode = EngagementCode;
            request.Sponsor = Sponsor;
            request.Environment = Environment;
            request.Parameters = Parameters;
            request.ContentType = "application/json";

            IRestResponse response = RestClient.Create(request);

            Assert.That((int)response.StatusCode, Is.EqualTo(200), "Automation Trigger endpoint is not working properly");
        }
    }
}
