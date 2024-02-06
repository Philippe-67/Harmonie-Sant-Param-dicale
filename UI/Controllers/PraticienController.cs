//using Microsoft.AspNetCore.Mvc;

//namespace UI.Controllers
//{
//    public class PraticienController1 : Controller
//    {
//        public IActionResult Index()
//        {
//            return View();
//        }
//    }
//}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UI.Models; // Assurez-vous d'ajuster le namespace

public class PraticienController : Controller
{
    private readonly HttpClient _httpClient;

    public PraticienController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
        
        _httpClient.BaseAddress = new Uri("https://LocalHost:5000"); // Assurez-vous d'ajuster l'URL de l'API

    }

    public async Task<IActionResult> Index()
    {
        try
        {
            var response = await _httpClient.GetAsync("/api/praticien");

            if (response.IsSuccessStatusCode)
            {
                var praticienList = await response.Content.ReadFromJsonAsync<List<Praticien>>();
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
