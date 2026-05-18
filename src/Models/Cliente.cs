
using System.ComponentModel.DataAnnotations;

public class Cliente
{
    [Required]
    public string Nome{get; set;}
    
    [Required]
    [StringLength(11)]
    public string CPF {get; set;}
    
    [EmailAddress]
    public string Email{get; set;}

    public List<Pedido> pedidos;
}