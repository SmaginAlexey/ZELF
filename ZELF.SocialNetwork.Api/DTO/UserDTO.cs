using System;

namespace ZELF.SocialNetwork.Api.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Raiting { get; set; }
    }
}
