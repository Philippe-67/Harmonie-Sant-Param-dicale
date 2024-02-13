using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UI.Models; // Assurez-vous d'ajuster le namespace

public class RdvController : Controller
{
    private readonly HttpClient _httpClient;

    public RdvController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
        //  _httpClient.BaseAddress = new Uri("https://votre-api-rdv.com"); // Assurez-vous d'ajuster l'URL de l'API
        _httpClient.BaseAddress = new Uri("https://LocalHost:5000"); // Assurez-vous d'ajuster l'URL de l'API 5001

    }

    public async Task<IActionResult> Index()
    {
        try
        {
            var response = await _httpClient.GetAsync("/api/rdv");

            if (response.IsSuccessStatusCode)
            {
                var rdvList = await response.Content.ReadFromJsonAsync<List<Rdv>>();
                return View(rdvList);
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
    //// Action pour afficher la liste des rendez-vous d'un praticien spécifique
    // public async Task<IActionResult> Index(int idPraticien)
    // {
    //     try
    //     {
    //         // Appel à une nouvelle méthode dans l'API pour récupérer les rendez-vous par praticien
    //         var response = await _httpClient.GetAsync($"/api/rdv/praticien/{idPraticien}");

    //         if (response.IsSuccessStatusCode)
    //         {
    //             var rdvList = await response.Content.ReadFromJsonAsync<List<Rdv>>();
    //             return View(rdvList);
    //         }
    //         else
    //         {
    //             var errorMessage = await response.Content.ReadAsStringAsync();
    //             return View("Error", errorMessage);
    //         }
    //     }
    //     catch (Exception ex)
    //     {
    //         return View("Error", ex.Message);
    //     }
    // }


    //public IActionResult Details(int id)
    //{
    //    // Logique pour obtenir les détails du rendez-vous par son ID
    //    // Utilisez l'API de l'arrière-plan ou un service dédié

    //    // Exemple statique pour l'illustration
    //    var rdv = new Rdv { Id = id, Date = DateTime.Now, NomPatient = "John Doe", NomPraticien = "Dr. Smith" };

    //    return View(rdv);



    
    
    public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Rdv rdv)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/api/rdv", rdv);

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

