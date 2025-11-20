using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Models
{
    public class Veiculo
    {
        public int VeiculoID { get; private set; }
        public string CategoriaID { get; private set; }
        public string Placa { get; private set; }
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public int Ano { get; private set; }
        public bool StatusVeiculo { get; private set; }


        public Veiculo(string categoriaID, string placa, string marca, string modelo, int ano, bool statusVeiculo)
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

        public void SetStatusVeiculo(bool statusVeiculo)
        {
            StatusVeiculo = statusVeiculo;
        }

        public override string? ToString()
        {
            return $"Placa: {Placa}\nMarca: {Marca}\nModelo: {Modelo}\nAno: {Ano}\nStatus: {StatusVeiculo}";
        }
    }
}
