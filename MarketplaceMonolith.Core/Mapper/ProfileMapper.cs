using AutoMapper;
using Marketplace.Shared.DTO.User;
using MarketplaceMonolith.Infrastructure.Models;


namespace MarketplaceMonolith.Core.Mapper
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<UserModel, UserDTO>();
        }
    }
}
