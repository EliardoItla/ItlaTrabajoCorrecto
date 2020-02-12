using ControlDelItla.Models;
using ControlDelItla.Models.TableView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlDelItla.Controllers
{
    public class EstudianteMateriaController : Controller
    {
        public ControlItlaEntities2 db = new ControlItlaEntities2();
        public ActionResult Index()
        {
            List<ListaSeleccionarMateria> lista;
            using (ControlItlaEntities2 db = new ControlItlaEntities2())
            {
                lista = (from l in db.EstudianteAsignaturas
                         select new ListaSeleccionarMateria
                         {
                             Id = l.id,
                             IdAsignatura = l.idAsignatura,
                             IdEstudiante = l.idEstudiante,
                             Asignatura = l.Asignatura,
                             Estudiante = l.Estudiante


                         }).ToList();
            }
            return View(lista);

        }
        public ActionResult Crear()
        {

            ViewBag.idAsignatura = new SelectList(db.Asignaturas.ToList(), "Id", "Nombre");
            ViewBag.idEstudiante = new SelectList(db.Estudiantes.ToList(), "Id", "Nombre");
            return View();

        }
        [HttpPost]
        public ActionResult Crear([Bind(Include = "id,idEstudiante,idAsignatura")] EstudianteAsignatura EstAsign)
        {
            if (ModelState.IsValid)
            {
                db.EstudianteAsignaturas.Add(EstAsign);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAsignatura = new SelectList(db.Asignaturas, "Id", "Nombre", EstAsign.idAsignatura);
            ViewBag.idEstudiante = new SelectList(db.Estudiantes, "Id", "Nombre", EstAsign.idEstudiante);
            return View(EstAsign);
        }

        public ActionResult Editar(int Id)
        {
            EstudianteAsignatura EstAsign = db.EstudianteAsignaturas.Find(Id);
            ViewBag.idAsignatura = new SelectList(db.Asignaturas.ToList(), "Id", "Nombre");
            ViewBag.idEstudiante = new SelectList(db.Estudiantes.ToList(), "Id", "Nombre");
            return View();

        }
        [HttpPost]
        public ActionResult Editar([Bind(Include = "id,idEstudiante,idAsignatura")] EstudianteAsignatura EstAsign)
        {
            if (ModelState.IsValid)
            {
                db.Entry(EstAsign).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAsignatura = new SelectList(db.Asignaturas, "Id", "Nombre", EstAsign.idAsignatura);
            ViewBag.idEstudiante = new SelectList(db.Profesors, "Id", "Nombre", EstAsign.idEstudiante);
            return View(EstAsign);
        }
        [HttpGet]
        public ActionResult Borrar(int Id)
        {


            EstudianteAsignatura EstAsign = db.EstudianteAsignaturas.Find(Id);
            db.EstudianteAsignaturas.Remove(EstAsign);
            db.SaveChanges();

            return Redirect("~/EstudianteMateria/");
        }
    }
}