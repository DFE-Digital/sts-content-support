using Contentful.Core;
using Microsoft.AspNetCore.Mvc;

namespace ContentFul.ApI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreditCardController : ControllerBase
    {      
        private readonly ILogger<CreditCardController> _logger;
        private readonly IContentfulClient _client;

        public CreditCardController(ILogger<CreditCardController> logger, IContentfulClient client)
        {
            _logger = logger;
            _client = client;
        }

        [HttpGet(Name = "GetCreditCard")]
        public async Task<IActionResult> Get()
        {
            var cards = await _client.GetEntries<CreditCard>();
            return cards == null ? NotFound() : Ok(cards);
        }
    }
}
