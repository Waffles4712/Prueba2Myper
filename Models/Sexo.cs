using System;
using System.Collections.Generic;

namespace CrudTrabajadores.Models;

public partial class Sexo
{
    public int IdSexo { get; set; }

    public string? Sexo1 { get; set; }

    public virtual ICollection<Trabajadore> Trabajadores { get; set; } = new List<Trabajadore>();
}
