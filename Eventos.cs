using System;

namespace DelegatesEventosMetodosAnonimos
{

    public class Eventos
    {
        public Eventos()
        {
            Estoque estoque = new Estoque("Estoque");
            estoque.Preco = 27.10M;
            AdicionaAssinante(estoque);
            AlteraPreco(estoque);
        }

        public void AdicionaAssinante(Estoque estoque){
            //registrando o evento
            estoque.PrecoMudou += estoque_PrecoMudou;
        }

        public void AlteraPreco(Estoque estoque){
            estoque.Preco = 31.59M;
        }

        //método assinante
        void estoque_PrecoMudou(object sender, PrecoMudouEventArgs e)
        {
            if ((e.NovoPreco - e.UltimoPreco) / e.UltimoPreco > 0.1M)
            {
                Console.WriteLine("Preço do estoque cresceu 10%");
            }
        }
    }

    public class PrecoMudouEventArgs : EventArgs
    {
        public readonly decimal UltimoPreco;
        public readonly decimal NovoPreco;

        public PrecoMudouEventArgs(decimal ultimoPreco, decimal novoPreco)
        {
            UltimoPreco = ultimoPreco;
            NovoPreco = novoPreco;
        }
    }

    public class Estoque
    {
        string nome;
        decimal preco;

        public Estoque(string nome) => this.nome = nome;

        public event EventHandler<PrecoMudouEventArgs> PrecoMudou;

        //método transmissor/publisher
        protected virtual void OnPrecoMudou(PrecoMudouEventArgs e)
        {
            PrecoMudou?.Invoke(this, e);
        }

        public decimal Preco
        {
            get => preco;
            set
            {
                if (preco == value) return;
                decimal precoAntigo = preco;
                preco = value;
                OnPrecoMudou(new PrecoMudouEventArgs(precoAntigo, preco));
            }
        }
    }
}