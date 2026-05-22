using Microsoft.EntityFrameworkCore;

public class PedidoRepository : IPedidoRepository
{
    private readonly AppDbContext _context;

    public PedidoRepository(AppDbContext context)
    {
        _context = context;
    }

    private IQueryable<Pedido> QueryWithDetails() =>
        _context.Set<Pedido>()
            .Include(p => p.Cliente)       
            .Include(p => p.Funcionario)   
            .Include(p => p.Itens)         
                .ThenInclude(i => i.Produto); 


    public async Task<Pedido?> GetValueAsync(int id) =>
        await QueryWithDetails()
            .FirstOrDefaultAsync(p => p.Id == id);

    public async Task<IEnumerable<Pedido>> GetAllAsync() =>
        await QueryWithDetails()
            .AsNoTracking()
            .ToListAsync();

    public async Task AddAsync(Pedido entity)
    {
        await _context.Set<Pedido>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Pedido entity)
    {
        _context.Set<Pedido>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var pedido = await _context.Set<Pedido>().FindAsync(id);
        if (pedido is null) return;

        _context.Set<Pedido>().Remove(pedido);
        await _context.SaveChangesAsync();
    }

  
    public async Task<Pedido?> GetByIdWithDetailsAsync(int id) =>
        await QueryWithDetails()
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);

    public async Task<IEnumerable<Pedido>> GetAllWithDetailsAsync() =>
        await QueryWithDetails()
            .AsNoTracking()
            .ToListAsync();

    public async Task<IEnumerable<Pedido>> GetByStatusWithDetailsAsync(Status status) =>
        await QueryWithDetails()
            .AsNoTracking()
            .Where(p => p.Status == status) 
            .ToListAsync();

    public async Task<IEnumerable<Pedido>> GetByProdutoNameWithDetailsAsync(string produtoName) =>
        await QueryWithDetails()
            .AsNoTracking()
            .Where(p => p.Itens.Any(i => i.Produto.Nome.Contains(produtoName))) 
            .ToListAsync();

    public async Task<IEnumerable<Pedido>> GetByStatusAndDateRangeWithDetailsAsync(
        Status status, DateTime startDate, DateTime endDate) =>
        await QueryWithDetails()
            .AsNoTracking()
            .Where(p => p.Status == status
                     && p.Data >= startDate  
                     && p.Data <= endDate)
            .ToListAsync();

    public async Task<IEnumerable<Pedido>> GetByQuantidadeRangeAndStatusWithDetailsAsync(
        int minQuantidade, int maxQuantidade, Status status) =>
        await QueryWithDetails()
            .AsNoTracking()
            .Where(p => p.Status == status
                     && p.Itens.Any(i => i.Quantidade >= minQuantidade
                                      && i.Quantidade <= maxQuantidade))
            .ToListAsync();

    public async Task<IEnumerable<Pedido>> GetByClienteNameAndStatusWithDetailsAsync(
        string clienteName, Status status) =>
        await QueryWithDetails()
            .AsNoTracking()
            .Where(p => p.Cliente.Nome.Contains(clienteName) 
                     && p.Status == status)
            .ToListAsync();


    public async Task<IEnumerable<Pedido>> GetAllWithPaginationAsync(int pageNumber, int pageSize) =>
        await QueryWithDetails()
            .AsNoTracking()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

    public async Task<IEnumerable<Pedido>> GetByStatusWithPaginationAsync(
        Status status, int pageNumber, int pageSize) =>
        await QueryWithDetails()
            .AsNoTracking()
            .Where(p => p.Status == status)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

  

    public async Task<Pedido?> UpdateStatusAsync(int id, Status newStatus)
    {
        var pedido = await _context.Set<Pedido>().FindAsync(id);
        if (pedido is null) return null;

        pedido.Status = newStatus;
        await _context.SaveChangesAsync();
        return pedido;
    }

    public async Task<IEnumerable<Pedido>> UpdateStatusByDateRangeAsync(
        DateTime startDate, DateTime endDate, Status newStatus)
    {
        var pedidos = await _context.Set<Pedido>()
            .Where(p => p.Data >= startDate && p.Data <= endDate)
            .ToListAsync();

        pedidos.ForEach(p => p.Status = newStatus);
        await _context.SaveChangesAsync();
        return pedidos;
    }

    public async Task<IEnumerable<Pedido>> UpdateStatusByProdutoNameAsync(
        string produtoName, Status newStatus)
    {
        var pedidos = await _context.Set<Pedido>()
            .Include(p => p.Itens)           
                .ThenInclude(i => i.Produto) 
            .Where(p => p.Itens.Any(i => i.Produto.Nome.Contains(produtoName)))
            .ToListAsync();

        pedidos.ForEach(p => p.Status = newStatus);
        await _context.SaveChangesAsync();
        return pedidos;
    }

    public async Task DeleteByStatusAsync(Status status)
    {
        var pedidos = await _context.Set<Pedido>()
            .Where(p => p.Status == status)
            .ToListAsync();

        _context.Set<Pedido>().RemoveRange(pedidos);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        var pedidos = await _context.Set<Pedido>()
            .Where(p => p.Data >= startDate && p.Data <= endDate)
            .ToListAsync();

        _context.Set<Pedido>().RemoveRange(pedidos);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteByProdutoNameAsync(string produtoName)
    {
        var pedidos = await _context.Set<Pedido>()
            .Include(p => p.Itens)
                .ThenInclude(i => i.Produto)
            .Where(p => p.Itens.Any(i => i.Produto.Nome.Contains(produtoName)))
            .ToListAsync();

        _context.Set<Pedido>().RemoveRange(pedidos);
        await _context.SaveChangesAsync();
    }
}