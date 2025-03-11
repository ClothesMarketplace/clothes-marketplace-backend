using Marketplace.Shared.DTO.AuthResults;
using Marketplace.Shared.DTO.User;
using MarketplaceMonolith.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceMonolith.Infrastructure.Repository.User
{
    internal interface IUserRepository
    {
        Task<OperationResult> Registration(RegistrationRequest registrationRequest);
        Task<OperationResult> Login(LoginRequest loginRequest);
        Task<UserModel> GetUserById(string id);
    }
}
