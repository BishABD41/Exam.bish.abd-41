using System;
using System.Collections.Generic;

namespace GGExam.Entities;

public partial class Status
{
    public int Statusid { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
