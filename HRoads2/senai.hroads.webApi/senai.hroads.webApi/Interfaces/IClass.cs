using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IClass
    {
        List<Class> ListarClasses();

        Class BuscarPorId(int id);

        void CadastrarClasses(Class novaClass);

        void DeletarClasses(int id);

        void AtualizarClasses(int id, Class ClassAtualizada);





       


    }
}
