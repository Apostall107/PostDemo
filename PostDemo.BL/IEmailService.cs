namespace PostDemo.BL {
    public interface IEmailService {
        string FormatAttachmentName(string attachmentName, string receiverName, DateTime? date);
    }
}