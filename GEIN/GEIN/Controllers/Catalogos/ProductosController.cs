using GEIN.Models;
using GEIN.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GEIN.Controllers.Catalogos
{
    public class ProductosController : Controller
    {
        private string urlBase = "https://localhost:7068/";
        private string controller = "api/Productos/";
        private IClientAPI<Producto> api;

        public ProductosController()
        {
            api = new ClientAPI<Producto>(urlBase, controller);
        }

        // GET: Marcas 
        public async Task<IActionResult> Index()
        {
            List<Producto> model = await api.getAllMethod();
            return View(model);
        }

        // GET: MarcasController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            Producto model = await api.getOneByIdMethod(id);
            return View(model);
        }

        // GET: MarcasController/Create
        public ActionResult Create()
        {
            CargarCombosProductos();
            return View();
        }

        // POST: MarcasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Producto model)
        {
            if (ModelState.IsValid)
            {
                if (await api.addMethod(model))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            CargarCombosProductos();
            return View(model);
        }

        // GET: MarcasController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            Producto model = await api.getOneByIdMethod(id);
            CargarCombosProductos();
            return View(model);
        }

        // POST: MarcasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Producto model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await api.updateMethod(model.IdProducto, model);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction("Index");
            }
            CargarCombosProductos();
            return View(model);
        }

        // GET: MarcasController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            await api.deleteMethod(id);//el metodo devuelve booleano del resultado de la operacion
            return RedirectToAction(nameof(Index));
        }

        private async void CargarCombosProductos()
        {
            SelectList listaCategorias = new SelectList(await new ClientAPI<Categoria>(urlBase, "api/Categorias").getAllMethod(), "IdCategoria", "Descripcion");
            SelectList listaMarcas = new SelectList(await new ClientAPI<Marca>(urlBase, "api/Marcas").getAllMethod(), "IdMarca", "Descripcion");
            TempData["listaCategorias"] = listaCategorias;
            TempData["listaMarcas"] = listaMarcas;
        }
    }
}
