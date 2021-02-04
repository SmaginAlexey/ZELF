using ZELF.SocialNetwork.Api.DTO;
using ZELF.SocialNetwork.EFData.Models;

namespace ZELF.SocialNetwork.Domain.Tests.Factories
{
    public static class UserEntityFactory
    {
        public static UserEntity Convert(this UserDTO user)
        {
            return new UserEntity
            {
                Id = user.Id,
                Name = user.Name,
                Raiting = user.Raiting
            };
        }
    }
}
