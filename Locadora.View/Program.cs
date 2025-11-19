
using Locadora.Controller;
using Locadora.Models;
using Microsoft.Data.SqlClient;
using Utils.Databases;


//TODO: Refatorar código, criar padronização


//2 formas de instanciar classes:
var cliente = new Cliente("Igor", "i@email.com");
ClienteController clienteController = new();


try
{
    clienteController.AdicionarCliente(cliente);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}


clienteController.AtualizarTelefoneCliente("99998888", "f@email.com");


try
{
    var listaClientes = clienteController.ListarClientes();


    foreach (var clienteListado in listaClientes)
    {
        Console.WriteLine(clienteListado);
    }
}
catch(Exception ex) 
{
    Console.WriteLine(ex.Message);
}





//Documento documento = new Documento(1, "RG", "123456789", new DateOnly(2020,1,1), new DateOnly(2030,1,1));
//Console.WriteLine(documento.ToString());  
