using Marketplace.Shared.DTO.AuthResults;
using Marketplace.Shared.DTO.User;
using MarketplaceMonolith.Api.Data;
using MarketplaceMonolith.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace MarketplaceMonolith.Infrastructure.Repository.User
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;
        private readonly PasswordHasher<UserModel> _passwordHasher;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
            _passwordHasher = new PasswordHasher<UserModel>();
        }

        public async Task<UserModel> GetUserById(string id)
        {
            var user = await _dataContext.ApplicationUser.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));

            return user;
        }

        public async Task<OperationResult> Login(LoginRequest loginRequest)
        {
            var user = await _dataContext.ApplicationUser.FirstOrDefaultAsync(x => x.Email == loginRequest.Email);

            if (user == null)
            {
                return OperationResult.Fail("User with this email was not found");
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginRequest.Password);

            if (result == PasswordVerificationResult.Success)
            {
                return OperationResult.Ok(user.Id.ToString());
            }

            return OperationResult.Fail("Something went wrong");
        }

        public async Task<OperationResult> Registration(RegistrationRequest registrationRequest)
        {
            var user = await _dataContext.ApplicationUser.FirstOrDefaultAsync(x => x.Email == registrationRequest.Email);

            if (user == null)
            {
                var newUser = new UserModel
                {
                    Id = Guid.NewGuid(),
                    Email = registrationRequest.Email,
                    UserName = registrationRequest.Name,
                    Role = "User",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                };

                newUser.PasswordHash = _passwordHasher.HashPassword(newUser, registrationRequest.Password);

                await _dataContext.ApplicationUser.AddAsync(newUser);
                await _dataContext.SaveChangesAsync();

                return OperationResult.Ok(newUser.Id.ToString());
            }

            return OperationResult.Fail("User with this email already exist");
        }


    }
}
