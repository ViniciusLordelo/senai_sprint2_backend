using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IHabilidade
    {
        List<Habilidade> ListarHabilidades();

        Habilidade BuscarPorId(int id);

        void CadastrarHabilidades(Habilidade novaClass);

        void DeletarHabilidades(int id);

        void AtualizarHabilidades(int id, Habilidade HabilidadesAtualizada);

    }
}
