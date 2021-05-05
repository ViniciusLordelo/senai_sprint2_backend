using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class HabilidadesRepository : IHabilidade
    {
        HRoadsContext ctx = new HRoadsContext();

        public void AtualizarHabilidades(int id, Habilidade HabilidadesAtualizada)
        {
            Habilidade HabilidadeBuscada = ctx.Habilidades.Find(id);

            if (HabilidadesAtualizada.Nome != null)
            {
                HabilidadeBuscada.Nome = HabilidadesAtualizada.Nome;

                ctx.Habilidades.Update(HabilidadeBuscada);

                ctx.SaveChanges();
            }

        }
        public Habilidade BuscarPorId(int id)
        {
            //retorna o primeiro id encontrado para a Habilidade informada
            return ctx.Habilidades.FirstOrDefault(c => c.IdHabilidades == id);
        }

        public void CadastrarHabilidades(Habilidade novaHabilidade)
        {
            //Adiciona uma Habilidade
            ctx.Habilidades.Add(novaHabilidade);

            //Salva as informaçoes para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public void DeletarHabilidades(int id)
        {
           Habilidade HabilidadeBuscada = ctx.Habilidades.Find(id);

            ctx.Habilidades.Remove(HabilidadeBuscada);

            ctx.SaveChanges();
        }

        public List<Habilidade> ListarHabilidades()
        {
            return ctx.Habilidades.ToList();
        }
    }
}
