using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsuariosApp.Domain.Dtos;
using UsuariosApp.Domain.Interfaces.Services;

namespace UsuariosApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController(IUsuarioService usuarioService) : ControllerBase
    {
        [HttpPost("autenticar")]
        [ProducesResponseType(typeof(AutenticarResponse), 200)]
        public IActionResult Autenticar([FromBody] AutenticarRequest request)
        {
            try
            {
                var response = usuarioService.Autenticar(request);

                //HTTP 200 OK
                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                //Http 401 - Unauthorized/ Não autorizado
                return StatusCode(401, new { e.Message });
            }
            catch (Exception e) 
            {
                //Http 500 - Internal Server Error/ Erro do servidor
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpPost("criar")]
        [ProducesResponseType(typeof(CriarContaResponse), 201)]
        public IActionResult Criar([FromBody] CriarContaRequest request)
        {
            try
            {
                var response = usuarioService.CriarConta(request);
                return StatusCode(201, response); //HTTP 201 Created
            }
            catch (ValidationException e)
            {
                //Http 400 - Bad Request/ Requisição inválida
                return StatusCode(400, new { e.Errors });
            }
            catch (ApplicationException e)
            {
                //Http 409 - Conflict/ Conflito
                return StatusCode(409, new { e.Message });
            }
            catch (Exception e)
            {
                //Http 500 - Internal Server Error/ Erro do servidor
                return StatusCode(500, new { e.Message });
            }
        }
    }
}
