using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

[Table("LessonCompletion")]
public partial class LessonCompletion
{
    [Key]
    public int Id { get; set; }

    public int? LessonId { get; set; }

    public int? UserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CompletedDate { get; set; }

    [ForeignKey("LessonId")]
    [InverseProperty("LessonCompletions")]
    public virtual Lesson? Lesson { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("LessonCompletions")]
    public virtual User? User { get; set; }
}
