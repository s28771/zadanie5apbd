using Microsoft.AspNetCore.Mvc;
using Tutorial4.Database;
using Tutorial4.Models;

namespace Tutorial4.Controllers;

[ApiController]
[Route("api/animals")]
public class AnimalController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAnimals()
    {
        var animals = StaticData.animals;
        return Ok(animals);
    }

    [HttpGet("{id}")]
    public IActionResult GetAnimal(int id)
    {
        var animal = FindAnimalById(id);
        return animal == null ? NotFound() : Ok(animal);
    }

    [HttpPost]
    public IActionResult AddAnimal([FromBody] Animal animal)
    {
        if (animal == null)
        {
            return BadRequest();
        }

        animal.Id = StaticData.animals.Max(a => a.Id) + 1;
        StaticData.animals.Add(animal);
        return CreatedAtAction(nameof(GetAnimal), new { id = animal.Id }, animal);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAnimal(int id, [FromBody] Animal animal)
    {
        if (animal == null)
        {
            return BadRequest();
        }

        var existingAnimal = FindAnimalById(id);
        if (existingAnimal == null)
        {
            return NotFound();
        }
        
        UpdateExistingAnimal(existingAnimal, animal);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animal = FindAnimalById(id);
        if (animal == null)
        {
            return NotFound();
        }

        StaticData.animals.Remove(animal);
        return Ok();
    }

    private Animal FindAnimalById(int id)
    {
        return StaticData.animals.FirstOrDefault(a => a.Id == id);
    }

    private void UpdateExistingAnimal(Animal existingAnimal, Animal newAnimalData)
    {
        existingAnimal.Name = newAnimalData.Name;
        existingAnimal.Category = newAnimalData.Category;
        existingAnimal.Weight = newAnimalData.Weight;
        existingAnimal.FurColor = newAnimalData.FurColor;
    }
}
