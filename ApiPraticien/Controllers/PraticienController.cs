using Microsoft.AspNetCore.Mvc;
using ApiPraticien.Models;
using ApiPraticien.Data;

[Route("api/[controller]")]
[ApiController]
public class PraticienController : ControllerBase
{
    private readonly PraticienService _praticienService;

    public PraticienController(PraticienService praticienService)
    {
        _praticienService = praticienService;
    }

    [HttpGet("{id}")]
    public IActionResult GetPraticienById(int id)
    {
        var praticien = _praticienService.GetPraticienById(id);
        if (praticien == null)
        {
            return NotFound();
        }

        // Vous pouvez retourner une réponse JSON
        return Ok(praticien);
    }

    [HttpPost]
    public IActionResult CreatePraticien([FromBody] Praticien praticien)
    {
        var createdPraticien = _praticienService.CreatePraticien(praticien);
        return CreatedAtAction(nameof(GetPraticienById), new { id = createdPraticien.Id }, createdPraticien);
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePraticien(int id, [FromBody] Praticien praticien)
    {
        var updatedPraticien = _praticienService.UpdatePraticien(id, praticien);
        if (updatedPraticien == null)
        {
            return NotFound();
        }

        return Ok(updatedPraticien);
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePraticien(int id)
    {
        var result = _praticienService.DeletePraticien(id);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}

