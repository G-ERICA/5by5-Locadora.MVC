
using Locadora.Controller;
using Locadora.Models;
using Microsoft.Data.SqlClient;
using Utils.Databases;

#region ClientesEDocumentos
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
#endregion



#region CategoriasEVeiculos
var categoriaController = new CategoriaController();

#region AdicionarCategoria
//var categoria = new Categoria("Sportcar", "Droga, é o Brian", 220.00M);

//try
//{
//    categoriaController.AdicionarCategoria(categoria);
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}
#endregion

#region ListarCategorias
//try
//{
//    List<Categoria> categorias = categoriaController.ListarCategorias();
//    foreach (var cat in categorias)
//    {
//        Console.WriteLine(cat);
//    }
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}
#endregion

#region AtualizarCategoria
//var categoria = new Categoria("Sportcar", "Droga, é o Brian", 220.00M);
//try
//{
//    categoriaController.AtualizarCategoria("Sportcar", categoria);
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}
#endregion

#region Delete Categoria

#endregion

#endregion

