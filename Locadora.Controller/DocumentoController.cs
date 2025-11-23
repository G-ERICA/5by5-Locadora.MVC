using Locadora.Controller.Interfaces;
using Locadora.Models;
using Microsoft.Data.SqlClient;

namespace Locadora.Controller
{
    public class DocumentoController : IDocumentoController
    {
        public void AdicionarDocumento(Documento documento, SqlConnection connection, SqlTransaction transaction)
        {

            try 
            {
                SqlCommand command = new SqlCommand(Documento.INSERTDOCUMENTO, connection, transaction);

                command.Parameters.AddWithValue("@ClienteId", documento.ClienteId);
                command.Parameters.AddWithValue("@TipoDocumento", documento.TipoDocumento);
                command.Parameters.AddWithValue("@Numero", documento.Numero);
                command.Parameters.AddWithValue("@DataEmissao", documento.DataEmissao);
                command.Parameters.AddWithValue("@DataValidade", documento.DataValidade);

                command.ExecuteNonQuery();
            }
            catch(SqlException ex)
            {
                transaction.Rollback();
                throw new Exception("Erro ao adicionar documento: " + ex.Message);
            }
            catch (Exception ex) 
            {
                transaction.Rollback();
                throw new Exception("Erro inesperado ao adicionar documento: " + ex.Message);
            }
        }
        public void AtualizarDocumentos(Documento documento, SqlConnection connection, SqlTransaction transaction)
        {
            try
            {
                SqlCommand command = new SqlCommand(Documento.UPDATEDOCUMENTO, connection, transaction);

                command.Parameters.AddWithValue("@IdCliente", documento.ClienteId);
                command.Parameters.AddWithValue("@TipoDocumento", documento.TipoDocumento);
                command.Parameters.AddWithValue("@Numero", documento.Numero);
                command.Parameters.AddWithValue("@DataEmissao", documento.DataEmissao);
                command.Parameters.AddWithValue("@DataValidade", documento.DataValidade);

                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
                throw new Exception("Erro ao alterar documento: " + ex.Message);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("Erro inesperado ao alterar documento: " + ex.Message);
            }
        }

    }
}