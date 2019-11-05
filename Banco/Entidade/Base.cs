using System;
using System.Collections.Generic;
using System.Text;

namespace Banco.Entidade
{
    public abstract class Base
    {
        public int Id { get; set; } = new Random().Next(1, 999);
        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
