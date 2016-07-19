namespace Layer.Api.Operations
{
    public class SetSessionTtlOperation : LayerOperation<int>
    {
        public SetSessionTtlOperation(int value)
            : base(value)
        {
        }

        public override string Operation => "set";

        public override string Property => "session_ttl_in_seconds";
    }
}