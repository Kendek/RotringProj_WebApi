using System;
using System.Collections.Generic;

namespace RotringWebApi2._0.Entities;

public partial class Tanulo
{
    public int Id { get; set; }

    public string Nev { get; set; } = null!;

    public string SzulHely { get; set; } = null!;

    public DateTime SzulIdo { get; set; }

    public string Anyjanev { get; set; } = null!;

    public string Lakcim { get; set; } = null!;

    public DateTime BeirIdo { get; set; }

    public string Szak { get; set; } = null!;

    public string Osztaly { get; set; } = null!;

    public int Kolise { get; set; }

    public string Koli { get; set; } = null!;

    public int Naploszam { get; set; }

    public int Torzsszam { get; set; }

    public string Matek { get; set; } = null!;

    public string Irodalom { get; set; } = null!;

    public string Nyelvtan { get; set; } = null!;

    public string Idegennyelv { get; set; } = null!;

    public string Tesi { get; set; } = null!;

    public string Fizika { get; set; } = null!;

    public string Szakma { get; set; } = null!;
}
