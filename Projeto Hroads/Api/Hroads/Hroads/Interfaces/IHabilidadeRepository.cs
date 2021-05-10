using Hroads.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads.Interfaces
{
    interface IHabilidadeRepository
    {
        void Create(Habilidade NovoHabilidade);

        List<Habilidade> Read();

        Habilidade ReadById(int Id);

        void Update(Habilidade HabilidadeAtualizado, int Id);

        void Delete(int Id);
    }
}
