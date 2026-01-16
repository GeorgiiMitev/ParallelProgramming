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

        ManualResetEventSlim canReadSignal = new ManualResetEventSlim(true);

        int activeReaders = 0;

        public bool TryGetValue(string key, out object value)
        {
            canReadSignal.Wait();
            Interlocked.Increment(ref activeReaders); // increase the number of current readers
            var result = cache.TryGetValue(key, out value);
            Interlocked.Decrement(ref activeReaders); // i am not reading anymore, decrease the number of readers
            return result;
        }

        public void Add(string key, object value)
        {
            lock (cache)
            {
                canReadSignal.Reset(); // tells readers they cannot proceed and must wait
                cache[key] = value;    
                canReadSignal.Set(); //lets all pending readers read.
            }
        }
    }
}
