namespace Layer.Api.Operations
{
    public class AddBlocksOperation : LayerOperation<string>
    {
        public AddBlocksOperation(string value)
            : base(value)
        {
        }

        public override string Operation => "add";

        public override string Property => "blocks";
    }
}