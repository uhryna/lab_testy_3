using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serialization.Json;
using RESTTest.Model;
using System.Collections.Generic;
using System.Net;

namespace Lab_3
{
    [TestFixture]
    public class CompleteTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GET_WhenGetPostsWithId_ShouldBeSuccessResponse()
        {
            // arrange
            RestClient client = new RestClient("https://restful-booker.herokuapp.com/booking");
            RestRequest request = new RestRequest("", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void POST_WhenExecutePostModel_ShouldBeSuccessResponse()
        {
            // arrange
            RestClient client = new RestClient("https://restful-booker.herokuapp.com/booking");
            RestRequest request = new RestRequest("", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new PostsModel()
            {
                firstname = "Jim",
                lastname = "Brown",
                totalprice = 111,
                depositpaid = true,
                bookingdates = new BookingDates()
                {
                    checkin = "2018-01-01",
                    checkout = "2019-01-01"
                },
                additionalneeds = "Breakfast"
            });
            request.AddHeader("Accept", "application/json");
            // act
            IRestResponse<PostsModel> response = client.Execute<PostsModel>(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        }


       [Test]
        public void PUT_UpdateBookInformation_ShouldReturnSuccessResponse()
        {
            // arrange
            RestClient client = new RestClient("https://restful-booker.herokuapp.com/booking/");
            RestRequest request = new RestRequest("27686", Method.PUT);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new PostsModel()
            {
                firstname = "Jim",
                lastname = "Brown",
                totalprice = 111,
                depositpaid = true,
                bookingdates = new BookingDates()
                {
                    checkin = "2018-01-01",
                    checkout = "2019-01-01"
                },
                additionalneeds = "Breakfast"
            });
            request.AddHeader("Accept", "application/json");

            client.Authenticator = new HttpBasicAuthenticator("admin", "password123");

            // act
            var response = client.Execute<PostsModel>(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        }

        [Test]
        public void DELETE_RemovePostsWithId_ShouldBeSuccessful()
        {
            // arrange
            RestClient client = new RestClient("https://restful-booker.herokuapp.com/booking/");
            RestRequest request = new RestRequest("42041", Method.DELETE);

            client.Authenticator = new HttpBasicAuthenticator("admin", "password123");
            
            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }
        [Test]
        public void GET_WhenGetRequestWithCharacterId_ShouldBeSuccessResponse()
        {
            // arrange
            RestClient client = new RestClient("https://www.breakingbadapi.com//api/characters/");
            RestRequest request = new RestRequest("1", Method.GET);
            //act
            IRestResponse response = client.Execute<NewModel>(request);
            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}