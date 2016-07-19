using System;

namespace Layer.Api.Contexts
{
    public class ContentObject
    {
        public string Id { get; set; }

        public long Size { get; set; }

        public string DownloadUri { get; set; }

        public string RefreshUrl { get; set; }

        public DateTimeOffset ExpirationDate { get; set; }
    }
}