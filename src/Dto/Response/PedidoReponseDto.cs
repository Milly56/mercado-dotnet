
public class PedidoResponseDto
{
    public int Id{get; set;}

    public Status Status{get; set;}
 
    public Cliente Cliente{get; set;} = new();

    public Funcionario Funcionario{get; set;} = new();

    public List<ItemPedido> Itens{get;set;} = new ();

    public DateTime Data{get;set;}

}