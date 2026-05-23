using System.ComponentModel.DataAnnotations;



public class PedidoRequestDto
{    
    [Required]
    public Status Status { get; set; }
    [Required]
    public int Cliente { get; set; }
    [Required]
    public int Funcionario { get; set; }
    [Required]
    public List<ItemPedido> Itens { get; set; } = new();
    [Required]
    public DateTime Data { get; set; }

}
