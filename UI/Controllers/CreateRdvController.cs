using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class CreateRdvController : Controller
    {
        private readonly HttpClient _httpClient;

        public CreateRdvController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            //  _httpClient.BaseAddress = new Uri("https://votre-api-rdv.com"); // Assurez-vous d'ajuster l'URL de l'API
            _httpClient.BaseAddress = new Uri("https://LocalHost:5000"); // Assurez-vous d'ajuster l'URL de l'API

        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ApiRdv.Models.Rdv rdv)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/api/cree-rdv", rdv);

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
}