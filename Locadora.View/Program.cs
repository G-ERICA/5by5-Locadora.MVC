
using Locadora.Controller;
using Locadora.Models;
using Locadora.Models.Enums;
using Microsoft.Data.SqlClient;
using Utils.Databases;

#region ClientesEDocumentos
var cliente = new Cliente("José Antonio", "jose_ant@email.com", "11985639514");
ClienteController clienteController = new();

var documento = new Documento("RG", "951753852", new DateOnly(2020,1,1), new DateOnly(2030,1,1));

#region AdicionarCliente
//try
//{
//    clienteController.AdicionarCliente(cliente, documento);
//    Console.WriteLine("Cliente adicionado com sucesso");
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}
#endregion

#region AtualizarTelefone
//try
//{
//    clienteController.AtualizarTelefoneCliente("11996328569", "c@email.com");
//    Console.WriteLine("Telefone atualizado com sucesso");
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
//    Console.WriteLine("Cliente deletado com sucesso");
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
//    Console.WriteLine("Documento atualizado com sucesso");
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}
#endregion

#endregion

#region Categoria
var categoriaController = new CategoriaController();

#region AdicionarCategoria
//var categoria = new Categoria("Caminhonete", 200.00M, "Picapes - cargas e pessoas");

//try
//{
//    categoriaController.AdicionarCategoria(categoria);
//    Console.WriteLine("Categoria adicionada com sucesso");
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
//var categoria = new Categoria("Sportcar", 240.00M, "Carro Esportivo");
//try
//{
//    categoriaController.AtualizarCategoria("Sportcar", categoria);
//    Console.WriteLine("Categoria atualizada com sucesso");
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}
#endregion

#region Delete Categoria
//try
//{
//    categoriaController.DeletarCategoria("Sportcar");
//    Console.WriteLine("Categoria excluida com sucesso");
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}
#endregion

#region AdicionarComProcedure
////Exemplo de adição usando Procedure

//var categoria = new Categoria("Moto",50.00M, "CG 125");

//try
//{
//    categoriaController.AdicionarCategoriaProcedure(categoria);
//    Console.WriteLine("Categoria adicionada com sucesso");
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}
#endregion

#endregion

#region Veiculos
var veiculoController = new VeiculoController();

#region AdicionarVeiculo
//var veiculo = new Veiculo(4, "XYZ1234", "Ford", "Mustang", 2020, EStatusVeiculo.Disponivel.ToString());
//try
//{
//    veiculoController.AdicionarVeiculo(veiculo);
//    Console.WriteLine("Veículo adicionado com sucesso");
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}
#endregion

#region ListarVeiculos
//try
//{
//    List<Veiculo> veiculos = veiculoController.ListarTodosVeiculos();
//    foreach (var veiculo in veiculos)
//    {
//        Console.WriteLine(veiculo);
//    }
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}
#endregion



#endregion