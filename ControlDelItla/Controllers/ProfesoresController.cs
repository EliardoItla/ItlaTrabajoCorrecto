using ControlDelItla.Models;
using ControlDelItla.Models.TableView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlDelItla.Controllers
{
    public class ProfesoresController : Controller
    {
        // GET: Profesores
        public ActionResult Index()
        {
            List<TableClass> lista;
            using (ControlItlaEntities2 db = new ControlItlaEntities2())
            {
                lista = (from l in db.Profesors
                         select new TableClass
                         {
                             Id = l.Id,
                             Nombre = l.Nombre,
                             Apellido = l.Apellido,
                             Matricula = l.Matricula,
                             Fecha_de_Nacimiento = l.Fecha_Nacimiento
                         }).ToList();
            }

            return View(lista);
        }
        public ActionResult Crear()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Crear(CrearTableClass model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    using (ControlItlaEntities2 db = new ControlItlaEntities2())
                    {
                        var tabla = new Profesor();

                        tabla.Nombre = model.Nombre;
                        tabla.Apellido = model.Apellido;
                        tabla.Matricula = model.Matricula;
                        tabla.Fecha_Nacimiento = model.Fecha_de_Nacimiento;

                        db.Profesors.Add(tabla);
                        db.SaveChanges();
                    }
                    return Redirect("~/Profesores/");
                }

                return View(model);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ActionResult Editar(int Id)
        {
            CrearTableClass model = new CrearTableClass();
            using (ControlItlaEntities2 db = new ControlItlaEntities2())
            {
                var tabla = db.Profesors.Find(Id);

                model.Nombre = tabla.Nombre;
                model.Apellido = tabla.Apellido;
                model.Matricula = tabla.Matricula;
                model.Fecha_de_Nacimiento = tabla.Fecha_Nacimiento;
                model.Id = tabla.Id;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Editar(CrearTableClass model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ControlItlaEntities2 db = new ControlItlaEntities2())
                    {
                        var tabla = db.Profesors.Find(model.Id);

                        tabla.Nombre = model.Nombre;
                        tabla.Apellido = model.Apellido;
                        tabla.Matricula = model.Matricula;
                        tabla.Fecha_Nacimiento = model.Fecha_de_Nacimiento;

                        db.Entry(tabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Profesores/");
                }

                return View(model);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [HttpGet]
        public ActionResult Borrar(int Id)
        {
            using (ControlItlaEntities2 db = new ControlItlaEntities2())
            {
                var tabla = db.Profesors.Find(Id);

                db.Profesors.Remove(tabla);
                db.SaveChanges();
            }
            return Redirect("~/Profesores/");
        }
    }
}