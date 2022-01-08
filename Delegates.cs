using System;
using System.Collections.Generic;
using System.Linq;

namespace DelegatesEventosMetodosAnonimos
{
    public class Delegates
    {
        // definindo explicitamente o delegate personalizado
        delegate string NovoDelegateConverteString(string inString);

        public static void ExemploDelegateSemFuncDelegate()
        {
            // Instanciando o delegate personalizado para referenciar o método UppercaseString
            NovoDelegateConverteString converteMetodo = UppercaseString;
            string nome = "Brasil";
            // Utilizando o delegate instanciado para chamar o método UppercaseString
            Console.WriteLine(converteMetodo(nome));
        }

        private static string UppercaseString(string inputString)
        {
            return inputString.ToUpper();
        }

        public static void ExemploDelegateUtilizandoFuncDelegate()
        {
            // Instanciando o delegate Func para referenciar o método UppercaseString
            Func<string, string> converteMetodo = UppercaseString;
            string nome = "Brasil";
            // Utilizando o delegate Func instanciado para chamar o método UppercaseString
            Console.WriteLine(converteMetodo(nome));

            string UppercaseString(string inputString)
            {
                return inputString.ToUpper();
            }
            // Esse exemplo produz no console o seguinte output
            //    BRASIL
        }

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