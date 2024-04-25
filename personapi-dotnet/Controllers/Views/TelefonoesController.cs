using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers.Views
{
    public class TelefonoesController : Controller
    {
        private readonly PersonaDbContext _context;

        public TelefonoesController(PersonaDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("http://localhost:5123/api/apitelefono");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var telefonos = JsonConvert.DeserializeObject<List<Telefono>>(content);
                return View(telefonos);
            }
            else
            {
                return View(new List<Telefono>());
            }
        }

        // GET: Telefonos/Details/5
        public async Task<IActionResult> Details(string num)
        {
            if (string.IsNullOrEmpty(num))
            {
                return NotFound();
            }

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"http://localhost:5123/api/apitelefono/{num}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var telefono = JsonConvert.DeserializeObject<Telefono>(content);
                return View(telefono);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: Telefonos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Telefonos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Num,Oper,Duenio")] Telefono telefono)
        {
            if (ModelState.IsValid)
            {
                var httpClient = new HttpClient();
                var json = JsonConvert.SerializeObject(telefono);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("http://localhost:5123/api/apitelefono", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error al crear el teléfono.");
                }
            }
            return View(telefono);
        }

        // GET: Telefonos/Edit/5
        public async Task<IActionResult> Edit(string num)
        {
            if (string.IsNullOrEmpty(num))
            {
                return NotFound();
            }

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"http://localhost:5123/api/apitelefono/{num}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var telefono = JsonConvert.DeserializeObject<Telefono>(content);
                return View(telefono);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: Telefonos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string num, [Bind("Num,Oper,Duenio")] Telefono telefono)
        {
            if (num != telefono.Num)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var httpClient = new HttpClient();
                var json = JsonConvert.SerializeObject(telefono);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync($"http://localhost:5123/api/apitelefono/{num}", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error al actualizar el teléfono.");
                }
            }
            return View(telefono);
        }

        // GET: Telefonos/Delete/5
        public async Task<IActionResult> Delete(string num)
        {
            if (string.IsNullOrEmpty(num))
            {
                return NotFound();
            }

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"http://localhost:5123/api/apitelefono/{num}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var telefono = JsonConvert.DeserializeObject<Telefono>(content);
                return View(telefono);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: Telefonos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string num)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.DeleteAsync($"http://localhost:5123/api/apitelefono/{num}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error al eliminar el teléfono.");
                return RedirectToAction(nameof(Index)); // Otra opción: return View("Error");
            }
        }

    }
}
