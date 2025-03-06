using Marketplace.Shared.DTO.AuthResults;
using Marketplace.Shared.DTO.User;
using MarketplaceMonolith.Api.Data;
using MarketplaceMonolith.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MarketplaceMonolith.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;
        private readonly PasswordHasher<UserModel> _passwordHasher;

        public UserRepository(DataContext dataContext, PasswordHasher<UserModel> passwordHasher)
        {
            _dataContext = dataContext;
            _passwordHasher = passwordHasher;
        }

        public async Task<OperationResult> Login(LoginRequest loginRequest)
        {
            var user = await _dataContext.ApplicationUser.FirstOrDefaultAsync(x => x.Email == loginRequest.Email);

            if (user == null)
            {
                return OperationResult.Fail("User was not found");
            }

            var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginRequest.Password);

            if (passwordVerificationResult == PasswordVerificationResult.Failed)
            {
                return OperationResult.Fail("Incorrect password");
            }

            return OperationResult.Ok(user.Id.ToString());
        }

        public async Task<OperationResult> Registration(RegistrationRequest registrationRequest)
        {
            var user = await _dataContext.ApplicationUser.FirstOrDefaultAsync(x => x.Email == registrationRequest.Email);

            if (user != null)
            {
                return OperationResult.Fail("User with this email already exists");
            }

            var newUser = new UserModel
            {
                Id = Guid.NewGuid(),
                Email = registrationRequest.Email,
                UpdatedAt = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow,
                Role = "user",
                UserName = registrationRequest.Name,
            };;

            newUser.PasswordHash = _passwordHasher.HashPassword(newUser, registrationRequest.Password);

            await _dataContext.ApplicationUser.AddAsync(newUser);
            await _dataContext.SaveChangesAsync();  


            return OperationResult.Ok(newUser.Id.ToString());
        }

    }
}
