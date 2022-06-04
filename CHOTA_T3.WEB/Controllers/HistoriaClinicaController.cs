using CHOTA_T3.WEB.BD;
using CHOTA_T3.WEB.Models;
using CHOTA_T3.WEB.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CHOTA_T3.WEB.Controllers
{
    [Authorize]
    public class HistoriaClinicaController : Controller
    {
        private DbEntities _DbEntities;
        public HistoriaClinicaController(DbEntities dbEntities)
        {
            _DbEntities = dbEntities;
        }

        public IActionResult Listar()
        {
            var item = _DbEntities.historiaClinicas
                .Include(o => o.mascota)
                .Include(o => o.mascota.dueño)
                .ToList();
            return View(item);
        }
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Crear(AuxClass Datos)
        {
            Dueño dueño = new Dueño();
            Mascota mascota = new Mascota();
            HistoriaClinica historiaClinica = new HistoriaClinica();

            dueño.Nombre = Datos.NombreDueño;
            dueño.Direccion = Datos.Direccion;
            dueño.Telefono = Datos.Telefono;
            dueño.Email = Datos.Email;

            _DbEntities.dueños.Add(dueño);
            _DbEntities.SaveChanges();

            mascota.Sexo = Datos.Sexo;
            mascota.Especie = Datos.Especie;
            mascota.Raza = Datos.Raza;
            mascota.Tamaño = Datos.Tamaño;
            mascota.IdDueño = _DbEntities.dueños.First(o => o.Nombre == Datos.NombreMascota).id;
            _DbEntities.mascotas.Add(mascota);
            _DbEntities.SaveChanges();

            historiaClinica.FechaRegistro = Datos.FechaRegistro;
            historiaClinica.IdMascota = _DbEntities.mascotas.First(o => o.NombreMascota == Datos.NombreMascota).Id;
            _DbEntities.historiaClinicas.Add(historiaClinica);
            _DbEntities.SaveChanges();

            //return RedirectToAction("Listar", "HistoriaClinica");
            return View("Listar", Datos);
        }
        private Usuarios GetLoggedUser()
        {
            var claim = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name);
            var username = claim.Value;

            return _DbEntities.usuarios.First(o => o.Username == username);
        }
    }
}
