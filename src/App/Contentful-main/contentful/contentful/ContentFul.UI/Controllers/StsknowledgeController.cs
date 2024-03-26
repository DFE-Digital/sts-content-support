using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Projects.Models;
using System.Collections.Generic;
using System.Diagnostics;
using static Projects.Models.STSKnowledgebase;


namespace Projects.Controllers
{
    public class StsknowledgeController : Controller
    {
        private readonly ILogger<StsknowledgeController> _logger;

        public StsknowledgeController(ILogger<StsknowledgeController> logger)
        {
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            string apiUrl = "https://localhost:44349/Stsknowledge";

            //List<ComponentTitle> componentTitles = [];
            //IEnumerable<Contentful.Core.Models.Entry<dynamic>> componentTitles = [];
            //IEnumerable<dynamic> componentTitles = [];
            List<JsonData> componentTitles = new  List<JsonData>();
            List<Cards> cards_lst = new List<Cards>();
            List<string> cards_img = new List<string>();
            Finaldataview bindingview = new Finaldataview();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                //var response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    //Jsondatafinal data = response.Content;
                    var data = await response.Content.ReadAsStringAsync();
                    //Jsondatafinal data = await response.Content;

                    
                    Jsondatafinal responsestring = JsonConvert.DeserializeObject<Jsondatafinal>(data);
                    //IList<STSKnowledgebase> modelObj = new JavaScriptSerializer().Deserialize<IList<Class1>>(data);
                    componentTitles = JsonConvert.DeserializeObject<List<JsonData>>(responsestring.Page) ?? [];
                    cards_lst = JsonConvert.DeserializeObject<List<Cards>>(responsestring.cards) ?? [];
                    cards_img = JsonConvert.DeserializeObject<List<string>>(responsestring.image) ?? [];
                    //componentTitles = JsonConvert.DeserializeObject<List<STSKnowledgebase>>(data) ?? [];
                    //componentTitles = JsonConvert.DeserializeObject<IEnumerable<Contentful.Core.Models.Entry<dynamic>>>(data) ?? [];
                    //componentTitles = JsonConvert.DeserializeObject<IEnumerable<dynamic>>(responsestring) ?? [];

                    
                    bindingview.Page = componentTitles;
                    bindingview.cards = cards_lst;
                    bindingview.image = cards_img;
                }
            }
            return View(bindingview);
            //return View(componentTitles);
            //return View("");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
