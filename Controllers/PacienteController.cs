using InScreeningApi.Models;
using InScreeningApi.Repository;
using InScreeningApi.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace InScreeningApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteRepository PacienteRepository;

        public PacienteController(IPacienteRepository paciente)
        {
            PacienteRepository = paciente;
        }

        /// <summary>
        /// Obter todos os Pacientes sem nenhum parametro
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Retorna a lista de pacientes</response>
        /// <response code="500"> Erro ao obter pacientes</response>
        /// <response code="404"> Pacientes não encontrados</response>
        /// 
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paciente>>> GetPacientes()
        {
            return Ok(await PacienteRepository.GetPacientes());
        }



        /// <summary>
        /// Obter todos os Endereços
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Retorna a lista de endereços</response>
        /// <response code="500"> Erro ao obter endereços</response>
        /// <response code="404"> Endereços não encontrados</response>
        /// 
        
        [HttpGet("enderecos")]
        public async Task<ActionResult<IEnumerable<Endereco>>> GetEndereco()
        {
            return Ok(await PacienteRepository.GetEndereco());
        }



        /// <summary>
        /// Obter todos os Pacientes pelo id selecionado
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Retorna o paciente</response>
        /// <response code="500"> Erro ao obter paciente</response>
        /// <response code="404"> Paciente não encontrado</response>
        
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Paciente>> GetPaciente(int id)
        {
            try
            {
                var result = await PacienteRepository.GetPaciente(id);
                if (result == null) return NotFound();

                return result;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter paciente");
            }
        }



        /// <summary>
        /// Endpoint para cadastrar novos Pacientes
        /// </summary>
        /// <returns>Retorna o paciente criado</returns>
        /// <remarks> 
        ///     Sample request:
        ///         POST /api/Paciente
        ///         {
        ///             "nome": "Nome do Paciente",
        ///             "cpf": "CPF do paciente",
        ///             "email": "Email do paciente",
        ///             "rg": "RG do paciente",
        ///             "sexo": "None = 0, Feminino = 1, Masculino = 2, Outro = 3",
        ///             "enderecoId": "Endereco vinculado"
        ///         }
        /// </remarks>
        /// <response code="201"> Salva o paciente</response>
        /// <response code="500"> Erro ao salvar o paciente</response>
        /// <response code="400"> Dados inválidos</response>
        
        [HttpPost]
        public async Task<ActionResult<Paciente>> AddPaciente([FromBody] Paciente paciente)
        {
            try
            {
                if (paciente == null) return BadRequest();

                var createpa = await PacienteRepository.AddPaciente(paciente);

                return CreatedAtAction(nameof(GetPaciente),
                    new { id = createpa.pacienteId }, createpa);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao criar paciente");
            }
        }



        /// <summary>
        /// Endpoint para cadastrar novos Endereços
        /// </summary>
        /// <returns>Retorna o endereço criado</returns>
        /// <remarks> 
        ///     Sample request:
        ///         POST /api/Paciente/enderecos
        ///         {
        ///             "logradouro": "Logradouro do endereço",
        ///             "numero": "Número",
        ///             "bairro": "Bairro",
        ///             "cidade": "Cidade",
        ///             "estado": "Estado",
        ///             "cep": "CEP"
        ///         }
        /// </remarks>
        /// <response code="201"> Salva o endereço</response>
        /// <response code="500"> Erro ao salvar o endereço</response>
        /// <response code="400"> Dados inválidos</response>
        
        [HttpPost("enderecos")]
        public async Task<ActionResult<Endereco>> AddEndereco([FromBody] Endereco endereco)
        {
            try
            {
                if (endereco == null) return BadRequest();

                var createend = await PacienteRepository.AddEndereco(endereco);

                return CreatedAtAction(nameof(GetEndereco),
                    new { id = createend.EnderecoId }, createend);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao criar endereço");
            }
        }




        /// <summary>
        /// Deletar os Pacientes
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Deletar o Paciente</response>
        /// <response code="500"> Erro ao deletar Paciente</response>
        /// <response code="404"> Paciente não encontrado</response>
       
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeletePaciente(int id)
        {
            try
            {
                var pacienteToDelete = await PacienteRepository.GetPaciente(id);

                if (pacienteToDelete == null)
                    return NotFound($"Paciente com id {id} não encontrado");

                await PacienteRepository.DeletePaciente(id);

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
        public async Task<ActionResult<Paciente>> UpdatePaciente([FromBody] Paciente paciente)
        {
            try
            {
                var pacUpdate = await PacienteRepository.GetPaciente(paciente.pacienteId);

                if (pacUpdate == null) return NotFound($"Paciente com id {paciente.pacienteId} não encontrado");

                return await PacienteRepository.UpdatePaciente(paciente);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar Paciente");
            }
        }
    }
}
