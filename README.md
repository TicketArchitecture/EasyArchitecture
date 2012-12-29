# EasyArchitecture

Um framework simples e leve para acelerar a construção de API's.

Com EasyArchitecture é possível:
* Proteger o modelo de domínio
* Prototipar
* Deixar para decidir mais tarde qual tecnologia usar
* Efetuar testes unitários
* 
* Permitir testabilidade


## Serviços de infra-estrutura:

O EasyArchiteture provê serviços de infra-estrutura.

### Log

Através de uma interface simples e intuítiva é possível logar mensagens e exceptions.

```csharp
        Logger.Message("Uma mensagem de debug").Debug();
```

### Armazenagem
### Tradução de objetos
### Inversão de Controle
### Cache
### Persistência
### Validação de objetos

##Extensão:
Através de plugins, os serviços de infra-estrutura podem ser extendidos.
Há diversos serviços disponíveis no projeto: [EasyArchitecture.Plugins](https://github.com/henriquericcio/EasyArchitecture.Plugins)

##Ambientes:
* Linux: Mono 
* Windows: .Net Framework

##Comece a usar
[Nuget Package](http://nuget.org/packages/easyarchitecture)

##Conheça mais
[Documentação](http://henriquericcio.github.com/EasyArchitecture/)

