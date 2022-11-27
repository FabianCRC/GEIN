using GEIN.Models;
using GEIN.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GEIN.Controllers.Catalogos
{
    public class CategoriasController : Controller
    {
        private string urlBase = "https://localhost:7068/";
        private string controller = "api/Categorias/";
        private IClientAPI<Categoria> api;

        public CategoriasController()
        {
            api = new ClientAPI<Categoria>(urlBase, controller);
        }

        // GET: Categorias 
        public async Task<IActionResult> Index()
        {
            List<Categoria> model = await api.getAllMethod();
            return View(model);
        }

        // GET:CategoriasController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            Categoria model = await api.getOneByIdMethod(id);
            return View(model);
        }

        // GET: CategoriasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Categoria model)
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

        // GET: CategoriasController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            Categoria model = await api.getOneByIdMethod(id);
            return View(model);
        }

        // POST: CategoriasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Categoria model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await api.updateMethod(model.IdCategoria, model);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: CategoriasController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            await api.deleteMethod(id);//el metodo devuelve booleano del resultado de la operacion
            return RedirectToAction(nameof(Index));
        }
    }
}
