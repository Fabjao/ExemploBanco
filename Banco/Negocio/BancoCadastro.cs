using System;
using System.Collections.Generic;
using System.Text;
using Banco.Entidade;

namespace Banco.Negocio
{
   public class BancoCadastro
    {
        public Entidade.Banco CadastrarBanco()
        {
            Entidade.Banco banco = new Entidade.Banco();

            Console.WriteLine("=========Cadastro do Banco===========");
            Console.Write("Digite o nome do banco:");
            banco.Nome = "Pan";// Console.ReadLine();

            Console.WriteLine("Digite o número do Telefone:");
            banco.Telefone = 12311231; // int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Endereço:");
            banco.Endereco = "Avenida Jabaquara, 2819";// Console.ReadLine();

            Console.WriteLine("Dados Cadastrado com sucesso");
            //Console.ReadKey();

            return banco;
        }

        public Funcionario CadastrarFuncionario()
        {
            Console.Clear();
            Funcionario funcionario = new Funcionario();
            Console.WriteLine("=========Cadastro de Funcionario===========");

            Console.Write("\nDigite o nome do funcionario: ");
            funcionario.Nome = Console.ReadLine();

            Console.Write("\n Digite a idade do funcionario: ");
            funcionario.Idade = int.Parse(Console.ReadLine());

            Console.Write("\n Digite o sexo do funcionario: ");
            funcionario.Sexo = Console.ReadLine();
            Console.WriteLine("Cadastro com sucesso");
            Console.ReadKey();
            return funcionario;
            
        }

        public Cliente CadastrarCliente(List<Funcionario> funcionarios)
        {
            if(funcionarios.Count == 0) {
                Console.WriteLine("Cadastre pelo menos 1 funcionario");
                Console.ReadKey();
                return null;
            }
            Cliente cliente = new Cliente();
            void msgPadrao()
            {
                Console.Clear();
                Console.WriteLine("=========Cadastro de Cliente===========");
                Console.WriteLine();
            };

            msgPadrao();

            Console.WriteLine("===========Funcionarios=============");

            funcionarios.ForEach(f => {
                  Console.WriteLine(f);
            });

            Console.WriteLine("Digite o codigo funcionario");
            int codigo = int.Parse(Console.ReadLine());
            cliente.Funcionario = funcionarios.Find(f=> f.Id == codigo);
            
            Console.Write("\nDigite o nome: ");
            cliente.Nome = Console.ReadLine();

            Console.Write("\n Digite a idade: ");
            cliente.Idade = int.Parse(Console.ReadLine());

            Console.Write("\n Digite o sexo: ");
            cliente.Sexo = Console.ReadLine();

            //Cadastrar a conta

            Console.WriteLine("Qual tipo de conta você deseja:");
            Console.WriteLine("[1]-Poupança [2]-Corrente");
            string tipo = Console.ReadLine();
            if (tipo.Equals("1"))
                cliente.Contas.Add(CadastraContaPoupanca(cliente));
            else
                cliente.Contas.Add(CadastraContaCorrente(cliente));

            Console.WriteLine("Cadastro de cliente com sucesso");
            Console.ReadKey();

            return cliente;

        }

        public ContaPoupanca CadastraContaPoupanca(Cliente cliente)
        {
            ContaPoupanca contaPoupanca = new ContaPoupanca();
            Console.WriteLine("Digite a agencia");
            contaPoupanca.Agencia = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o numero da conta");
            contaPoupanca.NumeroConta = int.Parse(Console.ReadLine());
            contaPoupanca.Saldo = decimal.Zero;
            contaPoupanca.Cliente = cliente;

            return contaPoupanca;
        }

        public Conta CadastraContaCorrente(Cliente cliente)
        {
            Conta contaCorrente = new Conta();
            Console.WriteLine("Digite a agencia");
            contaCorrente.Agencia = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o numero da conta");
            contaCorrente.NumeroConta = int.Parse(Console.ReadLine());
            contaCorrente.Saldo = decimal.Zero;
            Console.WriteLine("Digite o Limite");
            contaCorrente.Limite = decimal.Parse(Console.ReadLine());
            contaCorrente.Cliente = cliente;

            return contaCorrente;
        }

        
    }
}
