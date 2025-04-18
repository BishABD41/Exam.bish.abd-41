using System;
using System.Collections.Generic;

namespace GGExam.Entities;

public partial class Gender
{
    public int Genderid { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
