

using ApiRdv.Models;
using Microsoft.AspNetCore.Mvc;
[Route("api/[controller]")]
[ApiController]
//[Route("api/rdv")]
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
        try
        {
            var rdvList = _rdvService.GetAllRdv();
            return Ok(rdvList);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur interne : {ex.Message}");
        }
    }
    // Nouvelle action pour récupérer les rendez-vous par praticien
    //[HttpGet("praticien/{id}")]
    //public IActionResult GetRdvByPraticien(int id)
    //{
    //    try
    //    {
    //        var rdvList = _rdvService.GetRdvByPraticien(id);
    //        return Ok(rdvList);
    //    }
    //    catch (Exception ex)
    //    {
    //        return StatusCode(500, $"Erreur interne : {ex.Message}");
    //    }
    //}


    [HttpGet("{id}")]
    public IActionResult GetRdvById(int id)
    {
        try
        {
            var rdv = _rdvService.GetRdvById(id);
            if (rdv == null)
            {
                return NotFound();
            }

            return Ok(rdv);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur interne : {ex.Message}");
        }
    }
    /// <summary>
    /// /////////////ici modification pour creer un rdv////////////////////////
    /// </summary>
    /// <param name="rdv"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult CreateRdv([FromBody] Rdv rdv)
    {
        try
        {
            var createdRdv = _rdvService.CreateRdv(rdv);
            return CreatedAtAction(nameof(GetRdvById), new { id = createdRdv.Id }, createdRdv);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur interne : {ex.Message}");
        }
    }

    // Autres actions pour la mise à jour, suppression, etc.
}
