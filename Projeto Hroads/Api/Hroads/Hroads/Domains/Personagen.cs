using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Hroads.Domains
{
    public partial class Personagen
    {
        public int IdPersonagem { get; set; }

        [Required(ErrorMessage = "O ID da classe é obrigatório!")]
        public int? IdClasse { get; set; }

        [Required(ErrorMessage = "O nome do personagem é obrigatório!")]
        public string NomePersonagem { get; set; }

        [Required(ErrorMessage = "A capacidade máxima de vida é obrigatório!")]
        public string CapacidadeMaximaVida { get; set; }

        [Required(ErrorMessage = "A capacidade máxima de mana é obrigatório!")]
        public string CapacidadeMaximaMana { get; set; }

        [Required(ErrorMessage = "A data da atualização é obrigatório!")]
        public string DataAtualizacao { get; set; }

        [Required(ErrorMessage = "A data da criação é obrigatório!")]
        public string DataCriacao { get; set; }

        public virtual Class IdClasseNavigation { get; set; }
    }
}
