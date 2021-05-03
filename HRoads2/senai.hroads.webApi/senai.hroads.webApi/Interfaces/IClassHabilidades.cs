using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IClassHabilidades
    {
        List<ClassesHabilidade> ListarClasseHabilidades();

        ClassesHabilidade BuscarPorId(int id);

        void CadastrarClasseHabilidades(ClassesHabilidade novaClassHabilidades);

        void DeletarClasseHabilidades(int id);

        void AtualizarClasseHabilidades(int id, Class ClasseHabilidadesAtualizada);
    }
}
