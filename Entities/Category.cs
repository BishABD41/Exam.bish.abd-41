using System;
using System.Collections.Generic;

namespace GGExam.Entities;

public partial class Category
{
    public int Categoryid { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
