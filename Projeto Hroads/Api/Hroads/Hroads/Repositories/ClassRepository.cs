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
    public class ClassRepository : IClassRepository
    {

        SENAI_HROADSContext ctx = new SENAI_HROADSContext();


        public void Create(Class NovoClass)
        {
            ctx.Classes.Add(NovoClass);

            ctx.SaveChanges();
        }


        public void Delete(int Id)
        {

            ctx.Classes.Remove(ReadById(Id));

            ctx.SaveChanges();
        }


        public List<Class> Read()
        {
            return ctx.Classes
                .Include(c => c.Personagens)
                .Include(c => c.HabilidadeClasses)
                .ToList();
        }


        public Class ReadById(int Id)
        {
            return ctx.Classes.FirstOrDefault(c => c.IdClasse == Id);
        }


        public void Update(Class ClassAtualizado, int Id)
        {
            Class ClassBuscada = ReadById(Id);

            if(ClassAtualizado.NomeClasse != null)
            {
                ClassBuscada.NomeClasse = ClassAtualizado.NomeClasse;
                
                ctx.Classes.Update(ClassBuscada);

                ctx.SaveChanges();
            };

        }
    }
}
