using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UI.Models;
using UI.Models.ErrorViewModel;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();

        }
        //public IActionResult Rdv()
        //{
        //    return View();

        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}




//using Microsoft.AspNetCore.Mvc;
//using System.Diagnostics;
//using UI.Models;

//namespace UI.Controllers
//{
//    public class HomeController : Controller
//    {
//        private readonly IHttpClientFactory _httpClientFactory;

//        //  private readonly ILogger<HomeController> _logger;

//        public HomeController(IHttpClientFactory httpClientFactory)
//        //   public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)

//        {
//            // _logger = logger;
//            _httpClientFactory = httpClientFactory;
//        }

//        public async Task<IActionResult> Index()
//        {
//            // Example: Call ApiGateway to get data from ApiRdv
//            var apiGatewayClient = _httpClientFactory.CreateClient("ApiGateway");
//           var response = await apiGatewayClient.GetAsync("/api/rdv");
//            var rdvData = await response.Content.ReadAsStringAsync();

//            // Example: Call ApiGateway to get data from ApiPraticien
//            response = await apiGatewayClient.GetAsync("/api/praticien");
//            var praticienData = await response.Content.ReadAsStringAsync();

//            // Process the data as needed and pass it to the view
//            ViewBag.RdvData = rdvData;
//            ViewBag.PraticienData = praticienData;

//            return View();
//        }

//        //public IActionResult Index()
//        //{
//        //    return View();
//        //}

//        public IActionResult Privacy()
//        {
//            return View();
//        }

//        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//        public IActionResult Error()
//        {
//            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//        }
//    }
//}
//////////////////////////////////////////////////////////
//using Microsoft.AspNetCore.Mvc;
//using System.Net.Http;
//using System.Threading.Tasks;
//using Newtonsoft.Json;
//using ApiRdv.Models;
//using ApiPraticien.Models; // Assurez-vous d'avoir la référence à Newtonsoft.Json pour la désérialisation JSON.

//public class HomeController : Controller
//{
//    private readonly HttpClient _httpClient;

//    public HomeController(HttpClient httpClient)
//    {
//        _httpClient = httpClient;
//        _httpClient.BaseAddress = new Uri("https://localhost:5000"); // Assurez-vous de configurer la bonne adresse de votre APIGateway.
//    }

    //public async Task<IActionResult> Index()
    //    {
    //        // Appel à l'API pour récupérer tous les rendez-vous
    //        var rendezVousResponse = await _httpClient.GetAsync("/api/rdv");
    //       // rendezVousResponse.EnsureSuccessStatusCode();

    //        var rendezVousJson = await rendezVousResponse.Content.ReadAsStringAsync();
    //        var rendezVousList = JsonConvert.DeserializeObject<List<Rdv>>(rendezVousJson);

    //        // Appel à l'API pour récupérer tous les praticiens
    //        var praticiensResponse = await _httpClient.GetAsync("/api/praticien");
    //     //   praticiensResponse.EnsureSuccessStatusCode();

    //        var praticiensJson = await praticiensResponse.Content.ReadAsStringAsync();
    //        var praticienList = JsonConvert.DeserializeObject<List<Praticien>>(praticiensJson);

    //       //tilisez rendezVousList et praticienList comme nécessaire dans votre vue

    //        return View();
    //    }
    //}
    // ...
    ////public async Task<IActionResult> Index()
    ////{
    ////    try
    ////    {
    ////        // Appel à l'API pour récupérer tous les rendez-vous
    ////        var rendezVousResponse = await _httpClient.GetAsync("/api/rdv");
    ////        rendezVousResponse.EnsureSuccessStatusCode();

    ////        var rendezVousJson = await rendezVousResponse.Content.ReadAsStringAsync();
    ////        var rendezVousList = JsonConvert.DeserializeObject<List<Rdv>>(rendezVousJson);

    ////        // Transmettez les données à la vue
    ////        return View(rendezVousList);
    ////    }
    ////    catch (Exception ex)
    ////    {
    ////        // Gérez l'erreur comme vous le souhaitez (journalisation, redirection vers une page d'erreur, etc.)
    ////        return RedirectToAction("Erreur", new { message = ex.Message });
    ////    }
    ////}
