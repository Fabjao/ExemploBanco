using System;
using System.Collections.Generic;
using System.Text;

namespace Banco.Entidade
{
  public  class ContaPoupanca: Base
    {
        public Cliente Cliente { get; set; }
        public int Agencia { get; set; }
        public int NumeroConta { get; set; }
        public decimal Saldo { get; set; }
        public virtual string ExibirDados()
        {
            return $"Agencia:{Agencia} CP:{NumeroConta}";
        }
    }
}
