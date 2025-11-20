
using Locadora.Controller;
using Locadora.Models;
using Microsoft.Data.SqlClient;
using Utils.Databases;


var cliente = new Cliente("José Antonio", "ja@email.com", "11985639514");
ClienteController clienteController = new();

var documento = new Documento("RG", "951753852", new DateOnly(2020,1,1), new DateOnly(2030,1,1));
DocumentoController documentoController = new();


//try
//{
//    clienteController.AdicionarCliente(cliente, documento);
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}


//try
//{
//    clienteController.AtualizarTelefoneCliente("11996328569", "c@email.com");
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}


try
{
    var listaClientes = clienteController.ListarClientes();


    foreach (var clienteListado in listaClientes)
    {
        Console.WriteLine(clienteListado);
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}


//try
//{
//    clienteController.DeletarCliente("f@email.com");
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}
