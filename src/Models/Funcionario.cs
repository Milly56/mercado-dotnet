

using System.ComponentModel.DataAnnotations;

public  class Funcionario
{
   
   public int Id{get; set;}

   [Required]
   [StringLength(100)]
   public string Nome { get;  set;} = string.Empty;

   [Required]
   [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF deve conter 11 números.")]
   public string? CPF{ get; set; } = string.Empty;
   public double Salario{get; set;}

}
