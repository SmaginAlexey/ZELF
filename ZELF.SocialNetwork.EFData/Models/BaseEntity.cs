using System;

namespace ZELF.SocialNetwork.EFData.Models
{
    public abstract class BaseEntity
    {
        public DateTime CreatedDate { get; set; }

        public Guid CreateUser { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public Guid? ModifiedUser { get; set; }
    }
}
