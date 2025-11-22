using Locadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Controller.Interfaces
{
    public interface ILocacaoController
    {
        public void AdicionarLocacao(Locacao locacao, string cpf);
        public List<Locacao> ListarLocacoes();
        public void CancelarLocacao(string placa);
        public void EncerrarLocacao(string placa);
    }
}
