using brunsker_api.data;
using brunsker_api.models;
using brunsker_api.viewmodel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace brunsker_api.controlers;

[ApiController]

public class ImovelController : ControllerBase
{
    [HttpGet("v1/imoveis")]
    public async Task<ActionResult> GetAsync(
    [FromServices] AppDbContext context
    )
    {

        try
        {
            var imoveis = await context.imoveis.ToListAsync();
            return Ok(imoveis);


        }
        catch
        {
            return StatusCode(500, "ERR005-Falha interna no servidor.");
        }
    }

    [HttpGet("v1/imoveis/{id:int}")]
    public async Task<IActionResult> GetByIdAsync(
        [FromRoute] int id,
        [FromServices] AppDbContext context
    )
    {
        try
        {
            var imovel = await context.imoveis.FirstOrDefaultAsync(x => x.Id == id);
            if (imovel == null) return StatusCode(404, "ERR006-Imóvel não localizado.");
            return Ok(imovel);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "ERR005-Falha interna no servidor.");


        }
    }

    [HttpPost("v1/imoveis")]
    public async Task<IActionResult> PostAsync(
        [FromBody] Imovel imovel,
        [FromServices] AppDbContext context
    )
    {
        try
        {
            await context.imoveis.AddAsync(imovel);
            await context.SaveChangesAsync();
            return StatusCode(201, imovel);
            //return Created($"v1/imoveis/{imovel.Id}", imovel);
        }
        catch (DbUpdateException ex)
        {
            return StatusCode(500, "ERR003-Não foi possível criar um imóvel.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, "ERR004-Falha interna no servidor.");
        }


    }

    [HttpPut("v1/imoveis/{id:int}")]
    public async Task<IActionResult> PutAsync(
        [FromRoute] int id,
        [FromBody] Imovel imovel,
        [FromServices] AppDbContext context
    )
    {
        var ImovelToChange = await context.imoveis.FirstOrDefaultAsync(x => x.Id == id);
        if (ImovelToChange == null) return NotFound("Imóvel não localizado.");
        ImovelToChange.Cidade = imovel.Cidade;
        ImovelToChange.Bairro = imovel.Bairro;
        ImovelToChange.Quartos = imovel.Quartos;
        ImovelToChange.Banheiros = imovel.Banheiros;
        ImovelToChange.ValorImovel = imovel.ValorImovel;
        ImovelToChange.Garagem = imovel.Garagem;
        ImovelToChange.Cep = imovel.Cep;


        context.imoveis.Update(ImovelToChange);
        context.SaveChangesAsync();
        return Ok(imovel);


    }

    [HttpDelete("v1/imoveis/{id:int}")]
    public async Task<ActionResult<Imovel>> DeleteAsync(
        [FromRoute] int id,
        [FromServices] AppDbContext context
    )
    {

        try
        {
            var imovelToDelete = await context.imoveis.FirstOrDefaultAsync(x => x.Id == id);
            if (imovelToDelete == null) return NotFound("Imovél não encontrado.");

            context.imoveis.Remove(imovelToDelete);
            context.SaveChangesAsync();
            return Ok("deletado");
        }
        catch (Exception ex)
        {
            return StatusCode(500, "ERR005-Falha interna no servidor.");


        }

    }
}

