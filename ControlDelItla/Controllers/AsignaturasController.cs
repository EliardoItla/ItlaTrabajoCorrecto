using ControlDelItla.Models;
using ControlDelItla.Models.TableView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlDelItla.Controllers
{
    public class AsignaturasController : Controller
    {
        // GET: Asignaturas
        public ActionResult Index()
        {
            List<AsignaturaView> lista;
            using (ControlItlaEntities2 db = new ControlItlaEntities2())
            {
                lista = (from l in db.Asignaturas
                         select new AsignaturaView
                         {
                             Id = l.Id,
                             Nombre = l.Nombre,
                             
                         }).ToList();
            }

            return View(lista);
        }
        public ActionResult Crear()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Crear(AsignaturaView model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    using (ControlItlaEntities2 db = new ControlItlaEntities2())
                    {
                        var tabla = new Asignatura();

                        tabla.Nombre = model.Nombre;

                        db.Asignaturas.Add(tabla);
                        db.SaveChanges();
                    }
                    return Redirect("~/Asignaturas/");
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
            AsignaturaView model = new AsignaturaView();
            using (ControlItlaEntities2 db = new ControlItlaEntities2())
            {
                var tabla = db.Asignaturas.Find(Id);

                model.Nombre = tabla.Nombre;
                model.Id = tabla.Id;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Editar(AsignaturaView model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ControlItlaEntities2 db = new ControlItlaEntities2())
                    {
                        var tabla = db.Asignaturas.Find(model.Id);

                        tabla.Nombre = model.Nombre;

                        db.Entry(tabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Asignaturas/");
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
                var tabla = db.Asignaturas.Find(Id);

                db.Asignaturas.Remove(tabla);
                db.SaveChanges();
            }
            return Redirect("~/Asignaturas/");
        }
    }
}
