using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

public partial class StudentAnswer
{
    [Key]
    public int Id { get; set; }

    public int AttemptId { get; set; }

    public int QuestionId { get; set; }

    public int? AnswerId { get; set; }

    public string? WrittenAnswer { get; set; }

    public bool IsCorrect { get; set; }

    [ForeignKey("AnswerId")]
    [InverseProperty("StudentAnswers")]
    public virtual Answer? Answer { get; set; }

    [ForeignKey("AttemptId")]
    [InverseProperty("StudentAnswers")]
    public virtual QuizAttempt Attempt { get; set; } = null!;

    [ForeignKey("QuestionId")]
    [InverseProperty("StudentAnswers")]
    public virtual Question Question { get; set; } = null!;
}
