using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

public partial class Certificate
{
    [Key]
    public int Id { get; set; }

    public int? CourseId { get; set; }

    public int? UserId { get; set; }

    public string? DownloadUrl { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? GeneratedAt { get; set; }

    [ForeignKey("CourseId")]
    [InverseProperty("Certificates")]
    public virtual Course? Course { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Certificates")]
    public virtual User? User { get; set; }
}
