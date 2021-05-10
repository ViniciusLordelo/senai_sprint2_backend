using Hroads.Contexts;
using Hroads.Domains;
using Hroads.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        SENAI_HROADSContext ctx = new SENAI_HROADSContext();

        public Usuario Login(string Email, string Senha)
        {
            return ctx.Usuarios.FirstOrDefault(c => c.EmailUsuario == Email && c.SenhaUsuario == Senha);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="NovoUsuario"></param>
        public void Create(Usuario NovoUsuario)
        {
            ctx.Usuarios.Add(NovoUsuario);

            ctx.SaveChanges();
        }

        /// <summary>
        /// E
        /// </summary>
        /// <param name="Id"></param>
        public void Delete(int Id)
        {
            ctx.Usuarios.Remove(ReadById(Id));

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns>Uma lista de usuários</returns>
        public List<Usuario> Read()
        {
            return ctx.Usuarios
                .Include(u => u.IdTipoUsuarioNavigation)
                .ToList();
        }


        /// <summary>
        /// Busca um usuário pelo Id
        /// </summary>
        /// <param name="Id">Id do usuário que será buscado</param>
        /// <returns>Um usuário</returns>
        public Usuario ReadById(int Id)
        {
            return ctx.Usuarios.FirstOrDefault(c => c.IdUsuario == Id);
        }


        /// <summary>
        /// Método para atualizar um usuário
        /// </summary>
        /// <param name="UsuarioAtualizado">Usuário contendo as novas informações</param>
        /// <param name="Id">Id do usuário que será atualizado</param>
        public void Update(Usuario UsuarioAtualizado, int Id)
        {
            Usuario UsuarioBuscado = ReadById(Id);
            
            if(UsuarioAtualizado.NomeUsuario != null)
            {
                UsuarioBuscado.NomeUsuario = UsuarioAtualizado.NomeUsuario;

                ctx.Usuarios.Update(UsuarioBuscado);

                ctx.SaveChanges();
            }

            if(UsuarioAtualizado.EmailUsuario != null)
            {
                UsuarioBuscado.EmailUsuario = UsuarioAtualizado.EmailUsuario;

                ctx.Usuarios.Update(UsuarioBuscado);

                ctx.SaveChanges();
            }

            if(UsuarioAtualizado.SenhaUsuario != null)
            {
                UsuarioBuscado.SenhaUsuario = UsuarioAtualizado.SenhaUsuario;

                ctx.Usuarios.Update(UsuarioBuscado);

                ctx.SaveChanges();
            }

            if(UsuarioAtualizado.IdTipoUsuario != null)
            {
                UsuarioBuscado.IdTipoUsuario = UsuarioAtualizado.IdTipoUsuario;

                ctx.Usuarios.Update(UsuarioBuscado);

                ctx.SaveChanges();
            }
        }
    }
}
