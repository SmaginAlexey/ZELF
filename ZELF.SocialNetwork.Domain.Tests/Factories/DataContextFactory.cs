using System;
using Microsoft.EntityFrameworkCore;
using ZELF.SocialNetwork.EFData;

namespace ZELF.SocialNetwork.Domain.Tests.Factories
{
    public static class DataContextFactory
    {
        private static T CreateContext<T>(Func<DbContextOptions<T>, T> func) where T : DbContext
        {
            var optionsBuilder = new DbContextOptionsBuilder<T>();
            optionsBuilder.UseInMemoryDatabase($"InMemoryDatabase{Guid.NewGuid()}");
            var context = func(optionsBuilder.Options);
            return context;
        }

        public static SocialNetworkContext CreateSocialNetworkContext()
        {
            return CreateContext<SocialNetworkContext>(options => new SocialNetworkContext(options));
        }
    }
}
