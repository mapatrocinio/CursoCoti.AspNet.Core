AULA 31 DDD

DDD – Domain Driven Design
Desenvolvimento Orientado a Domínio
O DDD é conjunto de boas práticas voltado para desenvolvimento de aplicações orientadas a Domínio. É um conceito criado por Eric Evans no livro “Domain-Driven Design” e que tem como objetivo definir um tipo de desenho de aplicação voltado para o domínio de conhecimento do projeto.
O que é o Domínio?
Composto por tudo aquilo que se refere às regras de negócio e conhecimento do projeto. Por exemplo:
• Modelagem de entidades
• Regras de negócio
O objetivo principal do DDD é desenvolver uma arquitetura de sistemas onde possamos ISOLAR o Domínio de todas as demais camadas do projeto.

1 – Presentation Layer
Projeto .NET CORE API

Domain Layer
Camada de domínio, consiste na principal camada do projeto DDD.
Nela estarão contidos o modelo de entidades, regras de negócio do sistema
e o uso dos princípios SOLID para desenvolvimento.

Repositories Contracts
Serão criadas as interfaces que irão definir os métodos a serem implementados na camada de infraestrutura de banco de dados.

Bases (Super Types)
É uma boa prática em DDD sempre criarmos interfaces ou classes genéricas para depois então especializarmos estas interfaces ou classes.

UnitOfWork
Iremos criar uma interface para definir como deverá ser implementado no repositório o padrão UnitOfWork (gerenciamento de transações para todos os repositórios).

Instalando o EntityFramework
Gerenciador de pacotes do Nuget
Microsoft.EntityFrameworkCore v.2.1.11

Microsoft.EntityFrameworkCore.SqlServer v.2.1.11

Microsoft.EntityFrameworkCore.Tools v.2.1.11

Microsoft.EntityFrameworkCore.Design v.2.1.11

InfraStructure Layer
Criando a camada de acesso a banco de dados implementando os contratos de repositório definidos pela camada de domínio.

ORM – Object Relational Mapping
Mapeamento Objeto Relacional
Mapear cada classe Domain Entity para que possa ser criado e interpretado como uma tabela do banco de dados (Migrations)
** Adicionar referência no projeto Infra.Data para o projeto Domain

DataContext
Classe para configurar o acesso ao banco de dados através do EntityFramework.

Implementando os contratos de repositório definidos no domínio:

Repositories
Implementando as classes de repositório de banco de dados baseado nos contratos de interfaces criados na camada de domínio.

CONTINUA AULA 32

Criando uma base de dados:

** Adicionando referência no projeto Presentation
para o projeto InfraStructure.Data

Startup.cs
Configurando o EntityFramework e fazer a
injeção de dependência da connectionstring.

CodeFirst Migrations
Recurso do EntityFramework para interpretar os mapeamentos das
entidades e atualizar a estrutura de tabelas do banco de dados conforme o

Para executarmos o Migrations é necessário criarmos uma classe
que “rode” o CodeFirst e atualize a estrutura do banco de dados.

Executando o Migrations
/ Ferramentas / Gerenciador de pacotes do NuGet
/ Console do gerenciador de pacotes

gerenciador de pacotes
Selecione o projeto Infra.Data

Add-Migration ProjetoDDD

Update-Database

Domain Services
Classes que serão desenvolvidas na camada de domínio com o objetivo de implementar as regras de negócio do projeto.

Linguagem Ubíqua
Em DDD, os nomes dos métodos, serviços destinados a implementar as regras de negócio do sistema devem ser os mesmos usados pelos usuários / stakeholders do projeto. Ou seja, é importante evitarmos aqui o uso de nomenclaturas que não sejam as utilizadas no mundo real do usuário.

Primeiro passo:
Criando interfaces para definir os contratos das regras de negócio:

Criando interfaces de negócio especificas para cada entidade de domínio:

Implementando as interfaces:
/Services/BaseDomainService.cs
Programando as regras de negócio do sistema de forma genérica.

Application
Trata-se de uma camada que irá fazer a junção do Domínio com a camada de Apresentação.

** Precisamos adicionar na Application referencia para a camada Domain

CONTINUA AULA 33


DDD – Domain Driven Design
Arquitetura orientada a domínio
Application Layer
Camada entre o domínio e a apresentação. Tem como objetivo disponibilizar os serviços da camada de domínio para que sejam acessados pela camada de apresentação.


/Application/Mappings
Criar os mapeamentos do AutoMapper
EntityToModelMapping (Consultas / Saída de dados)
• Plano → PlanoConsultaModel
• Cliente → ClienteConsultaModel
ModelToEntityMapping (Cadastro, Edição / Entrada de dados)
• PlanoCadastroModel → Plano
• PlanoEdicaoModel → Plano
• ClienteCadastroModel → Cliente
• ClienteEdicaoModel → Cliente

Instalando o AutoMapper (v.8.1.0)

Application Services
Serviços da camada de aplicação.
Classes que irão disponibilizar as regras de negócio do Domínio para a camada de apresentação, por meio de Serviços de aplicação.
Primeiro, iremos criar os contratos (interfaces):

Implementando as interfaces:

Para que possamos fazer com que o AutoMapper funcione na camada de apresentação, precisamos criar a classe abaixo:
Esta classe será registrada no Startup.cs
Classe de configuração do AutoMapper

/Mappings/AutoMapperConfig.cs

Adicionando referência no projeto Presentation para os demais:

Instalando o Swagger:
Documentação da API
Swashbuckle.aspnetcore

Modificando a página inicial do projeto para: swagger

Startup.cs
• Configuração do EntityFramework
• Configuração do AutoMapper
• Configuração do Swagger
• Mapeamento da injeção de dependência








