using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZELF.SocialNetwork.Api.DTO;
using ZELF.SocialNetwork.Api.Interfaces;
using ZELF.SocialNetwork.Api.Requests;
using ZELF.SocialNetwork.EFData;
using ZELF.SocialNetwork.EFData.Models;

namespace ZELF.SocialNetwork.Domain.Services
{
    public class UserService : IUserService<Guid>
    {
        private readonly SocialNetworkContext _context;

        public UserService(SocialNetworkContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateUser(CreateUserRequest request, CancellationToken token)
        {
            var user = new UserEntity
            {
                Name = request.Name,
                Raiting = new Random().Next(0, int.MaxValue)
            };
            await _context.AddAsync(user, token);
            await _context.SaveChangesAsync(token);
            return user.Id;
        }

        public async Task<bool> SubscribeUser(SubscribeUserRequest<Guid> request, CancellationToken token)
        {
            var value = new SubscribeUserEntity
            {
                FromUserId = request.FromUserId,
                ToUserId = request.ToUserId
            };
            await _context.AddAsync(value, token);
            await _context.SaveChangesAsync(token);
            return true;
        }

        public async Task<IEnumerable<UserDTO>> GetTopUsers(TopUsersRequest request, CancellationToken token)
        {
            var result = await _context.Users.AsNoTracking()
                .OrderByDescending(x => x.Raiting)
                .Take(request.Count)
                .ToArrayAsync(token);

            if (token.IsCancellationRequested)
                return Enumerable.Empty<UserDTO>();

            return result.Select(x => new UserDTO
            {
                Id = x.Id,
                Name = x.Name,
                Raiting = x.Raiting
            });
        }
    }
}
