using Locadora.Controller.Interfaces;
using Locadora.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Utils.Databases;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Locadora.Controller
{
    public class FuncionarioController : IFuncionarioController
    {
        public List<Funcionario> ListarFuncionarios()
        {
            return null;
        }
        public Funcionario BuscarFuncionarioPorCPF(string cpf)
        {
            SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString());

            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand(Funcionario.SELECTFUNCIONARIOPORCPF, connection);

                command.Parameters.AddWithValue("@CPF", cpf);

                SqlDataReader reader = command.ExecuteReader();
                Funcionario funcionario = null;
                if (reader.Read())
                {
                    funcionario = new Funcionario(
                        reader["Nome"].ToString(),
                        reader["CPF"].ToString(),
                        reader["Email"].ToString(),
                        (decimal)reader["Salario"]
                    );
                    funcionario.setFuncionarioID(Convert.ToInt32(reader["FuncionarioID"]));
                }

                return funcionario;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao buscar funcionario por cpf: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado ao buscar funcionario por cpf: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public string BuscarNomeFuncionarioPorID(int id)
        {
            SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand(Funcionario.SELECTFUNCIONARIOPORID, connection);
                command.Parameters.AddWithValue("@IdFuncionario", id);
                SqlDataReader reader = command.ExecuteReader();
                string nome = null;
                if (reader.Read())
                {
                    nome = reader["Nome"].ToString();
                }

                return nome;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao buscar funcionário: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado ao buscar funcionário: " + ex.Message);
            }
        }
        public void AtualizarFuncionario(string email, decimal salario, string cpf)
        {

        }
        public void DeletarFuncionario(string cpf)
        {

        }
    }
}
