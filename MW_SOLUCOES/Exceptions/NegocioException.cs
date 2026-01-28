namespace MW_SOLUCOES.Exceptions;

public class NegocioException : Exception
{
    public NegocioException() { }
    public NegocioException(string mensagem) : base(mensagem) { }
}
