using ApiFramework.Services;
using NUnit.Framework;
using RestSharp;
using System.Configuration;

namespace ApiFramework.Tests.Common
{
        [TestFixture]
        public abstract class BaseTest
        {
        
            public string BASE_URL = ConfigurationManager.AppSettings["BASE_URL"];
            public string ROOTSITE_URL = ConfigurationManager.AppSettings["ROOTSITE_URL"];
            public string RBAC_URL = ConfigurationManager.AppSettings["RBAC_URL"];
            public string IDENTITY_URL = ConfigurationManager.AppSettings["IDENTITY_URL"];
            public string CTP_URL = ConfigurationManager.AppSettings["CTP_URL"];
            public string EYDX_URL = ConfigurationManager.AppSettings["EYDX_URL"];
            public string Content_URL = ConfigurationManager.AppSettings["Content_URL"];

            public RestSerializer serializer;
            public RestAdapter RestClient;

        //protected Resources resources;
        [SetUp]
            public void StartUpTest()
            {
                //resources = new Resources();
            }
            [TearDown]
            public void EndTest()
            {
                // kill webdriver instaces
            }
        }

    }

