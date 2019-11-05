using System;
using System.Collections.Generic;
using System.Text;

namespace Banco.Entidade
{
    public class Extrato : Base
    {        
        public ContaPoupanca Conta { get; set; }
        public EnumTipoMovimentacao Tipo { get; set; }
        public decimal Valor { get; set; }

        public override string ToString()
        {
            return $"Nome:{this.Conta.Cliente.Nome} " +
                $"{DataCadastro.ToString("dd/MM/yyyy")} - {Valor}";
        }
    }
}
