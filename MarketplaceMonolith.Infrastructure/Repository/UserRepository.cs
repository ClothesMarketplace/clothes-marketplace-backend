using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceMonolith.Infrastructure.Repository
{
    public class UserRepository
    {
        public async Task<string> getUserName()
        {
            return await Task.FromResult("UserName");
        }
    }
}
