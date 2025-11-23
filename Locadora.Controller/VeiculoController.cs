using Locadora.Controller.Interfaces;
using Locadora.Models;
using Microsoft.Data.SqlClient;
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
                    //string categoria = categoriaController.BuscarCategoriaPorID(reader.GetInt32(0));

                    var veiculo = new Veiculo(
                        reader.GetInt32(0),
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetString(4),
                        reader.GetInt32(5),
                        reader.GetString(6)
                    );
                    veiculo.SetNomeCategoria(reader.GetString(1));

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
            Veiculo veiculo = null;
            var connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();

            using (var command = new SqlCommand(Veiculo.SELECTVEICULOSPORPLACA, connection))
            {
                command.Parameters.AddWithValue("@Placa", placa);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        veiculo = new Veiculo(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetInt32(4),
                            reader.GetString(5)
                        );
                        veiculo.SetVeiculoID(reader.GetInt32(6));
                    }
                }
            }
            return veiculo;
        }
        
        public decimal BuscarDiariaPorVeiculoID(int veiculoID)
        {
            SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();
            try
            {
                var command = new SqlCommand(Veiculo.SELECTDIARIAPORVEICULO, connection);
                command.Parameters.AddWithValue("@VeiculoID", veiculoID);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return reader.GetDecimal(0);
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao buscar diária do veículo: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado ao buscar diária do veículo: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return 0;
        }
        public string BuscarStatusPorVeiculoID(int veiculoID)
        {
            SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();
            try
            {
                var command = new SqlCommand(Veiculo.SELECTVEICULOPORID, connection);
                command.Parameters.AddWithValue("@VeiculoID", veiculoID);

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return reader.GetString(2);
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao buscar status do veículo: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado ao buscar status do veículo: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return null;
        }
        public (string, string, string) BuscarMarcaModeloPorVeiculoID(int veiculoID)
        {
            SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();
            try
            {
                var command = new SqlCommand(Veiculo.SELECTVEICULOPORID, connection);
                command.Parameters.AddWithValue("@VeiculoID", veiculoID);

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return (reader.GetString(0), reader.GetString(1), reader.GetString(3));
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao buscar marca e modelo do veículo: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado ao buscar marca e modelo do veículo: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return (null, null, null);
        }
        public void AtualizarStatusVeiculo(string statusVeiculo, string placa)
        {
            var connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();

            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                try 
                {
                    var veiculoEncontrado = BuscarVeiculoPlaca(placa) ??
                        throw new Exception("Veículo não encontrado para atualizar status.");

                    var command = new SqlCommand(Veiculo.UPDATEVEICULO, connection, transaction);
                    command.Parameters.AddWithValue("@StatusVeiculo", statusVeiculo);
                    command.Parameters.AddWithValue("@Placa", veiculoEncontrado.Placa);

                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao atualizar status do veículo no banco de dados: " + ex.Message);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro inesperado ao atualizar status do veículo: " + ex.Message);
                }
            }
        }
        public void DeletarVeiculo(string placa)
        {
            SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();
            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                try
                {
                    var veiculoEncontrado = BuscarVeiculoPlaca(placa) ??
                        throw new Exception("Veículo não encontrado para deletar.");

                    var command = new SqlCommand(Veiculo.DELETEVEICULO, connection, transaction);
                    command.Parameters.AddWithValue("@Placa", veiculoEncontrado.Placa);

                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao deletar veículo no banco de dados: " + ex.Message);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro inesperado ao deletar veículo: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}