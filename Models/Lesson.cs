using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

public partial class Lesson
{
    [Key]
    public int Id { get; set; }

    public int? CourseId { get; set; }

    [StringLength(255)]
    public string? Title { get; set; }

    [StringLength(255)]
    public string? Content { get; set; }

    public string? VideoUrl { get; set; }

    public int? OrderNumber { get; set; }

    public int? EstimatedDuration { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [ForeignKey("CourseId")]
    [InverseProperty("Lessons")]
    public virtual Course? Course { get; set; }

    [InverseProperty("Lesson")]
    public virtual ICollection<LessonAttachment> LessonAttachments { get; set; } = new List<LessonAttachment>();

    [InverseProperty("Lesson")]
    public virtual ICollection<LessonCompletion> LessonCompletions { get; set; } = new List<LessonCompletion>();

    [InverseProperty("Lesson")]
    public virtual ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();
}
