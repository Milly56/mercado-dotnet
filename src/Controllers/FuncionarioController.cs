using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

[ApiController]
[Route("api/[controller]")]
[Tags("Funcionários")]
public class FuncionarioController : ControllerBase
{
    private readonly FuncionarioService _service;

    public FuncionarioController(FuncionarioService service)
    {
        _service = service;
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Listar funcionários", Description = "Retorna todos os funcionários cadastrados no sistema")]
    [ProducesResponseType(typeof(IEnumerable<FuncionarioResponseDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var funcionarios = await _service.GetAllAsync();
        var response = funcionarios.Select(f => new FuncionarioResponseDto
        {
            Id = f.Id,
            Nome = f.Nome,
            CPF = f.CPF ?? string.Empty,
            Salario = f.Salario
        });
        return Ok(response);
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Buscar funcionário por ID", Description = "Retorna um funcionário específico pelo seu identificador")]
    [ProducesResponseType(typeof(FuncionarioResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var funcionario = await _service.GetByIdAsync(id);
        if (funcionario == null) return NotFound();

        return Ok(new FuncionarioResponseDto
        {
            Id = funcionario.Id,
            Nome = funcionario.Nome,
            CPF = funcionario.CPF ?? string.Empty,
            Salario = funcionario.Salario
        });
    }

    [HttpGet("nome/{nome}")]
    [SwaggerOperation(Summary = "Buscar funcionário por nome", Description = "Retorna funcionários filtrando pelo nome")]
    [ProducesResponseType(typeof(FuncionarioResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByNome(string nome)
    {
        var funcionario = await _service.GetByNomeAsync(nome);
        if (funcionario == null) return NotFound();

        return Ok(new FuncionarioResponseDto
        {
            Id = funcionario.Id,
            Nome = funcionario.Nome,
            CPF = funcionario.CPF ?? string.Empty,
            Salario = funcionario.Salario
        });
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Criar funcionário", Description = "Cadastra um novo funcionário no sistema do supermercado")]
    [ProducesResponseType(typeof(FuncionarioResponseDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> Add([FromBody] FuncionarioRequestDto dto)
    {
        var funcionario = new Funcionario
        {
            Nome = dto.Nome,
            CPF = dto.CPF,
            Salario = dto.Salario
        };

        await _service.AddAsync(funcionario);

        var response = new FuncionarioResponseDto
        {
            Id = funcionario.Id,
            Nome = funcionario.Nome,
            CPF = funcionario.CPF ?? string.Empty,
            Salario = funcionario.Salario
        };

        return CreatedAtAction(nameof(GetById), new { id = funcionario.Id }, response);
    }

    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Atualizar funcionário", Description = "Atualiza os dados de um funcionário existente")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, [FromBody] FuncionarioRequestDto dto)
    {
        var funcionario = await _service.GetByIdAsync(id);
        if (funcionario == null) return NotFound();

        funcionario.Nome = dto.Nome;
        funcionario.CPF = dto.CPF;
        funcionario.Salario = dto.Salario;

        await _service.UpdateAsync(funcionario);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Remover funcionário", Description = "Remove um funcionário do sistema pelo ID")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}