using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Hroads.Domains
{
    public partial class Habilidade
    {
        public Habilidade()
        {
            HabilidadeClasses = new HashSet<HabilidadeClass>();
        }

        public int IdHabilidade { get; set; }

        [Required(ErrorMessage = "O ID do tipo de habilidade é obrigatório!")]
        public int? IdTipoHabilidade { get; set; }

        [Required(ErrorMessage = "O nome da habilidade é obrigatório!")]
        public string NomeHabilidade { get; set; }

        public virtual TipoHabilidade IdTipoHabilidadeNavigation { get; set; }
        public virtual ICollection<HabilidadeClass> HabilidadeClasses { get; set; }
    }
}
