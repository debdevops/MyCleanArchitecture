using Moq;
using MyCleanArchitecture.Application.Interfaces;
using MyCleanArchitecture.Application.Services;
using MyCleanArchitecture.Domain.Entities;
using Xunit;

namespace MyCleanArchitecture.Application.Tests
{
   
    public sealed class Test1
    {
        [Fact]
        public async Task GetUserById_ShouldReturnUser_WhenUserExists()
        {
            var mockRepo = new Mock<IUserRepository>();
            var userId = Guid.NewGuid();
            mockRepo.Setup(repo => repo.GetByIdAsync(userId))
                    .ReturnsAsync(new User("John Doe", "john.doe@example.com"));

            var service = new UserService(mockRepo.Object);
            var user = await service.GetUserByIdAsync(userId);

            Xunit.Assert.NotNull(user);
            Xunit.Assert.Equal("John Doe", user?.Name);
        }
    }
}
