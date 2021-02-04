using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ZELF.SocialNetwork.Domain.Tests
{
    public static class DataContextExtensions
    {
        public static async Task<T> Fill<T, TEntity>(this T context, params TEntity[] entities) where T : DbContext
        {
            foreach (var i in entities)
            {
                await context.AddAsync(i);
            }
            await context.SaveChangesAsync();
            return context;
        }
    }
}
