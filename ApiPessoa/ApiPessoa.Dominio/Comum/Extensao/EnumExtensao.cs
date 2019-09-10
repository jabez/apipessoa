using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ApiPessoa.Dominio.Comum.Extensao
{
    public static class EnumExtensao
    {
        /// <summary>
        /// Verifica se o valor existe na enum.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerador"></param>
        /// <returns></returns>
        public static bool ExisteNaEnum<T>(this Enum enumerador) =>
            Enum.IsDefined(typeof(T), enumerador);

        public static string ObterDescricao(this Enum enumerador)
        {
            var tipo = enumerador.GetType();
            if (!tipo.IsEnum)
                throw new ArgumentException($"{nameof(enumerador)} deve ser do tipo do enumerador", nameof(enumerador));

            var membro = tipo.GetMember(enumerador.ToString());
            if (membro.Length > 0)
            {
                var attrs = membro[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }

            return enumerador.ToString();
        }
    }
}
