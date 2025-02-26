using MarketplaceMonolith.Api.Data;
using MarketplaceMonolith.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;


namespace MarketplaceMonolith.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<UserModel> getUser(Guid userId)
        {
            var user = await _dataContext.ApplicationUser.FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {userId} not found.");
            }
            return user;
        }
    }
}
