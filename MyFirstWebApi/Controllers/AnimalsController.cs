using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstWebApi.Models;

namespace MyFirstWebApi.Controllers
{
    [Route("api/animals")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        List<Animals> _animals = new List<Animals>
            {
                new Animals {Id = 1, Name = "Steve", Type = "Elephant", Weight = 2000},
                new Animals {Id = 2, Name = "Gary", Type = "Monkey", Weight = 82},
                new Animals {Id =3, Name = "Raymond", Type = "Bird", Weight = 220}
            };

        // GET /api/animals
        [HttpGet]
        public IActionResult GetAllAnimals()
        {
            return Ok(_animals);
        }

        //GET /api/animals/{id}
        [HttpGet("{id}")]
        public IActionResult GetSingleAnimal(int id)
        {
            var animalIWant = _animals.FirstOrDefault(a => a.Id == id);

            if (animalIWant == null)
            {
                return NotFound($"Animal with the id {id} was not found.");
            }

            return Ok(animalIWant);
        }

        //POST /api/animals
        [HttpPost]
        public IActionResult AddAnAnimal(Animals animalToAdd)
        {
            _animals.Add(animalToAdd);

            return Ok(_animals);
        }

        //PUT /api/animals/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateAnAnimal(int id, Animals animal)
        {
            var animalToUpdate = _animals.FirstOrDefault(a => a.Id == id);

            if (animalToUpdate == null)
            {
                return NotFound("Can't update because it doesn't exist.");
            }

            animalToUpdate.Name = animal.Name;
            animalToUpdate.Weight = animal.Weight;
            animalToUpdate.Type = animal.Type;

            return Ok(animalToUpdate);
        }
    }
}