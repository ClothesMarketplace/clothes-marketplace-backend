using Marketplace.Shared.DTO.AuthResults;
using Marketplace.Shared.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceMonolith.Core.Services.User
{
    public interface IUserService
    {
        Task<OperationResult> Registration(RegistrationRequest registrationRequest);
        Task<OperationResult> Login(LoginRequest loginRequest);
    }
}
