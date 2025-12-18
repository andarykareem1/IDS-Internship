namespace WebApplication2.DTOs.Certificates
{
    public class CertificateDto
    {
        public int CertificateId { get; set; }
        public int CourseId { get; set; }
        public int UserId { get; set; }
        
        public DateTime? GeneratedAt { get; set; }
    }
}
