using System;
using System.Collections.Generic;

namespace App.Models;

public partial class Attendancelog
{
    public int Logid { get; set; }

    public int? Employeeid { get; set; }

    public DateTime Eventtime { get; set; }

    public string Eventtype { get; set; } = null!;

    public string? NfcTagid { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Employee? NfcTag { get; set; }
}
