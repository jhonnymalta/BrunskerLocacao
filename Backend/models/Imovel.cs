using System.ComponentModel.DataAnnotations;

namespace brunsker_api.models;

public class Imovel
{

    public int Id { get; set; }
    public string? Cidade { get; set; }
    public string? Bairro { get; set; }
    public string? Quartos { get; set; }
    public string? Banheiros { get; set; }

    public string? Garagem { get; set; }
    [Required(ErrorMessage = "Valor do imóvel é obrigatório.")]
    public string? ValorImovel { get; set; }

    [Required(ErrorMessage = "Cep do imóvel é obrigatório.")]
    public string Cep { get; set; }

    public int CorretorCode { get; set; }

}
