using System;
using System.Collections.Generic;
using System.Text;
using Banco.Entidade;

namespace Banco.Negocio
{
    public class BancoOperacao
    {
        public Extrato Movimentacao(List<Cliente> clientes)
        {
            Console.Clear();
            Console.WriteLine("============Movimentação==============");
            Console.WriteLine();
            Console.WriteLine("Lista de clientes");
            clientes.ForEach(c => {
                Console.WriteLine(c);
            });
            Console.WriteLine("Digite o codigo do cliente");
            int codigoCliente = int.Parse(Console.ReadLine());

            Cliente cliente = clientes.Find(c => c.Id == codigoCliente);

            Extrato extrato = new Extrato();

            Console.WriteLine("Qual operação deseja fazer -[1] Saque [2] Deposito");
            string tipoOperacao = Console.ReadLine();

            if (tipoOperacao.Equals("1"))
                extrato.Tipo = EnumTipoMovimentacao.SAQUE;
            else
                extrato.Tipo = EnumTipoMovimentacao.DEPOSITO;

            Console.WriteLine("Qual o valor:");
            decimal valor = decimal.Parse(Console.ReadLine());
            extrato.Valor = valor;

            if (cliente.Contas.Count > 1) {
                Console.WriteLine("Qual conta deseja movimentar - [1] Poupança [2] Corrente");
                string tipoConta = Console.ReadLine();

                cliente.Contas.ForEach(c => {
                    if (c.GetType().Equals(typeof(ContaPoupanca)) && tipoConta.Equals("1")) {
                        SaqueDeposito(c, extrato.Tipo, valor);
                        extrato.Conta = c;
                    }
                    else if (c.GetType().Equals(typeof(Conta)) && tipoConta.Equals("2")) {
                        SaqueDeposito(c, extrato.Tipo, valor);
                        extrato.Conta = c;
                    }
                });
            }
            else
                cliente.Contas.ForEach(c => {
                    SaqueDeposito(c, extrato.Tipo, valor);
                    extrato.Conta = c;
                });

            return extrato;
        }

        public void SaqueDeposito(ContaPoupanca conta, EnumTipoMovimentacao tipo, decimal valor)
        {
            if (EnumTipoMovimentacao.SAQUE == tipo)
                conta.Saldo -= valor;
            else
                conta.Saldo += valor;
        }
        
    }
}
