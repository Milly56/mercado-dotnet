
public class FuncionarioService
{
    private readonly IFuncionarioRepository _repository;

    public FuncionarioService(IFuncionarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Funcionario>> GetAllAsync() =>
        await _repository.GetAllAsync();

    public async Task<Funcionario?> GetByIdAsync(int id) =>
        await _repository.GetValueAsync(id);

    public async Task<Funcionario?> GetByNomeAsync(string nome) =>
        await _repository.GetFuncionarioAsync(nome);

    public async Task AddAsync(Funcionario funcionario) =>
        await _repository.AddAsync(funcionario);

    public async Task UpdateAsync(Funcionario funcionario) =>
        await _repository.UpdateAsync(funcionario);

    public async Task DeleteAsync(int id) =>
        await _repository.DeleteAsync(id);
}