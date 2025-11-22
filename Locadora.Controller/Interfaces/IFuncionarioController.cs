using Locadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Controller.Interfaces
{
    public interface IFuncionarioController
    {
        public List<Funcionario> ListarFuncionarios();
        public Funcionario BuscarFuncionarioPorCPF(string cpf);
        public void AtualizarFuncionario(string email, decimal salario, string cpf);
        public void DeletarFuncionario(string cpf);

    }
}
