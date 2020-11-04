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
    public class InstanceStatusTests : BaseTest
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

        [TestCase("602213D1-098A-4238-82BB-0064A54EF512", "Ok: Instance Draft")]
        [TestCase("602213D1-098A-4238-82BB-0064A54EF512", "Ok: Instance In Progress")]
        [TestCase("602213D1-098A-4238-82BB-0064A54EF512", "Ok: Instance Submitted")]
        [TestCase("602213D1-098A-4238-82BB-0064A54EF512", "Ok: Instance Provisioning Completed")]
        [TestCase("602213D1-098A-4238-82BB-0064A54EF512", "Ok: Instance Provisioning Failed")]
        public void GetServiceInstanceStatusResultOk(string serviceInstanceId, string expectedResponse)
        {
            GetServiceInstanceStatus request = new GetServiceInstanceStatus();
            request.serviceInstanceId = serviceInstanceId;

            IRestResponse response = RestClient.Create(request);

            Assert.That((int)response.StatusCode, Is.EqualTo(200), "Instance Status endpoint is not working properly");
            JObject responseMessage = JObject.Parse(response.Content);
            Assert.That(responseMessage[0].ToString(), Is.EqualTo(expectedResponse), "Instance Status endpoint is not working properly");
        }

        [TestCase("602213D1", "ServiceRequestID is not valid")]
        [TestCase("", "ServiceRequestID is not valid")]
        [TestCase("DDDDDDDD", "ServiceRequestID is not valid")]
        public void GetServiceInstanceStatusInvalidInstanceId(string serviceInstanceId, string expectedResponse)
        {
            GetServiceInstanceStatus request = new GetServiceInstanceStatus();
            request.serviceInstanceId = serviceInstanceId;

            IRestResponse response = RestClient.Create(request);

            Assert.That((int)response.StatusCode, Is.EqualTo(400), "Instance Status endpoint is not working properly");
            JObject responseMessage = JObject.Parse(response.Content);
            Assert.That(responseMessage["errors"][0].ToString(), Is.EqualTo(expectedResponse), "Instance Status endpoint is not working properly");
        }

        [TestCase("602213D1-098A-4238-82BB-0064A54EF512", "ServiceRequestID does not exist")]
        public void GetServiceInstanceStatusInstanceIdDoesNotExist(string serviceInstanceId, string expectedResponse)
        {
            GetServiceInstanceStatus request = new GetServiceInstanceStatus();
            request.serviceInstanceId = serviceInstanceId;

            IRestResponse response = RestClient.Create(request);

            Assert.That((int)response.StatusCode, Is.EqualTo(404), "Instance Status endpoint is not working properly");
            JObject responseMessage = JObject.Parse(response.Content);
            Assert.That(responseMessage["errors"][0].ToString(), Is.EqualTo(expectedResponse), "Instance Status endpoint is not working properly");
        }
    }
}
