using Microsoft.AspNetCore.Mvc;
using ApiCrud.Domain.Services;
using ApiCrud.DTOs.Response;
using ApiCrud.DTOs.Request;

namespace ApiCrud.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EstudantesController : ControllerBase
{
    private readonly IEstudanteService _estudanteService;

    public EstudantesController(IEstudanteService estudanteService)
    {
        _estudanteService = estudanteService;
    }

    [HttpGet]
    public async Task<IEnumerable<EstudanteDto>> GetAllAsync()
    {
        return await _estudanteService.ListAsync();
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] CreateEstudanteDto createEstudanteDto)
    {

        if (!ModelState.IsValid) //Verifica os erros da validação
        {
            return BadRequest(ModelState);
        }

        await _estudanteService.AddEstudanteAsync(createEstudanteDto);
        return Ok();
    }



}
