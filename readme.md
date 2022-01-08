# Delegates, eventos e métodos anônimos
![Delegates, eventos e métodos anônimos](/docs/meme.jpeg) 
=========

## Delegates

Definição: Um Delegate é um ponteiro para um método. Um Delegate pode ser passado como um parâmetro para um método. Podemos mudar a implementação do método dinamicamente em tempo de execução, a única coisa que precisamos para fazer isso seria manter o tipo de parâmetro e o tipo de retorno.
### Func e Action Delegates

Func<TResult> Delegate é um delegate que retorna o parâmetro TResult e pode ou não receber parâmetros.
Já o Action delegate tem retorno void e pode ou não receber parâmetros.
[Documentação do Action delegate](https://docs.microsoft.com/en-us/dotnet/api/system.action?view=net-6.0)
~~~cs
public delegate void Action();
~~~
Por exemplo, podemos usar esses delegates(Func e Action) definidos no namespace System para passar um método como um parâmetro sem declarar explicitamente um delegate personalizado.
No código [Delegates.cs](Delegates.cs) deixamos um exemplo utilizando Func delegate, mostrando a praticidade de instanciar o Func delegate, em vez de, explicitamente definir um novo delegate e assinalar um método a esse novo delegate.


### Delegates e variância(paramêtros de tipos genéricos)

A conversão implícita entre delegates foi inserida no .NET 4, logo delegates genéricos que tenham diferentes tipos especificados por parâmetros de tipos genéricos podem ser assinalados uns aos outros, desde que exista e seja respeitada a relação de herança entre esses tipos, conforme exigido pela variância.
Confira na classe [Delegates.cs](Delegates.cs) os métodos DelegateGenerico() e DelegateGenericoSemOut() para um melhor entendimento sobre o tema.

Declarando o parâmetro de retorno como covariante, ou seja, permite utilizar o tipo especificado ou qualquer tipo menos derivado.
~~~cs
public delegate T ExemploDelegateGenerico<out T>();
~~~

Dessa forma, só é possível assinalar o delegate dString para dObject porque o tipo T foi declarado covariante
~~~cs
ExemploDelegateGenerico<string> dString = () => " ";
ExemploDelegateGenerico<Object> dObject = dString;
~~~

[Link da documentação sobre delegates e variância](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/covariance-contravariance/variance-in-delegates)

## Métodos anônimos
Os métodos anônimos foram introduzidos no C# 2.0, eles foram criados para ser possível definir delegates sem criar um método nomeado. Nesse sentido os métodos anônimos são métodos sem nome, apenas o corpo.

### Escrevendo métodos anônimos

Métodos anônimos são declarados junto com a criação da instância do delegate, sempre precedidos pela keyword "delegate".
Não é necessário especificar o tipo de retorno em um método anônimo; ele é inferido da instrução return dentro do corpo do método.
~~~cs
delegate int Transformer(int i);
Transformer square = delegate (int x) { return x * x; };
~~~

[Link para documentação sobre predicate delegate, que o método Find utiliza no exemplo com List](https://docs.microsoft.com/en-us/dotnet/api/system.predicate-1?view=net-5.0)
~~~cs
public T? Find(Predicate<T> match);
~~~

## Eventos
Os eventos formalizam o padrão [Pub-Sub](https://en.wikipedia.org/wiki/Publish%E2%80%93subscribe_pattern), o publisher/broadcaster determina quando publicar uma mensagem(ou evento), invocando o delegate.
~~~cs
protected virtual void OnPrecoMudou(PrecoMudouEventArgs e)
{
    PrecoMudou?.Invoke(this, e);
}
~~~
Os assinantes/subscribers decidem quando começam e terminam de receber as mensagens utilizando += e -= no delegate do publisher.
~~~cs
public void AdicionaAssinante(Estoque estoque){
    //registrando o evento
    estoque.PrecoMudou += estoque_PrecoMudou;
}
~~~
Se removermos a palavra-chave event, PrecoMudou se torna um delegate comum, o código seguirá funcionando porém os assinantes poderão interferir no funcionamento uns dos outros o que deixa o código menos robusto. Veja as seguintes observações:
    - Por exemplo um assinante pode reatribuir o delegate PrecoMudou utilizando =, ao invés de +=, substituindo assim outros assinantes que ficariam sem receber os eventos.
    - Um assinante poderia limpar todos os assinantes setando PrecoMudou como null.
    - Um assinante poderia transmitir para outros assinantes utilizando o método Invoke() do delegate PrecoMudou.

No exemplo utilizamos o delegate genérico System.EventHandler<>
(/docs/delegate_eventhandler.png)     
