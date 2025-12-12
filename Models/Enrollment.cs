using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

public partial class Enrollment
{
    [Key]
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? CourseId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EnrolledAt { get; set; }

    public int? Progress { get; set; }

    public string? Status { get; set; }

    [ForeignKey("CourseId")]
    [InverseProperty("Enrollments")]
    public virtual Course? Course { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Enrollments")]
    public virtual User? User { get; set; }
}
