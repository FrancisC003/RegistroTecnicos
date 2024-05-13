

using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;
namespace RegistroTecnicos.Services;

public class TecnicosServices
{
    private readonly Contexto _context;
    public  TecnicosServices(Contexto contexto)
    {
        _context = contexto;
    }


    public async Task<bool> Existe(int tecnicos)
    {
        return await _context.Tecnicos
            .AnyAsync(t => t.TecnicosId == tecnicos);
    }

    public async Task<bool> Insertar(Tecnicos tecnicos)
    {
        _context.Tecnicos.Add(tecnicos);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Tecnicos tecnicos)
    {
        _context.Update(tecnicos);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Tecnicos tecnicos)
    {
        if (!await Existe(tecnicos.TecnicosId))
            return await Insertar(tecnicos);
        else
            return await Modificar(tecnicos);
    }

    public async Task <bool>Eliminar(int id)
    {
        var tecnicos = await _context.Tecnicos.
            Where(T=>T.TecnicosId==id).ExecuteDeleteAsync();
        return tecnicos > 0;
    }

    public async Task <Tecnicos?> Buscar(int id)
    {
        return await _context.Tecnicos.
            AsNoTracking()
            .FirstOrDefaultAsync(T =>T.TecnicosId==id);
    }

    public List<Tecnicos> Listar(Expression<Func<Tecnicos, bool>> expression)
    {
        return _context.Tecnicos.
            AsNoTracking()
            .Where(expression)
            .ToList();
    }
}
