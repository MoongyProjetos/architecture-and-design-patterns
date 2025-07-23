using Microsoft.Extensions.Caching.Memory;
using Seguradora.Domain;

namespace Seguradora.Data.CacheService
{
    public class SinistroCacheService : ISinistroCacheService
    {
        private readonly IMemoryCache _cache;
        public SinistroCacheService(IMemoryCache cache) => _cache = cache;

        public Task<Sinistro?> GetAsync(Guid id) => Task.FromResult(_cache.TryGetValue(id, out Sinistro? value) ? value : null);
        public Task SetAsync(Sinistro sinistro)
        {
            _cache.Set(sinistro.Id, sinistro, TimeSpan.FromMinutes(5));
            return Task.CompletedTask;
        }
    }
}
