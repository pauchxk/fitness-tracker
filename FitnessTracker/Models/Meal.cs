using System;
using System.Collections.Generic;

namespace FitnessTracker.Models;

public partial class Meal
{
    public int MealId { get; set; }

    public string MealName { get; set; } = null!;

    public string Method { get; set; } = null!;

    public string? Notes { get; set; }

    public int Calories { get; set; }

    public int Protein { get; set; }

    public int? Fat { get; set; }

    public int? Carbohydrates { get; set; }

    public int? Fiber { get; set; }

    public string Type { get; set; } = null!;
}
