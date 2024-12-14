using MyCleanArchitecture.Domain.Entities;


namespace MyCleanArchitecture.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(Guid id);
        Task AddAsync(User user);
    }
}
