using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

public partial class Course
{
    [Key]
    public int Id { get; set; }

    [StringLength(255)]
    public string? Title { get; set; }

    public string? ShortDescription { get; set; }

    public string? LongDescription { get; set; }

    [StringLength(255)]
    public string? ThumbNail { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    public bool? IsPublished { get; set; }

    public int? CategoryId { get; set; }

    public int? DifficultyLevelId { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Courses")]
    public virtual Category? Category { get; set; }

    [InverseProperty("Course")]
    public virtual ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();

    [ForeignKey("CreatedBy")]
    [InverseProperty("Courses")]
    public virtual User? CreatedByNavigation { get; set; }

    [ForeignKey("DifficultyLevelId")]
    [InverseProperty("Courses")]
    public virtual DifficultyLevel? DifficultyLevel { get; set; }

    [InverseProperty("Course")]
    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    [InverseProperty("Course")]
    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

    [InverseProperty("Course")]
    public virtual ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();
}
