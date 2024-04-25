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
    public class ProfesionsController : Controller
    {
        private readonly PersonaDbContext _context;

        public ProfesionsController(PersonaDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("http://localhost:5123/api/apiprofesion");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var profesions = JsonConvert.DeserializeObject<List<Profesion>>(content);
                return View(profesions);
            }
            else
            {
                return View(new List<Profesion>());
            }
        }

        // GET: Profesions/Details/5
        // GET: Profesions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"http://localhost:5123/api/apiprofesion/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var profesions = JsonConvert.DeserializeObject<Profesion>(content);
                return View(profesions);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: Profesions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Profesions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Des")] Profesion profesion)
        {
            if (ModelState.IsValid)
            {
                var httpClient = new HttpClient();
                var json = JsonConvert.SerializeObject(profesion);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("http://localhost:5123/api/apiprofesion", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error al crear la profesion.");
                }
            }
            return View(profesion);
        }

        // GET: Profesions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"http://localhost:5123/api/apiprofesion/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var profesion = JsonConvert.DeserializeObject<Profesion>(content);
                return View(profesion);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: Profesions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Des")] Profesion profesion)
        {
            if (id != profesion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var httpClient = new HttpClient();
                var json = JsonConvert.SerializeObject(profesion);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync($"http://localhost:5123/api/apiprofesion/{id}", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error al actualizar la profesiion.");
                }
            }
            return View(profesion);
        }

        // GET: Profesion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"http://localhost:5123/api/apiprofesion/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var profesion = JsonConvert.DeserializeObject<Profesion>(content);
                return View(profesion);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: Profesions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.DeleteAsync($"http://localhost:5123/api/apiprofesion/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error al eliminar la profesion.");
                return RedirectToAction(nameof(Index)); // Otra opción: return View("Error");
            }
        }
    }
}
