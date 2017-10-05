using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Cqrs.Metadata.Dynamic
{
    public class Metadata : Dictionary<string, JObject>, IMetadata
    {
        public TMetadata Get<TMetadata>()
        {
            var key = typeof(TMetadata).Name;

            return TryGetValue(key, out var value)
                        ? value.ToObject<TMetadata>()
                        : default(TMetadata);
        }

        public void Set<TMetadata>(TMetadata feature)
        {
            var key = typeof(TMetadata).Name;

            this[key] = JObject.FromObject(feature);
        }
    }
}
