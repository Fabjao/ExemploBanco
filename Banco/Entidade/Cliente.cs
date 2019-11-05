using System;
using System.Collections.Generic;
using System.Text;

namespace Banco.Entidade
{
    public class Cliente : DadosPessoais
    {
        public Funcionario Funcionario { get; set; }
        public List<ContaPoupanca> Contas { get; set; } = new List<ContaPoupanca>();
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"Id:{Id} - Nome:{Nome}");
            Contas.ForEach(c => {
                stringBuilder.Append(c.GetType().Equals(typeof(ContaPoupanca)) ? "Poupança:" : "Corrente:");
                stringBuilder.Append(c.Saldo);
            });
            return stringBuilder.ToString();
        }
    }
}