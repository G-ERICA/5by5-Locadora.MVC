using Locadora.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Databases;

namespace Locadora.Controller
{
    public class LocacaoFuncionarioController
    {
        public void AdicionarRelação(int locacaoID, int funcionarioID)
        {
            var connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();

            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                try
                {
                    SqlCommand command = new SqlCommand(LocacaoFuncionario.INSERTRELACAO , connection, transaction);
                    command.Parameters.AddWithValue("@LocacaoID", locacaoID);
                    command.Parameters.AddWithValue("@FuncionarioID", funcionarioID);

                    command.ExecuteNonQuery();
                    transaction.Commit();

                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao adiconar funcionario e locação a tabela relacional: " + ex.Message);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro inesperado ao adiconar funcionario e locação a tabela relacional: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
