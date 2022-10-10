namespace MyPregnancyTracker.Services.EmailSender
{
    public class EmailAttachment
    {
        public byte[] Content { get; set; }

        public string FileName { get; set; }

        public string MIMEType { get; set; }
    }
}
