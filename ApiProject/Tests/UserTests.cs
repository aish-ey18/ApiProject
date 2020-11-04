using ApiFramework.Api;
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
using System.Collections.Generic;
using System.Net;

namespace ApiFramework.Tests
{
    public class UserTests : BaseTest
    {

        [SetUp]
        public void Init()
        {
            RestClient = new RestAdapter(ROOTSITE_URL);
            serializer = new RestSerializer();
            //Authorize
            var access_token = "eyJhbGciOiJSUzI1NiIsImtpZCI6Inh1ak16em5rdmFjWEg1Zmx5NVRCd2ciLCJ0eXAiOiJhdCtqd3QifQ.eyJuYmYiOjE2MDI2MjQzOTAsImV4cCI6MTYwMjYzMTU5MCwiaXNzIjoiaHR0cHM6Ly9pZGVudGl0eS1xYS5jdHAuZXkuY29tIiwiYXVkIjoicmJhYyIsImNsaWVudF9pZCI6IkdhaWEtUUEiLCJzdWIiOiJlajhIQ1lEeXhXUkZkckZDS0kwbmhycWQ0UEthbTlRTWl0MzQ3RHRnaVVJIiwiYXV0aF90aW1lIjoxNjAyNTk0OTU2LCJpZHAiOiJhYWQiLCJuYW1lIjoiSnVhbiBQZXJleXJhIiwicHJlZmVycmVkX3VzZXJuYW1lIjoiSnVhbi5QZXJleXJhQGV5LmNvbSIsImludGVybmFsX2lkIjoiNzBlMzVkOWUtMDEzNC00NDcyLTgxYzQtY2MxNWE4NzcxMzFmIiwic2NvcGUiOlsib3BlbmlkIiwicHJvZmlsZSIsImVwbXAiLCJyYmFjIl0sImFtciI6WyJleHRlcm5hbCJdfQ.Qhh13cZBqgCIVf-05N4FhhXfVEmF4xXG8QDWwuX5KzvAIHY94Di7TqFzqs6ltoAKyqGC1jNAq9RCG_w_iW0-t70p9lCvNhw33soKZsQvmrwSoP5OvNXcKxSfDL0ZPByBY3BM9-iK984FUO9LHPMLAFGEtlGq6IceNj-xozirBx0j8ncwXyQwUTZwZMgAFRjXq0aStAmxYFFTdaXIImsQc5aOyeMvNAKshY65ZEWp32RVP4xJJDtLtR1oB9Y8Ek0aMhe5gz0Sag8ayYm6gaazlEwzwWt7TAFOTiL_9BuQ3G7QqlIJABY4DUIyhhk41_IbNsJ1FQtyPLC3AUxvQOOnPg";
            RestClient.Authorize(access_token);
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
        }

        [Test]
        [Category("PipelineTest")]
        public void CheckHealthRootsite()
        {
            IRestResponse response = RestClient.Create(new Health());

            Assert.That((int)response.StatusCode, Is.EqualTo(200), "Rootsite is not Up");
            Assert.That(response.Content, Is.EqualTo("Healthy"), "Rootsite is not Up");
        }

        [Test]
        [Category("PipelineTest")]
        public void PostUsersWithoutRequiredParameters()
        {
            IRestResponse response = RestClient.Create(new PostUser() {
                ContentType = "application/json",
            });

            Assert.That((int)response.StatusCode, Is.EqualTo(400), "Rootsite is registering users without required parameters");
        }

        [Test]
        [Category("PipelineTest")]
        public void GetUsersWithRequiredParameters()
        {
            IRestResponse response = RestClient.Create(new GetUser() { 
                pageNumber = 1,
                pageSize = 20
            });

            Assert.That((int)response.StatusCode, Is.EqualTo(200), "Rootsite is not accepting requests without required parameters");
        }

        [Test]
        [Category("PipelineTest")]
        public void GetUsersWithOutRequiredParameters()
        {
            IRestResponse response = RestClient.Create(new GetUser());

            Assert.That((int)response.StatusCode, Is.EqualTo(400), "Rootsite is accepting requests without required parameters");
        }

        [Test]
        [Category("PipelineTest")]
        public void GetUsersSearchingInAd()
        {
            IRestResponse response = RestClient.Create(new GetUsersSearch()
            {
                searchTerm = "cris",
                limit = 5
            });

            Assert.That((int)response.StatusCode, Is.EqualTo(200), "Rootsite is not searching users in ad");
        }

        [Test]
        [Category("PipelineTest")]
        public void GetUsersSearchingInAdWithoutRequiredParameters()
        {
            IRestResponse response = RestClient.Create(new GetUsersSearch()
            {
                searchTerm = "",
                limit = 5
            });

            JObject responseMessage = JObject.Parse(response.Content);
            Assert.That((int)response.StatusCode, Is.EqualTo(400), "Rootsite is searching users in ad without required parameters");
            Assert.That(responseMessage["errors"]["SearchTerm"][0].ToString(), Is.EqualTo("The SearchTerm field is required."), "Rootsite is searching users in ad without required parameters");
        }

        [Test]
        [Category("PipelineTest")]
        public void GetUsersById()
        {
            IRestResponse response = RestClient.Create(new GetUserById()
            {
                Id = "d7dcd994-3770-4723-9f91-eda1b3d5c6e4"
            });

            Assert.That((int)response.StatusCode, Is.EqualTo(200), "Rootsite is not accepting requests without required parameters");
        }

        [Test]
        [Category("PipelineTest")]
        public void GetUsersByIdUsingInvalidId()
        {
            IRestResponse response = RestClient.Create(new GetUserById()
            {
                Id = "d7dcd994"
            });

            Assert.That((int)response.StatusCode, Is.EqualTo(400), "Rootsite is accepting requests with invalid parameters");
            JObject responseMessage = JObject.Parse(response.Content);
            Assert.That(responseMessage["errors"]["id"][0].ToString(), Is.EqualTo("The value 'd7dcd994' is not valid."), "Rootsite is not accepting requests without required parameters");
        }
    }
}
