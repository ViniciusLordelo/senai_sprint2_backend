using Hroads.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads.Interfaces
{
    interface IClassRepository
    {

        void Create(Class NovoClass);

        List<Class> Read();

        Class ReadById(int Id);

        void Update(Class ClassAtualizado, int Id);

        void Delete(int Id);
    }
}
