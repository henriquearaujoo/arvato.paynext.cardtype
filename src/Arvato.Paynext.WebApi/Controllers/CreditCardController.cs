using Arvato.Paynext.Application;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Arvato.Paynext.CreditCards;
using Arvato.Paynext.WebApi.Model;
using FluentValidation;

namespace Arvato.Paynext.WebApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CreditCardController : ControllerBase
    {
        private readonly ICreditCardService _cardService;

        public CreditCardController(
            ICreditCardService cardService)
        {
            _cardService = cardService;
        }
        /// <summary>
        /// Return the type of credit card given card data.
        /// </summary>
        [HttpPost("type")]
        [ProducesResponseType(typeof(CreditCardOutput), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetType(CreditCardInput request)
        {
            var result = _cardService.GetCreditCardType(request);
            return Ok(result);
        }
    }
}
