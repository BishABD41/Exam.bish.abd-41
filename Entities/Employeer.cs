using System;
using System.Collections.Generic;

namespace GGExam.Entities;

public partial class Employeer
{
    public int Employeeid { get; set; }

    public string? Fio { get; set; }

    public DateOnly? Birthday { get; set; }

    public string? Tel { get; set; }

    public string? Email { get; set; }

    public string? Adres { get; set; }
}
