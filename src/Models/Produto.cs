

using System.ComponentModel.DataAnnotations;

public class Produto
{
    public int Id{get; set;}

    [Required]
    public string Nome {get; set;} = string.Empty;
    [Required]
    public decimal Preco{get;set;}
    public int Estoque {get; set;}
   public Categoria Categoria{get; set;}

}

