using System.ComponentModel.DataAnnotations;

public class Gerente: Funcionario
{
    [Required]
    public decimal LimiteDesconto{get; set;}
}
