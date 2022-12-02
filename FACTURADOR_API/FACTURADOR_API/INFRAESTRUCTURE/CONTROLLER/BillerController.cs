using Microsoft.AspNetCore.Mvc;
using FACTURADOR_API.APPLICATION.SERVICE;
using FACTURADOR_API.DOMAIN.MODELS;

namespace FACTURADOR_API.INFRAESTRUCTURE.CONTROLLER
{
    [Route("[controller]")]
    public class BillerController : Controller
    {
        private IBillerService _billerService;
        public BillerController(IBillerService billerService)
        {
            _billerService = billerService;
        }

        [HttpGet("{CI}")]
        public ActionResult<Biller> GetBiller(string CI, string startDate, string finishDate)
        {
            try
            {
                var biller = _billerService.getBiller(CI, DateTime.Parse(startDate), DateTime.Parse(finishDate));
                return Ok(biller);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
