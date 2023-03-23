using Microsoft.AspNetCore.Mvc;
using RegistrationBL.Interface;
using RegistrationDA.Entities;

namespace RegistrationWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : Controller
    {
        private IRegistrationBL _registration;
        private ILogger<RegistrationController> _logger;

        public RegistrationController(IRegistrationBL registration, ILogger<RegistrationController> logger)
        {
            _registration = registration;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<Registration> Get(int id)
        {
            try
            {
                return await _registration.RegistrationGetById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
            return new Registration();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Registration registration)
        {
            try
            {
                var result = await _registration.Create(registration);
                if (result)
                    return new JsonResult(new { StatusCode = 201, Value = "Added successfully" });
                else
                    return new JsonResult(new { StatusCode = 500, Value = "Error occured" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return new JsonResult(new { StatusCode = 500, Value = "Error occured" });
            }
        }

        [HttpPut("Put")]
        public async Task<IActionResult> Put([FromBody] Registration registration)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new { StatusCode = 400, Value = "Required information is missing" });
            }
            try
            {
                var result = await _registration.Update(registration);
                if (result)
                    return new JsonResult(new { StatusCode = 201, Value = "Added successfully" });
                else
                    return new JsonResult(new { StatusCode = 500, Value = "Error occured" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return new JsonResult(new { StatusCode = 500, Value = "Error occured" });
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _registration.Remove(id);
                if (result)
                    return new JsonResult(new { StatusCode = 201, Value = "Deleted successfully" });
                else
                    return new JsonResult(new { StatusCode = 500, Value = "Error occured" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return new JsonResult(new { StatusCode = 500, Value = "Error occured" });
            }
        }

        [HttpGet]
        public async Task<IEnumerable<Registration>> Get()
        {
            try
            {
                return await _registration.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return Enumerable.Empty<Registration>();
            }
        }

        [HttpPost("SearchRegistrations")]
        public async Task<IEnumerable<Registration>> SearchRegistrations([FromBody] SearchRegistration searchRegistration)
        {
            try
            {
                return await _registration.SearchRegistration(searchRegistration.SearchKey ?? string.Empty);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return Enumerable.Empty<Registration>();
            }
        }
    }
}
