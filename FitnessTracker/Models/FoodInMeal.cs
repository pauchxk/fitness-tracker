using System;
using System.Collections.Generic;

namespace FitnessTracker.Models;

public partial class FoodInMeal
{
    public int FoodId { get; set; }

    public int MealId { get; set; }

    public decimal Amount { get; set; }

    public virtual Food Food { get; set; } = null!;

    public virtual Meal Meal { get; set; } = null!;
}
