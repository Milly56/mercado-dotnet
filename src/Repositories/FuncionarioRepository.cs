using Microsoft.EntityFrameworkCore;

public class FuncionarioRepository : IFuncionarioRepository
{
    private readonly AppDbContext _context;

    public FuncionarioRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Funcionario?> GetValueAsync(int id) =>
        await _context.Set<Funcionario>().FindAsync(id);

    public async Task<IEnumerable<Funcionario>> GetAllAsync() =>
        await _context.Set<Funcionario>().ToListAsync();

    public async Task AddAsync(Funcionario entity)
    {
        await _context.Set<Funcionario>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Funcionario entity)
    {
        _context.Set<Funcionario>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var funcionario = await GetValueAsync(id);
        if (funcionario != null)
        {
            _context.Set<Funcionario>().Remove(funcionario);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Funcionario?> GetFuncionarioAsync(string nome) =>
        await _context.Set<Funcionario>()
            .FirstOrDefaultAsync(f => f.Nome == nome);
}