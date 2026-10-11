using Microsoft.AspNetCore.Mvc;
using prova_2.Models;
using prova_2.Repository;
using prova_2.Validations;

namespace prova_2.Controllers; 

[ApiController]
[Route("api/[controller]")]
public class JogadoresController : ControllerBase
{
    private readonly IJogadorRepository _repository;

    public JogadoresController(IJogadorRepository repository)
    {
        _repository = repository;
    }

    // 1. Cadastrar jogador
    [HttpPost]
    public IActionResult Cadastrar([FromBody] Jogador jogador)
    {
        var erros = JogadorValidator.Validar(jogador);
        if (erros.Count > 0)
            return BadRequest(erros);

        if (_repository.ObterPorCpf(jogador.Cpf!) != null)
            return BadRequest("Já existe um jogador cadastrado com este CPF.");

        jogador.Aprovado = null;
        _repository.Adicionar(jogador);

        return Created("", jogador);
    }

    // 2. Listar todos
    [HttpGet]
    public IActionResult Listar()
    {
        return Ok(_repository.ListarTodos());
    }

    // 3. Registrar resultado
    [HttpPost("resultado")]
    public IActionResult RegistrarResultado([FromBody] ResultadoRequest request)
    {
        var erros = JogadorValidator.ValidarResultado(request);
        if (erros.Count > 0)
            return BadRequest(erros);

        var jogador = _repository.ObterPorCpf(request.Cpf!);

        if (jogador == null)
            return NotFound("Jogador não encontrado. Não foi possível registrar o resultado.");

        if (jogador.Aprovado != null)
            return BadRequest("O resultado deste jogador já foi registrado.");

        jogador.Aprovado = request.Aprovado;

        return Ok(jogador);
    }

    // 4. Consultar aprovados
    [HttpGet("aprovados")]
    public IActionResult ListarAprovados()
    {
        return Ok(_repository.ListarAprovados());
    }
}



