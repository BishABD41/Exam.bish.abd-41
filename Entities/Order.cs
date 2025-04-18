using System;
using System.Collections.Generic;

namespace GGExam.Entities;

public partial class Order
{
    public int Orderid { get; set; }

    public string? Fio { get; set; }

    public string? Tel { get; set; }

    public string? Email { get; set; }

    public string? Discount { get; set; }

    public int? Quantity { get; set; }

    public int? Genderid { get; set; }

    public int? StatusId { get; set; }

    public int? ProductsId { get; set; }

    public virtual Gender? Gender { get; set; }

    public virtual Product? Products { get; set; }

    public virtual Status? Status { get; set; }
}
