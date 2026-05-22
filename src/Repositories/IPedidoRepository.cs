public interface IPedidoRepository : IRepository<Pedido>
{

    Task<Pedido?> GetByIdWithDetailsAsync(int id);
    Task<IEnumerable<Pedido>> GetAllWithDetailsAsync();
    Task<IEnumerable<Pedido>> GetByStatusWithDetailsAsync(Status status);                                                      
    Task<IEnumerable<Pedido>> GetByProdutoNameWithDetailsAsync(string produtoName);                                            
    Task<IEnumerable<Pedido>> GetByStatusAndDateRangeWithDetailsAsync(Status status, DateTime startDate, DateTime endDate);      
    Task<IEnumerable<Pedido>> GetByQuantidadeRangeAndStatusWithDetailsAsync(int minQuantidade, int maxQuantidade, Status status);
    Task<IEnumerable<Pedido>> GetByClienteNameAndStatusWithDetailsAsync(string clienteName, Status status);                  


    Task<IEnumerable<Pedido>> GetAllWithPaginationAsync(int pageNumber, int pageSize);
    Task<IEnumerable<Pedido>> GetByStatusWithPaginationAsync(Status status, int pageNumber, int pageSize);


    Task<Pedido?> UpdateStatusAsync(int id, Status newStatus);
    Task<IEnumerable<Pedido>> UpdateStatusByDateRangeAsync(DateTime startDate, DateTime endDate, Status newStatus);
    Task<IEnumerable<Pedido>> UpdateStatusByProdutoNameAsync(string produtoName, Status newStatus);

    Task DeleteByStatusAsync(Status status);
    Task DeleteByDateRangeAsync(DateTime startDate, DateTime endDate);
    Task DeleteByProdutoNameAsync(string produtoName);
}