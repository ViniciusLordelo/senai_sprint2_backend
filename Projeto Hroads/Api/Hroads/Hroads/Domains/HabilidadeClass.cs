using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Hroads.Domains
{
    public partial class HabilidadeClass
    {
        public int IdHabilidadeClasses { get; set; }

        [Required(ErrorMessage = "O ID da classe é obrigatório!")]
        public int? IdClasse { get; set; }

        [Required(ErrorMessage = "O ID da habilidade é obrigatório!")]
        public int? IdHabilidade { get; set; }

        public virtual Class IdClasseNavigation { get; set; }
        public virtual Habilidade IdHabilidadeNavigation { get; set; }
    }
}
