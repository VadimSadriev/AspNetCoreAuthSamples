using Auth.Common.Dtos.Identity;
using Auth.IntergrationTests.Base;
using Auth.IntergrationTests.Extensions;
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
            var userCreateDto = new UserCreateDto
            {
                Email = "Test@gmail.com",
                UserName = "TestUser123",
                Password = "Password12345"
            };

            var response = await TestClient.PostAsJsonAsync(_signupUrl, userCreateDto);

            var result = await response.Content.ReadAsAsync<UserResponseDto>();
        }
    }
}
