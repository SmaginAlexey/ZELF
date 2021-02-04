using System.ComponentModel.DataAnnotations;

namespace ZELF.SocialNetwork.Api.Requests
{
    public class CreateUserRequest
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        [RegularExpression("[a-zA-Z][a-zA-Z ]+")]
        [StringLength(64)]
        public string Name { get; set; }
    }
}
