using System;
using System.Linq;
using System.Net;
using ApiCIandT.Model;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;

namespace ApiCIandT.Test
{
    [TestFixture]
    class PostTest
    {
        [Test]
        public void SavePostWithGet()
        {
            IRestClient Client = new RestClient("https://jsonplaceholder.typicode.com/");
            IRestRequest RequestGet = new RestRequest("users/{id}", Method.GET);
            RequestGet.AddUrlSegment("id", 1);
            IRestResponse ResponseGet = Client.Execute(RequestGet);
            JObject ResultGet = JObject.Parse(ResponseGet.Content);

            IRestRequest RequestPost = new RestRequest("posts", Method.POST);
            RequestPost.AddJsonBody(new Posts()
            {
                title = "The trooper",
                body = "You'll take my life but I'll take yours too"
                    + "You'll fire your musket but I'll run you through So when you're waiting"
                    + " for the next attack You'd better stand there's no turning back",
                userId = "1"
            });

            IRestResponse ResponsePost = Client.Execute<Posts>(RequestPost);
            JObject ResultPost = JObject.Parse(ResponseGet.Content);
            Assert.That(ResultPost["userId"].ToString(), Contains.Substring("1"), "Resultado buscado não foi encontrado");
        }

        [Test]
        public void SavePostWithoutTitle()
        {
            IRestClient Client = new RestClient("https://jsonplaceholder.typicode.com/");
            IRestRequest Request = new RestRequest("posts", Method.POST);

            Request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            Request.AddJsonBody(new Posts()
            {
                title = "",
                body = "You'll take my life but I'll take yours too"
                    + "You'll fire your musket but I'll run you through So when you're waiting"
                    + " for the next attack You'd better stand there's no turning back",
                userId = "1"
            });

            IRestResponse Response = Client.Execute<Posts>(Request);

            Assert.That(Response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }
    }
}
