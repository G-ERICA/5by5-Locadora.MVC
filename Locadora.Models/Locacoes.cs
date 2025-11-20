using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Models
{
    public class Locacoes
    {
        public int LocacaoID { get; private set; }
        public int ClienteID { get; private set; }
        public int VeiculoID { get; private set; }
        public DateOnly DataLocacao { get; private set; }
        public DateOnly DataDevolucaoPrevista { get; private set; }
        public DateOnly DataDevolucaoReal { get; private set; }
        public decimal ValorDiaria { get; private set; }
        public decimal ValorTotal { get; private set; }
        public decimal Multa { get; private set; }
        public string Status { get; private set; }
       
        public Locacoes(int clienteID, int veiculoID, DateOnly dataLocacao, DateOnly dataDevolucaoprevista, DateOnly dataDevolucaoReal, decimal valorDiaria, decimal valorTotal, decimal multa, string status)
        {
            ClienteID = clienteID;
            VeiculoID = veiculoID;
            DataLocacao = dataLocacao;
            DataDevolucaoPrevista = dataDevolucaoprevista;
            DataDevolucaoReal = dataDevolucaoReal;
            ValorDiaria = valorDiaria;
            ValorTotal = valorTotal;
            Multa = multa;
            Status = status;
        }
        public void SetLocacaoID(int locacaoID)
        {
            LocacaoID = locacaoID;
        }
        public override string? ToString()
        {
            return $"Data Locação: {DataLocacao}\nData Devolução Prevista: {DataDevolucaoPrevista}\nData Devolução Real: {DataDevolucaoReal}\nValor Diária: {ValorDiaria}\nValor Total: {ValorTotal}\nMulta: {Multa}\nStatus: {Status}";
        }

    }
}
