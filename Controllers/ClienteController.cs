using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CaixaEletronico.Data;
using CaixaEletronico.Models;

namespace CaixaEletronico.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
         private readonly IRepository _repo;

        public ClienteController(IRepository repo)
        {
            _repo = repo;
        }

         /// <summary>
        /// Buscar os clientes.
        /// </summary>
        /// <response code="200">Retorna os clientes</response>
        /// <response code="400">Caso não haja nenhum cliente</response>

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllClienteAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Buscar um cliente pelo seu Id
        /// </summary>
        /// <response code="200">Retorna o cliente filtrado</response>
        /// <response code="400">Caso não haja cliente  com este id</response> 

        [HttpGet("{clienteId}")]
        public async Task<IActionResult> GetByClienteId(int clienteId)
        {
            try
            {
                var result = await _repo.GetClienteAsyncById(clienteId);
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Inserir um cliente
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
        /// <param name="model">Dados do cliente a ser inserido</param>
        /// <response code="200">Caso o cliente seja inserido com sucesso</response>
        /// <response code="400">Caso já exista um cliente com a mesmo nome e a mesma conta</response>

        [HttpPost]
        public async Task<IActionResult> post(Cliente model)
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
        /// Atualizar um cliente
        /// </summary>
        /// /// <param name="clienteId">Id do cliente a ser atualizado</param>
        /// <param name="model">Novos dados para atualizar o cliente indicado</param>
        /// <response code="200">Cao o cliente seja atualizado com sucesso</response>
        /// <response code="400">Caso não exista um cliente com este Id</response>   

        [HttpPut("{clienteId}")]
        public async Task<IActionResult> put(int clienteId, Cliente model)
        {
            try
            {
                var clientes = await _repo.GetClienteAsyncById(clienteId);
                if(clientes == null) return NotFound();

                _repo.Update(model);

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
        /// Excluir um cliente
        /// </summary>
        /// /// <param name="clienteId">Id do cliente a ser excluído</param>
        /// <response code="200">Caso o cliente seja excluido com sucesso</response>
        /// <response code="400">Caso não exista um cliente com este Id</response>  

        [HttpDelete("{clienteId}")]
        public async Task<IActionResult> delete(int clienteId)
        {
            try
            {
                var clientes = await _repo.GetClienteAsyncById(clienteId);
                if(clientes == null) return NotFound();

                _repo.Delete(clientes);

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