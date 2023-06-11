using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoAutoEscola.API.Presentation.Helper;
public static class CpfHelper
{
    public static bool ValidarCpf(string cpf)
    {
        // Remover caracteres não numéricos do CPF
        cpf = new string(cpf.Where(char.IsDigit).ToArray());

        // Verificar se o CPF possui 11 dígitos
        if (cpf.Length != 11)
            return false;

        // Verificar se todos os dígitos são iguais (caso contrário, o CPF é inválido)
        if (cpf.Distinct().Count() == 1)
            return false;

        // Calcular os dígitos verificadores
        int[] multiplicadoresDigito1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicadoresDigito2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        string cpfSemDigitos = cpf.Substring(0, 9);
        int soma = cpfSemDigitos.Select((c, i) => int.Parse(c.ToString()) * multiplicadoresDigito1[i]).Sum();
        int resto = soma % 11;
        int digito1 = resto < 2 ? 0 : 11 - resto;

        cpfSemDigitos += digito1;
        soma = cpfSemDigitos.Select((c, i) => int.Parse(c.ToString()) * multiplicadoresDigito2[i]).Sum();
        resto = soma % 11;
        int digito2 = resto < 2 ? 0 : 11 - resto;

        // Verificar se os dígitos calculados são iguais aos dígitos verificadores do CPF
        return cpf.EndsWith(digito1.ToString() + digito2.ToString());
    }
}
