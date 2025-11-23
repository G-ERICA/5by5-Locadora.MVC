using Locadora.Controller.Interfaces;
using Locadora.Models;
using Microsoft.Data.SqlClient;
using Utils.Databases;


namespace Locadora.Controller
{
    public class ClienteController : IClienteController
    {

        public void AdicionarCliente(Cliente cliente, Documento documento)
        {
            var connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();

            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                try
                {
                    SqlCommand command = new SqlCommand(Cliente.INSERTCLIENTE, connection, transaction);
                    command.Parameters.AddWithValue("@Nome", cliente.Nome);
                    command.Parameters.AddWithValue("@Email", cliente.Email);
                    command.Parameters.AddWithValue("@Telefone", cliente.Telefone ?? (object)DBNull.Value);

                    int clientId = Convert.ToInt32(command.ExecuteScalar());
                    documento.SetClienteId(clientId);

                    var documentoController = new DocumentoController();
                   
                    cliente.setClienteId(clientId);
                    documentoController.AdicionarDocumento(documento, connection, transaction);

                    transaction.Commit();
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao adicionar cliente: " + ex.Message);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro inesperado ao adicionar cliente: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public List<Cliente> ListarClientes()
        {
            var connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();
            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                try
                {
                    SqlCommand command = new SqlCommand(Cliente.SELECTALLCLIENTES, connection, transaction);
                    SqlDataReader reader = command.ExecuteReader();
                    List<Cliente> listaClientes = new List<Cliente>();

                    while (reader.Read())
                    {
                        var cliente = new Cliente(reader["Nome"].ToString(),
                                                    reader["Email"].ToString(),
                                                    reader["Telefone"] != DBNull.Value ?
                                                    reader["Telefone"].ToString() : null

                        );


                        var documento = new Documento(
                            reader["TipoDocumento"].ToString(),
                            reader["Numero"].ToString(),
                            DateOnly.FromDateTime(reader.GetDateTime(5)),
                            DateOnly.FromDateTime(reader.GetDateTime(6))
                        );

                        cliente.setDocumento(documento);

                        listaClientes.Add(cliente);
                    }

                    return listaClientes;

                }
                catch (SqlException ex)
                {
                    throw new Exception("Erro ao listar clientes: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro inesperado ao listar clientes: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public string BuscarNomeClientePorID(int clienteID) 
        {
            SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand(Cliente.SELECTCLIENTEPORID, connection);
                command.Parameters.AddWithValue("@ClienteID", clienteID);

                SqlDataReader reader = command.ExecuteReader();
                string nomeCliente = String.Empty;

                if (reader.Read())
                {
                    nomeCliente = reader["Nome"].ToString() ?? String.Empty;
                }
                return nomeCliente;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao buscar nome do cliente: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado ao buscar nome do cliente: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public Cliente BuscaClientePorEmail(string email)
        {
            SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();

            try
            {
                SqlCommand command = new SqlCommand(Cliente.SELECTCLIENTEPOREMAIL, connection);
                command.Parameters.AddWithValue("@Email", email);
                SqlDataReader reader = command.ExecuteReader();
                Cliente cliente = null;

                if (reader.Read())
                {
                    cliente = new Cliente(reader["Nome"].ToString(),
                                                reader["Email"].ToString(),
                                                reader["Telefone"] != DBNull.Value ?
                                                reader["Telefone"].ToString() : null
                    );
                    cliente.setClienteId(Convert.ToInt32(reader["ClienteID"]));

                    var documento = new Documento(
                            reader["TipoDocumento"].ToString(),
                            reader["Numero"].ToString(),
                            DateOnly.FromDateTime(reader.GetDateTime(6)),
                            DateOnly.FromDateTime(reader.GetDateTime(7))
                    );
                    cliente.setDocumento(documento);
                }
                return cliente;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao buscar cliente: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado ao vuscar cliente: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public void AtualizarTelefoneCliente(string telefone, string email)
        {
            SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();
            

            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                var clienteEncontrado = this.BuscaClientePorEmail(email);
                if (clienteEncontrado is null)
                    throw new Exception("Não existe cliente cadastrado com este email");
                clienteEncontrado.setTelefone(telefone);

                try
                {
                    SqlCommand command = new SqlCommand(Cliente.UPDATEFONECLIENTE, connection, transaction);
                    command.Parameters.AddWithValue("@Telefone", clienteEncontrado.Telefone);
                    command.Parameters.AddWithValue("@IDCliente", clienteEncontrado.ClienteId);
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao atualizar cliente: " + ex.Message);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro inesperado ao atualizar cliente: " + ex.Message);
                }
                finally                 
                {
                    connection.Close();
                }
            }

        }
        public void AtualizarDocumentoCliente(string email, Documento documento)
        {
            var clienteEncontrado = this.BuscaClientePorEmail(email) ??
                throw new Exception("Não existe cliente cadastrado com este email");

            var connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();

            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                try
                {
                    documento.SetClienteId(clienteEncontrado.ClienteId);

                    DocumentoController documentoController = new DocumentoController();
                    documentoController.AtualizarDocumentos(documento, connection, transaction);

                    transaction.Commit();
                }
                catch (SqlException ex)
                {

                    transaction.Rollback();
                    throw new Exception("Erro ao atualizar documento do cliente: " + ex.Message);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro inesperado ao atualizar documento do cliente: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }


        }
        public void DeletarCliente(string email)
        {

            var clienteEncontrado = this.BuscaClientePorEmail(email);
            if (clienteEncontrado is null)
                throw new Exception("Não existe cliente cadastrado com este email");

            var connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();

            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                try 
                {
                    SqlCommand command = new SqlCommand(Cliente.DELETECLIENTE, connection, transaction);
                    command.Parameters.AddWithValue("@IDCliente", clienteEncontrado.ClienteId);
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao deletar cliente: " + ex.Message);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro inesperado ao deletar cliente: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

        }
    }
}