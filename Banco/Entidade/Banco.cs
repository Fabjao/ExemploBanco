using System;
using System.Collections.Generic;
using System.Text;

namespace Banco.Entidade
{
    public class Banco : DadosGerais
    {
        public string Endereco { get; set; }
        public int Telefone { get; set; }
        public List<Cliente> Clientes { get; set; } = new List<Cliente>();
        public List<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();
        public List<Extrato> Movimentocao { get; set; } = new List<Extrato>();
    }
}
