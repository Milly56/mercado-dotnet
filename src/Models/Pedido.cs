using System.ComponentModel.DataAnnotations;


public class Pedido
{
    public int Id{get; set;}

    [Required]
    public Status Status{get; set;}
    [Required]
    public Cliente Cliente{get; set;} = new();

    public Funcionario Funcionario{get; set;} = new();

    public List<ItemPedido> Itens{get;set;} = new ();

    public DateTime Data{get;set;}

}