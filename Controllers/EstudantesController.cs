using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiCrud.Data;
using ApiCrud.Model;

namespace ApiCrud.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EstudantesController : ControllerBase
{
    private readonly AppDbContext _context;

    public EstudantesController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Estudantes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Estudante>>> GetEstudantes()
    {
        return await _context.Estudantes.ToListAsync();
    }

    // GET: api/Estudantes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Estudante>> GetEstudante(Guid id)
    {
        var estudante = await _context.Estudantes.FindAsync(id);

        if (estudante == null)
        {
            return NotFound();
        }

        return estudante;
    }

    // PUT: api/Estudantes/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutEstudante(Guid id, Estudante estudante)
    {
        if (id != estudante.Id)
        {
            return BadRequest();
        }

        _context.Entry(estudante).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EstudanteExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Estudantes
    [HttpPost]
    public async Task<ActionResult<Estudante>> PostEstudante(Estudante estudante)
    {
        _context.Estudantes.Add(estudante);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetEstudante", new { id = estudante.Id }, estudante);
    }

    // DELETE: api/Estudantes/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEstudante(Guid id)
    {
        var estudante = await _context.Estudantes.FindAsync(id);
        if (estudante == null)
        {
            return NotFound();
        }

        _context.Estudantes.Remove(estudante);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool EstudanteExists(Guid id)
    {
        return _context.Estudantes.Any(estudante => estudante.Id == id);
    }
}
