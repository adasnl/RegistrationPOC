using Microsoft.AspNetCore.Mvc;
using RegistrationBL.Interface;
using RegistrationDA.Entities;

namespace RegistrationWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : Controller
    {
        private IRegistrationBusinessLayerService _registration;
        private ILogger<RegistrationController> _logger;

        public RegistrationController(IRegistrationBusinessLayerService registration, ILogger<RegistrationController> logger)
        {
            _registration = registration;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<RegistrationDA.Entities.Registration> Get(int id)
        {
            return await _registration.RegistrationGetById(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegistrationDA.Entities.Registration registration)
        {
            var result = await _registration.Create(registration);
            if (result)
                return new JsonResult(new { StatusCode = 201, Value = "Added successfully" });
            else
                return new JsonResult(new { StatusCode = 500, Value = "Error occured" });
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] RegistrationDA.Entities.Registration registration)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new { StatusCode = 400, Value = "Required information is missing" });
            }

            var result = await _registration.Update(registration);
            if (result)
                return new JsonResult(new { StatusCode = 201, Value = "Added successfully" });
            else
                return new JsonResult(new { StatusCode = 500, Value = "Error occured" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _registration.Remove(id);
            if (result)
                return new JsonResult(new { StatusCode = 201, Value = "Deleted successfully" });
            else
                return new JsonResult(new { StatusCode = 500, Value = "Error occured" });
        }

        [HttpGet]
        public async Task<IEnumerable<RegistrationDA.Entities.Registration>> Get()
        {
            return await _registration.GetAll();
        }

        [HttpPost("SearchRegistrations")]
        public async Task<IEnumerable<RegistrationDA.Entities.Registration>> SearchRegistrations([FromBody] SearchRegistration searchRegistration)
        {
            return await _registration.SearchRegistration(searchRegistration.SearchKey ?? string.Empty);
        }
    }
}
