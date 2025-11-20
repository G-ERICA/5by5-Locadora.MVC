
using Locadora.Controller;
using Locadora.Models;
using Microsoft.Data.SqlClient;
using Utils.Databases;


//Exemplo das 2 formas de instanciar classes:
var cliente = new Cliente("Igor", "i@email.com");
ClienteController clienteController = new();


//try
//{
//    clienteController.AdicionarCliente(cliente);
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"Erro inesperado ao adiconar cliente: " + ex.Message);
//}


//try
//{
//    clienteController.AtualizarTelefoneCliente("77774444", "h@email.com");
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"Erro inesperado ao atualizar cliente:" + ex.Message);
//}


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
//    Console.WriteLine($"Erro inesperado ao listar clientes: " + ex.Message);
//}

try
{
    clienteController.DeletarCliente("h@email.com");
}
catch (Exception ex)
{
    Console.WriteLine($"Erro inesperado ao deletar cliente: " + ex.Message);
}






//Documento documento = new Documento(1, "RG", "123456789", new DateOnly(2020,1,1), new DateOnly(2030,1,1));
//Console.WriteLine(documento.ToString());  
