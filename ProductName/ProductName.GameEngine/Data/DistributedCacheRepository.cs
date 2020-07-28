using Microsoft.Extensions.Caching.Distributed;
using ProductName.Business.Data;
using ProductName.Business.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProductName.GameEngine.Data
{
    public class DistributedCacheRepository : IRepository<Character>
    {
        private readonly IDistributedCache _cache;
        public DistributedCacheRepository(IDistributedCache cache)
        {
            _cache = cache;
        }
        public async Task<bool> CreateOrUpdateAsync(Character model)
        {
            await _cache.SetAsync(model.Id.ToString(), model.ToByteArray(), CancellationToken.None);
            return true;

        }

        public async Task<int> CreateOrUpdateAsync(IEnumerable<Character> models)
        {
            foreach(var model in models)
            {
                await _cache.SetAsync(model.Id.ToString(), model.ToByteArray(), CancellationToken.None);
            }
            return models.Count();
        }

        public async Task<Character> GetAsync(Guid id)
        {
            return await _cache.GetAsync<Character>(id.ToString(), CancellationToken.None);
        }
    }

    internal static class Extensions
    {
        public static byte[] ToByteArray(this object obj)
        {
            if (obj == null)
            {
                return null;
            }
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (MemoryStream memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, obj);
                return memoryStream.ToArray();
            }
        }
        public static T FromByteArray<T>(this byte[] byteArray) where T : class
        {
            if (byteArray == null)
            {
                return default(T);
            }
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (MemoryStream memoryStream = new MemoryStream(byteArray))
            {
                return binaryFormatter.Deserialize(memoryStream) as T;
            }
        }

        public async static Task SetAsync<T>(this IDistributedCache distributedCache, string key, T value, DistributedCacheEntryOptions options, CancellationToken token = default(CancellationToken))
        {
            await distributedCache.SetAsync(key, value.ToByteArray(), options, token);
        }

        public async static Task<T> GetAsync<T>(this IDistributedCache distributedCache, string key, CancellationToken token = default(CancellationToken)) where T : class
        {
            var result = await distributedCache.GetAsync(key, token);
            return result.FromByteArray<T>();
        }
    }
}

