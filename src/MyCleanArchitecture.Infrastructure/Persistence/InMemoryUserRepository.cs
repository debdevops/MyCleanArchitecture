using MyCleanArchitecture.Application.Interfaces;
using MyCleanArchitecture.Domain.Entities;

namespace MyCleanArchitecture.Infrastructure.Persistence
{
    public class InMemoryUserRepository : IUserRepository
    {
        private readonly List<User> _users = new();

        public Task<User?> GetByIdAsync(Guid id)
        {
            return Task.FromResult(_users.FirstOrDefault(u => u.Id == id));
        }

        public Task AddAsync(User user)
        {
            _users.Add(user);
            return Task.CompletedTask;
        }
    }
}
