using Auth.Application.Dtos.Identity;
using Auth.Domain;
using Auth.Infrastructure.Auth.Jwt;
using Auth.Infrastructure.Identity.Data;
using Auth.Infrastructure.Identity.Services;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Auth.UnitTests
{
    public class UserManagerServiceTests
    {
        private readonly UserManagerService _suit;
        private readonly Mock<UserManager<AppUser>> _userManagerMock = new Mock<UserManager<AppUser>>();
        private readonly Mock<IJwtAuthService> _jwtAuthServiceMock = new Mock<IJwtAuthService>();
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();

        public UserManagerServiceTests()
        {
            var options = new DbContextOptionsBuilder<AppDataContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new AppDataContext(options);

            _suit = new UserManagerService(
                _userManagerMock.Object,
                _jwtAuthServiceMock.Object,
                _mapperMock.Object,
                context
                );
        }

        [Fact]
        public async Task CreateUser_Should_Success()
        {
            // arrange
            var userDto = new UserCreateDto
            {
                UserName = "New User",
                Email = "NewUser@gmail.com",
                Password = "NewUser12345"
            };

            var appUser = new AppUser
            {
                Id = "UserId",
                UserName = userDto.UserName,
                Email = userDto.Email
            };

            var identityResult = new IdentityResult();

            _userManagerMock.Setup(x => x.CreateAsync(appUser, userDto.Password))
                .Returns(async () => identityResult);

            // act
            var userId = await _suit.CreateUser(userDto);


            // assert
        }
    }
}
