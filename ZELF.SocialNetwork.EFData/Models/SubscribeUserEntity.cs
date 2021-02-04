using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ZELF.SocialNetwork.EFData.Models
{
    [Index(nameof(FromUserId), nameof(ToUserId))]
    public class SubscribeUserEntity : BaseEntity
    {
        [Required]
        [ForeignKey(nameof(FromUser))]
        public Guid FromUserId { get; set; }

        public virtual UserEntity FromUser { get; set; }

        [Required]
        [ForeignKey(nameof(ToUser))]
        public Guid ToUserId { get; set; }

        public virtual UserEntity ToUser { get; set; }
    }
}
