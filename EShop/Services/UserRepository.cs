using Microsoft.EntityFrameworkCore;
using EShop.Models;
using EShop.Models.User;

namespace EShop.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUserAsync(UserRequest request)
        {
            if (!await _context.Users.AnyAsync(x => x.Email == request.Email))
            {
                var userEntity = new UserEntity()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Adress = request.Adress,
                    Password = request.Password,
                    Number = request.Number,
                };

                _context.Users.Add(userEntity);
                await _context.SaveChangesAsync();

                return new User
                {
                    Id = userEntity.Id,
                    FirstName = userEntity.FirstName,
                    LastName= userEntity.LastName,
                    Email= userEntity.Email,
                    Adress= userEntity.Adress,
                    Number = userEntity.Number,
                };
            }
            return null!;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<UserEntity>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<UserEntity> GetUserAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> UpdateUserAsync(int id, UserRequest request)
        {
            var userEntity = await _context.Users.FindAsync(id);
            if (userEntity != null)
            {
                userEntity.FirstName = request.FirstName;
                userEntity.LastName = request.LastName;
                userEntity.Email = request.Email;
                userEntity.Adress = request.Adress;
                userEntity.Password = request.Password;
                userEntity.Number = request.Number;


                _context.Entry(userEntity).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return new User
                {
                    Id = userEntity.Id,
                    FirstName = userEntity.FirstName,
                    LastName = userEntity.LastName,
                    Email = userEntity.Email,
                    Adress = userEntity.Adress,
                    Number = userEntity.Number,
                };
            }
            return null!;
        }
    }
}
