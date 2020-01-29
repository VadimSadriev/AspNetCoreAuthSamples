using Auth.Common.Dtos.Identity;
using Auth.IntergrationTests.Base;
using Auth.IntergrationTests.Extensions;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Auth.IntergrationTests
{
    public class AccountControllerTests : IntegrationTest
    {
        private static string _baseUrl = "api/account";

        private readonly string _signupUrl = _baseUrl + "/signup";

        [Fact]
        public async Task Signup_Success()
        {
            // arrange
            var userCreateDto = new UserCreateDto
            {
                Email = "Test@gmail.com",
                UserName = "TestUser",
                Password = "Password12345"
            };

            // act
            var response = await TestClient.PostAsJsonAsync(_signupUrl, userCreateDto);

            // assert

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Should().NotBeNull();

            var responseContent = await response.Content.ReadAsAsync<UserResponseDto>();

            responseContent.Email.Should().Be(userCreateDto.Email);
            responseContent.UserName.Should().Be(userCreateDto.UserName);
        }
    }
}
