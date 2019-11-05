namespace Banco.Entidade
{
    public class Conta : ContaPoupanca
    {
        public decimal Limite { get; set; }

        public override string ExibirDados()
        {
            return $"Agencia:{Agencia} CC:{NumeroConta} Limite:{Limite}";
        }
    }
}