using ExampleSolid;
using Microsoft.AspNetCore.Mvc;

namespace WebExampleSolid.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarWashController : ControllerBase
    {
        private CarWash _carWash;

        public CarWashController(CarWash carWash)
        {
            _carWash = carWash;
        }

        [HttpPost()]
        public ActionResult<decimal> Pracing()
        {      
            _carWash.Pricing();

            return _carWash.WashingCost;
        }
    }
}
