using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Hroads.Domains
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O nome do usuário é obrigatório!")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "O email do usuário é obrigatório!")]
        public string EmailUsuario { get; set; }

        [Required(ErrorMessage = "A senha do usuário é obrigatório!")]
        public string SenhaUsuario { get; set; }

        [Required(ErrorMessage = "O ID do tipo de usuário é obrigatório!")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "A senha deverá ter de 8 a 50 caracteres")]
        public int? IdTipoUsuario { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
    }
}
