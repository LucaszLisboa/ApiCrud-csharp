using ApiCrud.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Data;

public class EstudanteRepository : BaseRepository
{
  
    public EstudanteRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<Estudante>> ListAsync()
    {
        return await _context.Estudantes.ToListAsync();
    }

    public async Task AddEstudanteAsync(Estudante estudante)
    {
        await _context.Estudantes.AddAsync(estudante);
        _context.SaveChanges();
    }
}

