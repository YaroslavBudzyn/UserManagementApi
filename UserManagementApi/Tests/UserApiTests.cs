using Domain.Entities;
using NUnit.Framework;
using System.Net.Http.Json;
using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
namespace Tests
{
    [TestFixture]
    public class UserApiTests
    {
        private HttpClient _client = null!;

        [SetUp]
        public void Setup()
        {
            var factory = new WebApplicationFactory<UserManagementApi.Program>();
            _client = factory.CreateClient();
        }

        [Test]
        public async Task Create_ValidUser_ReturnsCreated()
        {
            var newUser = new User
            {
                FullName = "Test",
                Email = "test@example.com",
                DateOfBirth = new DateTime(1990, 1, 1)
            };

            var response = await _client.PostAsJsonAsync("/users", newUser);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [Test]
        public async Task Get_Users_ReturnsOk()
        {
            var response = await _client.GetAsync("/users");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public async Task Create_InvalidEmail_ReturnsBadRequest()
        {
            var newUser = new User
            {
                FullName = "Invalid Email User",
                Email = "invalid-email",
                DateOfBirth = new DateTime(1990, 1, 1)
            };

            var response = await _client.PostAsJsonAsync("/users", newUser);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Test]
        public async Task Create_FutureDateOfBirth_ReturnsBadRequest()
        {
            var newUser = new User
            {
                FullName = "Future Man",
                Email = "future@example.com",
                DateOfBirth = DateTime.UtcNow.AddYears(10) // future date
            };

            var response = await _client.PostAsJsonAsync("/users", newUser);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}