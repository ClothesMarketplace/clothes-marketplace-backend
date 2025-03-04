using AutoMapper;
using Marketplace.Shared.DTO.User;
using MarketplaceMonolith.Infrastructure.Repository;

namespace MarketplaceMonolith.Core.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(UserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO> getUser(Guid userId)
        {
            var user = await _userRepository.getUser(userId);

            return _mapper.Map<UserDTO>(user);
        }
    }
}
