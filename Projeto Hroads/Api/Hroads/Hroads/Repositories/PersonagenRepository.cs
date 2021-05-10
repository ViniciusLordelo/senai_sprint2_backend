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
    public class PersonagenRepository : IPersonagenRepository
    {

        SENAI_HROADSContext ctx = new SENAI_HROADSContext();

        public void Create(Personagen NovoPersonagen)
        {
            ctx.Personagens.Add(NovoPersonagen);

            ctx.SaveChanges();
        }


        public void Delete(int Id)
        {
            ctx.Personagens.Remove(ReadById(Id));

            ctx.SaveChanges();
        }


        public List<Personagen> Read()
        {
            return ctx.Personagens
                .Include(p => p.IdClasseNavigation)
                .ToList();
        }


        public Personagen ReadById(int Id)
        {
            return ctx.Personagens.FirstOrDefault(c => c.IdPersonagem == Id);
        }


        public void Update(Personagen PersonagenAtualizado, int Id)
        {
            Personagen PersonagenBuscado = ReadById(Id);

            if(PersonagenAtualizado.NomePersonagem != null)
            {
                PersonagenBuscado.NomePersonagem = PersonagenAtualizado.NomePersonagem;

                ctx.Personagens.Update(PersonagenBuscado);

                ctx.SaveChanges();
            }

            if(PersonagenBuscado.CapacidadeMaximaVida != null)
            {
                PersonagenBuscado.CapacidadeMaximaVida = PersonagenAtualizado.CapacidadeMaximaVida;

                ctx.Personagens.Update(PersonagenBuscado);

                ctx.SaveChanges();
            }

            if(PersonagenBuscado.CapacidadeMaximaMana != null)
            {
                PersonagenBuscado.CapacidadeMaximaMana = PersonagenAtualizado.CapacidadeMaximaMana;

                ctx.Personagens.Update(PersonagenBuscado);

                ctx.SaveChanges();
            }

            if(PersonagenBuscado.IdClasse != null)
            {
                PersonagenBuscado.IdClasse = PersonagenAtualizado.IdClasse;

                ctx.Personagens.Update(PersonagenBuscado);

                ctx.SaveChanges();
            }

            if(PersonagenBuscado.DataAtualizacao != null)
            {
                PersonagenBuscado.DataAtualizacao = PersonagenAtualizado.DataAtualizacao;

                ctx.Personagens.Update(PersonagenBuscado);

                ctx.SaveChanges();
            }
        }
    }
}
