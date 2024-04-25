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
    public class EstudiosController : Controller
    {
        private readonly PersonaDbContext _context;

        public EstudiosController(PersonaDbContext context)
        {
            _context = context;
        }


        // GET: estudios
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("http://localhost:5123/api/apiestudio");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var estudios = JsonConvert.DeserializeObject<List<Estudio>>(content);
                return View(estudios);
            }
            else
            {
                return View(new List<Estudio>());
            }
        }

        // GET: estudios/Details/5
        // GET: estudios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"http://localhost:5123/api/apiestudio/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var estudio = JsonConvert.DeserializeObject<Estudio>(content);
                return View(estudio);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: estudios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: estudios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cc,Nombre,Apellido,Genero,Edad")] Estudio estudio)
        {
            if (ModelState.IsValid)
            {
                var httpClient = new HttpClient();
                var json = JsonConvert.SerializeObject(estudio);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("http://localhost:5123/api/apiestudio", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error al crear el estudio.");
                }
            }
            return View(estudio);
        }

        // GET: estudios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"http://localhost:5123/api/apiestudio/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var estudio = JsonConvert.DeserializeObject<Estudio>(content);
                return View(estudio);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: estudios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int idProf, int ccPer, [Bind("IdProf,CcPer,Fecha,Univer")] Estudio estudio)
        {
            if(idProf != estudio.IdProf || ccPer != estudio.CcPer)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var httpClient = new HttpClient();
                var json = JsonConvert.SerializeObject(estudio);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync($"http://localhost:5123/api/apiestudio/{idProf}/{ccPer}", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error al actualizar la estudio.");
                }
            }
            return View(estudio);
        }

        // GET: estudios/Delete/5
        public async Task<IActionResult> Delete(int? idProf, int? ccPer)
        {
            if (idProf == null | ccPer == null)
            {
                return NotFound();
            }

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"http://localhost:5123/api/apiestudio//{idProf}/{ccPer}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var estudio = JsonConvert.DeserializeObject<Estudio>(content);
                return View(estudio);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: estudios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int idProf, int ccPer)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.DeleteAsync($"http://localhost:5123/api/apiestudio//{idProf}/{ccPer}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error al eliminar la estudio.");
                return RedirectToAction(nameof(Index)); // Otra opción: return View("Error");
            }
        }
    }
}
