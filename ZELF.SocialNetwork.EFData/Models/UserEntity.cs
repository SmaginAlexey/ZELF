using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ZELF.SocialNetwork.EFData.Models
{
    [Table("Users"), Index(nameof(Raiting))]
    public class UserEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Raiting { get; set; }
    }
}
