using System.ComponentModel.DataAnnotations;


public class Pedido
{
    [Required]
    public Status status{get; set;}
    [Required]
    public Cliente cliente{get; set;}

    public Funcionario Funcionario{get; set;}

    public List<ItemPedido> Itens{get;set;}

    public DateTime data{get;set;}

}