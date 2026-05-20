using System.ComponentModel.DataAnnotations;


public class ItemPedido
{
    public int Id{get; set;}

    [Required]
    public Produto Produto{get; set;} = new ();
    [Required]
    public int Quantidade{get; set;}

    public decimal PrecoUnitario{get; set;}

    public decimal Total => Quantidade * PrecoUnitario;


}
