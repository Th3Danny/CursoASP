using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CursoASPAjax.IServices;
using CursoASPAjax.IServices.Services;

namespace CursoASPAjax.Controllers
{
    public class PersonasController : Controller
    {
        private readonly IPersonasService _service = new PersonasService();

        // GET: Personas
        public ActionResult Index(string term)
        {
            var personas = string.IsNullOrEmpty(term) 
                ? _service.ListarTodas() 
                : _service.FiltrarPersonas(term);
            return View(personas);
        }

        // GET: Personas/GetPersonasSuggestions?term=...
        public JsonResult GetPersonasSuggestions(string term)
        {
            var suggestions = _service.BuscarPersonas(term);
            return Json(suggestions, JsonRequestBehavior.AllowGet);
        }

        // GET: Personas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personas personas = _service.ObtenerPorId(id.Value);
            if (personas == null)
            {
                return HttpNotFound();
            }
            return View(personas);
        }

        // GET: Personas/Create
        public ActionResult Create()
        {
            ViewBag.idPais = new SelectList(_service.ListarPaises(), "Id", "Pais");
            return View();
        }

        // POST: Personas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Edad,idPais,Telefono")] Personas personas)
        {
            if (ModelState.IsValid)
            {
                _service.Insertar(personas);
                return RedirectToAction("Index");
            }

            ViewBag.idPais = new SelectList(_service.ListarPaises(), "Id", "Pais", personas.idPais);
            return View(personas);
        }

        // GET: Personas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personas personas = _service.ObtenerPorId(id.Value);
            if (personas == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPais = new SelectList(_service.ListarPaises(), "Id", "Pais", personas.idPais);
            return View(personas);
        }

        // POST: Personas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Edad,idPais,Telefono")] Personas personas)
        {
            if (ModelState.IsValid)
            {
                _service.Actualizar(personas);
                return RedirectToAction("Index");
            }
            ViewBag.idPais = new SelectList(_service.ListarPaises(), "Id", "Pais", personas.idPais);
            return View(personas);
        }

        // GET: Personas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personas personas = _service.ObtenerPorId(id.Value);
            if (personas == null)
            {
                return HttpNotFound();
            }
            return View(personas);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _service.Eliminar(id);
            return RedirectToAction("Index");
        }

        // GET: Personas/BuscarPersonaPais
        public ActionResult BuscarPersonaPais(int? idPais)
        {
            ViewBag.idPais = new SelectList(_service.ListarPaises(), "Id", "Pais", idPais);
            List<PersonasPorPaisVM> resultados = new List<PersonasPorPaisVM>();

            if (idPais != null)
            {
                resultados = _service.ListarPersonasPorPais(idPais.Value);
            }

            return View(resultados);
        }

        [HttpPost]
        public ActionResult cambioSlider(int min, int max)
        {
            var personas = _service.FiltrarPorEdad(min, max);
            return PartialView("_TablaPersonas", personas);
        }
    }
}
