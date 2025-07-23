using Seguradora.Domain;

namespace Seguradora.Data.CacheService
{

    // 4. Cache Service (Redis ou MemoryCache simulada)
    public interface ISinistroCacheService
    {
        Task<Sinistro?> GetAsync(Guid id);
        Task SetAsync(Sinistro sinistro);
    }
}
