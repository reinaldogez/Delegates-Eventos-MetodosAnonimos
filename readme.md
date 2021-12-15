# Delegates, eventos e métodos anônimos
![Delegates, eventos e métodos anônimos](/docs/meme.jpeg) 
=========

## Delegates

### Func and Action Delegates

Func<TResult> Delegate é um delegate que retorna o parâmetro TResult e pode ou não receber parâmetros.
Já o Action delegate tem retorno void e pode ou não receber parâmetros.
[Documentação do Action delegate](https://docs.microsoft.com/en-us/dotnet/api/system.action?view=net-6.0)
~~~cs
public delegate void Action();
~~~
Por exemplo, podemos usar esses delegates(Func and Action) definidos no namespace System para passar um método como um parâmetro sem declarar explicitamente um delegate.

### Delegates e variância(paramêtros de tipos genéricos)

A conversão implícita entre delegates foi inserida no .NET 4, logo delegates genéricos que tenham diferentes tipos especificados por parâmetros de tipos genéricos podem ser assinalados uns aos outros, desde que exista e seja respeitada a relação de herança entre esses tipos, conforme exigido pela variância.
Confira na classe [Delegates.cs](Delegates.cs) os métodos DelegateGenerico() e DelegateGenericoSemOut() para um melhor entendimento sobre o tema.

Link da documentação sobre delegates e variância <br>
https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/covariance-contravariance/variance-in-delegates
## Métodos anônimos
Os métodos anônimos foram introduzidos no C# 2.0, eles foram criados para ser possível definir delegates sem criar um método nomeado. Nesse sentido os métodos anônimos são métodos sem nome, apenas o corpo.

### Escrevendo métodos anônimos

Métodos anônimos são declarados junto com a criação da instância do delegate, sempre precedidos pela keyword "delegate".
Não é necessário especificar o tipo de retorno em um método anônimo; ele é inferido da instrução return dentro do corpo do método.
~~~cs
delegate int Transformer(int i);
Transformer square = delegate (int x) { return x * x; };
~~~

Link para documentação sobre predicate delegate, que o método Find utiliza no exemplo com List
~~~cs
public T? Find(Predicate<T> match);
~~~
https://docs.microsoft.com/en-us/dotnet/api/system.predicate-1?view=net-5.0