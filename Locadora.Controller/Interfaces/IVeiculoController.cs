using Locadora.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Controller.Interfaces
{
    public interface IVeiculoController
    {
        public void AdicionarVeiculo(Veiculo veiculo);
        public List<Veiculo> ListarTodosVeiculos();
        public Veiculo BuscarVeiculoPlaca(string placa);
        public decimal BuscarDiariaPorVeiculoID(int veiculoID);
        public string BuscarStatusPorVeiculoID(int veiculoID);
        public (string, string, string) BuscarMarcaModeloPorVeiculoID(int veiculoID);
        public void AtualizarStatusVeiculo(string statusVeiculo, string placa);
        public void DeletarVeiculo(string placa);
    }
}