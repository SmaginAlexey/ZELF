using System.Collections.Generic;
using ZELF.SocialNetwork.EFData.Models;

namespace ZELF.SocialNetwork.Domain.Tests.Comparers
{
    public class UserEntityEqualityComparer : IEqualityComparer<UserEntity>
    {
        public bool Equals(UserEntity x, UserEntity y)
        {
            return x?.Id == y?.Id;
        }

        public int GetHashCode(UserEntity obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
