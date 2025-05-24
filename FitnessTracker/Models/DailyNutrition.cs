using System;
using System.Collections.Generic;

namespace FitnessTracker.Models;

public partial class DailyNutrition
{
    public int LogId { get; set; }

    public int DfoodId { get; set; }

    public int Calories { get; set; }

    public int Protein { get; set; }

    public int? Fat { get; set; }

    public int? Carbohydrates { get; set; }

    public int? Fiber { get; set; }

    public virtual DailyFood Dfood { get; set; } = null!;

    public virtual DailyLog Log { get; set; } = null!;
}
