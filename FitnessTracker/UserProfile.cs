using System;
using System.Collections.Generic;

namespace FitnessTracker;

public partial class UserProfile
{
    public string UserName { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public decimal Height { get; set; }

    public decimal Weight { get; set; }
}
