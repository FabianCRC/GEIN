using GEIN.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;

namespace GEIN.Servicios
{
    public class ClientAPI<T> : IClientAPI<T>
    {
        private string _baseUrl;
        private string _controller;


        /// <summary>
        /// Clase para consumir API con metodos genericos de CRUD utilizando Generics
        /// </summary>
        /// <param name="baseUrl">Url base del API que se va a consumir</param>
        /// <param name="controller">Nombre del controlador que se va a consumir</param>
        public ClientAPI(string baseUrl, string controller)
        {
            this._baseUrl = baseUrl;
            this._controller = controller;
        }

        /// <summary>
        /// Metodo getAll generico
        /// </summary>
        /// <returns>Task<List<T>></returns>
        public async Task<List<T>> getAllMethod()
        {
            List<T> aux = new List<T>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync(_controller);
                if (res.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<List<T>>(res.Content.ReadAsStringAsync().Result);
                }
            }
            return default;
        }
        /// <summary>
        /// Metodo GetOneByIdGenerico generico
        /// </summary>
        /// <returns>Task<T></returns> 
        public async Task<T> getOneByIdMethod(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync(_controller + id);

                if (res.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<T>(res.Content.ReadAsStringAsync().Result);
                }
                return default;
            }
        }
        /// <summary>
        /// Metodo add generico
        /// </summary>
        /// <returns>Task<bool></returns> 
        public async Task<bool> addMethod(T t)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                var content = JsonConvert.SerializeObject(t);
                var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                var postTask = client.PostAsync(_controller, byteContent).Result;
                if (postTask.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;

            }
        }
        /// <summary>
        /// Metodo update generico
        /// </summary>
        /// <returns>Task<bool></returns> 
        public async Task<bool> updateMethod(int id, T t)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                var content = JsonConvert.SerializeObject(t);
                var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                var postTask = client.PutAsync(_controller + id, byteContent).Result;

                if (postTask.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }
        /// <summary>
        /// Metodo delete generico
        /// </summary>
        /// <returns>Task<bool></returns> 
        public async Task<bool> deleteMethod(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.DeleteAsync(_controller + id);
                if (res.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }

        }
    }
}
