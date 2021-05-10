using Hroads.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads.Interfaces
{
    interface ITipoHabilidadeRepository
    {
        void Create(TipoHabilidade NovoTipoHabilidade);

        List<TipoHabilidade> Read();

        TipoHabilidade ReadById(int Id);

        void Update(TipoHabilidade TipoHabilidadeAtualizado, int Id);

        void Delete(int Id);
    }
}
