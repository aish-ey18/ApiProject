using System;
using ApiFramework.Api.Microsoft;
using ApiFramework.Models;
using ApiFramework.Services;
using ApiFramework.Tests.Common;
using NUnit.Framework;
using RestSharp;

namespace ApiFramework.Tests
{
    public class TokenTests : BaseTest
    {
        //public TokenModel TokenModel { get; private set; }

        [SetUp]
        public void Init()
        {
            RestClient = new RestAdapter(Content_URL);
        }

        [Test]
        [Category("PipelineTest")]
        public void GetCacheTest()
        {
            var info = new GetCache()
            {
                authorization = "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6ImtnMkxZczJUMENUaklmajRydDZKSXluZW4zOCIsImtpZCI6ImtnMkxZczJUMENUaklmajRydDZKSXluZW4zOCJ9.eyJhdWQiOiI2ZTg4NDcxYy1mYjVkLTQ2ZWMtODFmOS02MmYzZGFhOTM1NTgiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC81Yjk3M2Y5OS03N2RmLTRiZWItYjI3ZC1hYTBjNzBiODQ4MmMvIiwiaWF0IjoxNjAzMjg0NDEyLCJuYmYiOjE2MDMyODQ0MTIsImV4cCI6MTYwMzI4ODMxMiwiYWlvIjoiQVVRQXUvOFJBQUFBaUJOeVkwbVZTbW1qWStpQmtmS0NtRWFodzk4ZlNiZ0FBUUp3a1VVQWxRUW1KSmU2K2RGM1A5T3dpTC9vYzZKS0x2a203bjlLNHlPcS80d1VRNldwM1E9PSIsImFtciI6WyJwd2QiLCJyc2EiXSwiZmFtaWx5X25hbWUiOiJHdXB0YSIsImdpdmVuX25hbWUiOiJBaXNod2FyeWEiLCJpcGFkZHIiOiIxMDMuMTAyLjEwMy4xOTYiLCJuYW1lIjoiQWlzaHdhcnlhIEd1cHRhIiwibm9uY2UiOiI1ZTUyMzQ2NS0wMGQzLTRkMjEtYmNlMi04NGY1NWJjMTcyZWYiLCJvaWQiOiIzMmE2YmMzYy1jNjNhLTQ5MDUtYmMzMy04YjM5ODFmMTVmZWUiLCJvbnByZW1fc2lkIjoiUy0xLTUtMjEtMzgxNDQ0OTgxNi0xMTQ3NDE0NzQ0LTMyODcxMjYyNDUtNjM1NDIyIiwicmgiOiIwLkFTRUFtVC1YVzk5MzYwdXlmYW9NY0xoSUxCeEhpRzVkLS14R2dmbGk4OXFwTlZnaEFMUS4iLCJzdWIiOiJQN3Zlc21pWW1Lems5T19RZDFQX2VqZ25vOHpvVnozeVRfcHV1dzRPYTBVIiwidGlkIjoiNWI5NzNmOTktNzdkZi00YmViLWIyN2QtYWEwYzcwYjg0ODJjIiwidW5pcXVlX25hbWUiOiJBaXNod2FyeWEuR3VwdGE0QGluLmV5LmNvbSIsInVwbiI6IkFpc2h3YXJ5YS5HdXB0YTRAaW4uZXkuY29tIiwidXRpIjoiaWZRYk5IMUVSRTI3ek1uYVR6UWtBQSIsInZlciI6IjEuMCJ9.fLumq4zg_-dT96Jmvb5BC9JmJwGcYwjsTVefXDg7xj_S6NK-vjduhX2WPgVMH6mqsQcsnoCEPCdIc5Iiu1fFyAy2l1iYxYQ4pznvJiyW9Nr2TXH2FUzrO-mhK4zYjK-WUxbsMO93_opJo5A6ruv1jT0Gv1qa6n6rSqD4hquMhvvfTrvleJOY75pwqCKPrpMAlcCiFV5gPMz-hHAbejFkrddH_WStWrygRv-LHafTbvTDqE6zHGyJTTyHiyAkWUCeUZDqE4fnhjduxcQEZAxXiKOE3v0zodhLGO8ca_5bZ1bDoTWO35rY23-BKwYj0WenPU3bHLULpaq2jruK36NVqA",
                contentkey = "Y29udGVudHBhc3N3b3JkMTIzNA==",
                ContentType = "application/json",
                cacheName = "repoHierarchyCache"
            };

            IRestResponse response = RestClient.Create(info);
            Console.WriteLine(response.Content);
            int StatusCode = (int)response.StatusCode;
            Console.WriteLine(StatusCode);
            Assert.AreEqual(200, StatusCode, "Status code is not 200");

        }
    //    public void TokenTest()
    //    {          

    //        var tokenInfo = new PostToken()
    //        {
    //            ResourceId = "4667418b-7015-4ceb-b207-2193896769a8",
    //            ClientId = "d011af7a-2630-4082-b72a-68f18959969d",
    //            ContentType = "application/x-www-form-urlencoded",
    //            GrantType = "client_credentials",
    //            ClientSecret = "sJkT-pTIlCC022h6lgDzQSeuBUIvV-.*",
    //            Resource = "95ed5b7a-e96b-49c1-9864-18f61dcfcb3a"
    //        };
            
    //        IRestResponse response = RestClient.Create(tokenInfo);

    //        int StatusCode = (int)response.StatusCode;
    //        //Assert that correct Status is returned
    //        Assert.AreEqual(200, StatusCode, "Status code is not 200");
    //    }
    }

}
