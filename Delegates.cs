using System;

namespace DelegatesEventosMetodosAnonimos
{
    public class Delegates
    {
        // O tipo T é declarado covariante utilizando a palavra-chave out. 
        public delegate T SampleGenericDelegate<out T>();
        public static void GenericDelegate()
        {
            SampleGenericDelegate<string> dString = () => " ";

            // Só é possível assinalar o delegate dString para dObject
            // porque o tipo T foi declarado covariante
            SampleGenericDelegate<Object> dObject = dString;
        }

        public delegate T SampleGenericDelegateWithoutOut<T>();
        public static void GenericDelegateWithoutOut()
        {
            // Perceba que a ausência do out, permite que o delegate seja instanciado  
            SampleGenericDelegateWithoutOut<String> dString = () => " ";
            SampleGenericDelegateWithoutOut<Object> dObject = () => " ";

            // porém, não é possível atribuir um delegate ao outro sem 
            // marcar o tipo T como covariante(utilizando a palavra-chave out)
            // logo, a instrução a seguir gera um erro no compilador.
            // SampleGenericDelegateWithoutOut <Object> dObject = dString;  

        }
    }
}