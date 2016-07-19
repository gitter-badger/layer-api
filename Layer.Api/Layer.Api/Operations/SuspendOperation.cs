namespace Layer.Api.Operations
{
    public class SuspendOperation : LayerOperation<bool>
    {
        public SuspendOperation(bool value)
            : base(value)
        {
        }

        public override string Property => "suspended";

        public override string Operation => "set";
    }
}