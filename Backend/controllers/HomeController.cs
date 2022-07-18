using Microsoft.AspNetCore.Mvc;

namespace brunsker_api.controlers;

[ApiController]
[Route("")]
public class HomeController : ControllerBase
{
    //Health-Check
    [HttpGet("")]
    public ActionResult Get()
    {
        return Ok();
    }

}