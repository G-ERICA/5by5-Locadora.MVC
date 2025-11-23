using Locadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Controller.Interfaces
{
    public interface IClienteController
    {
        public void AdicionarCliente(Cliente cliente, Documento documento);
        public List<Cliente> ListarClientes();
        public Cliente BuscaClientePorEmail(string email);
        public string BuscarNomeClientePorID(int clienteID);
        public void AtualizarTelefoneCliente(string telefone, string email);
        public void AtualizarDocumentoCliente(string email, Documento documento);
        public void DeletarCliente(string email);
    }
}