using Locadora.Controller.Interfaces;
using Locadora.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Utils.Databases;

namespace Locadora.Controller
{
    public class VeiculoController : IVeiculoController
    {
        public void AdicionarVeiculo(Veiculo veiculo)
        {
            SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();
            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                try
                {
                    SqlCommand command = new SqlCommand(Veiculo.INSERTVEICULO, connection, transaction);
                    command.Parameters.AddWithValue("@CategoriaID", veiculo.CategoriaID);
                    command.Parameters.AddWithValue("@Placa", veiculo.Placa);
                    command.Parameters.AddWithValue("@Marca", veiculo.Marca);
                    command.Parameters.AddWithValue("@Modelo", veiculo.Modelo);
                    command.Parameters.AddWithValue("@Ano", veiculo.Ano);
                    command.Parameters.AddWithValue("@StatusVeiculo", veiculo.StatusVeiculo);

                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao adicionar veículo no banco de dados: " + ex.Message);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro inesperado ao adicionar veículo: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public List<Veiculo> ListarTodosVeiculos()
        {
            var connection = new SqlConnection(ConnectionDB.GetConnectionString());
            List<Veiculo> veiculos = new List<Veiculo>();

            connection.Open();

            try 
            {

                var command = new SqlCommand(Veiculo.SELECTVEICULOS, connection);
                var reader = command.ExecuteReader();
                CategoriaController categoriaController = new CategoriaController();

                while (reader.Read())
                {
                    string categoria = categoriaController.BuscarCategoriaPorID(reader.GetInt32(0));

                    //command.Parameters.AddWithValue("c.Nome", categoria);
                    var veiculo = new Veiculo(
                        reader.GetInt32(0),
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetString(4),
                        reader.GetInt32(5),
                        reader.GetString(6)
                    );
                    veiculo.SetNomeCategoria(categoria);

                    veiculos.Add(veiculo);
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao listar veículos: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado ao listar veículos: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return veiculos;
        }
        public Veiculo BuscarVeiculoPlaca(string placa)
        {
            throw new NotImplementedException();
        }
        public void AtualizarStatusVeiculo(string statusVeiculo)
        {
            throw new NotImplementedException();
        }
        public void DeletarVeiculo(string placa)
        {
            throw new NotImplementedException();
        }
    }
}
