using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UI.Models;


public class PraticienController : Controller
{
    private readonly HttpClient _httpClient;

    public PraticienController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
        
        _httpClient.BaseAddress = new Uri("https://LocalHost:5000"); // Assurez-vous d'ajuster l'URL de l'API

    }
    //methode pour obtenir les elts de ViewBag .PraticienList
    public async Task<IActionResult> Index()
    {
        try
        {
            var response = await _httpClient.GetAsync("/api/praticien");

            if (response.IsSuccessStatusCode)
            {
                var praticienList = await response.Content.ReadFromJsonAsync<List<Praticien>>();
                ViewBag.PraticiensList = new SelectList(praticienList, "Id", "Nom");
                return View(praticienList);

            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                return View("Error", errorMessage);
            }
        }
        catch (Exception ex)
        {
            return View("Error", ex.Message);
        }
    }
    [HttpPost]//pour gérer la soumission du formulaire avec la DropDownList sélectionnée.
    public IActionResult Index(int PraticienId)
    {
        // Faites quelque chose avec l'ID du praticien, par exemple, redirigez vers une action qui affiche l'agenda
        return RedirectToAction("AfficherAgenda", new { praticienId = PraticienId });
    }


    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Praticien Praticien)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("/api/praticien", Praticien);

            if (response.IsSuccessStatusCode)
            {
                // Redirigez vers la liste des rendez-vous après la création réussie
                return RedirectToAction("Index");
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                return View("Error", errorMessage);
            }
        }
        catch (Exception ex)
        {
            return View("Error", ex.Message);
        }
    }
}
