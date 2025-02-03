using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketplaceMonolith.Infrastructure.Repository;

namespace MarketplaceMonolith.Core.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> getUserName()
        {
            return await _userRepository.getUserName();
        }
    }
}
