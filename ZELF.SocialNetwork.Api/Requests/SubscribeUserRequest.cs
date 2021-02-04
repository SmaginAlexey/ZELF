using System.ComponentModel.DataAnnotations;
using ZELF.SocialNetwork.Host.ValidationAttributes;

namespace ZELF.SocialNetwork.Api.Requests
{
    public class SubscribeUserRequest<T>
    {
        /// <summary>
        /// Пользователь, которого надо подписать
        /// </summary>
        [NotEmpty]
        public T FromUserId { get; set; }

        /// <summary>
        /// Пользователь, на которого надо подписаться
        /// </summary>
        [NotEmpty]
        public T ToUserId { get; set; }
    }
}
