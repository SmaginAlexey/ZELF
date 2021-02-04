using System.ComponentModel.DataAnnotations;

namespace ZELF.SocialNetwork.Api.Requests
{
    public class TopUsersRequest
    {
        /// <summary>
        /// Количество пользователей
        /// </summary>
        [Range(1, int.MaxValue)]
        public int Count { get; set; }
    }
}
