using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Controller.Interfaces
{
    public interface ILocacaoFuncionarioController
    {
     public void AdicionarRelação(int locacaoID, int funcionarioID);
    }
}
