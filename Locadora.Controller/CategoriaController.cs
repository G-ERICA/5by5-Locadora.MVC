﻿using Locadora.Controller.Interfaces;
using Locadora.Models;
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
    public class CategoriaController : ICategoriaController
    {
        public void AdicionarCategoria(Categoria categoria) 
        {
            var connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();

            using (SqlTransaction transaction = connection.BeginTransaction()) 
            {

                try 
                {
                    var command = new SqlCommand(Categoria.INSERTCATEGORIA, connection, transaction);
                    command.Parameters.AddWithValue("@Nome", categoria.Nome);
                    command.Parameters.AddWithValue("@Descricao", categoria.Descricao);
                    command.Parameters.AddWithValue("@Diaria", categoria.Diaria);

                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (SqlException ex) 
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao adicionar categora: " + ex);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro inesperado ao adicionar categora: " + ex);
                }
                finally 
                {
                    connection.Close();
                }
            }
        }
        public List<Categoria> ListarCategorias() 
        {
            var connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();

            try 
            { 
                List<Categoria> categorias = new List<Categoria>();

                var command = new SqlCommand(Categoria.SELECTCATEGORIAS, connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var categoria = new Categoria(
                    reader["Nome"].ToString(),
                    Convert.ToDecimal(reader["Diaria"]),
                    reader["Descricao"] != DBNull.Value ? reader["Descricao"].ToString() : null
                    );

                    categorias.Add(categoria);
                }
                return categorias; 
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao listar categoras: ", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado ao listar categoras: ", ex);
            }
            finally
            {
                connection.Close();
            }
        }
        public string BuscarCategoriaPorID(int id)
        {
            var connection = new SqlConnection(ConnectionDB.GetConnectionString());

            connection.Open();

            try
            {
                var command = new SqlCommand(Categoria.SELECTCATEGORIAPORID, connection);
                command.Parameters.AddWithValue("CategoriaID", id);

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string nomeCategoria = reader["Nome"].ToString();
                    return nomeCategoria;
                }
            
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao buscar categora por ID: ", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado ao buscar categora por ID: ", ex);
            }
            finally
            {
                connection.Close();
            }

            return null;
        }
        public Categoria BuscarCategoriaPorNome(string nome) 
        {
            var connection = new SqlConnection(ConnectionDB.GetConnectionString());

            connection.Open();

            try 
            {
                var command = new SqlCommand(Categoria.SELECTCATEGORIAPORNOME, connection);
                command.Parameters.AddWithValue("@Nome", nome);

                var reader = command.ExecuteReader();

                if (reader.Read()) 
                {
                    var categoria = new Categoria(
                        reader["Nome"].ToString(),
                        Convert.ToDecimal(reader["Diaria"]),
                        reader["Descricao"] != DBNull.Value ? reader["Descricao"].ToString() : null
                    );
                    return categoria;
                }
            }
            catch (SqlException ex) 
            {
                throw new Exception("Erro ao buscar categora por nome: ", ex);
            }
            catch (Exception ex) 
            {
                throw new Exception("Erro inesperado ao buscar categora por nome: ", ex);
            }
            finally 
            {
                connection.Close();
            }

            return null;
        }
        public void AtualizarCategoria(string nome, Categoria categoria) 
        {
            Categoria categoriaEncontrada = BuscarCategoriaPorNome(nome) ?? 
                throw new Exception("Categora não encontrada.");

            var connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();

            using(SqlTransaction transaction = connection.BeginTransaction()) 
            {
                categoria.SetNomeCategoria(categoriaEncontrada.Nome);
                try 
                { 

                    var command = new SqlCommand(Categoria.UPDATECATEGORIA, connection, transaction);
                    command.Parameters.AddWithValue("@Nome", categoriaEncontrada.Nome);
                    command.Parameters.AddWithValue("@Descricao", categoria.Descricao is null ? DBNull.Value : categoria.Descricao);
                    command.Parameters.AddWithValue("@Diaria", categoria.Diaria);

                    command.ExecuteNonQuery();
                    transaction.Commit();

                }
                catch (SqlException ex) 
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao adicionar categora: " + ex);
                }
                catch (Exception ex) 
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao adicionar categora: " + ex);
                }
                finally { connection.Close(); }
            }


        }
        public void DeletarCategoria(string nome)
        {
            Categoria categoriaEncontrada = BuscarCategoriaPorNome(nome) ??
                throw new Exception("Categora não encontrada.");

            var connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();

            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                try
                {
                    var command = new SqlCommand(Categoria.DELETECATEGORIA, connection, transaction);
                    command.Parameters.AddWithValue("@Nome", categoriaEncontrada.Nome);

                    command.ExecuteNonQuery();
                    transaction.Commit();

                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao adicionar categora: " + ex);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao adicionar categora: " + ex);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public void AdicionarCategoriaProcedure(Categoria categoria)
        {
            var connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();
            try
            {
                var command = new SqlCommand(Categoria.INSERTCATEGORIAPROCEDURE, connection);
                command.Parameters.AddWithValue("@Nome", categoria.Nome);
                command.Parameters.AddWithValue("@Descricao", categoria.Descricao);
                command.Parameters.AddWithValue("@Diaria", categoria.Diaria);
                command.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao adicionar categora: " + ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado ao adicionar categora: " + ex);
            }
            finally
            {
                connection.Close();
            }

        }
    }
}