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
    public class PersonasController : Controller
    {
        private readonly PersonaDbContext _context;

        public PersonasController(PersonaDbContext context)
        {
            _context = context;
        }

        // GET: Personas
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("http://localhost:5123/api/apipersona");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var personas = JsonConvert.DeserializeObject<List<Persona>>(content);
                return View(personas);
            }
            else
            {
                return View(new List<Persona>());
            }
        }

        // GET: Personas/Details/5
        // GET: Personas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"http://localhost:5123/api/apipersona/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var persona = JsonConvert.DeserializeObject<Persona>(content);
                return View(persona);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: Personas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Personas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cc,Nombre,Apellido,Genero,Edad")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                var httpClient = new HttpClient();
                var json = JsonConvert.SerializeObject(persona);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("http://localhost:5123/api/apipersona", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error al crear la persona.");
                }
            }
            return View(persona);
        }

        // GET: Personas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"http://localhost:5123/api/apipersona/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var persona = JsonConvert.DeserializeObject<Persona>(content);
                return View(persona);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: Personas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cc,Nombre,Apellido,Genero,Edad")] Persona persona)
        {
            if (id != persona.Cc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var httpClient = new HttpClient();
                var json = JsonConvert.SerializeObject(persona);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync($"http://localhost:5123/api/apipersona/{id}", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error al actualizar la persona.");
                }
            }
            return View(persona);
        }

        // GET: Personas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"http://localhost:5123/api/apipersona/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var persona = JsonConvert.DeserializeObject<Persona>(content);
                return View(persona);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.DeleteAsync($"http://localhost:5123/api/apipersona/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error al eliminar la persona.");
                return RedirectToAction(nameof(Index)); // Otra opción: return View("Error");
            }
        }

    }
}
