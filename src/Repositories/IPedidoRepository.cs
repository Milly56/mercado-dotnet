public interface IPedidoRepository : IRepository<Pedido>
{

    Task<Pedido?> GetByIdWithDetailsAsync(int id);
    Task<IEnumerable<Pedido>> GetAllWithDetailsAsync();
    Task<IEnumerable<Pedido>> GetByStatusWithDetailsAsync(Status status);                                                        // Status é enum, não string
    Task<IEnumerable<Pedido>> GetByProdutoNameWithDetailsAsync(string produtoName);                                              // vem de Itens -> Produto.Nome
    Task<IEnumerable<Pedido>> GetByStatusAndDateRangeWithDetailsAsync(Status status, DateTime startDate, DateTime endDate);      // Data, não DataPedido
    Task<IEnumerable<Pedido>> GetByQuantidadeRangeAndStatusWithDetailsAsync(int minQuantidade, int maxQuantidade, Status status); // Quantidade vem do ItemPedido
    Task<IEnumerable<Pedido>> GetByClienteNameAndStatusWithDetailsAsync(string clienteName, Status status);                      // Cliente é navigation direta


    Task<IEnumerable<Pedido>> GetAllWithPaginationAsync(int pageNumber, int pageSize);
    Task<IEnumerable<Pedido>> GetByStatusWithPaginationAsync(Status status, int pageNumber, int pageSize);


    Task<Pedido?> UpdateStatusAsync(int id, Status newStatus);
    Task<IEnumerable<Pedido>> UpdateStatusByDateRangeAsync(DateTime startDate, DateTime endDate, Status newStatus);
    Task<IEnumerable<Pedido>> UpdateStatusByProdutoNameAsync(string produtoName, Status newStatus);

    Task DeleteByStatusAsync(Status status);
    Task DeleteByDateRangeAsync(DateTime startDate, DateTime endDate);
    Task DeleteByProdutoNameAsync(string produtoName);
}