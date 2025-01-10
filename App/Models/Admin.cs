using System;
using System.Collections.Generic;

namespace App.Models;

public partial class Admin
{
    public int Adminid { get; set; }

    public int? Employeeid { get; set; }

    public string Username { get; set; } = null!;

    public string Passwordhash { get; set; } = null!;

    public DateTime? Createdat { get; set; }

    public virtual Employee? Employee { get; set; }
}
