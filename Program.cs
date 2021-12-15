using System;
using System.Collections.Generic;

namespace DelegatesEventosMetodosAnonimos
{
    class Program
    {
        static void Main(string[] args)
        {
            //new MetodosAnonimos().ExemploUtilizandoLista();
            List<int> listaValoresMenoresQue10 = Delegates.EncontrarInteirosComValorMenorFunc();
        }
    }
}
