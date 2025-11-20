
using Locadora.Controller;
using Locadora.Models;
using Microsoft.Data.SqlClient;
using Utils.Databases;


var cliente = new Cliente("José Antonio", "ja@email.com", "11985639514");
ClienteController clienteController = new();

var documento = new Documento("RG", "951753852", new DateOnly(2020,1,1), new DateOnly(2030,1,1));

#region AdicionarCliente
//try
//{
//clienteController.AdicionarCliente(cliente, documento);
//}
//catch (Exception ex)
//{
//Console.WriteLine(ex.Message);
//}
#endregion

#region AtualizarTelefone
//try
//{
//    clienteController.AtualizarTelefoneCliente("11996328569", "c@email.com");
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}
#endregion

#region ListarClientes
//try
//{
//    var listaClientes = clienteController.ListarClientes();


//    foreach (var clienteListado in listaClientes)
//    {
//        Console.WriteLine(clienteListado);
//    }
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}
#endregion

#region DeletarCliente
//try
//{
//    clienteController.DeletarCliente("f@email.com");
//      Console.WriteLine("Cliente deletado com sucesso");
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}
#endregion

#region AtualizarDocumento
//documento = new Documento("CPF", "12345678900", new DateOnly(2022, 5, 10), new DateOnly(2032, 5, 10));

//try
//{
//    clienteController.AtualizarDocumentoCliente("ja@email.com", documento);
//      Console.WriteLine("Documento atualizado com sucesso");
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}

#endregion