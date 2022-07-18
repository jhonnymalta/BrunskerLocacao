using System.ComponentModel.DataAnnotations;

namespace brunsker_api.models;

public class Corretor
{
    public int Id { get; set; }
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [StringLength(150, MinimumLength = 3, ErrorMessage = "O campo deve conter entre 3 a 150 caracteres.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "O email é obrigatório.")]
    [EmailAddress]
    public string Email { get; set; }
    public string Password { get; set; }


}
