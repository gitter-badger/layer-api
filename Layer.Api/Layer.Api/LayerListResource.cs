using System.Collections.Generic;

namespace Layer.Api
{
    public class LayerListResource<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int TotalCount { get; set; }
    }
}
