using ApiCrud.Domain.Models;
using ApiCrud.DTOs.Request;
using ApiCrud.DTOs.Response;

namespace ApiCrud.Domain.Services;

public interface IEstudanteService
{
    Task<IEnumerable<EstudanteDto>> ListAsync();

    Task AddEstudanteAsync(CreateEstudanteDto createEstudanteDto);
}
