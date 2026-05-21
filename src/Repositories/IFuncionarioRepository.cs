
public interface IFuncionarioRepository : IRepository<Funcionario>
{
    Task<Funcionario?> GetFuncionarioAsync(string Nome);
}
