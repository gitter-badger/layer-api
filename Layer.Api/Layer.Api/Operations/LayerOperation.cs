using Newtonsoft.Json;

namespace Layer.Api.Operations
{
    public abstract class LayerOperation<T>
    {
        protected LayerOperation(T value)
        {
            Value = value;
        }

        [JsonProperty(PropertyName = "operation")]
        public abstract string Operation { get; }

        [JsonProperty(PropertyName = "property")]
        public abstract string Property { get;}

        [JsonProperty(PropertyName = "value")]
        public T Value { get; }
    }
}