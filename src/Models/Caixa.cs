

using System.ComponentModel.DataAnnotations;

public class Caixa : Funcionario
{
    [Required]
    public int TotalVendasRealizadas{get; set;}
}