namespace ApiCrud.DTOs.Response;

public class EstudanteDto
{
    public Guid Id { get; set; }
    public string? Nome { get; set; }

    public EstudanteDto(Guid id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}
