using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;

namespace ApiCIandT
{
    [TestFixture]
    public class GetTest
    {
        [Test]
        public void MethodGETReturningAllUsers()
        {
            IRestClient Clients = new RestClient("https://jsonplaceholder.typicode.com/");
            IRestRequest Request = new RestRequest("users/", Method.GET);

            Request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };

            IRestResponse response = Clients.Execute(Request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void MethodGETVerifyEmail()
        {
            IRestClient Client = new RestClient("https://jsonplaceholder.typicode.com/");
            IRestRequest RequestGet = new RestRequest("users/{id}", Method.GET);
            RequestGet.AddUrlSegment("id", 1);
            IRestResponse ResponseGet = Client.Execute(RequestGet);
            JObject ResultGet = JObject.Parse(ResponseGet.Content);
            Assert.IsTrue(IsValidEmail(ResultGet["email"].ToString()));
        }

        [Test]
        public void MethodGETVerifyCatchphrase()
        {
            IRestClient Client = new RestClient("https://jsonplaceholder.typicode.com/");

            IRestRequest RequestGet = new RestRequest("users/{id}", Method.GET);
            RequestGet.AddUrlSegment("id", 1);

            IRestResponse ResponseGet = Client.Execute(RequestGet);
            JObject ResultGet = JObject.Parse(ResponseGet.Content);

            string EmailToVerify = ResultGet["company"]["catchPhrase"].ToString();

            Assert.IsTrue(EmailToVerify.Length <= 50);
        }

        public bool IsValidEmail(string source)
        {
            return new EmailAddressAttribute().IsValid(source);
        }
    }

}
