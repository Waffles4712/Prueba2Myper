using System;
using System.Collections.Generic;

namespace CrudTrabajadores.Models;

public partial class TipoDocumento
{
    public int IdTipo { get; set; }

    public string? Tipodocumento1 { get; set; }

    public virtual ICollection<Trabajadore> Trabajadores { get; set; } = new List<Trabajadore>();
}
