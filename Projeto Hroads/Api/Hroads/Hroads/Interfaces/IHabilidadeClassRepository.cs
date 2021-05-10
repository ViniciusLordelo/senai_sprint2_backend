using Hroads.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads.Interfaces
{
    interface IHabilidadeClassRepository
    {
        void Create(HabilidadeClass NovoHabilidadeClass);

        List<HabilidadeClass> Read();

        HabilidadeClass ReadById(int Id);

        void Update(HabilidadeClass HabilidadeClassAtualizado, int Id);

        void Delete(int Id);
    }
}
