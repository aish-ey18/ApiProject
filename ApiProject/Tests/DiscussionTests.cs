using ApiFramework.Api;
using ApiFramework.Api.EYDX_Discussion;
using ApiFramework.Api.Microsoft;
using ApiFramework.Api.Rootsite.Users;
using ApiFramework.Models;
using ApiFramework.Services;
using ApiFramework.Databases.MongoDB;
using ApiFramework.Tests.Common;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace ApiFramework.Tests
{

    class DiscussionTests : BaseTest
    {
        public static String DiscussionGuid;

        [SetUp]
        public void Init()
        {
            RestClient = new RestAdapter(EYDX_URL);

            //Authorize
            var access_token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6Im5PbzNaRHJPRFhFSzFqS1doWHNsSFJfS1hFZyIsImtpZCI6Im5PbzNaRHJPRFhFSzFqS1doWHNsSFJfS1hFZyJ9.eyJhdWQiOiI2ZTg4NDcxYy1mYjVkLTQ2ZWMtODFmOS02MmYzZGFhOTM1NTgiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC81Yjk3M2Y5OS03N2RmLTRiZWItYjI3ZC1hYTBjNzBiODQ4MmMvIiwiaWF0IjoxNjEyMTczNjkxLCJuYmYiOjE2MTIxNzM2OTEsImV4cCI6MTYxMjE3NzU5MSwiYWlvIjoiQVVRQXUvOFRBQUFBVzUxY0g3NmVVaEx5UVgzL25lRkhqRmN4d2xhRHFJZWt3WWVVWllhUGJ2d0RreUZZK1pkaGUyMlBkak51Qld3Nm16YmRINDNkRXl1d0hoK1V1RkUrQ0E9PSIsImFtciI6WyJwd2QiLCJyc2EiXSwiZmFtaWx5X25hbWUiOiJHdXB0YSIsImdpdmVuX25hbWUiOiJBaXNod2FyeWEiLCJpcGFkZHIiOiIyMjMuMjM2LjEwNi4xODciLCJuYW1lIjoiQWlzaHdhcnlhIEd1cHRhIiwibm9uY2UiOiJlYjdhY2M0MC01NmRjLTQwZjctYTIwZi0zOWJlMDhjOTUyZmQiLCJvaWQiOiIzMmE2YmMzYy1jNjNhLTQ5MDUtYmMzMy04YjM5ODFmMTVmZWUiLCJvbnByZW1fc2lkIjoiUy0xLTUtMjEtMzgxNDQ0OTgxNi0xMTQ3NDE0NzQ0LTMyODcxMjYyNDUtNjM1NDIyIiwicmgiOiIwLkFTRUFtVC1YVzk5MzYwdXlmYW9NY0xoSUxCeEhpRzVkLS14R2dmbGk4OXFwTlZnaEFMUS4iLCJzdWIiOiJQN3Zlc21pWW1Lems5T19RZDFQX2VqZ25vOHpvVnozeVRfcHV1dzRPYTBVIiwidGlkIjoiNWI5NzNmOTktNzdkZi00YmViLWIyN2QtYWEwYzcwYjg0ODJjIiwidW5pcXVlX25hbWUiOiJBaXNod2FyeWEuR3VwdGE0QGV5LmNvbSIsInVwbiI6IkFpc2h3YXJ5YS5HdXB0YTRAZXkuY29tIiwidXRpIjoib3hCM2l0czdMVVNRR1hSU1hqWkpBQSIsInZlciI6IjEuMCJ9.BF6RbbHfKlcZFuAB94fKFldcIv3HjPoZMvfkxaFVQkPIe62y1UyxNCn7O1vA6MGvcXWJr3nNivNkwGuAQWblph3TQTFGXg2zQPWWLBW-GVY3Ds3RUnIMpZNWOSkZtq_vSrL9SpQm9yVVdWgxgCgNiv179WshUHe5ObRql5gsOg0RfdcsHkS228xZndNUI-UARQaDlEFXVNZAFMl-CY4Mg6vMD6_S9uNV3kCbK_IUx_9svAmVNzDqm9edve_P4w2EdR2SfzuPYtcO6g-3OTafXfk6Xj7Y60wqAoCEMSNe4Tg1hQVsMOjkURu9pS2K04ov6m6eHf-hG592cIy5SyuVgQ";
            RestClient.Authorize(access_token);
        }

        [Test, Order(1)]
        [Category("Regression")]
        public void Postdiscussion()
        {
            var postdis = new PostDiscussion()
            {
                ContentType = "application/json",
                body = "{\r\n  \"body\": \"question from c# framework testing\",\r\n  \"tags\": [\r\n    \"277ece61-2cee-4291-900f-efa16d6880e5\"\r\n  ],\r\n  \"title\": \"Testing the c# framework automation........\"\r\n}",
                ServiceKey = "ZGlzY3Vzc2lvbiBzZXJ2aWNlIHRva2Vu",
            };

            IRestResponse response = RestClient.Create(postdis);
            JObject responseMessage = JObject.Parse(response.Content);
            DiscussionGuid = responseMessage.GetValue("guid").Value<string>();

            Assert.That((int)response.StatusCode, Is.EqualTo(201), "Error occurred in request");
            MongoDBHelper mongo = new MongoDBHelper();
            var record = mongo.SelectDB("mongodb://usedpateydcdb02:IaGQOv47eWhlNd7x5Ecxn5sWx4pbSHDHpImVlDIINyDYnlVGB2IfRvX2vjNUevEANQGmOnCjuawSH6NRQg7qyw==@usedpateydcdb02.documents.azure.com:10255/?ssl=true&replicaSet=globaldb", "eydx", "discussion", "guid", DiscussionGuid);
            Assert.IsNotNull(record);
        }

        [Test, Order(4)]
        [Category("Regression")]
        public void Putdiscussion()
        {
            Console.WriteLine(DiscussionGuid);
            var putdis = new PutDiscussion()
            {
                ContentType = "application/json",
                body = "{\r\n  \"body\": \"question from c# framework testing-Updated\",\r\n  \"tags\": [\r\n    \"277ece61-2cee-4291-900f-efa16d6880e5\"\r\n  ],\r\n  \"title\": \"Testing the c# framework automation-Updated........\"\r\n}",
                ServiceKey = "ZGlzY3Vzc2lvbiBzZXJ2aWNlIHRva2Vu",
                DiscussionGuid = DiscussionGuid
            };

            IRestResponse response = RestClient.Create(putdis);
            //JObject responseMessage = JObject.Parse(response.Content);
            DiscussionGuid = putdis.DiscussionGuid;

            Assert.That((int)response.StatusCode, Is.EqualTo(201), "Error occurred in request");
            MongoDBHelper mongo = new MongoDBHelper();
            var record = mongo.SelectDB("mongodb://usedpateydcdb02:IaGQOv47eWhlNd7x5Ecxn5sWx4pbSHDHpImVlDIINyDYnlVGB2IfRvX2vjNUevEANQGmOnCjuawSH6NRQg7qyw==@usedpateydcdb02.documents.azure.com:10255/?ssl=true&replicaSet=globaldb", "eydx", "discussion", "guid", DiscussionGuid);
            var modifiedBy = record.GetValue("modifiedBy");
            var userEmail = modifiedBy["userEmail"].AsString;
            Assert.That(userEmail, Is.EqualTo("aboli.kulkarni@ey.com"), "Error occurred in request");
            Console.WriteLine("Record updated");
        }


        [Test, Order(2)]
        [Category("Regression")]
        public void GetDiscussion()
        {
            var getdis = new GetDiscussion()
            {
                ServiceKey = "ZGlzY3Vzc2lvbiBzZXJ2aWNlIHRva2Vu"
            };

            IRestResponse response = RestClient.Create(getdis);
            Console.WriteLine(response.Content);
            Assert.That((int)response.StatusCode, Is.EqualTo(200), "Error occurred in request");
        }

        [Test, Order(3)]
        [Category("Regression")]
        public void GetDiscussionById()
        {
            var getdisById = new GetDiscussionByID()
            {
                ServiceKey = "ZGlzY3Vzc2lvbiBzZXJ2aWNlIHRva2Vu",
                DiscussionGuid = DiscussionGuid
            };

            IRestResponse response = RestClient.Create(getdisById);
            Console.WriteLine(response.Content);
            Assert.That((int)response.StatusCode, Is.EqualTo(200), "Error occurred in request");
        }

        [Test, Order(5)]
        [Category("Regression")]
        public void PatchDiscussion()
        {
            var patchdis = new PatchDiscussion()
            {
                ServiceKey = "ZGlzY3Vzc2lvbiBzZXJ2aWNlIHRva2Vu",
                DiscussionGuid = DiscussionGuid,
                isEditableFlag = true,
                isHiddenFlag = false
            };

            IRestResponse response = RestClient.Create(patchdis);
            var discussionGuid = patchdis.DiscussionGuid;
            Assert.That((int)response.StatusCode, Is.EqualTo(201), "Error occurred in request");

            MongoDBHelper mongo = new MongoDBHelper();
            var record = mongo.SelectDB("mongodb://usedpateydcdb02:IaGQOv47eWhlNd7x5Ecxn5sWx4pbSHDHpImVlDIINyDYnlVGB2IfRvX2vjNUevEANQGmOnCjuawSH6NRQg7qyw==@usedpateydcdb02.documents.azure.com:10255/?ssl=true&replicaSet=globaldb", "eydx", "discussion", "guid", discussionGuid);
            var editableFlag = record.GetValue("editable").AsBoolean;
            var hiddenFlag = record.GetValue("hidden").AsBoolean;

            Assert.That(editableFlag, Is.True, "Error occurred in request");
            Assert.That(hiddenFlag, Is.False, "Error occurred in request");
            Console.WriteLine("Record patched");

        }

        [Test, Order(6)]
        [Category("Regression")]
        public void DeleteDiscussion()
        {
            var deletedis = new DeleteDiscussion()
            {
                ServiceKey = "ZGlzY3Vzc2lvbiBzZXJ2aWNlIHRva2Vu",
                DiscussionGuid = DiscussionGuid
            };

            IRestResponse response = RestClient.Create(deletedis);
            var discussionGuid = deletedis.DiscussionGuid;
            Assert.That((int)response.StatusCode, Is.EqualTo(200), "Error occurred in request");

            MongoDBHelper mongo = new MongoDBHelper();
            var record = mongo.SelectDB("mongodb://usedpateydcdb02:IaGQOv47eWhlNd7x5Ecxn5sWx4pbSHDHpImVlDIINyDYnlVGB2IfRvX2vjNUevEANQGmOnCjuawSH6NRQg7qyw==@usedpateydcdb02.documents.azure.com:10255/?ssl=true&replicaSet=globaldb", "eydx", "discussion", "guid", discussionGuid);

            Assert.IsNull(record);
        }


    }
}
