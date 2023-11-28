using DeLijnApp.Engine;
using DeLijnApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeLijnApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StelplaatsController : ControllerBase
    {
        [HttpPost]
        public ActionResult<StelplaatsModel> Plan([FromBody] StelplaatsModel stelplaats)
        {
            var result = new ParkingEngine().ParkBuses(stelplaats);

            return Ok(result);
        }
    }
}
