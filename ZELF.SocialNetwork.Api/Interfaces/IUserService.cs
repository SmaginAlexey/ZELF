using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ZELF.SocialNetwork.Api.DTO;
using ZELF.SocialNetwork.Api.Requests;

namespace ZELF.SocialNetwork.Api.Interfaces
{
    public interface IUserService<TUSerId>
    {
        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <returns>Id созданного пользователя</returns>
        Task<TUSerId> CreateUser(CreateUserRequest request, CancellationToken token);

        /// <summary>
        /// Подписать одного пользователя на другого
        /// </summary>
        /// <returns>Флаг успешности подписания пользователя</returns>
        Task<bool> SubscribeUser(SubscribeUserRequest<TUSerId> request, CancellationToken token);

        /// <summary>
        /// Получить топовых пользователей
        /// </summary>
        Task<IEnumerable<UserDTO>> GetTopUsers(TopUsersRequest request, CancellationToken token);
    }
}
