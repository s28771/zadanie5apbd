using Microsoft.AspNetCore.Mvc;
using Tutorial4.Database;
using Tutorial4.Models;

namespace Tutorial4.Controllers;

[ApiController]
[Route("api/visits")] // Consistent route naming convention
public class VisitController : ControllerBase
{
    [HttpGet("animal/{animalId}")]
    public IActionResult GetVisitsByAnimal(int animalId)
    {
        var visits = StaticData.visits.Where(v => v.AnimalId == animalId).ToList();
        if (!visits.Any())
        {
            return NotFound();
        }
        return Ok(visits);
    }

    [HttpPost]
    public IActionResult AddVisit([FromBody] Visit visit)
    {
        if (visit == null)
        {
            return BadRequest();
        }

        if (!StaticData.animals.Any(a => a.Id == visit.AnimalId))
        {
            return NotFound();
        }

        visit.Id = StaticData.visits.Count + 1; 
        StaticData.visits.Add(visit);
        return CreatedAtAction(nameof(GetVisitsByAnimal), new { id = visit.AnimalId }, visit);
    }
}