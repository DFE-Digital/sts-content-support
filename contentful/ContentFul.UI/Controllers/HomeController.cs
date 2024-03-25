using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Projects.Models;
using Newtonsoft.Json;

namespace Projects.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;       
    }

    public  async Task<IActionResult> Index()
    {
        string apiUrl = "https://localhost:44349/CreditCard";
        List<CreditCard> creditCard = [] ;

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                creditCard = JsonConvert.DeserializeObject<List<CreditCard>>(data) ?? [];
            }
        }
        return View(creditCard);    
    }
 

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
