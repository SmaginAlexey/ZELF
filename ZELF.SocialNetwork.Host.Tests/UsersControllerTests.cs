using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;
using ZELF.SocialNetwork.Api.DTO;
using ZELF.SocialNetwork.Api.Requests;
using ZELF.SocialNetwork.Host.Tests.Factories;

namespace ZELF.SocialNetwork.Host.Tests
{
    public class UsersControllerTests
    {
        [Fact]
        public async Task CreateUserTest()
        {
            var url = "/api/users/create-user";
            var maxLength = 64;

            var client = ServerFactory.CreateHttpClient();

            var body = new CreateUserRequest
            {
                Name = "1"
            };
            var result = await client.PutAsync(url, body.GetContent());
            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);

            body = new CreateUserRequest
            {
                Name = string.Join("", Enumerable.Range(0, maxLength + 1).Select(x => "a"))
            };
            result = await client.PutAsync(url, body.GetContent());
            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);

            body = new CreateUserRequest
            {
                Name = string.Join("", Enumerable.Range(0, 4).Select(x => "1"))
            };
            result = await client.PutAsync(url, body.GetContent());
            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);

            body = new CreateUserRequest
            {
                Name = "My Name",
            };
            result = await client.PutAsync(url, body.GetContent());
            result.EnsureSuccessStatusCode();
            var json = await result.Content.ReadAsStringAsync();
            var deserialize = JsonConvert.DeserializeObject<Guid>(json);
            Assert.True(deserialize != Guid.Empty);
        }

        [Fact]
        public async Task SubscribeUserTest()
        {
            var url = "/api/users/subscribe-user";
            var client = ServerFactory.CreateHttpClient();

            var body = new SubscribeUserRequest<Guid>
            {
                FromUserId = Guid.Empty,
                ToUserId = Guid.Empty
            };
            var result = await client.PostAsync(url, body.GetContent());
            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);

            body = new SubscribeUserRequest<Guid>
            {
                FromUserId = Guid.NewGuid(),
                ToUserId = Guid.NewGuid()
            };
            result = await client.PostAsync(url, body.GetContent());
            result.EnsureSuccessStatusCode();

            var json = await result.Content.ReadAsStringAsync();
            var deserialize = JsonConvert.DeserializeObject<bool>(json);
            Assert.True(deserialize);
        }

        [Fact]
        public async Task GetTopUsersTest()
        {
            var url = "/api/users/top-users";
            var client = ServerFactory.CreateHttpClient();

            var body = new TopUsersRequest
            {
                Count = 0,
            };
            var result = await client.PostAsync(url, body.GetContent());
            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);

            body = new TopUsersRequest
            {
                Count = 100,
            };
            result = await client.PostAsync(url, body.GetContent());
            result.EnsureSuccessStatusCode();
            var json = await result.Content.ReadAsStringAsync();
            var deserialize = JsonConvert.DeserializeObject<IEnumerable<UserDTO>>(json);
            Assert.True(!deserialize.Any());
        }
    }
}
