using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

public partial class LessonAttachment
{
    [Key]
    public int Id { get; set; }

    public int? LessonId { get; set; }

    public string? FileUrl { get; set; }

    public string? FileType { get; set; }

    public string? FileName { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UploadedAt { get; set; }

    [ForeignKey("LessonId")]
    [InverseProperty("LessonAttachments")]
    public virtual Lesson? Lesson { get; set; }
}
