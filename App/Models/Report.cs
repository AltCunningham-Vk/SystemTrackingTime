using System;
using System.Collections.Generic;

namespace App.Models;

public partial class Report
{
    public int Reportid { get; set; }

    public int? Employeeid { get; set; }

    public DateTime Checkintime { get; set; }

    public DateTime? Checkouttime { get; set; }

    public DateTime? Createdat { get; set; }

    public virtual Employee? Employee { get; set; }
}
