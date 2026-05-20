
using System.ComponentModel.DataAnnotations;

public class Cliente
{
    [Required]
    [StringLength(100)]
    public string Nome{get; set;} = string.Empty;
    
    [Required]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF deve conter 11 números.")]
    public string CPF {get; set;} = string.Empty;
    
    [EmailAddress]
    public string Email{get; set;} = string.Empty;

    public List<Pedido> pedidos{get; set;} = new();
}