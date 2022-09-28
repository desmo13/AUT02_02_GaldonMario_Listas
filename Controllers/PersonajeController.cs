using Microsoft.AspNetCore.Mvc;
using AUT02_02_GaldonMario_Listas.Models;
using System.Xml.Linq;

namespace AUT02_02_GaldonMario_Listas.Controllers
{

    public class PersonajeController : Controller
    {

            public static List<Personaje> listaPersonaje = new List<Personaje>()
            {
                new Personaje() { Familia = "Familia1", Id = 0, Name = "Nombre1", NumHijos = 1 },
                new Personaje() { Familia = "Familia2", Id = 1, Name = "Joselito", NumHijos = 1 },
                new Personaje() { Familia = "Familia3", Id = 2, Name = "Manolo", NumHijos = 10 }
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

        /*Funcion que es llamada cuando se apreta el boton de llamar de la lista 
         * Cada boton que se genera en el formulario se genera con un valor que envia diferente que es el ID de la persona 
         * Luego lo recogemos en esta funcion y en un bucle foreach vamos comparando si encuentra un id en la lista igual al enviado lo borra y sale del bucle con un break
         * PD:que pestano no vea que e metido un break en un blucle for si no me mata
         */
        public IActionResult Delete(int Id)
        {
            foreach(var elemento in listaPersonaje)
            {
                if (elemento.Id == Id)
                {
                    listaPersonaje.Remove(elemento);
                    break;
                }
            }

                
            
            return RedirectToAction("Index");
        }
    }
}
