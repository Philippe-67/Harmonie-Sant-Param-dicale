﻿
using Microsoft.AspNetCore.Mvc;
using ApiRdv.Models;


[Route("api/[controller]")]
[ApiController]
public class RdvController : ControllerBase
{
    private readonly RdvService _rdvService;

    public RdvController(RdvService rdvService)
    {
        _rdvService = rdvService;
    }
    [HttpGet]
    public IActionResult GetAllRdv()
    {
        var allRdv = _rdvService.GetAllRdv();
        return Ok(allRdv);
    }


    [HttpGet("{id}")]
    public IActionResult GetRdvById(int id)
    {
        var rdv = _rdvService.GetRdvById(id);
        if (rdv == null)
        {
            return NotFound();
        }

        // Vous pouvez retourner une réponse JSON
        return Ok(rdv);
    }

    [HttpPost]
    public IActionResult CreateRdv([FromBody] Rdv rdv)
    {
        var createdRdv = _rdvService.CreateRdv(rdv);
        return CreatedAtAction(nameof(GetRdvById), new { id = createdRdv.Id }, createdRdv);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateRdv(int id, [FromBody] Rdv rdv)
    {
        var updatedRdv = _rdvService.UpdateRdv(id, rdv);
        if (updatedRdv == null)
        {
            return NotFound();
        }

        return Ok(updatedRdv);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteRdv(int id)
    {
        var result = _rdvService.DeleteRdv(id);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}
