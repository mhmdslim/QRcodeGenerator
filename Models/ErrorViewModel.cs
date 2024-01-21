namespace testQRcode.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string WebSiteURLText { get; set; } = string.Empty;
        public string QRImageURL { get; set; }
    }
}
