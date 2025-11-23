﻿using Locadora.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Models
{
    public class Veiculo
    {
        public static readonly string INSERTVEICULO = @"INSERT INTO tblVeiculos(CategoriaID, Placa, Marca, Modelo, Ano, StatusVeiculo) 
                                                        VALUES(@CategoriaID, @Placa, @Marca, @Modelo, @Ano, @StatusVeiculo)";

        public static readonly string SELECTVEICULOS = @"SELECT v.CategoriaID ,c.Nome AS Categoria, v.Placa, v.Marca, v.Modelo, v.Ano, v.StatusVeiculo
                                                        FROM tblVeiculos v
                                                        JOIN tblCategorias c
                                                        ON v.CategoriaID = c.CategoriaID";

        public static readonly string SELECTVEICULOSPORPLACA = @"SELECT CategoriaID, Placa, Marca, Modelo, Ano, StatusVeiculo, VeiculoID 
                                                             FROM tblVeiculos
                                                             WHERE Placa = @Placa";

        public static readonly string SELECTDIARIAPORVEICULO = @"SELECT c.Diaria
                                                                FROM tblVeiculos v
                                                                JOIN tblCategorias c
                                                                ON v.CategoriaID = c.CategoriaID
                                                                WHERE VeiculoID = @VeiculoID";

        public static readonly string SELECTVEICULOPORID = @"SELECT Marca, Modelo, StatusVeiculo, Placa 
                                                            FROM tblVeiculos 
                                                             WHERE VeiculoID = @VeiculoID";


        public static readonly string UPDATEVEICULO = @"UPDATE tblVeiculos 
                                                        SET StatusVeiculo = @StatusVeiculo 
                                                        WHERE Placa = @Placa";

        public static readonly string DELETEVEICULO = @"DELETE FROM tblVeiculos 
                                                        WHERE Placa = @Placa";


        public int VeiculoID { get; private set; }
        public int CategoriaID { get; private set; }
        public string NomeCategoria { get; private set; }
        public string Placa { get; private set; }
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public int Ano { get; private set; }
        public string StatusVeiculo { get; private set; }


        public Veiculo(int categoriaID, string placa, string marca, string modelo, int ano, string statusVeiculo)
        {
            CategoriaID = categoriaID;
            Placa = placa;
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            StatusVeiculo = statusVeiculo;
        }

        public void SetVeiculoID(int veiculoID)
        {
            VeiculoID = veiculoID;
        }
        public void SetNomeCategoria(string nomecategoria)
        {
            NomeCategoria = nomecategoria;
        }

        public void SetStatusVeiculo(string statusVeiculo)
        {
            StatusVeiculo = statusVeiculo;
        }

        public override string? ToString()
        {
            return $"Placa: {Placa}\n" +
                $"Marca: {Marca}\n" +
                $"Modelo: {Modelo}\n" +
                $"Ano: {Ano}\n" +
                $"Status: {StatusVeiculo}\n" +
                $"Categoria: {NomeCategoria}\n";
        }
    }
}