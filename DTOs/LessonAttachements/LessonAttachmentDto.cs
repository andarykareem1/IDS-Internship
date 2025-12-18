namespace WebApplication2.DTOs.LessonAttachments
{
    public class LessonAttachmentDto
    {
        public int LessonAttachmentId { get; set; }

        public string FileUrl { get; set; } = string.Empty;

        public string FileType { get; set; } = string.Empty;

        public int LessonId { get; set; }

        public DateTime? UploadedAt { get; set; }
    }
}
