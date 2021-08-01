using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CaixaEletronico.Data;
using CaixaEletronico.Models;

namespace CaixaEletronico.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CaixaController : ControllerBase
    {
        private readonly IRepository _repo;

        public CaixaController(IRepository repo)
        {
            _repo = repo;
        }

         /// <summary>
        /// Buscar valor do dinheiro do caixa.
        /// </summary>
        /// <param name="GetAllCaixaAsync">Retorna todos valores de dinheiro do caixa</param>
        /// <response code="200">Retorna os valores</response>
        /// <response code="400">Caso não haja nenhum valor</response>
         [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllCaixaAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Atualizar dinheiro no caixa
        /// </summary>
        /// /// <param name="caixaDinheiroDisponivel">Valor do dinheiro para ser atualizado</param>
        /// <param name="model">Novos dados para atualizar o valor do dinheiro</param>
        /// <response code="200">Caso o dinheiro seja atualizado com sucesso</response>
        /// <response code="404">Caso não exista ocorra a atualização</response>   

        [HttpPut("{caixaDinheiroDisponivel}")]
        public async Task<IActionResult> put(decimal caixaDinheiroDisponivel, Caixa model)
        {
            try
            {
                var caixa = await _repo.GetCaixaAsyncByDinheiro(caixaDinheiroDisponivel);
                if(caixa == null) return NotFound();

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
    }
}