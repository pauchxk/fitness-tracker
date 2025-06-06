using System;
using System.Collections.Generic;

namespace FitnessTracker.Models;

public partial class DailyWorkout
{
    public int DworkoutId { get; set; }

    public int LogId { get; set; }

    public bool PreWorkout { get; set; }

    public string? Notes { get; set; }

    public virtual ICollection<ExercisesInWorkout> ExercisesInWorkouts { get; set; } = new List<ExercisesInWorkout>();

    public virtual DailyLog Log { get; set; } = null!;
}
