using System.ComponentModel.DataAnnotations;


public class ItemPedido
{
    [Required]
    public Produto produto{get; set;}
    [Required]
    public int Quantidade{get; set;}

    public decimal PrecoUnitario{get; set;}

    public decimal Total => Quantidade * PrecoUnitario;


}
