using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ApiPessoa.Dominio.Comum.Extensao
{
    public static class StringExtensao
    {
        public static bool VerificarSeEhNuloOuVazio(this string campo) =>
           string.IsNullOrWhiteSpace(campo);

        public static bool VerificarSeEhNumerico(this string campo) =>
           !campo.VerificarSeEhNuloOuVazio() && Regex.IsMatch(campo, @"^\d+$");
        public static string Aparar(this string campo) =>
            string.IsNullOrEmpty(campo) ? campo : campo.Trim();
    }
}
