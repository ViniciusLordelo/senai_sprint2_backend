using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Hroads.Domains
{
    public partial class Class
    {
        public Class()
        {
            HabilidadeClasses = new HashSet<HabilidadeClass>();
            Personagens = new HashSet<Personagen>();
        }

        public int IdClasse { get; set; }

        [Required(ErrorMessage = "O nome da classe é obrigatório!")]
        public string NomeClasse { get; set; }

        public virtual ICollection<HabilidadeClass> HabilidadeClasses { get; set; }
        public virtual ICollection<Personagen> Personagens { get; set; }
    }
}
