using Microsoft.AspNetCore.Mvc;
using Tutorial4.Database;

namespace Tutorial4.Controllers;

[ApiController]
[Route("/animals-controller")]
// [Route("[controller]")]
public class AnimalsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAnimals()
    {
        var animals = new MockDb().Animals;
        return Ok(animals);
    }
    
    [HttpPost]
    public IActionResult AddAnimal()
    {
        return Created();
    }
}