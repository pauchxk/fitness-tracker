using System;
using System.Collections.Generic;

namespace FitnessTracker.Models;

public partial class DailyFood
{
    public decimal? Amount { get; set; }

    public int DfoodId { get; set; }

    public int? FoodId { get; set; }

    public int? MealId { get; set; }

    public string? MealType { get; set; }

    public virtual ICollection<DailyNutrition> DailyNutritions { get; set; } = new List<DailyNutrition>();

    public virtual Food? Food { get; set; }

    public virtual Meal? Meal { get; set; }
}
