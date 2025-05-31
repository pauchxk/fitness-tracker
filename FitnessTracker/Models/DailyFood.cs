using System;
using System.Collections.Generic;

namespace FitnessTracker.Models;

public partial class DailyFood
{
    public int Amount { get; set; }

    public int DfoodId { get; set; }

    public int? FoodId { get; set; }

    public int? MealId { get; set; }

    public string MealType { get; set; } = null!;

    public int? LogId { get; set; }

    public virtual Food? Food { get; set; }

    public virtual DailyNutrition? Log { get; set; }

    public virtual Meal? Meal { get; set; }
}
