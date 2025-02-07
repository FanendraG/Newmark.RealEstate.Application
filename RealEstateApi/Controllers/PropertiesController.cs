using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Models;
using RealEstateApi.Services;

namespace RealEstateApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertiesController : ControllerBase
    {
        private readonly IBlobStorageService _blobStorageService;

        public PropertiesController(IBlobStorageService blobStorageService)
        {
            _blobStorageService = blobStorageService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Property>>> Get()
        {
            var (properties, errorMessage) = await _blobStorageService.GetPropertiesAsync();

            if (!string.IsNullOrEmpty(errorMessage))
            {
                if (errorMessage.Contains("Blob not found"))
                    return NotFound(new { message = errorMessage });
                if (errorMessage.Contains("Unauthorized access"))
                    return Unauthorized(new { message = errorMessage });
                if (errorMessage.Contains("Network error"))
                    return StatusCode(503, new { message = errorMessage }); // Service Unavailable
                if (errorMessage.Contains("Deserialization error"))
                    return BadRequest(new { message = errorMessage }); // Bad Request
                return StatusCode(500, new { message = errorMessage }); // Internal Server Error
            }

            return Ok(properties);
        }
    }
}
