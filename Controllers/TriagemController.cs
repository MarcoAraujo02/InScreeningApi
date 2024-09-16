using InScreeningApi.Models;
using InScreeningApi.Repository;
using InScreeningApi.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace InScreeningApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TriagemController : ControllerBase
    {

        private readonly ITriagemRepository TriagemRepository;

        public TriagemController(ITriagemRepository triagem)
        {
            TriagemRepository = triagem;
        }



        /// <summary>
        /// Obter todos as triagens
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Retorna a lista de triagem</response>
        /// <response code="500"> Erro ao obter triagem</response>
        /// <response code="404"> Triagem nao encontrada</response>
        /// 

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Triagem>>> GetTriagem()
        {
            return Ok(await TriagemRepository.GetTriagem());
        }



        /// <summary>
        /// Obter todas as Triagens pelo id selecionado
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Retorna a triagem</response>
        /// <response code="500"> Erro ao obter triagem</response>
        /// <response code="404"> Triagem nao encontrada</response>

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Triagem>> GetTriagem(int id)
        {
            try
            {
                var result = await TriagemRepository.GetTriagem(id);
                if (result == null) return NotFound();

                return result;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Triagem");
            }
        }



        /// <summary>
        /// Endpoint para cadastrar novas triagens
        /// </summary>
        /// <returns>Retorna a triagem criada</returns>
        /// <remarks> 
        ///     Sample request:
        ///         POST /api/Paciente
        ///         {
        ///             "Sintomas": "Sintomas do paciente",
        ///             "Prioridade": "Prioridade do paciente sendo Alta = 0, Media = 1, Baixa = 2",
        ///             "pacienteId": "Id do paciente que a triagem esta relacionada",
        ///             "funcionarioId": "Id do funcionario que a triagem esta relacionada",
        ///       
        ///         }
        /// </remarks>
        /// <response code="201"> Salva a triagem</response>
        /// <response code="500"> Erro ao salvar a triagem</response>
        /// <response code="400"> Dados inválidos</response>

        [HttpPost]
        public async Task<ActionResult<Triagem>> AddTriagem([FromBody] Triagem triagem)
        {
            try
            {
                if (triagem == null) return BadRequest();

                var createtri = await TriagemRepository.AddTriagem(triagem);

                return CreatedAtAction(nameof(GetTriagem),
                    new { id = createtri.triagemId }, createtri);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao cadastrar triagem");
            }
        }



        /// <summary>
        /// Deletar as triagens
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Deletar a triagem</response>
        /// <response code="500"> Erro ao deletar triagem</response>
        /// <response code="404"> Triagem não encontrado</response>

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeletePaciente(int id)
        {
            try
            {
                var pacienteToDelete = await TriagemRepository.GetTriagem (id);

                if (pacienteToDelete == null)
                    return NotFound($"Triagem com id {id} não encontrado");

                await TriagemRepository.DeleteTriagem(id);

                return Ok($"Paciente com id {id} deletado");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar paciente");
            }
        }



        /// <summary>
        /// Atualizar dados
        /// </summary>
        /// <returns></returns>
        /// 

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Triagem>> UpdateTriagem([FromBody] Triagem triagem)
        {
            try
            {
                var FunUpdate = await TriagemRepository.GetTriagem(triagem.triagemId);

                if (FunUpdate == null) return NotFound($"Triagem com id {triagem.triagemId} não encontrado");

                return await TriagemRepository.UpdateTriagem(triagem);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar Triagem");
            }
        }

    }
}
