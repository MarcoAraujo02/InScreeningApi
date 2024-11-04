using InScreeningApi.Data;
using InScreeningApi.Models;
using InScreeningApi.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using InScreeningApi.Repository;
using System.Collections;

namespace InScreeningApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExameController : ControllerBase
    {

        private readonly IExameRepository _exameRepository;

        public ExameController(IExameRepository exameRepository)
        {
            _exameRepository = exameRepository;
        }

        /// <summary>
        /// Obter todos os Exames realizados, API de IA deve estar rodando para o funcionamento
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Retorna a lista de exames</response>
        /// <response code="500"> Erro ao obter Exame</response>
        /// <response code="404"> Exame não encontrado</response>
        /// 

        [HttpGet]
        public async Task<ActionResult<IEnumerable>> GetExame()
        {
            try
            {
                var exames = await _exameRepository.GetExame();

                return Ok(exames);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao obter exames: " + ex.Message);
            }
           
        }
    }
}
