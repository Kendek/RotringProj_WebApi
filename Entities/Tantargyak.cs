using System;
using System.Collections.Generic;

namespace RotringWebApi2._0.Entities;

public partial class Tantargyak
{
    public int Id { get; set; }

    public string Tantargy { get; set; } = null!;

    public string Evfolyam { get; set; } = null!;

    public string KozSzak { get; set; } = null!;

    public int Hetiora { get; set; }

    public int Evesora { get; set; }
}
