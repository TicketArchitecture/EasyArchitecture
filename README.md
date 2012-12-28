EasyArchitecture
================

Um framework simples e leve para acelerar a construção de API's

##Objetivos:
* Dar suporte a pequenos e grandes sistemas
* Proteger o modelo de domínio
* Permitir decisão tardia de tecnologias
* Permitir testabilidade

##Serviços de infra-estrutura:
* Log
* Armazenagem
* Tradução de objetos
* Inversão de Controle
* Cache
* Persistência
* Validação de objetos

##Extensão:
	Através de plugins, os serviços de infra-estrutura podem ser extendidos.
	Há diversos serviços disponíveis no projeto: [EasyArchitecture.Plugins](https://github.com/henriquericcio/EasyArchitecture.Plugins)

##Ambientes:
* Linux: Mono 
* Windows: .Net Framework


##Testes
	Descritos do nível mais baixo para o mais alto.

1. Testes de Runtime
	Validam as funcionalidades do núcleo do framework.

1.  Plugins
	Testa diretamente os plugins.

1. Intances
	Verifica se as chamadas aos plugins estao sendo realizadas.

1. Services
	Tenta capturar erros do comportamento dos serviços de infra-estrutura.

1. User code
	Simula o uso do código de usuário.

