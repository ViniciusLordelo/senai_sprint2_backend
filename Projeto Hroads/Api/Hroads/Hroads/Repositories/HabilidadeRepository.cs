using Hroads.Contexts;
using Hroads.Domains;
using Hroads.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads.Repositories
{
    public class HabilidadeRepository : IHabilidadeRepository
    {

        SENAI_HROADSContext ctx = new SENAI_HROADSContext();

        /// <summary>
        /// Cria uma nova Habilidade
        /// </summary>
        /// <param name="NovoHabilidade">A nova Habilidade que será criada</param>
        public void Create(Habilidade NovoHabilidade)
        {
            ctx.Habilidades.Add(NovoHabilidade);

            ctx.SaveChanges();
        }


        /// <summary>
        /// Deleta uma Habilidade
        /// </summary>
        /// <param name="Id">Id da Habilidade que será deletada</param>
        public void Delete(int Id)
        {
            ctx.Habilidades.Remove(ReadById(Id));

            ctx.SaveChanges();
        }


        /// <summary>
        /// Busca todas as Habilidades
        /// </summary>
        /// <returns>Uma lista de Habilidades</returns>
        public List<Habilidade> Read()
        {
            return ctx.Habilidades
                .Include(h => h.IdTipoHabilidadeNavigation)
                .ToList();
        }


        /// <summary>
        /// Busca uma Habilidade pelo Id
        /// </summary>
        /// <param name="Id">Id da Habilidade buscada</param>
        /// <returns>Habilidade buscada</returns>
        public Habilidade ReadById(int Id)
        {
            return ctx.Habilidades.FirstOrDefault(c => c.IdHabilidade == Id);
        }

        /// <summary>
        /// Método para atualizar Habilidade
        /// </summary>
        /// <param name="HabilidadeAtualizado">Objeto contendo as novas infos de Habilidade</param>
        /// <param name="Id">Id da Habilidade buscada</param>
        public void Update(Habilidade HabilidadeAtualizado, int Id)
        {
            Habilidade HabilidadeBuscada = ReadById(Id);

            if(HabilidadeBuscada.NomeHabilidade != null && HabilidadeBuscada.IdTipoHabilidade != null)
            {
                HabilidadeBuscada.NomeHabilidade = HabilidadeAtualizado.NomeHabilidade;
                HabilidadeBuscada.IdTipoHabilidade = HabilidadeAtualizado.IdTipoHabilidade;

                ctx.Habilidades.Update(HabilidadeBuscada);

                ctx.SaveChanges();
            }
        }
    }
}
