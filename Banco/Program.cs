using System;
using System.Collections.Generic;
using System.Linq;
using Banco.Entidade;
using Banco.Negocio;

namespace Banco
{
    public class Program
    {

        public static void Main(string[] args)
        {
            BancoCadastro cadastros = new BancoCadastro();
            BancoOperacao operacao = new BancoOperacao();

            Entidade.Banco banco = cadastros.CadastrarBanco();

            do {
                Console.Clear();
                Console.WriteLine($"=============Banco {banco.Nome}===============");
                Console.WriteLine();
                Console.WriteLine("1- Cadastrar Funcionario");
                Console.WriteLine("2- Cadastrar Cliente");
                Console.WriteLine("3- Exibir Cliente");
                Console.WriteLine("4- Movimentação");
                Console.WriteLine("5- Exibir Movimentação");
                Console.WriteLine("9- Sair");
                Console.WriteLine();
                Console.WriteLine("Digite uma opção:");
                int.TryParse(Console.ReadLine(), out int opcao);
                switch (opcao) {
                    case 1:
                        Funcionario funcionario = cadastros.CadastrarFuncionario();
                        banco.Funcionarios.Add(funcionario);
                        break;
                    case 2:
                        Cliente cliente = cadastros.CadastrarCliente(banco.Funcionarios);
                        if (cliente != null)
                            banco.Clientes.Add(cliente);
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("========Clientes============");
                        if (banco.Clientes.Count == 0) Console.WriteLine("Não ha clientes");
                        banco.Clientes.ForEach(c => {
                            Console.WriteLine(c);
                        });
                        Console.ReadKey();
                        break;
                    case 4: //Movimetacao                        
                        Extrato extrato = operacao.Movimentacao(banco.Clientes);
                        banco.Movimentocao.Add(extrato);
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("==========Movimentação=============");
                        if (banco.Movimentocao.Count == 0) Console.WriteLine("Não há movimentação");

                        banco.Movimentocao.OrderBy(e => e.Conta.Cliente.Nome).ToList().ForEach(m => {
                            Console.WriteLine(m);
                        });
                        Console.ReadKey();
                        break;
                    case 9:
                        Console.WriteLine("Obrigado por usar nosso sistema");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opção invalida");
                        Console.ReadKey();
                        break;
                }


            } while (true);


            //Cliente cliente = new Cliente();
            //Conta conta = new Conta { Agencia = 12, NumeroConta = 54565, Limite = 10.34M };
            //ContaPoupanca contaPoupanca = new ContaPoupanca { Agencia = 26, NumeroConta = 86 };

            //cliente.Contas.Add(conta);
            //cliente.Contas.Add(contaPoupanca);

            //cliente.Contas.ForEach(c => {
            //    if (c.GetType().Equals(typeof(Conta)))
            //        Console.WriteLine(c.ExibirDados());
            //    else
            //        Console.WriteLine(c.ExibirDados());
            //});


        }
    }
}
