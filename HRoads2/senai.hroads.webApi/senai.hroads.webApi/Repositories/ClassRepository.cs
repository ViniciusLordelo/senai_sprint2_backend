using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class ClassRepository : IClass
    {
        HRoadsContext ctx = new HRoadsContext();
        public void AtualizarClasses(int id, Class ClassAtualizada)
        {
            Class ClassBuscada = ctx.Classes.Find(id);

            if (ClassAtualizada.ClassesHabilidades == null)
            {
                ClassBuscada.ClassesHabilidades = ClassAtualizada.ClassesHabilidades;

                ctx.Classes.Update(ClassBuscada);

                ctx.SaveChanges();
            }
        }

        public Class BuscarPorId(int id)
        {
            //retorna o primeiro id encontrado para a classe informada
            return ctx.Classes.FirstOrDefault(c => c.IdClasses == id);
        }

        public void CadastrarClasses(Class novaClass)
        {
            //Adiciona uma classe
            ctx.Classes.Add(novaClass);

            //Salva as informaçoes para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public void DeletarClasses(int id)
        {
            Class ClassBuscada = ctx.Classes.Find(id);

            ctx.Classes.Remove(ClassBuscada);

            ctx.SaveChanges();
        }


        //Lista todas as classes
        public List<Class> ListarClasses()
        {
            return ctx.Classes.ToList();
        }
    }
}
