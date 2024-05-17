using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using torneos.Models;
using System.Data.Entity;

namespace torneos.Controllers
{
    public class TorneosController : Controller
    {
        private torneosContext db= new torneosContext();
        // GET: Torneos
        public ActionResult Index()
        {
            // Recuperar la relación con Municipio
            var torneo = db.Torneos.Include(mun => mun.Municipio); // para que funciones linq colocar using System.Data.Entity;
            return View(db.Torneos.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            //LLenar DropDownList con todos los municipios
            ViewBag.MunicipioId = new SelectList(db.Municipios, "MunicipioId", "Nombre");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Torneo torneo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Torneos.Add(torneo);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    if (e.InnerException != null)
                    {
                        ViewBag.ErrorMessage = e.Message;
                        ViewBag.MunicipioId = new SelectList(db.Municipios, "MunicipioId", "Nombre",torneo.MunicipioId);
                        return View(torneo);
                    }
                }
            }
            ViewBag.MunicipioId = new SelectList(db.Municipios, "MunicipioId", "Nombre", torneo.MunicipioId);
            return View(torneo);

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Torneo torneo = db.Torneos.Find(id);
            if (torneo != null)
            {
                ViewBag.MunicipioId = new SelectList(db.Municipios, "MunicipioId", "Nombre", torneo.MunicipioId);
                return View(torneo);
            }
            else
            {
                ViewBag.Info = ("Torneo no encontrado...");
                ViewBag.MunicipioId = new SelectList(db.Municipios, "MunicipioId", "Nombre", torneo.MunicipioId);
                return View();
            }

        }

        [HttpPost]
        public ActionResult Edit(Torneo torneo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(torneo).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    if (e.InnerException != null)
                    {
                        ViewBag.ErrorMessage = e.Message;
                        ViewBag.MunicipioId = new SelectList(db.Municipios, "MunicipioId", "Nombre", torneo.MunicipioId);
                        return View(torneo);
                    }
                }
            }
            ViewBag.MunicipioId = new SelectList(db.Municipios, "MunicipioId", "Nombre", torneo.MunicipioId);
            return View(torneo);

        }
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id != null)
            {
                Torneo torneo = db.Torneos.Find(id);
                return View(torneo);
            }
            return View();

        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            //Torneo torneo = db.Torneos.Find(id);
            var torneo = db.Torneos.Find(id);// select * from Torneos where TorneoId=id
            if (torneo != null)
            {
                return View(torneo);
            }
            else
            {
                ViewBag.Info = ("Torneo no encontrado...");
                return View();
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Torneo torneo = db.Torneos.Find(id);
            if (torneo != null)
            {
                try
                {
                    db.Torneos.Remove(torneo);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                catch (Exception)
                {
                    ViewBag.Error = ("El torneo no se ha eliminado...");
                    return View(torneo);

                }
            }
            return View();
        }


        //Metodo para gestionar la conexión con la base de datos
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