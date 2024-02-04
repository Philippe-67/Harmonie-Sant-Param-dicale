//using Microsoft.AspNetCore.Mvc;
//using System.Diagnostics;
//using UI.Models;

//namespace UI.Controllers
//{
//    public class HomeController : Controller
//    {  
//        private readonly IHttpClientFactory _httpClientFactory;

//      //  private readonly ILogger<HomeController> _logger;

//        public HomeController( IHttpClientFactory httpClientFactory)
//     //   public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)

//        {
//           // _logger = logger;
//            _httpClientFactory = httpClientFactory;
//        }

//        public async Task<IActionResult> Index()
//        {
//            // Example: Call ApiGateway to get data from ApiRdv
//            var apiGatewayClient = _httpClientFactory.CreateClient("ApiGateway");
//            var response = await apiGatewayClient.GetAsync("/api/Rdv");
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
//} ///////////////////////////////////////////////////////////////////
//using Microsoft.AspNetCore.Mvc;
//using System.Net.Http;
//using System.Threading.Tasks;

//public class HomeController : Controller
//{
//    //private readonly IHttpClientFactory _httpClientFactory;

//    //public HomeController(IHttpClientFactory httpClientFactory)
//    //{
//    //    _httpClientFactory = httpClientFactory;
//    //}
//    private readonly IConfiguration _configuration;
//    private readonly HttpClient _apiGatewayClient;

//    public HomeController(IConfiguration configuration)
//    {
//        _configuration = configuration;

//        // Initialiser _apiGatewayClient avec l'adresse de l'API Gateway
//        _apiGatewayClient = new HttpClient
//        {
//            BaseAddress = new Uri(_configuration["ApiGatewayUrl"])
//        };
//    }
//    public async Task<IActionResult> Index()
//    {
//        // Example: Call ApiGateway to get data from ApiRdv
//        var apiGatewayClient = _httpClientFactory.CreateClient("ApiGateway");
//        var response = await apiGatewayClient.GetAsync("/api/rdv");
//        var rdvData = await response.Content.ReadAsStringAsync();

//        // Example: Call ApiGateway to get data from ApiPraticien
//        response = await apiGatewayClient.GetAsync("/api/praticien");
//        var praticienData = await response.Content.ReadAsStringAsync();

//        // Process the data as needed and pass it to the view
//        ViewBag.RdvData = rdvData;
//        ViewBag.PraticienData = praticienData;

//        return View();
//    }
//}//////////////////////////////////////////////////////////////////////

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Threading.Tasks;

public class HomeController : Controller
{
    private readonly IConfiguration _configuration;
    private readonly HttpClient _apiGatewayClient;

    //    public HomeController(IConfiguration configuration)
    //    {
    //        _configuration = configuration;

    //        // Initialiser _apiGatewayClient avec l'adresse de l'API Gateway
    //        _apiGatewayClient = new HttpClient
    //        {
    //            BaseAddress = new Uri(_configuration["ApiGatewayUrl"])
    //        };
    //    }

    //    public async Task<IActionResult> Index()
    //    {
    //        try
    //        {
    //            // Example: Call ApiGateway to get data from ApiRdv
    //            var responseRdv = await _apiGatewayClient.GetAsync("/api/rdv");
    //            responseRdv.EnsureSuccessStatusCode();
    //            var rdvData = await responseRdv.Content.ReadAsStringAsync();

    //            // Example: Call ApiGateway to get data from ApiPraticien
    //            var responsePraticien = await _apiGatewayClient.GetAsync("/api/praticien");
    //            responsePraticien.EnsureSuccessStatusCode();
    //            var praticienData = await responsePraticien.Content.ReadAsStringAsync();

    //            // Process the data as needed and pass it to the view
    //            ViewBag.RdvData = rdvData;
    //            ViewBag.PraticienData = praticienData;

    //            return View();
    //        }
    //        catch (HttpRequestException ex)
    //        {
    //            // Handle the exception appropriately, log, and display an error message to the user.
    //            ViewBag.ErrorMessage = "Erreur lors de la communication avec l'API Gateway.";
    //            return View();
    //        }
    //    }
    //}/////////////////////////////////////////////
    public HomeController(IConfiguration configuration)
    {
        _configuration = configuration;

        // Récupérer l'URL de l'API Gateway depuis la configuration
        string apiGatewayUrl = _configuration["ApiGatewayUrl"];

        // Vérifier si l'URL est null ou vide
        if (string.IsNullOrEmpty(apiGatewayUrl))
        {
            // Gérer l'erreur ou fournir une valeur par défaut
            throw new InvalidOperationException("L'URL de l'API Gateway n'est pas définie dans la configuration.");
        }

        // Initialiser _apiGatewayClient avec l'adresse de l'API Gateway
        _apiGatewayClient = new HttpClient
        {
            BaseAddress = new Uri(apiGatewayUrl)
        };
    }
}
