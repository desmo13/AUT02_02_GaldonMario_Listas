using Microsoft.AspNetCore.Mvc;
using AUT02_02_GaldonMario_Listas.Models;
using System.Xml.Linq;

namespace AUT02_02_GaldonMario_Listas.Controllers
{

    public class PersonajeController : Controller
    {

            public static List<Personaje> listaPersonaje = new List<Personaje>()
            {
                new Personaje() { Familia = "Familia1", Id = 0, Nombre = "Nombre1", NumeroHijos = 1 },
                new Personaje() { Familia = "Familia2", Id = 1, Nombre = "Joselito", NumeroHijos = 1 },
                new Personaje() { Familia = "Familia3", Id = 2, Nombre = "Manolo", NumeroHijos = 10 }
            };
          
        private int GeneradorId(List<Personaje> lista)
        {
            int indice =0;
            int posibleId=0;

            bool final=false;
            while (!final)
            {
                if (indice < lista.Count)
                {
                    if (lista[indice].Id != posibleId)
                    {
                        final = true;
                    }
                    else
                    {
                        indice++;
                        posibleId++;
                    }

                }
                else
                {

                    final = true;
                }
                
                
                    
                
               

            }
            return posibleId;
        }

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
            
            
            personaje.Id = GeneradorId(listaPersonaje);
            
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

        /*Funcion que es llamada cuando se apreta el boton de borrar de la lista 
         * Cada boton que se genera en el formulario se genera con un valor que envia diferente que es el ID de la persona 
         * Luego lo recogemos en esta funcion y en un bucle foreach vamos comparando si encuentra un id en la lista igual al enviado lo borra y sale del bucle con un break
         * 
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
