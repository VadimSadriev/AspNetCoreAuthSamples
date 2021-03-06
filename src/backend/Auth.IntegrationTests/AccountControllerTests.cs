﻿using Auth.Contracts.AccountContracts;
using Auth.IntegrationTests.Base;
using Auth.IntegrationTests.Extensions;
using FluentAssertions;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Auth.IntegrationTests
{
    public class AccountControllerTests : IntegrationTest
    {
        private static string _baseUrl = "api/account";

        private readonly string _signupUrl = _baseUrl + "/signup";

        [Fact]
        public async Task Signup_Success()
        {
            // arrange
            var userCreateContract = new UserCreateContract
            {
                Email = "Test@gmail.com",
                UserName = "TestUser",
                Password = "Password12345"
            };
            // act
            var response = await TestClient.PostAsJsonAsync(_signupUrl, userCreateContract);

            // assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Signip_Fail()
        {
            // arrange
            var userCreateDContract = new UserCreateContract
            {
                Email = "",
                UserName = null,
                Password = ""
            };

            // act
            var response = await TestClient.PostAsJsonAsync(_signupUrl, userCreateDContract);

            // assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}
