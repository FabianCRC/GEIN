using GEIN.Models;
using GEIN.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GEIN.Controllers.Catalogos
{
    public class MarcasController : Controller
    {
        private string urlBase = "https://localhost:7068/";
        private string controller = "api/Marcas/";
        private IClientAPI<Marca> api;

        public MarcasController()
        {
            api = new ClientAPI<Marca>(urlBase, controller);
        }

        // GET: Marcas 
        public async Task<IActionResult> Index()
        {
            List<Marca> model = await api.getAllMethod();
            return View(model);
        }

        // GET: MarcasController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            Marca model = await api.getOneByIdMethod(id);
            return View(model);
        }

        // GET: MarcasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MarcasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Marca model)
        {
            if (ModelState.IsValid)
            {
                if (await api.addMethod(model))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }

        // GET: MarcasController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            Marca model = await api.getOneByIdMethod(id);
            return View(model);
        }

        // POST: MarcasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Marca model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await api.updateMethod(model.IdMarca, model);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: MarcasController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            await api.deleteMethod(id);//el metodo devuelve booleano del resultado de la operacion
            return RedirectToAction(nameof(Index));
        }

    }
}
