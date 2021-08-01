using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CaixaEletronico.Data;
using CaixaEletronico.Models;

namespace CaixaEletronico.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContaController : ControllerBase
    {
         private readonly IRepository _repo;

        public ContaController(IRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Buscar as contas.
        /// </summary>
        /// <param name="GetAllContaAsync">Retorna todas as contas</param>
        /// <response code="200">Retorna as contas</response>
        /// <response code="400">Caso não haja nenhum compromisso</response>

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllContaAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Buscar um conta pelo seu numero
        /// </summary>
        /// <param name="contaNumero"> Numero da conta buscada</param>
        /// <response code="200">Retorna a conta  filtrada</response>
        /// <response code="400">Caso não haja conta  com este numero</response> 

        [HttpGet("{contaNumero}")]
        public async Task<IActionResult> GetContaAsyncByNumero(int contaNumero)
        {
            try
            {
                var result = await _repo.GetContaAsyncByNumero(contaNumero);
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Inserir uma conta 
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST /Modelo
        ///     {
        ///        "tarefa": "Reunião",
        ///        "local": "Escritorio",
        ///        "dia": "02/08/2021",
        ///        "hora": "08:30"
        ///     }
        /// </remarks>
        /// <param name="model">Dados da conta a ser inserida</param>
        /// <response code="200">Caso a conta seja inserida com sucesso</response>
        /// <response code="400">Caso já exista uma conta com as mesma informações</response>

        [HttpPost]
        public async Task<IActionResult> post(Conta model)
        {
            try
            {
                _repo.Add(model);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok(model);
                }                
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }


         /// <summary>
        /// Excluir uma conta
        /// </summary>
        /// /// <param name="contaNumero">Numero da conta a ser excluída</param>
        /// <response code="200">Caso a conta seja excluida com sucesso</response>
        /// <response code="400">Caso não exista uma conta com este numero</response>  

        [HttpDelete("{contaNumero}")]
        public async Task<IActionResult> delete(int contaNumero)
        {
            try
            {
                var conta = await _repo.GetContaAsyncByNumero(contaNumero);
                if(conta == null) return NotFound();

                _repo.Delete(conta);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok("Deletado");
                }                
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }
    }
}