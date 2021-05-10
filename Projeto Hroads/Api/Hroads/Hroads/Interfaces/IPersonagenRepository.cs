using Hroads.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads.Interfaces
{
    interface IPersonagenRepository
    {

        void Create(Personagen NovoPersonagen);

        List<Personagen> Read();

        Personagen ReadById(int Id);

        void Update(Personagen PersonagenAtualizado, int Id);

        void Delete(int Id);
    }
}
