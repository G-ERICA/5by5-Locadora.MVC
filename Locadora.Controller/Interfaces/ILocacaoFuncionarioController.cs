using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Controller.Interfaces
{
    public interface ILocacaoFuncionarioController
    {
        public void Adicionar(int locacaoID, int funcionarioID);
    }
}