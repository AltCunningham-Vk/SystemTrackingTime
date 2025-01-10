using System;
using System.Collections.Generic;

namespace App.Models;

public partial class Employee
{
    public int Employeeid { get; set; }

    public string Fullname { get; set; } = null!;

    public byte[]? Photo { get; set; }

    public string NfcTagid { get; set; } = null!;

    public DateTime? Createdat { get; set; }

    public virtual ICollection<Admin> Admins { get; set; } = new List<Admin>();

    public virtual ICollection<Attendancelog> AttendancelogEmployees { get; set; } = new List<Attendancelog>();

    public virtual ICollection<Attendancelog> AttendancelogNfcTags { get; set; } = new List<Attendancelog>();

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
}
