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
    public class LifecycleStatusTests : BaseTest
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


    }
}
