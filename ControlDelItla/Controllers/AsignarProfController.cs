using ControlDelItla.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ControlDelItla.Models.TableView;

namespace ControlDelItla.Controllers
{

    public class AsignarProfController : Controller
    {
        public ControlItlaEntities2 db = new ControlItlaEntities2();
        // GET: AsignarProf
        public ActionResult Index()
        {
                List<ListaAsignarProf> lista;
                using (ControlItlaEntities2 db = new ControlItlaEntities2())
                {
                lista = (from l in db.ProfesorAsignaturas
                         select new ListaAsignarProf
                         {
                             Id = l.id,
                             IdAsignatura = l.idAsignatura,
                             IdProfesor = l.idProfesor,
                             Asignatura = l.Asignatura,
                             Profesor = l.Profesor


                         }).ToList();
                }
                return View(lista);
            
        }
        public ActionResult Crear()
        {
            
                ViewBag.idAsignatura = new SelectList(db.Asignaturas.ToList(), "Id", "Nombre");
                ViewBag.idProfesor = new SelectList(db.Profesors.ToList(), "Id", "Nombre");
                return View();
            
        }
        [HttpPost]
        public ActionResult Crear([Bind(Include = "id,idProfesor,idAsignatura")] ProfesorAsignatura profAsign)
        {
            if (ModelState.IsValid)
            {
                db.ProfesorAsignaturas.Add(profAsign);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAsignatura = new SelectList(db.Asignaturas, "Id", "Nombre", profAsign.idAsignatura);
            ViewBag.idProfesor = new SelectList(db.Profesors, "Id", "Nombre", profAsign.idProfesor);
            return View(profAsign);
        }

        public ActionResult Editar(int Id)
        {
            ProfesorAsignatura profAsign = db.ProfesorAsignaturas.Find(Id);
            ViewBag.idAsignatura = new SelectList(db.Asignaturas.ToList(), "Id", "Nombre");
            ViewBag.idProfesor = new SelectList(db.Profesors.ToList(), "Id", "Nombre");
            return View();

        }
        [HttpPost]
        public ActionResult Editar([Bind(Include = "id,idProfesor,idAsignatura")] ProfesorAsignatura profAsign)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profAsign).State= System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAsignatura = new SelectList(db.Asignaturas, "Id", "Nombre", profAsign.idAsignatura);
            ViewBag.idProfesor = new SelectList(db.Profesors, "Id", "Nombre", profAsign.idProfesor);
            return View(profAsign);
        }
        [HttpGet]
        public ActionResult Borrar(int Id)
        {


            ProfesorAsignatura profAsign = db.ProfesorAsignaturas.Find(Id);
            db.ProfesorAsignaturas.Remove(profAsign);
            db.SaveChanges();
            
            return Redirect("~/AsignarProf/");
        }
        
    }
}
