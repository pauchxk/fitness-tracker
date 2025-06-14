﻿using System;
using System.Collections.Generic;

namespace FitnessTracker.Models;

public partial class Exercise
{
    public int ExerciseId { get; set; }

    public string ExerciseName { get; set; } = null!;

    public string ExerciseType { get; set; } = null!;

    public string MuscleGroup { get; set; } = null!;

    public string? MuscleSubGroup { get; set; }

    public string? Notes { get; set; }

    public string Goal { get; set; } = null!;

    public string ReccommendedRepsSets { get; set; } = null!;

    public virtual ICollection<ExercisesInWorkout> ExercisesInWorkouts { get; set; } = new List<ExercisesInWorkout>();

    public virtual ICollection<PersonalRecord> PersonalRecords { get; set; } = new List<PersonalRecord>();
}
