using Microsoft.AspNetCore.Mvc.Rendering;

namespace CrudTrabajadores.Models.ViewModels
{
    public class TrabajadoreVM
    {
        public Trabajadore oTrabajadore { get; set; }
        public List<SelectListItem> oListaDepartamento { get; set; }

        public List<SelectListItem> oListaProvincia { get; set; }

        public List<SelectListItem> oListaDistrito { get; set; }
        public List<SelectListItem> oListaTipodocumento { get; set; }
        public List<SelectListItem> oListaSexo { get; set; }

    }
}
