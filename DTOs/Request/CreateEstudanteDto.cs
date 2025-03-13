using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ApiCrud.DTOs.Request;

public class CreateEstudanteDto
{
    [NotNull]
    [MinLength(4)]
    public string Nome { get; set; }

    public CreateEstudanteDto(string nome)
    {
        Nome = nome;
    }
}
