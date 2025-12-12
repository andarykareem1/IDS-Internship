using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

public partial class InternshipDbContext : DbContext
{
    public InternshipDbContext()
    {
    }

    public InternshipDbContext(DbContextOptions<InternshipDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Answer> Answers { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Certificate> Certificates { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<DifficultyLevel> DifficultyLevels { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Lesson> Lessons { get; set; }

    public virtual DbSet<LessonAttachment> LessonAttachments { get; set; }

    public virtual DbSet<LessonCompletion> LessonCompletions { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Quiz> Quizzes { get; set; }

    public virtual DbSet<QuizAttempt> QuizAttempts { get; set; }

    public virtual DbSet<StudentAnswer> StudentAnswers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-EKPOH07H\\SQLEXPRESS;Database=OnlineLearningDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Answer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Answers__3214EC07270400FB");

            entity.HasOne(d => d.Question).WithMany(p => p.Answers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Answers_Questions");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC07689AAA7E");
        });

        modelBuilder.Entity<Certificate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Certific__3214EC070B73F727");

            entity.HasOne(d => d.Course).WithMany(p => p.Certificates).HasConstraintName("FK_Certificates_Courses");

            entity.HasOne(d => d.User).WithMany(p => p.Certificates).HasConstraintName("FK_Certificates_Users");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Courses__3214EC070371A4B6");

            entity.HasOne(d => d.Category).WithMany(p => p.Courses).HasConstraintName("FK_Courses_Categories");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Courses).HasConstraintName("FK_Courses_Users");

            entity.HasOne(d => d.DifficultyLevel).WithMany(p => p.Courses).HasConstraintName("FK_Courses_DifficultyLevels");
        });

        modelBuilder.Entity<DifficultyLevel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Difficul__3214EC079384F8A8");
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Enrollme__3214EC073C263BF7");

            entity.Property(e => e.Progress).HasDefaultValue(0);
            entity.Property(e => e.Status).HasDefaultValue("Active");

            entity.HasOne(d => d.Course).WithMany(p => p.Enrollments).HasConstraintName("FK_Enrollments_Courses");

            entity.HasOne(d => d.User).WithMany(p => p.Enrollments).HasConstraintName("FK_Enrollments_Users");
        });

        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Lessons__3214EC073F24961E");

            entity.HasOne(d => d.Course).WithMany(p => p.Lessons).HasConstraintName("FK_Lessons_Courses");
        });

        modelBuilder.Entity<LessonAttachment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LessonAt__3214EC07CCB4BECC");

            entity.HasOne(d => d.Lesson).WithMany(p => p.LessonAttachments).HasConstraintName("FK_LessonAttachments_Lessons");
        });

        modelBuilder.Entity<LessonCompletion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LessonCo__3214EC079557AEE9");

            entity.HasOne(d => d.Lesson).WithMany(p => p.LessonCompletions).HasConstraintName("FK_LessonCompletion_Lesson");

            entity.HasOne(d => d.User).WithMany(p => p.LessonCompletions).HasConstraintName("FK_LessonCompletion_Users");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Question__3214EC078645D265");

            entity.HasOne(d => d.Quiz).WithMany(p => p.Questions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Questions_Quizzes");
        });

        modelBuilder.Entity<Quiz>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Quizzes__3214EC073E9FA763");

            entity.HasOne(d => d.Course).WithMany(p => p.Quizzes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Quizzes_Courses");

            entity.HasOne(d => d.Lesson).WithMany(p => p.Quizzes).HasConstraintName("FK_Quizzes_Lessons");
        });

        modelBuilder.Entity<QuizAttempt>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__QuizAtte__3214EC072EC1DD55");

            entity.HasOne(d => d.Quiz).WithMany(p => p.QuizAttempts).HasConstraintName("FK_QuizAttempts_Quizzes");

            entity.HasOne(d => d.User).WithMany(p => p.QuizAttempts).HasConstraintName("FK_QuizAttempts_Users");
        });

        modelBuilder.Entity<StudentAnswer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StudentA__3214EC0742FFDB9A");

            entity.HasOne(d => d.Answer).WithMany(p => p.StudentAnswers).HasConstraintName("FK_StudentAnswers_Answers");

            entity.HasOne(d => d.Attempt).WithMany(p => p.StudentAnswers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentAnswers_Attempts");

            entity.HasOne(d => d.Question).WithMany(p => p.StudentAnswers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentAnswers_Questions");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07F9E57CFD");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
