using Microsoft.AspNetCore.Mvc;

namespace IntegraQnest.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var result = new HealthResponse
        {
            Status = "Healthy"
        };

        return Ok(result);
    }

    public class HealthResponse
    {
        public string Status { get; set; } = string.Empty;
    }
}