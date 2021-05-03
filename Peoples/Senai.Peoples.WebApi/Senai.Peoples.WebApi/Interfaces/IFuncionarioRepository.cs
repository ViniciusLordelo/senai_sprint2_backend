using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    interface IFuncionarioRepository
    {
        List<FuncionarioDomain> ListarFuncionarios();

        FuncionarioDomain BuscarPorId(int Id);

        void Cadastrar(FuncionarioDomain NovoFuncionario);

        void AtualizarIdURL(int Id, FuncionarioDomain Funcionario);

        void Deletar(int Id);


    }
}
