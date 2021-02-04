using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using ZELF.SocialNetwork.Api.Requests;
using ZELF.SocialNetwork.Domain.Services;
using ZELF.SocialNetwork.Domain.Tests.Factories;
using ZELF.SocialNetwork.EFData.Models;

namespace ZELF.SocialNetwork.Domain.Tests
{
    public class UserServiceTests
    {
        [Fact]
        public async Task CreateUserTest()
        {
            var context = DataContextFactory.CreateSocialNetworkContext();
            var service = new UserService(context);
            var result = await service.CreateUser(new CreateUserRequest(), CancellationToken.None);

            Assert.True(result != Guid.Empty);

            var user = context.Users.Single();
            Assert.Equal(user.Id, result);
        }

        [Fact]
        public async Task SubscribeUserTest()
        {
            var context = DataContextFactory.CreateSocialNetworkContext();
            var service = new UserService(context);

            var fromUser = new UserEntity { Id = Guid.NewGuid() };
            await context.Fill(fromUser);

            var toUser = new UserEntity { Id = Guid.NewGuid() };
            await context.Fill(toUser);

            var result = await service.SubscribeUser(new SubscribeUserRequest<Guid>
            {
                FromUserId = fromUser.Id,
                ToUserId = toUser.Id
            }, CancellationToken.None);
            Assert.True(result);

            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await service.SubscribeUser(new SubscribeUserRequest<Guid>
                {
                    FromUserId = fromUser.Id,
                    ToUserId = toUser.Id
                }, CancellationToken.None);
            });
        }

        [Fact]
        public async Task GetTopUsersTest()
        {
            var context = DataContextFactory.CreateSocialNetworkContext();
            var service = new UserService(context);

            var result = await service.GetTopUsers(new TopUsersRequest { Count = 1 }, CancellationToken.None);
            Assert.True(!result.Any());

            var users = Enumerable.Range(0, 100).Select(x => new UserEntity
            {
                Id = Guid.NewGuid(),
                Raiting = new Random().Next(0, int.MaxValue)
            }).ToArray();
            await context.Fill(users);

            result = await service.GetTopUsers(new TopUsersRequest { Count = 0 }, CancellationToken.None);
            Assert.True(!result.Any());

            result = await service.GetTopUsers(new TopUsersRequest { Count = users.Length }, CancellationToken.None);
            Assert.True(users.Select(x => x.Raiting).OrderByDescending(x => x).SequenceEqual(result.Select(x => x.Raiting).OrderByDescending(x => x)));

            result = await service.GetTopUsers(new TopUsersRequest { Count = 3 }, CancellationToken.None);
            Assert.True(users.Select(x => x.Raiting).OrderByDescending(x => x).Take(3).SequenceEqual(result.Select(x => x.Raiting).OrderByDescending(x => x)));
        }
    }
}
