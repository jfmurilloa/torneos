using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using torneos.Models;
using System.Data.Entity;

namespace torneos.Controllers
{
    public class MunicipiosController : Controller
    {
        //Objeto de tipo Context para acceder a las opciones ORM
        private torneosContext db = new torneosContext();

        // GET: Municipios
        public ActionResult Index()
        {
            return View(db.Municipios.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Municipio municipio)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Municipios.Add(municipio);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }                
                catch (Exception e)
                {
                    if (e.InnerException != null && e.InnerException.InnerException != null
                        && e.InnerException.InnerException.Message.Contains("IndexNombre"))
                    {
                        ViewBag.ErrorMessage = ("Error, ya hay un Municipio con el nombre: " + municipio.Nombre);
                        return View(municipio);
                    }                    
                }
            }
            return View(municipio);

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Municipio municipio = db.Municipios.Find(id);
            if (municipio != null)
            {
                return View(municipio);
            }
            else
            {
                ViewBag.Info = ("Municipio no encontrado...");
                return View();
            }
            
        }

        [HttpPost]
        public ActionResult Edit(Municipio municipio)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(municipio).State= EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    if (e.InnerException != null && e.InnerException.InnerException != null
                        && e.InnerException.InnerException.Message.Contains("IndexNombre"))
                    {
                        ViewBag.ErrorMessage = ("Error, ya hay un Municipio con el nombre: " + municipio.Nombre);
                        return View(municipio);
                    }
                }
            }
            return View(municipio);

        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Municipio municipio = db.Municipios.Find(id);
            if (municipio != null)
            {
                return View(municipio);
            }
            else
            {
                ViewBag.Info = ("Municipio no encontrado...");
                return View();
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Municipio municipio = db.Municipios.Find(id);
            if (municipio != null)
            {
                try
                {
                    db.Municipios.Remove(municipio);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                catch (Exception e)
                {
                    if (e.InnerException != null && e.InnerException.InnerException != null
                        && e.InnerException.InnerException.Message.Contains("REFERENCE"))
                    {
                        ViewBag.Error = ("No se puede eliminar, existen torneos asociados a este municipio");
                        return View(municipio);
                    }
                    else if (e.InnerException != null)
                    {
                        ViewBag.Error = e.Message;
                        return View(municipio);
                    }                   

                }
            }
            return View();
        }

        

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id != null)
            {
                Municipio municipio = db.Municipios.Find(id);
                return View(municipio);
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