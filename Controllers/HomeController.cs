using CrudTrabajadores.Models;
using CrudTrabajadores.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace CRUDTrabajador.Controllers
{
    public class HomeController : Controller
    {
        private readonly TrabajadoresPruebaContext _DBcontext;

        public HomeController(TrabajadoresPruebaContext context)
        {
            _DBcontext = context;
        }

        public IActionResult Index()
        {
            List<Trabajadore> lista = _DBcontext.Trabajadores.Include(d => d.oDepartamento).Include(p => p.oProvincia).Include(i => i.oDistrito).Include(s => s.oSexo).Include(t => t.oTipodocumento).ToList();
            return View(lista);
            
        }

        //Empleado detalle
        [HttpGet]
        public IActionResult Trabajadore_Detalle(int Id)
        {
            TrabajadoreVM oTrabajadoreVM = new TrabajadoreVM()
            {
                oTrabajadore = new Trabajadore(),
                oListaTipodocumento=_DBcontext.TipoDocumento.Select(tipodocumento => new SelectListItem()
                {
                    Text = tipodocumento.Tipodocumento1,
                    Value = tipodocumento.IdTipo.ToString()
                }).ToList(),
                oListaSexo = _DBcontext.Sexo.Select(sexo => new SelectListItem()
                {
                    Text = sexo.Sexo1,
                    Value = sexo.IdSexo.ToString()
                }).ToList(),

                oListaDepartamento = _DBcontext.Departamentos.Select(departamento => new SelectListItem()
                {
                    Text = departamento.NombreDepartamento,
                    Value = departamento.Id.ToString()
                }).ToList(),
                oListaProvincia = _DBcontext.Provincia.Select(provincium => new SelectListItem()
                {
                    Text = provincium.NombreProvincia,
                    Value = provincium.Id.ToString()
                }).ToList(),
                oListaDistrito = _DBcontext.Distritos.Select(distrito => new SelectListItem()
                {
                    Text = distrito.NombreDistrito,
                    Value = distrito.Id.ToString()
                }).ToList()


            };
            if (Id != 0)
            {
                oTrabajadoreVM.oTrabajadore = _DBcontext.Trabajadores.Find(Id);
            }
            return View(oTrabajadoreVM);
        }

        [HttpPost]
        public IActionResult Trabajadore_Detalle(TrabajadoreVM oTrabajadoreVM)
        {
            if (oTrabajadoreVM.oTrabajadore.Id == 0)
            {
                _DBcontext.Trabajadores.Add(oTrabajadoreVM.oTrabajadore);
            }
            else
            {
                _DBcontext.Trabajadores.Update(oTrabajadoreVM.oTrabajadore);
            }

            _DBcontext.SaveChanges();


            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Eliminar(int Id)
        {
            Trabajadore oTrabajadore = _DBcontext.Trabajadores.Include(d => d.oDepartamento).Where(u => u.Id == Id).FirstOrDefault();

            return View(oTrabajadore);
        }


        [HttpPost]
        public IActionResult Eliminar(Trabajadore oTrabajadore, bool confirmacion)
        {
            _DBcontext.Trabajadores.Remove(oTrabajadore);
            _DBcontext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult GetProvincias(int idDepartamento)
        {
            var provincias = _DBcontext.Provincia.Where(p => p.IdDepartamento == idDepartamento).ToList();

            return Json(provincias);
        }

        [HttpGet]
        public IActionResult GetDistritos(int idProvincia)
        {
            var distritos = _DBcontext.Distritos.Where(d => d.IdProvincia == idProvincia).ToList();

            return Json(distritos);
        }

    }
}