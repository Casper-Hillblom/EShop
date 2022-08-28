using EShop.Models.User;

namespace EShop.Services
{
    public interface IUserRepository
    {
        public Task<User> CreateUserAsync(UserRequest request);
        public Task<UserEntity> GetUserAsync(int id);
        public Task<IEnumerable<UserEntity>> GetAllUsersAsync();
        public Task<User> UpdateUserAsync(int id, UserRequest request);
        public Task<bool> DeleteUserAsync(int id);
    }
}

