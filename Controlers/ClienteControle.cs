using Projeto06.Entities;
using Projeto06.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Projeto06.Controlers
{
    public class ClienteControle
    {
        public void CadastrarCliente()
        {
            try
            {
                Console.WriteLine("\n*** CADASTRO DE CLIENTE ***\n");
                var cliente = new Cliente();
                Console.Write("NOME DO CLIENTE............: ");
                cliente.Nome = Console.ReadLine();
                Console.Write("CPF........................: ");
                cliente.Cpf = Console.ReadLine();
                Console.Write("DATA DE NASCIMENTO.........: ");
                cliente.DataNascimento = DateTime.Parse(Console.ReadLine());
                //TO DO: cadastrar o cliente no banco de dados
                var clienteRepository = new ClienteRepositores();
                clienteRepository.Inserir(cliente);
                Console.WriteLine(  "Cliente cadastrado com sucesso");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("\nOcorreram erros de validação:");
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nFalha ao cadastrar cliente:");
                Console.WriteLine(e.Message);
            }
        }
        public void ExecutarMenu()
        {
            Console.WriteLine("\n*** CONTROLE DE CLIENTES ***\n");
            Console.WriteLine("(1) - CADASTRAR CLIENTE");
            Console.WriteLine("(2) - ATUALIZAR CLIENTE");
            Console.WriteLine("(3) - EXCLUIR CLIENTE");
            Console.WriteLine("(4) - CONSULTAR CLIENTES");
            try
            {
                Console.Write("\nINFORME A OPÇÃO DESEJADA: ");
                var opcao = int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1: CadastrarCliente(); break;
                    case 2: break;
                    case 3: break;
                    case 4: break;
                    default:
                        
                            Console.WriteLine("\nOPÇÃO INVÁLIDA.");
                            break;
                        
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nErro: " + e.Message);
            }

        }
        //método para executar a edição de um cliente
        public void AtualizarCliente()
        {
            try
            {
                Console.WriteLine("\n*** EDIÇÃO DE CLIENTE ***\n");
                Console.Write("INFORME O ID DO CLIENTE....: ");
                var id = Guid.Parse(Console.ReadLine());
                //pesquisar no banco de dados o cliente através do id
                var clienteRepository = new ClienteRepository();
                var cliente = clienteRepository.ObterPorId(id);
                //verificar se o cliente foi encontrado
                if (cliente != null)
                {
                    Console.Write("INFORME O NOME DO CLIENTE..: ");
                    cliente.Nome = Console.ReadLine();
                    Console.Write("INFORME O CPF DO CLIENTE...: ");
                    cliente.Cpf = Console.ReadLine();
                    Console.Write("INFORME A DATA DE NASC.....: ");
                    cliente.DataNascimento = DateTime.Parse
                    (Console.ReadLine());
                    //atualizando o cliente no banco de dados
                    clienteRepository.Atualizar(cliente);
                    Console.WriteLine("\nCLIENTE ATUALIZADO COM SUCESSO.");
                }
                else
                {
                    Console.WriteLine("\nCliente não encontrado.");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("\nOcorreram erros de validação.");
                Treinamento em C# WebDeveloper Aula
06
           Sexta - feira, 30 de Junho de 2023
           Programação Orientada a Objetos em C#
13
            Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nFalha ao atualizar cliente:");
                Console.WriteLine(e.Message);
            }
        }
        //método para executar a exclusão de um cliente
        public void ExcluirCliente()
        {
            try
            {
                Console.WriteLine("\n*** EXCLUSÃO DE CLIENTE ***\n");
                Console.Write("INFORME O ID DO CLIENTE....: ");
                var id = Guid.Parse(Console.ReadLine());
                //pesquisar o cliente no banco de dados através do id
                var clienteRepository = new ClienteRepository();
                var cliente = clienteRepository.ObterPorId(id);
                //verificar se o cliente foi encontrado
                if (cliente != null)
                {
                    //excluindo o cliente
                    clienteRepository.Excluir(cliente);
                    Console.WriteLine("\nCLIENTE EXCLUÍDO COM SUCESSO.");
                }
                else
                {
                    Console.WriteLine("\nCliente não encontrado.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nFalha ao excluir cliente:");
                Console.WriteLine(e.Message);
            }
        }
        //método para consultar e imprimir todos os clientes cadastrados
        public void ConsultarClientes()
        {
            try
            {
                Console.WriteLine("\n*** CONSULTA DE CLIENTES ***\n");
                //consultando todos os clientes 
                //cadastrados no banco de dados
                var clienteRepository = new ClienteRepository();
                var clientes = clienteRepository.ObterTodos();
                //varrer e imprimir a lista de clientes:
                foreach (var item in clientes)
                {
                    Console.WriteLine("ID...........: " + item.Id);
                    Console.WriteLine("NOME.........: " + item.Nome);
                    Console.WriteLine("CPF..........: " + item.Cpf);
                    Treinamento em C# WebDeveloper Aula
06
              
                Console.WriteLine("DATA DE NASC.: "+ item.DataNascimento);
                    Console.WriteLine("...");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nFalha ao consultar clientes.");
                Console.WriteLine(e.Message);
            }
        }
    }
}


//                }
//                else
//                {
//                    Console.WriteLine("\nFIM DO PROGRAMA!");
//                }
//            }//namespace Projeto06.Controllers
////{
////    public class ClienteController
////    {
//        //método para executar o menu de opções
      
//                Console.WriteLine("\nDESEJA CONTINUAR? (S,N): ");
//                var escolha = Console.ReadLine();
//                if (escolha.Equals("S", StringComparison.OrdinalIgnoreCase))
//                {
//                    Console.Clear(); //limpar o prompt do DOS
//                    Treinamento em C# WebDeveloper Aula
//06
//                ExecutarMenu(); //recursividade!
//            catch (Exception e)
//            {
//                Console.WriteLine("\nErro: " + e.Message);
//            }


//        }           
//}