namespace MW_SOLUCOES.Helpers;

public static class CPFValidationHelper
{
    public static string RemoveFormat(string cpf)
    {
        if (string.IsNullOrWhiteSpace(cpf)) return string.Empty;
        return new string(cpf.Where(char.IsDigit).ToArray());
    }
    public static bool IsValid(string cpf)
    {
        string cpfLimpo = RemoveFormat(cpf);
        if (cpfLimpo.Length != 11)
            return false;

        if (IsValidSequence(cpfLimpo))
            return false;

        if (!ValidateDigit(cpfLimpo, 9, new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 }))
            return false;

        if (!ValidateDigit(cpfLimpo, 10, new int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 }))
            return false;

        return true;
    }

    private static bool IsValidSequence(string cpf)
    {
        string[] invalidos =
        {
            "00000000000", "11111111111", "22222222222", "33333333333", "44444444444",
            "55555555555", "66666666666", "77777777777", "88888888888", "99999999999"
        };
        return invalidos.Contains(cpf);
    }

    private static bool ValidateDigit(string cpf, int posicaoDigito, int[] pesos)
    {
        int soma = 0;

        for (int i = 0; i < pesos.Length; i++)
        {
            soma += (cpf[i] - '0') * pesos[i];
        }

        int resto = (soma * 10) % 11;

        int digitoCalculado = (resto == 10) ? 0 : resto;

        return digitoCalculado == (cpf[posicaoDigito] - '0');
    }
}
