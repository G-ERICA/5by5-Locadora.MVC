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

        public static readonly string SELECTVEICULOSNOMECATEGORIA = @"SELECT VeiculoID, CategoriaID, Placa, Marca, Modelo, Ano, StatusVeiculo 
                                                             FROM tblVeiculos
                                                             WHERE Placa = @Placa";

        public static readonly string UPDATEVEICULO = @"UPDATE tblVeiculos 
                                                        StatusVeiculo = @StatusVeiculo 
                                                        WHERE VeiculoID = @VeiculoID";

        public static readonly string DELETEVEICULO = @"DELETE FROM tblVeiculos 
                                                        WHERE VeiculoID = @VeiculoID";

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
            return $"Placa: {Placa}\nMarca: {Marca}\nModelo: {Modelo}\nAno: {Ano}\nStatus: {StatusVeiculo}\nCategoria: {NomeCategoria}\n";
        }
    }
}
