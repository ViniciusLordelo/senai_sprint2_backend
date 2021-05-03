using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Senai.Peoples.WebApi.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private string StringConexao = "Data Source=PC-DA-XUXA\\SQLEXPRESS; initial catalog=M_Peoples; integrated security=true";


        public void AtualizarIdURL(int Id, FuncionarioDomain Funcionario)
        {
            using(SqlConnection conexao = new SqlConnection(StringConexao))
            {
                string AtualizarIdURL = "UPDATE Funcionarios SET NomeFuncionario = @NomeFuncionario, SobrenomeFuncionario = @SobrenomeFuncionario WHERE IdFuncionario = @Id";
                
                using(SqlCommand command = new SqlCommand(AtualizarIdURL, conexao))
                {
                    command.Parameters.AddWithValue("@ID", Id);
                    command.Parameters.AddWithValue("@NomeFuncionario", Funcionario.NomeFuncionario);
                    command.Parameters.AddWithValue("@SobrenomeFuncionario", Funcionario.SobrenomeFuncionario);

                    conexao.Open();

                    command.ExecuteNonQuery();
                }
            }
        }


        public FuncionarioDomain BuscarPorId(int Id)
        {
            using(SqlConnection conexao = new SqlConnection(StringConexao))
            {
                string BuscarPorId = "SELECT IdFuncionario, NomeFuncionario, SobrenomeFuncionario FROM Funcionarios WHERE IdFuncionario = @Id";

                conexao.Open();

                SqlDataReader reader;

                using(SqlCommand command = new SqlCommand(BuscarPorId, conexao))
                {
                    command.Parameters.AddWithValue("@Id", Id);

                    reader = command.ExecuteReader();

                    if(reader.Read())
                    {
                        FuncionarioDomain FuncionarioBuscado = new FuncionarioDomain()
                        {
                            Idfuncionario         =  Convert.ToInt32(reader[0]),
                            NomeFuncionario       =  Convert.ToString(reader[1]),
                            SobrenomeFuncionario  =  Convert.ToString(reader[2])
                        };

                        return FuncionarioBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(FuncionarioDomain NovoFuncionario)
        {
            using(SqlConnection conexao = new SqlConnection(StringConexao))
            {
                string CadastrarFuncionario = "INSERT INTO Funcionarios(NomeFuncionario, SobrenomeFuncionario) VALUES (@NomeFuncionario, @SobrenomeFuncionario)";

                using(SqlCommand command = new SqlCommand(CadastrarFuncionario, conexao))
                {
                    command.Parameters.AddWithValue("@NomeFuncionario", NovoFuncionario.NomeFuncionario);
                    command.Parameters.AddWithValue("@SobrenomeFuncionario", NovoFuncionario.SobrenomeFuncionario);

                    conexao.Open();

                    command.ExecuteNonQuery();
                }
            }
        }


        public void Deletar(int Id)
        {
            using(SqlConnection conexao = new SqlConnection(StringConexao))
            {
                string DeletarFuncinario = "DELETE FROM Funcionarios WHERE IdFuncionario = @Id";

                using(SqlCommand command = new SqlCommand(DeletarFuncinario, conexao))
                {
                    command.Parameters.AddWithValue("@Id", Id);

                    conexao.Open();

                    command.ExecuteNonQuery();
                }
            }
        }


        public List<FuncionarioDomain> ListarFuncionarios()
        {
            List<FuncionarioDomain> Listafuncionarios = new List<FuncionarioDomain>();

            using(SqlConnection conexao = new SqlConnection(StringConexao))
            {
                string SelecionarTodos = "SELECT IdFuncionario, NomeFuncionario, SobrenomeFuncionario FROM Funcionarios";
                SqlDataReader Reader;

                conexao.Open();

                using(SqlCommand command = new SqlCommand(SelecionarTodos, conexao))
                {
                    Reader = command.ExecuteReader();

                    while(Reader.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain()
                        {
                            Idfuncionario = Convert.ToInt32(Reader[0]),
                            NomeFuncionario = Convert.ToString(Reader[1]),
                            SobrenomeFuncionario = Convert.ToString(Reader[2])
                        };

                        Listafuncionarios.Add(funcionario);
                    }
                }
            }

            return Listafuncionarios;
        }
    }
}
