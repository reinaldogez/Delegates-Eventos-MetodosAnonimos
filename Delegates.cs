using System;
using System.Collections.Generic;
using System.Linq;

namespace DelegatesEventosMetodosAnonimos
{
    public class Delegates
    {

        public static List<int> EncontrarInteirosComValorMenorFunc()
        {
            List<int> listaInteiros = new List<int>() { 2, 3, 15, 17 };
            //Primeiro exemplo utilizando método anônimo, no momento em que o Func delegate é instanciado.
            Func<int, bool> WhereFunc = delegate (int valor)
            {
                return valor < 10;
            };
            return listaInteiros.Where(WhereFunc).ToList<int>();
        }

        // O tipo T é declarado covariante utilizando a palavra-chave out. 
        public delegate T ExemploDelegateGenerico<out T>();
        public static void DelegateGenerico()
        {
            ExemploDelegateGenerico<string> dString = () => " ";

            // Só é possível assinalar o delegate dString para dObject
            // porque o tipo T foi declarado covariante
            ExemploDelegateGenerico<Object> dObject = dString;
        }

        public delegate T ExemploDelegateGenericoSemOut<T>();
        public static void DelegateGenericoSemOut()
        {
            // Perceba que a ausência do out, permite que o delegate seja instanciado  
            ExemploDelegateGenericoSemOut<String> dString = () => " ";
            ExemploDelegateGenericoSemOut<Object> dObject = () => " ";

            // porém, não é possível atribuir um delegate ao outro sem 
            // marcar o tipo T como covariante(utilizando a palavra-chave out)
            // logo, a instrução a seguir gera um erro no compilador.
            // SampleGenericDelegateWithoutOut <Object> dObject = dString;  

        }
    }
}