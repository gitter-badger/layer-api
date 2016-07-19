namespace Layer.Api
{
    public class LayerConfiguration
    {
        public LayerConfiguration(string appId, string platformKey)
        {
            ApplicationId = appId;
            PlatformApiKey = platformKey;
        }

        public string ApplicationId { get; set; }

        public string PlatformApiKey { get; set; }

        public string Version { get; set; } = "1.0";
    }
}