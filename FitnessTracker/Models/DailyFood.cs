using System;
using System.Collections.Generic;

namespace FitnessTracker.Models;

public partial class DailyFood
{
    public int? LogId { get; set; }

    public int? FoodId { get; set; }

    public int? MealId { get; set; }

    public decimal? Amount { get; set; }

    public virtual Food? Food { get; set; }

    public virtual DailyLog? Log { get; set; }

    public virtual Meal? Meal { get; set; }
}
