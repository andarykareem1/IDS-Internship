using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

public partial class DifficultyLevel
{
    [Key]
    public int Id { get; set; }

    [Column("Name")] 
    public string? DifficultyName { get; set; }

    public string? Description { get; set; }

    public int? DiffcultyOrder { get; set; }

    [InverseProperty("DifficultyLevel")]
    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
