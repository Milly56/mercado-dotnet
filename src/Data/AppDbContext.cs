using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Caixa> Caixas {get; set;}
    public DbSet<Funcionario> Funcionarios {get; set;}
    public DbSet<ItemPedido> ItemPedidos {get; set;}
    public DbSet<Produto> Produtos {get; set;}
    public DbSet<Gerente> Gerentes {get; set;}
    
}