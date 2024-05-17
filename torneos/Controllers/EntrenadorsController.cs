using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using torneos.Models;

namespace torneos.Controllers
{
    public class EntrenadorsController : Controller
    {
        private torneosContext db = new torneosContext();

        // GET: Entrenadors
        public ActionResult Index()
        {
            return View(db.Entrenadores.ToList());
        }

        // GET: Entrenadors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrenador entrenador = db.Entrenadores.Find(id);
            if (entrenador == null)
            {
                return HttpNotFound();
            }
            return View(entrenador);
        }

        // GET: Entrenadors/Create
        public ActionResult Create()
        {
            ViewBag.Genero=ObtenerGenero();
            return View();
        }

        // POST: Entrenadors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EntrenadorId,Documento,Nombres,Apellidos,FechaNacimiento,Rh,Eps,Arl,Genero,Celular")] Entrenador entrenador)
        {
            if (ModelState.IsValid)
            {
                db.Entrenadores.Add(entrenador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Genero = ObtenerGenero();
            return View(entrenador);
        }

        // GET: Entrenadors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrenador entrenador = db.Entrenadores.Find(id);
            if (entrenador == null)
            {
                return HttpNotFound();
            }
            return View(entrenador);
        }

        // POST: Entrenadors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EntrenadorId,Documento,Nombres,Apellidos,FechaNacimiento,Rh,Eps,Arl,Genero,Celular")] Entrenador entrenador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entrenador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(entrenador);
        }

        // GET: Entrenadors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrenador entrenador = db.Entrenadores.Find(id);
            if (entrenador == null)
            {
                return HttpNotFound();
            }
            return View(entrenador);
        }

        // POST: Entrenadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Entrenador entrenador = db.Entrenadores.Find(id);
            db.Entrenadores.Remove(entrenador);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private List<SelectListItem> ObtenerGenero()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text="Seleccione Genero",
                    Value="Seleccionar",
                    Selected=true,
                },
                new SelectListItem()
                {
                    Text="Femenino",
                    Value="Femenino"
                },
                new SelectListItem()
                {
                    Text="Masculino",
                    Value="Masculino"
                },
                new SelectListItem()
                {
                    Text="Otro",
                    Value="Otro"
                },
            };
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
