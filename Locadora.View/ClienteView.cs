using Locadora.Controller;
using Locadora.Models;
using Microsoft.Data.SqlClient;
using Utils.Inputs;

namespace Locadora.View
{
    public class ClienteView
    {
        public static void ExibirMenuClientes()
        {
            int op;
            bool convertido;

            ClienteController clienteController = new ClienteController();
            do
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("===== Menu de Clientes =====");
                    Console.WriteLine("1. Adicionar Cliente");
                    Console.WriteLine("2. Listar Clientes");
                    Console.WriteLine("3. Buscar Cliente Por E-mail");
                    Console.WriteLine("4. Atualizar Telefone do Cliente");
                    Console.WriteLine("5. Atualizar Documento do Cliente");
                    Console.WriteLine("6. Excluir Cliente");
                    Console.WriteLine("0. Voltar ao Menu Principal");
                    Console.WriteLine("=============================\n");
                    Console.Write("Selecione uma opção: ");
                    int.TryParse(Console.ReadLine(), out op);

                    if (op >= 0 && op <= 6)
                    {
                        convertido = true;
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        convertido = false;
                    }
                } while (convertido == false);

                switch (op)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("===== Adicionar Cliente =====\n");
                        string nome = InputHelper.LerString("Digite o nome do cliente: ", "Nome inválido.");
                        string email = InputHelper.LerString("Digite o email do cliente: ", "Email inválido.");
                        string? telefone = InputHelper.LerStringNulo("Digite o telefone do cliente (opcional): ",
                            "Telefone Invalido", true);

                        Cliente cliente = new Cliente(nome, email, telefone);

                        string tipoDoc =
                            InputHelper.LerString("Digite o tipo de documento: ", "Informe um tipo válido!");
                        string numero = InputHelper.LerString("Digite o numero do Documento: ", "Número inválido!");
                        DateOnly emissao =
                            InputHelper.LerData("Digite a Data de Emissão (dd/MM/yyyy): ", "Data inválida!");
                        DateOnly validade =
                            InputHelper.LerData("Digite a data de Validade (dd/MM/yyyy): ", "Data inválida!");

                        Documento documento = new Documento(tipoDoc, numero, emissao, validade);
                        try
                        {
                            clienteController.AdicionarCliente(cliente, documento);
                            Console.WriteLine("\nCliente adicionado com sucesso!");
                            Console.ReadKey();
                        }
                        catch (SqlException ex)
                        {
                            throw new Exception("Erro ao adicionar cliente. " + ex.Message);
                        }

                        catch (Exception ex)
                        {
                            throw new Exception("Erro ao adiconar cliente. " + ex.Message);
                        }

                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("===== Listar Clientes =====\n");


                        try
                        {
                            var listaClientes = new List<Cliente>();

                            listaClientes = clienteController.ListarClientes();

                            foreach (var item in listaClientes)
                            {
                                Console.WriteLine("=============================");
                                Console.WriteLine(item);
                                Console.WriteLine("=============================\n");
                            }
                            Console.ReadKey();
                        }
                        catch (SqlException ex)
                        {
                            throw new Exception("Erro ao buscar clientes. " + ex.Message);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Erro ao buscar clientes." + ex.Message);
                        }

                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("===== Buscar Cliente Por E-mail =====\n");

                        try
                        {
                            string emailLido = InputHelper.LerString("Digite o email do cliente: ", "Email inválido.");


                            Cliente clienteLido = clienteController.BuscaClientePorEmail(emailLido);

                            Console.WriteLine("\n===== Cliente Encontrado =====\n");
                            Console.WriteLine(clienteLido);
                            
                            Console.ReadKey();
                        }
                        catch (SqlException ex)
                        {
                            throw new Exception("Erro ao buscar cliente. " + ex.Message);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Erro inesperado ao buscar cliente. " + ex.Message);
                        }

                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("===== Alterar Telefone Cliente =====\n");

                        string emailBusca = InputHelper.LerString("Digite o email do cliente: ", "Email inválido.");

                        string? telefoneNovo = InputHelper.LerStringNulo("Digite o telefone do cliente (opcional): ",
                            "Telefone Invalido", true);

                        try
                        {
                            clienteController.AtualizarTelefoneCliente(telefoneNovo, emailBusca);

                            Console.WriteLine("Telefone do cliente alterado com sucesso!");
                            
                            Console.ReadKey();
                        }
                        catch (SqlException ex)
                        {
                            throw new Exception("Erro ao atualizar telefone do cliente. " + ex.Message);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Erro ao atualizar telefone do cliente. " + ex.Message);
                        }
                        break;

                    case 5:
                        Console.Clear();
                        Console.WriteLine("===== Alterar Documento Cliente =====");

                        string emailAlterarDocumento =
                            InputHelper.LerString("Digite o email do cliente: ", "Email inválido.");


                        try
                        {
                            var clienteAlterarDocumento =
                                clienteController.BuscaClientePorEmail(emailAlterarDocumento) ??
                                throw new Exception(
                                    "Não existe cliente com esse email cadastrado!");

                            string tipoDocAtualizar =
                                InputHelper.LerString("Digite o tipo de documento: ", "Informe um tipo válido!");
                            string numeroAtualizar =
                                InputHelper.LerString("Digite o numero do Documento: ", "Número inválido!");
                            DateOnly emissaoAtualizar =
                                InputHelper.LerData("Digite a Data de Emissão (dd/MM/yyyy): ", "Data inválida!");
                            DateOnly validadeAtualizar = InputHelper.LerData("Digite a data de Validade (dd/MM/yyyy): ",
                                "Data inválida!");

                            Documento documentoAtualizar = new Documento(tipoDocAtualizar, numeroAtualizar,
                                emissaoAtualizar, validadeAtualizar);
                            documentoAtualizar.SetClienteId(clienteAlterarDocumento.ClienteId);
                            clienteController.AtualizarDocumentoCliente(emailAlterarDocumento, documentoAtualizar);


                            Console.WriteLine("Documento do cliente alterado com sucesso!");
                            Console.ReadKey();
                        }
                        catch (SqlException ex)
                        {
                            throw new Exception("Erro ao atualizar documento. " + ex.Message);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Erro ao atualizar documento. " + ex.Message);
                        }
                        break;

                    case 6:
                        Console.Clear();
                        Console.WriteLine("===== Remover Cliente =====");

                        try
                        {
                            string clienteExcluir =
                                InputHelper.LerString("Digite o email do cliente: ", "Email inválido.");

                            clienteController.DeletarCliente(clienteExcluir);

                            Console.WriteLine("Cliente removido com sucesso!");
                            Console.ReadKey();
                        }
                        catch (SqlException ex)
                        {
                            throw new Exception("Erro ao remover cliente. " + ex.Message);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Erro ao remover cliente. " + ex.Message);
                        }
                        break;

                    case 0:
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }while(op != 0);
        }
    }
}