using Hroads.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads.Interfaces
{
    interface ITipoUsuarioRepository
    {

        void Create(TipoUsuario NovoTipoUsuario);

        List<TipoUsuario> Read();

        TipoUsuario ReadById(int Id);

        void Update(TipoUsuario TipoUsuarioAtualizado, int Id);

        void Delete(int Id);
    }
}
