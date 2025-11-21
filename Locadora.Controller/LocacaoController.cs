using Locadora.Controller.Interfaces;
using Locadora.Models;
using Locadora.Models.Enums;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Utils.Databases;

namespace Locadora.Controller
{
    public class LocacaoController : ILocacaoController
    {
        public void AdicionarLocacao(Locacao locacao)
        {
            var connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();

            using (SqlTransaction transaction = connection.BeginTransaction()) 
            {
                VeiculoController veiculoController = new VeiculoController();

                var diaria = veiculoController.BuscarDiariaPorVeiculoID(locacao.VeiculoID);
                    if(diaria == 0) 
                        throw new Exception("Diária do veículo não encontrada.");

                var statusVeiculo = veiculoController.BuscarStatusPorVeiculoID(locacao.VeiculoID);
                    if(statusVeiculo != "Disponível") 
                        throw new Exception("Veículo não está disponível para locação.");


                var dias = (locacao.DataDevolucaoPrevista - locacao.DataLocacao).TotalDays;
                var total = diaria * (decimal)dias;
                
                try 
                {
                    var command = new SqlCommand(Locacao.INSERTLOCACAO, connection, transaction);
                    command.Parameters.AddWithValue("@ClienteID", locacao.ClienteID);
                    command.Parameters.AddWithValue("@VeiculoID", locacao.VeiculoID);
                    command.Parameters.AddWithValue("@DataLocacao", locacao.DataLocacao);
                    command.Parameters.AddWithValue("@DataDevolucaoPrevista", locacao.DataDevolucaoPrevista);
                    command.Parameters.AddWithValue("@DataDevolucaoReal", (object?)locacao.DataDevolucaoReal ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ValorDiaria", diaria);
                    command.Parameters.AddWithValue("@ValorTotal", total);
                    command.Parameters.AddWithValue("@Multa", (object?)locacao.Multa ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Status", locacao.Status.ToString());

                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro inesperado ao adicionar veículo: " + ex.Message);
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
        
        public List<Locacao> ListarLocacoes()
        {
            var connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();

            
            var veiculoController = new VeiculoController();
            var clienteController = new ClienteController();
            var funcionarioController = new FuncionarioController();
            var locacoes = new List<Locacao>();


            try 
            {
                var command = new SqlCommand(Locacao.SELECTLOCACOES, connection);
                var reader = command.ExecuteReader();
                var diasLocacao = (int)(reader.GetDateTime(6) - reader.GetDateTime(7)).TotalDays;

                while (reader.Read())
                {
                    var locacao = new Locacao(
                        reader.GetInt32(4),
                        reader.GetInt32(5),
                        reader.GetDateTime(6),
                        diasLocacao
                    );

                    //trazer funcionario
                    var nomeCliente = clienteController.BuscarNomeClientePorID(reader.GetInt32(4));
                    var marca = veiculoController.BuscarMarcaModeloPorVeiculoID(reader.GetInt32(5));

                    //locacao.SetFuncionario
                    
                    locacao.SetDataDevolucaoPrevista(reader.GetDateTime(7));
                    locacao.SetDataDevolucaoReal(reader.IsDBNull(8) ? (DateTime?)null : reader.GetDateTime(8));
                    locacao.SetValorDiaria(reader.GetDecimal(9));
                    locacao.SetValorTotal(reader.GetDecimal(10));
                    locacao.SetMulta(reader.GetDecimal(11));
                    locacao.SetStatus((EStatusLocacao)Enum.Parse(typeof(EStatusLocacao), reader.GetString(12)));
                    
                    locacoes.Add(locacao);
                }


                /*  
                0 f.Nome, 
                1 c.Nome, 
                2 v.Marca, 
                3 v.Modelo, 
                4 l.ClienteID, 
                5 l.VeiculoID
                6 l.DataLocacao, 
                7 l.DataDevolucaoPrevista, 
                8 l.DataDevolucaoReal, 
                9 l.ValorDiaria, 
                10 l.ValorTotal, 
                11 l.Multa, 
                12 l.Status 
                */
                   
                return locacoes;
            }
            catch (SqlException ex)
            { 
                throw new Exception("Erro inesperado ao listar veículos: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado ao listar veículos: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }



        public Locacao BuscarLocacaoPorID(int locacaoID)
        {
            return null;
        }
        public void AtualizarLocacao(Locacao locacao)
        {

        }
    }
}
