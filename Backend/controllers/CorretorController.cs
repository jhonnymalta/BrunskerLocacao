using brunsker_api.data;
using brunsker_api.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace brunsker_api.controlers;




[ApiController]
public class CorretorController : ControllerBase
{
    const string connectionString = @"Server=localhost;Database=DB-Brunsker;User Id=root;Password=my-secret-pw;";






    [HttpPost("v1/corretores")]
    public async Task<IActionResult> PostAsync(
        [FromBody] Corretor corretor,
        [FromServices] AppDbContext context
    )
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(400, "ERR06-Informações necessárias");
        }
        try
        {
            return Ok();
        }
        catch (DbUpdateException ex)
        {
            return StatusCode(500, "ERR001-Não foi possível criar um corretor.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, "ERR002-Falha interna no servidor.");
        }



    }
}