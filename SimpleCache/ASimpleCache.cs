using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCache
{
    internal class ASimpleCache
    {
        Dictionary<string, object> cache { get; set; } = new Dictionary<string, object>();

        public bool TryGetValue(string key, out object value)
        {
            lock (cache)
            {
                return cache.TryGetValue(key, out value);
            }

        }

        public void Add(string key, object value)
        {
            lock (cache)
            {
                cache[key] = value;              
            }
        }
    }
}
