using Locadora.Controller.Interfaces;
using Locadora.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Databases;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Locadora.Controller
{
    public class FuncionarioController : IFuncionarioController
    {
        public void AdicionarFuncionario(Funcionario funcionario)
        {
            var connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();

            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                try
                {
                    var command = new SqlCommand(Funcionario.INSERTFUNCIONARIO, connection, transaction);
                    command.Parameters.AddWithValue("@Nome", funcionario.Nome);
                    command.Parameters.AddWithValue("@CPF", funcionario.CPF);
                    command.Parameters.AddWithValue("@Email", funcionario.Email);
                    command.Parameters.AddWithValue("@Salario", funcionario.Salario ?? (object)DBNull.Value);

                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao adicionar funcionário no banco de dados: " + ex.Message);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro inesperado ao adicionar funcionário: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public List<Funcionario> ListarFuncionarios()
        {
            return null;
        }
        public Funcionario BuscarFuncionarioPorCPF(string cpf)
        {
            return null;
        }
        public void AtualizarFuncionario(string email, decimal salario, string cpf)
        {

        }
        public void DeletarFuncionario(string cpf)
        {

        }
    }
}
