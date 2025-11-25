using Locadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Controller.Interfaces
{
    public interface ILocacaoController
    {
        public void AdicionarLocacao(string email, string placa, int diasLocacao, string cpf);
        public List<Locacao> ListarLocacoes();
        public void CancelarLocacao(int locacaoID);
        public void EncerrarLocacao(int locacaoID);
    }
}