using GEIN.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GEIN.Controllers
{
    public class MarcasController : Controller
    {
        private string urlBase = "https://localhost:7068/";

        // GET: Marcas 
        public async Task<IActionResult> Index()
        {
            List<Marca> aux = new List<Marca>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(urlBase);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.GetAsync("api/Marcas");

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<Marca>>(auxres);
                }
            }

            return View(aux);
        }

        // GET: MarcasController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            Marca aux = new Marca();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(urlBase);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.GetAsync("api/Marcas/" + id);

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<Marca>(auxres);
                }
            }
            return View(aux);
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
                using (var cl = new HttpClient())
                {
                    if (model.IdMarca != null)
                    {
                        cl.BaseAddress = new Uri(urlBase);
                        var content = JsonConvert.SerializeObject(model);
                        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                        var byteContent = new ByteArrayContent(buffer);
                        byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        var postTask = cl.PostAsync("api/Marcas", byteContent).Result;
                        if (postTask.IsSuccessStatusCode)
                        {
                            return RedirectToAction(nameof(Index));
                        }
                    }

                }

            }
            return View(model);
        }

        // GET: MarcasController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            Marca aux = new Marca();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(urlBase);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.GetAsync("api/Marcas/" + id);

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<Marca>(auxres);
                }
            }
            return View(aux);
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
                    using (var cl = new HttpClient())
                    {
                        cl.BaseAddress = new Uri(urlBase);
                        var content = JsonConvert.SerializeObject(model);
                        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                        var byteContent = new ByteArrayContent(buffer);
                        byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        var postTask = cl.PutAsync("api/Marcas/" + model.IdMarca, byteContent).Result;

                        if (postTask.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Index");
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: MarcasController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(urlBase);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.DeleteAsync("api/Marcas/" + id);
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
