using System;
using System.Collections.Generic;

namespace DelegatesEventosMetodosAnonimos
{
    public class MetodosAnonimos
    {
        public void ExemploUtilizandoLista()
        {
            List<string> nomes = new List<string> { "Reinaldo", "Jefferson", "Jessica", "Janice", "Manuela" };
            string resultado = nomes.Find(delegate (string nome)
                                       {
                                           return nome.StartsWith("M");
                                       });
            Console.WriteLine("Resultado com método anônimo: " + resultado);

            //Equivalente utilizando expressão lambda
            string resultadoComExpressaoLambda = nomes.Find(nome => nome.StartsWith("M"));
            Console.WriteLine("Resultado com expressão lambda: " + resultadoComExpressaoLambda);
            Console.ReadKey();

        }

    }
}