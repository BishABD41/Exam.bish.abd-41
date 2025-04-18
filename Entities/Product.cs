using System;
using System.Collections.Generic;

namespace GGExam.Entities;

public partial class Product
{
    public int Productid { get; set; }

    public string? Name { get; set; }

    public string? Article { get; set; }

    public int? Price { get; set; }

    public DateOnly? Data { get; set; }

    public DateOnly? BestBeforeDate { get; set; }

    public string? Firm { get; set; }

    public string? CountryProduct { get; set; }

    public int? Categoryid { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
