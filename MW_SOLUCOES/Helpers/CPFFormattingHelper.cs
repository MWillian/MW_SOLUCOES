namespace MW_SOLUCOES.Helpers;
using System.Data;

public static class CPFFormattingHelper
{
    public static void FormatCpf(string cpf)
    {
        cpf = cpf.Trim().Replace("-","").Replace(".","");
    }
}
