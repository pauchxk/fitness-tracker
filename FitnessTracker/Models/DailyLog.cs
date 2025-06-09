using System;
using System.Collections.Generic;

namespace FitnessTracker.Models;

public partial class DailyLog
{
    public int LogId { get; set; }

    public DateOnly LogDate { get; set; }

    public decimal? Weight { get; set; }

    public int? CaffeineIntake { get; set; }

    public decimal? SleepHours { get; set; }

    public int? Steps { get; set; }

    public virtual DailyNutrition? DailyNutrition { get; set; }

    public virtual DailyWorkout? DailyWorkout { get; set; }
}
