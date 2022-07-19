using brunsker_api.data;
using brunsker_api.models;
using brunsker_api.viewmodel;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace brunsker_api.controlers;

[ApiController]

public class ImovelController : ControllerBase
{
    const string connectionString = @"Server=localhost;Database=DB-Brunsker;User Id=root;Password=my-secret-pw;";




    [HttpGet("v1/imoveis")]
    public async Task<ActionResult> GetAsync()
    {
        await using (var connection = new MySqlConnection(connectionString))
        {
            try
            {
                var imoveis = connection.Query<Imovel>("SELECT * FROM imoveis;");
                return StatusCode(200, imoveis);

            }
            catch
            {
                return StatusCode(500, "ERR005-Falha interna no servidor.");
            }
        }


    }

    [HttpGet("v1/imoveis/{id:int}")]
    public async Task<ActionResult> GetByIdAsync(int id)
    {


        await using (var connection = new MySqlConnection(connectionString))
        {

            try
            {
                var imovel = await connection.QuerySingleOrDefaultAsync<Imovel>(@"SELECT * FROM imoveis WHERE ID = @id;", new { @id = id });
                return StatusCode(200, imovel);
            }
            catch
            {
                return StatusCode(500, "ERR005-Falha interna no servidor.");
            }
        }

    }
    // [HttpGet("v1/imoveis/{id: int}")]
    // public async Task<ActionResult> GetByIdAsync()
    // {
    //     await using (var connection = new MySqlConnection(connectionString))
    //     {
    //         try
    //         {

    //             var imovel = connection.Query<Imovel>(@$"SELECT * FROM imoveis WHERE ID = 9;");
    //             return StatusCode(200, imovel);

    //         }
    //         catch
    //         {
    //             return StatusCode(500, "ERR005-Falha interna no servidor.");
    //         }
    //     }
    // }
    [HttpPost("v1/imoveis")]
    public async Task<IActionResult> PostAsync(Imovel fromImovel)
    {

        var insertSQL = @"INSERT INTO imoveis (quartos,banheiros,garagem,ValorImovel,cep,CorretorCode,Bairro,Cidade)
                         values (@Quartos,@Banheiros,@Garagem, @ValorImovel ,@Cep,
                                '0',@Bairro,@Cidade);";


        await using (var connection = new MySqlConnection(connectionString))
        {
            System.Console.WriteLine(fromImovel);
            try
            {

                var rows = await connection.ExecuteAsync(insertSQL, new
                {
                    @Quartos = fromImovel.Quartos,
                    @Banheiros = fromImovel.Banheiros,
                    @Garagem = fromImovel.Garagem,
                    @ValorImovel = fromImovel.ValorImovel,
                    @Cep = fromImovel.Cep,
                    @CorretorCode = fromImovel.CorretorCode,
                    @Bairro = fromImovel.Bairro,
                    @Cidade = fromImovel.Cidade
                });
                return StatusCode(201, $"{rows} linhas afetadas");

            }
            catch
            {
                return StatusCode(500, "ERR005-Falha interna no servidor.");
            }
        }
    }



    [HttpDelete("v1/imoveis/{id:int}")]
    public async Task<ActionResult> DeleteAsync(int id)
    {

        var queryImovelToDelete = @"SELECT * FROM imoveis WHERE ID = @id ;";
        var queryDeleteImovel = @"DELETE FROM imoveis where id = @id;";
        await using (var connection = new MySqlConnection(connectionString))
        {


            try
            {
                await connection.ExecuteAsync(queryImovelToDelete, new { @id = id });
                var rows = await connection.ExecuteAsync(queryDeleteImovel, new { @id = id });
                return StatusCode(200, @$"{rows} linha(s) afetada(s)");
            }
            catch
            {
                return StatusCode(500, "ERR005-Falha interna no servidor.");
            }
        }

    }
}




//     }

//     [HttpPut("v1/imoveis/{id:int}")]
//     public async Task<IActionResult> PutAsync(
//         [FromRoute] int id,
//         [FromBody] Imovel imovel,
//         [FromServices] AppDbContext context
//     )
//     {
//         var ImovelToChange = await context.imoveis.FirstOrDefaultAsync(x => x.Id == id);
//         if (ImovelToChange == null) return NotFound("Imóvel não localizado.");
//         ImovelToChange.Cidade = imovel.Cidade;
//         ImovelToChange.Bairro = imovel.Bairro;
//         ImovelToChange.Quartos = imovel.Quartos;
//         ImovelToChange.Banheiros = imovel.Banheiros;
//         ImovelToChange.ValorImovel = imovel.ValorImovel;
//         ImovelToChange.Garagem = imovel.Garagem;
//         ImovelToChange.Cep = imovel.Cep;


//         context.imoveis.Update(ImovelToChange);
//         context.SaveChangesAsync();
//         return Ok(imovel);


//     }





