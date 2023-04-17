using System;
using System.Collections.Generic;

namespace CrudTrabajadores.Models;

public partial class Trabajadore
{
    public int Id { get; set; }

    public string? NumeroDocumento { get; set; }

    public string? Nombres { get; set; }

    public int? IdSexo { get; set; }

    public int? IdTipo { get; set; }

    public int? IdDepartamento { get; set; }

    public int? IdProvincia { get; set; }

    public int? IdDistrito { get; set; }

    public virtual Departamento? oDepartamento { get; set; }

    public virtual Distrito? oDistrito { get; set; }

    public virtual Provincium? oProvincia { get; set; }

    public virtual Sexo? oSexo { get; set; }

    public virtual TipoDocumento? oTipodocumento { get; set; }
}
