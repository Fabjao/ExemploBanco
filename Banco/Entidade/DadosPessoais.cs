using System;
using System.Collections.Generic;
using System.Text;

namespace Banco.Entidade
{
   public abstract class DadosPessoais : DadosGerais
    {
        public int Idade { get; set; }
        public string Sexo { get; set; }
    }
}
