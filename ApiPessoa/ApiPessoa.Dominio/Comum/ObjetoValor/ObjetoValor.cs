using System;
using System.Collections.Generic;
using System.Text;

namespace ApiPessoa.Dominio.Comum.ObjetoValor
{
    public abstract class ObjetoValor
    {
        protected abstract IEnumerable<object> ObterPropriedadesIgualdade();

        public bool Igual(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;

            ObjetoValor outro = obj as ObjetoValor;

            IEnumerator<object> valores = ObterPropriedadesIgualdade().GetEnumerator();
            IEnumerator<object> outroValores = outro.ObterPropriedadesIgualdade().GetEnumerator();

            while (valores.MoveNext() && outroValores.MoveNext())
            {
                if (valores.Current is null ^ outroValores.Current is null)
                    return false;

                if (valores.Current != null && !valores.Current.Equals(outroValores.Current))
                    return false;
            }
            return !valores.MoveNext() && !outroValores.MoveNext();
        }
    }
}
