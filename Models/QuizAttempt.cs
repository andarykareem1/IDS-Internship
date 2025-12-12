using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

public partial class QuizAttempt
{
    [Key]
    public int Id { get; set; }

    public int? QuizId { get; set; }

    public int? UserId { get; set; }

    public int? Score { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? AttemptDate { get; set; }

    [ForeignKey("QuizId")]
    [InverseProperty("QuizAttempts")]
    public virtual Quiz? Quiz { get; set; }

    [InverseProperty("Attempt")]
    public virtual ICollection<StudentAnswer> StudentAnswers { get; set; } = new List<StudentAnswer>();

    [ForeignKey("UserId")]
    [InverseProperty("QuizAttempts")]
    public virtual User? User { get; set; }
}
