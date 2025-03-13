using ApiCrud.Data;
using ApiCrud.Domain.Models;
using ApiCrud.Domain.Services;
using ApiCrud.DTOs.Request;
using ApiCrud.DTOs.Response;

namespace ApiCrud.Services;

public class EstudanteService : IEstudanteService
{
    private readonly EstudanteRepository _estudanteRepository;

    public EstudanteService(EstudanteRepository estudanteRepository)
    {
        _estudanteRepository = estudanteRepository;
    }

    public async Task<IEnumerable<EstudanteDto>> ListAsync()
    {
        try
        {
            var estudantes = await _estudanteRepository.ListAsync();
            return estudantes.Select(estudante => new EstudanteDto(estudante.Id, estudante.Nome));
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task AddEstudanteAsync(CreateEstudanteDto createEstudanteDto)
    {
        try
        {
            Estudante estudante = new Estudante(createEstudanteDto.Nome);
            await _estudanteRepository.AddEstudanteAsync(estudante);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
