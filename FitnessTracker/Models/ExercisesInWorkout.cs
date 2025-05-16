using System;
using System.Collections.Generic;

namespace FitnessTracker.Models;

public partial class ExercisesInWorkout
{
    public int DworkoutId { get; set; }

    public int ExerciseId { get; set; }

    public decimal Weight { get; set; }

    public int Reps { get; set; }

    public int Rpe { get; set; }

    public int? Partials { get; set; }

    public string? Notes { get; set; }

    public virtual DailyWorkout Dworkout { get; set; } = null!;

    public virtual Exercise Exercise { get; set; } = null!;
}
