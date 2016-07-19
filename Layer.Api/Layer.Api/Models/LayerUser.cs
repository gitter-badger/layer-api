namespace Layer.Api.Models
{
    public class LayerUser
    {
        public string Id { get; set; }

        public IdentityObject Identity { get; set; }

        public bool Suspended { get; set; }
    }
}