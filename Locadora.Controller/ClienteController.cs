using Locadora.Models;
using Microsoft.Data.SqlClient;
using System.Data.Common;
using System.Reflection.PortableExecutable;
using System.Transactions;
using Utils.Databases;


namespace Locadora.Controller
{
    public class ClienteController
    {

        //TODO: Refatorar o código mantendo o padrão do USING
        //TODO: Criar Delete de pessoa pelo ID

        public void AdicionarCliente(Cliente cliente) 
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
                    cliente.setClienteId(clientId);

                    transaction.Commit();
                }
                catch(SqlException ex) 
                {
                    transaction.Rollback(); 
                    throw new Exception("Erro: " + ex.Message);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro: " + ex.Message);
                }

            }
        }


        //public void AdicionarCliente(Cliente cliente)
        //{
        //    var connection = new SqlConnection(ConnectionDB.GetConnectionString());

        //    connection.Open();

        //    SqlCommand command = new SqlCommand(Cliente.INSERTCLIENTE, connection);
        //    command.Parameters.AddWithValue("@Nome", cliente.Nome);
        //    command.Parameters.AddWithValue("@Email", cliente.Email);
        //    command.Parameters.AddWithValue("@Telefone", cliente.Telefone ?? (object)DBNull.Value);

        //    //cliente.setClienteId((int)command.ExecuteScalar()); >>não funcionou porque o scope retorna decimal

        //    int clientId = Convert.ToInt32(command.ExecuteScalar());
        //    cliente.setClienteId(clientId);

        //    connection.Close();

        //}

        public List<Cliente> ListarClientes()
        {
            var connection = new SqlConnection(ConnectionDB.GetConnectionString());

            try 
            { 
                connection.Open();
                SqlCommand command = new SqlCommand(Cliente.SELECTALLCLIENTES, connection);

                SqlDataReader reader = command.ExecuteReader();

                List<Cliente> listaClientes = new List<Cliente>();

                while (reader.Read())
                {
                    var cliente = new Cliente(reader["Nome"].ToString(),
                                                reader["Email"].ToString(),
                                                reader["Telefone"] != DBNull.Value ?
                                                reader["Telefone"].ToString() : null

                                );
                    cliente.setClienteId(Convert.ToInt32(reader["ClienteID"]));

                    listaClientes.Add(cliente);
                }
                
                return listaClientes;

            }
            catch (SqlException ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }

        }

        #region

        //public List<Cliente> ListarClientes() 
        //{
        //    var connection = new SqlConnection(ConnectionDB.GetConnectionString());

        //    connection.Open();

        //    SqlCommand command = new SqlCommand(Cliente.SELECTALLCLIENTES, connection);

        //    SqlDataReader reader = command.ExecuteReader();

        //    List<Cliente> listaClientes = new List<Cliente>();
        //    while (reader.Read())
        //    {
        //        var cliente = new Cliente(reader["Nome"].ToString(),
        //                                    reader["Email"].ToString(),
        //                                    reader["Telefone"] != DBNull.Value ?
        //                                    reader["Telefone"].ToString() : null

        //        );
        //        cliente.setClienteId(Convert.ToInt32(reader["ClienteID"]));

        //        ListaClientes.Add(cliente);
        //    }


        //    connection.Close();

        //    return clientes;

        //}
        #endregion

        public Cliente BuscaClientePorEmail(string email) 
        {
            SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();

            try 
            {
                SqlCommand command = new SqlCommand(Cliente.SELECTCLIENTEPOREMAIL, connection);
                command.Parameters.AddWithValue("@Email", email);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) 
                {
                    var cliente = new Cliente(reader["Nome"].ToString(),
                                                reader["Email"].ToString(),
                                                reader["Telefone"] != DBNull.Value ?
                                                reader["Telefone"].ToString() : null
                    );
                    cliente.setClienteId(Convert.ToInt32(reader["ClienteID"]));
                    return cliente;
                }

                return null;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }


        }
        public void AtualizarTelefoneCliente(string telefone, string email) 
        {
            var clienteEncontrado = this.BuscaClientePorEmail(email);
            if (clienteEncontrado is null)
                throw new Exception();
            clienteEncontrado.setTelefone(telefone);

            SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString());

            connection.Open();
            try 
            {
                SqlCommand command = new SqlCommand(Cliente.UPDATEFONECLIENTE, connection);
                command.Parameters.AddWithValue("@Telefone", clienteEncontrado.Telefone);
                command.Parameters.AddWithValue("@IDCliente", clienteEncontrado.ClienteId);
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
            finally 
            { 
                connection.Close(); 
            }

        }

    }
}
