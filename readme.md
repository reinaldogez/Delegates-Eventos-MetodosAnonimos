# Delegates, eventos e métodos anônimos
![Delegates, eventos e métodos anônimos](/docs/meme.jpeg) 
=========

## Delegates

### Delegates e variância(paramêtros de tipos genéricos)

Os paramêtros de tipos genéricos foram inseridos no .NET 4, 

Link da documentação sobre delegates e variância
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

Link para documentação sobre predicado e "Predicate<T> Delegate", que o método Find utiliza no exemplo com List
~~~cs
public T? Find(Predicate<T> match);
~~~
https://docs.microsoft.com/en-us/dotnet/api/system.predicate-1?view=net-5.0