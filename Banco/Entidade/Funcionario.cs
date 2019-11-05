namespace Banco.Entidade
{
    public class Funcionario : DadosPessoais
    {
        public override string ToString()
        {
            return $"id:{Id} - Nome:{Nome}";
        }
    }
}