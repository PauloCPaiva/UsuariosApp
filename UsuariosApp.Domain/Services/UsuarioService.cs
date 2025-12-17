using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Dtos;
using UsuariosApp.Domain.Entities;
using UsuariosApp.Domain.Helpers;
using UsuariosApp.Domain.Interfaces.Repositories;
using UsuariosApp.Domain.Interfaces.Services;
using UsuariosApp.Domain.Validators;
using UsuariosApp.Infra.Data.Entities;

namespace UsuariosApp.Domain.Services
{
    /// <summary>
    /// Classe de serviço para regras de negócio de usuário.
    /// </summary>
    public class UsuarioService(IUsuarioRepository usuarioRepository, IPerfilRepository perfilRepository) : IUsuarioService
    {
        public AutenticarResponse Autenticar(AutenticarRequest request)
        {
            //Buscar o usuário no banco de dados baseado no email e na senha.
            var usuario = usuarioRepository.Get(request.Email, CryptoHelper.ToSha256(request.Senha));

            //Verificar se o usuário não foi encontrado
            if (usuario == null)
            {
                throw new ApplicationException("Acesso negado. Usuário inválido.");
            }

            //Retornar os dados do usuário autenticado
            return new AutenticarResponse(
                usuario.Id,                    //Id do usuário
                usuario.Nome,                  //Nome do usuário
                usuario.Email,                 //Email do usuário
                usuario.Perfil?.Nome,          //Nome do perfil do usuário
                DateTime.Now,                  //Data e hora do acesso
                DateTime.Now.AddHours(1),      //Data e hora de expiração do token
                "<<TOKEN>>"                    //Token JWT (vazio por enquanto)
                );
        }

        public CriarContaResponse CriarConta(CriarContaRequest request)
        {
            //Capturar os dados recebidos (request)
            var usuario = new Usuario
            {
                Nome = request.nome,
                Email = request.email,
                Senha = request.senha
            };


            //Criando um objeto da classe de validação (Fluent Validator)
            var validator = new UsuarioValidator();
            var result = validator.Validate(usuario);

            //Verificar se existe algum erro de validação no usuário
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            //Verificar se já existe outro usuário com o email cadastrado
            if (usuarioRepository.Get(usuario.Email) != null)
            {
                throw new ApplicationException("O email informado já está cadastrado. Tente outro.");
            }

            //Criptografar a senha do usuário
            usuario.Senha = CryptoHelper.ToSha256(usuario.Senha);

            //Consultando o perfil "OPERADOR" no banco de dados
            var perfil = perfilRepository.Get("OPERADOR");

            //Caso o perfil não exista, iremos cria-lo
            if (perfil == null)
            {
                perfil = new Perfil() { Nome = "OPERADOR" };
                perfilRepository.Add(perfil);  //Salvar o perfil no banco de dados               
            }

            //Associar o usuário ao perfil de operador
            usuario.PerfilId = perfil.Id;

            //Salvar no banco de dados
            usuarioRepository.Add(usuario);

            //Retornar os dados do usuário criado
            return new CriarContaResponse(
                usuario.Id,             //Id do usuário
                usuario.Nome,           //Nome do usuário
                usuario.Email,          //Email do usuário    
                usuario.DataHoraCriacao //Data e hora da criação do usuário
                );
        }
    }
}

