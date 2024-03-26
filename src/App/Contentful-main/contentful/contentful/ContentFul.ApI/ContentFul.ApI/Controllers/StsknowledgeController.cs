using Contentful.Core;
using Contentful.Core.Search;
using ContentFul.ApI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Dynamic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ContentFul.ApI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Route("api/[controller]")]
    
    public class StsknowledgeController : ControllerBase
    {
        private readonly ILogger<StsknowledgeController> _logger;
        private readonly IContentfulClient _client;

        public StsknowledgeController(ILogger<StsknowledgeController> logger, IContentfulClient client)
        {
            _logger = logger;
            _client = client;
        }

        [HttpGet(Name = "GetSTSKnowledgebase")]
        public async Task<IActionResult> Get()
        {
            List<dynamic> contdata = new List<dynamic>();
            List<JsonData> contdata_lst = new List<JsonData>();
            List<dynamic> lstentry = new List<dynamic>();
            List<Cards> cards_lst = new List<Cards>();
            List<dynamic> lstcard = new List<dynamic>();
            List<string> lstimg = new List<string>();
            //var stsknowledges = await _client.GetEntries<ComponentTitle>();
            //var stsknowledges = await _client.GetEntriesByType<STSKnowledgebase>("stsKnowledgebase");
            //var stsknowledges = await _client.GetEntriesByType<ComponentTitle>("stsKnowledgebase");
            // stsknowledges = await _client.GetEntriesByType<Field>("page");
            //var stsknowledges = await _client.GetEntriesByType<ComponentTitle>("page");


            //var stsimage = await _client.GetAsset("42ZjQrrgH7wVt2glcbYxhU");
            //var stsimage = await _client.GetAsset("3Qg7iytO9jZ4hMSVlVFrzI");
            //if (stsimage != null)
            //{
            //    string imgurl = stsimage.File.Url;
            //}
            var stsknowledges = await _client.GetEntriesByType<dynamic>("page");
            IEnumerable<Contentful.Core.Models.Entry<dynamic>> contentdata = stsknowledges.IncludedEntries;
            
            foreach (var stsdata in contentdata)
            {
                var data = stsdata.Fields;
                contdata.Add(stsdata.Fields);
                Console.WriteLine(data);
            }
            
            string response = JsonConvert.SerializeObject(contdata);
            contdata_lst = JsonConvert.DeserializeObject<List<JsonData>>(response) ?? [];
            //string conlst = contdata_lst[9].cards[0].sys.id;
            //var stslink = await _client.GetEntry<dynamic>("12A5g6VAlKmhkHRr7sWrih");

            //lstentry.Add(response);
            foreach (var entrylst in contdata_lst[9].cards)
            {
                lstentry.Add(await _client.GetEntry<dynamic>(entrylst.sys.id));
            }
            string jsoncardlist = JsonConvert.SerializeObject(lstentry);

            cards_lst = JsonConvert.DeserializeObject<List<Cards>>(jsoncardlist) ?? [];

            foreach(var cardlst in cards_lst)
            {
                lstcard.Add(await _client.GetAsset(cardlst.thumbnail.sys.id));
            }
                        
            foreach(var cardimg in lstcard)
            {
                lstimg.Add("https:"+ cardimg.File.Url);
            }
            var downloadfile = await _client.GetAsset(contdata_lst[5].documentFile.sys.id);
            lstimg.Add("https:" + downloadfile.File.Url);
            string jsonimglist = JsonConvert.SerializeObject(lstimg);

            //lstentry.Add(response);
            //lstentry.Add(lstimg);

            //lstimg.Add(response);

            Jsondata Final_response = new Jsondata();
            Final_response.Page = response;
            Final_response.cards = jsoncardlist;
            Final_response.image = jsonimglist;

            //var JObject1 = JObject.Parse(response);
            //var JObject2 = JObject.Parse(jsoncardlist);

            //var result = new JObject();

            //result.Merge(JObject1);
            //result.Merge(JObject2);

            //Console.WriteLine(result);

            //return Ok(response);
            return Ok(Final_response);
            //return stsknowledges == null ? NotFound() : Ok(contentdata);
        }

        // This client should only be created once per application.
        //var httpClient = new HttpClient();

        //var client = new ContentfulClient(httpClient, "<content_delivery_api_key>", "<content_preview_api_key>", "<space_id>");

        //var queryBuilder = QueryBuilder<YourClass>.New.ContentTypeIs("<content_type_id>").FieldEqualsAll("fields.tags", new[] { "flowers", "accessories" });
        //var entries = await client.GetEntries(queryBuilder);

        //// You can also use strong typing if your model class includes the field as a property.

        //var queryBuilder = QueryBuilder<YourClass>.New.ContentTypeIs("<content_type_id>").FieldEquals(f => f.Tags, new[] { "flowers", "accessories" });
        //var entries = await client.GetEntries(queryBuilder);
    }
}
