using Microsoft.AspNetCore.Mvc;
using AUT02_02_GaldonMario_Listas.Models;
using System.Xml.Linq;

namespace AUT02_02_GaldonMario_Listas.Controllers
{

    public class PersonajeController : Controller
    {

            public static List<Personaje> listaPersonaje = new List<Personaje>()
            {
                new Personaje() { Familia = "Familia1", Id = 1, Name = "Nombre1", NumHijos = 1 },
                new Personaje() { Familia = "Familia2", Id = 2, Name = "Joselito", NumHijos = 1 },
                new Personaje() { Familia = "Familia3", Id = 3, Name = "Manolo", NumHijos = 10 }
            };
          
        

        public IActionResult Index()
        {
            
            return View(listaPersonaje) ;
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Personaje personaje)
        {
            
            
            personaje.Id = listaPersonaje.Count + 1;
            
            if (ModelState.IsValid)
            {
                listaPersonaje.Add(personaje);
                return View("Index",listaPersonaje);
            }
            else
            {
                return View();
            }
        }
    }
}
