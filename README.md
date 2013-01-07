# EasyArchitecture

Um framework simples e leve para acelerar a construção de API's.

Com EasyArchitecture é possível:
* Proteger o modelo de domínio
* Prototipar
* Deixar para decidir mais tarde qual tecnologia usar
* Efetuar testes unitários
* Permitir testabilidade


# Serviços de infra-estrutura:

O EasyArchiteture provê serviços de infra-estrutura.

## Log

Através de uma interface simples e intuítiva é possível logar mensagens e exceptions.

```csharp
//logar mensagem de informação
Logger.Message("Este é a {0} de {1} mensagens", "primeira","muitas").Info();

//logar exception como fatal
Logger.Exception(exception).Fatal();

//logar um objeto complexo sem se preocupar com o formado, como debug
Logger.Raw(complexObject).Debug();

```

## Armazenagem

```csharp
//salva conteúdo binário e recupera chave
var id = Storer.Save(buffer);

//verifica existência de chave
if(!Storer.Exists(id))
    return;

//recupera conteúdo binário
var newBuffer = Storer.Get(id);

```


## Tradução de objetos

```csharp
//Traduz um objeto, criando um novo
var entity = Translator.This(source).To<Entity>();

//Traduz um objeto sobrepondo valores em um existente
destinty = Translator.This(source).To(destinty);

```

## Inversão de Controle

```csharp
//obtem a instância de uma façade
var facade = Container.Resolve<IDogFacade>();

//força o uso de outra implementação
Container.Register<IDogFacade,CatFacade>();

//obtem a instância do tipo registrado
facade = Container.Resolve<IDogFacade>();

```
## Cache

```csharp
//mantém em cache por 7 dias
Cache.This(item).With.ExpirationOf(7).Days.At("Samara-Call");

//recupera item
item = Cache.Get.At("Samara-Call");

//mantém em cache indefinidamente
Cache.This(item).With.NoExpiration.At("NewKey");

//verifica existência e remove do cache
if(Cache.Exists.At("NewKey"))
    Cache.Remove.At("NewKey");

//limpa completamente o cache
Cache.Clear();


```
## Persistência

```csharp
//Exemplo de uso do repository

```
## Validação de objetos

```csharp
//verifica se uma entidade é válida (caso não seja, uma exception será lançada)
Validator.This(entity).IsValid();

//verifica se uma entidade é válida, retornando a lista de mensagens
IList<string> messageList = Validator.This(entity).HasMessages();

```

# Extensão:
Através de plugins, os serviços de infra-estrutura podem ser extendidos.
Há diversos serviços disponíveis no projeto: [EasyArchitecture.Plugins](https://github.com/henriquericcio/EasyArchitecture.Plugins)

# Ambientes:
* Linux: Mono 
* Windows: .Net Framework

# Comece a usar
[Nuget Package](http://nuget.org/packages/easyarchitecture)

# Conheça mais
* [Documentação Oficial](http://henriquericcio.github.com/EasyArchitecture/) - Em andamento
* [Blog do idealizador](http://henriquericcio.com/category/easyarchitecture/) - Aqui estão comentadas e documentadas as idéias e decisões
