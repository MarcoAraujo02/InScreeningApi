    using InScreeningApi.Data;
    using InScreeningApi.Models;
    using InScreeningApi.Repository.Interface;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;

    namespace InScreeningApi.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class FuncionarioController : ControllerBase
        {
            private readonly IFuncionarioRepository funcionarioRepository;

            public FuncionarioController(IFuncionarioRepository funcionario)
            {
                funcionarioRepository = funcionario;
            }

            /// <summary>
            /// Obter todos os funcionario sem nenhum parametro
            /// </summary>
            /// <returns></returns>
            /// <response code="200"> Retorna a lista de funcionarios</response>
            /// <response code="500"> Erro ao obter funcionario</response>
            /// <response code="404"> Funcionario nao encontrado</response>
            /// 

            [HttpGet]
            public async Task<ActionResult<Funcionario>> GetFuncionarios()
            {
                try
                {

                    return Ok(await funcionarioRepository.GetFuncionario());
                }
                catch (Exception )
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao pegar funcionarios");
                }   
             
            }


            /// <summary>
            /// Obter todos os funcionario pelo id selecionado
            /// </summary>
            /// <returns></returns>
            /// <response code="200"> Retorna a lista de funcionarios</response>
            /// <response code="500"> Erro ao obter funcionario</response>
            /// <response code="404"> Funcionario nao encontrado</response>
            /// 

            [HttpGet("{id:int}")]
            public async Task<ActionResult<Funcionario>> GetFuncionario(int id)
            {
            try
            {
                var result = await funcionarioRepository.GetFuncionario(id);
                if (result == null) return NotFound();

                return result;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Funcionario");
            }
              
                
                
            }


            /// <summary>
            /// Endpoint para cadastrar novos Funcionarios
            /// </summary>
            /// <returns>Retorna o piao Funcionario</returns>
            /// <remarks> 
            ///     Sample request:
            ///         POST /api/Funcionario
            ///         {
            ///             "nome": "Nome do Funcionario",
            ///             "cpf": "cpf do Funcionario",
            ///             "email": "Email do Funcionario",
            ///         }
            /// </remarks>
            /// <response code="201"> Salva o Funcionario</response>
            /// <response code="500"> Erro ao salva o Funcionario</response>
            /// <response code="400"> Faltou algo</response>
            /// 
            
            [HttpPost]
            public async Task<ActionResult<Funcionario>> AddFuncionario([FromBody] Funcionario funcionario)
            {
                try
                {
                    if (funcionario == null) return BadRequest();

                    var createFunc = await funcionarioRepository.AddFuncionario(funcionario);


                    return CreatedAtAction(nameof(GetFuncionarios),
                        new { id = createFunc.funcionarioId }, createFunc);
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter funcionario");
                }
            }


            /// <summary>
            /// Deletar os Funcionarios
            /// </summary>
            /// <returns></returns>
            /// <response code="201"> Deletar o Funcionarios</response>
            /// <response code="500"> Erro ao Deletar Funcionarios</response>
            /// <response code="404"> Empregado nao Funcionarios</response>
            /// 
            
            [HttpDelete("{id:int}")]
            public async Task<ActionResult> DeleteFuncionario(int id)
            {
                try
                {
                    var funToDelete = await funcionarioRepository.GetFuncionario(id);

                    if (funToDelete == null)
                        return NotFound($"Funcionario com id {id} não encontrado");

                    await funcionarioRepository.DeleteFuncionario(id);

                    return Ok($"Funcionario com id {id} deletado");
                }
                catch (Exception ex)
                {
                    // Log the exception message
                    // Logger.LogError(ex, "Erro ao deletar Funcionario");

                    return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar Funcionario");
                }
            }


            /// <summary>
            /// Atualizar dados
            /// </summary>
            /// <returns></returns>
            /// 

            [HttpPut("{id:int}")]
            public async Task<ActionResult<Funcionario>> UpdateFuncionario([FromBody] Funcionario funcionario)
            {
                try
                {
                    var FunUpdate = await funcionarioRepository.GetFuncionario(funcionario.funcionarioId);

                    if (FunUpdate == null) return NotFound($"Empregado com id {funcionario.funcionarioId} não encontrado");

                    return await funcionarioRepository.UpdateFuncionario(funcionario);
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar Funcionario");
                }
            }


    }
}
