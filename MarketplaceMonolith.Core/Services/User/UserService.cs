using AutoMapper;
using Marketplace.Shared.DTO.AuthResults;
using Marketplace.Shared.DTO.User;
using MarketplaceMonolith.Core.Services.Jwt;
using MarketplaceMonolith.Infrastructure.Repository.User;

namespace MarketplaceMonolith.Core.Services.User
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly JwtService _jwtService;

        public UserService(UserRepository userRepository, IMapper mapper, JwtService jwtService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        public async Task<OperationResult> Login(LoginRequest loginRequest)
        {
            var result = await _userRepository.Login(loginRequest);

            if(result.Success)
            {
                var token = _jwtService.GenerateToken(result.Message, loginRequest.Email);

                return OperationResult.Ok(token);
            }

            return result;
        }

        public async Task<OperationResult> Registration(RegistrationRequest registrationRequest)
        {
            var result = await _userRepository.Registration(registrationRequest);

            if (result.Success)
            {
                var token = _jwtService.GenerateToken(result.Message, registrationRequest.Email);

                return OperationResult.Ok(token);
            }

            return result;
        }

    }
}
