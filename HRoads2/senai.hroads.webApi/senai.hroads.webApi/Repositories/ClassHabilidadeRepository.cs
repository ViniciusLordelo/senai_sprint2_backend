using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class ClassHabilidadeRepository : IClassHabilidades
    {
        HRoadsContext ctx = new HRoadsContext();

        public void AtualizarClasseHabilidades(int id, ClassesHabilidade ClasseHabilidadesAtualizada)
        {
            ClassesHabilidade ClassHabilidadesBuscada = ctx.ClassesHabilidades.Find(id);

            if (ClasseHabilidadesAtualizada.IdClasses != null)
            {
                ClassHabilidadesBuscada.IdClasses = ClasseHabilidadesAtualizada.IdClasses;

                ctx.ClassesHabilidades.Update(ClassHabilidadesBuscada);

                ctx.SaveChanges();
            }

            if (ClasseHabilidadesAtualizada.IdHabilidades != null)
            {
                ClassHabilidadesBuscada.IdHabilidades = ClasseHabilidadesAtualizada.IdHabilidades;

                ctx.ClassesHabilidades.Update(ClassHabilidadesBuscada);

                ctx.SaveChanges();
            }



        }


        public ClassesHabilidade BuscarPorId(int id)
        {
            return ctx.ClassesHabilidades.FirstOrDefault(c => c.IdClassesHabilidades == id);
        }

        public void CadastrarClasseHabilidades(ClassesHabilidade novaClassHabilidades)
        {
            //Adiciona uma classeHabilidades
            ctx.ClassesHabilidades.Add(novaClassHabilidades);

            //Salva as informaçoes para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public void DeletarClasseHabilidades(int id)
        {
            ClassesHabilidade ClassHabilidadesBuscada = ctx.ClassesHabilidades.Find(id);

            ctx.ClassesHabilidades.Remove(ClassHabilidadesBuscada);

            ctx.SaveChanges();
        }

        public List<ClassesHabilidade> ListarClasseHabilidades()
        {
            return ctx.ClassesHabilidades.ToList();
        }
    }
}
