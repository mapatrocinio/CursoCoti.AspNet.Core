Acesso a banco de dados com Entity Framework CORE
ORM (Objeto Relational Mapping)
8

1 – Services Layer
Projeto Asp.Net CORE API


Criando os controllers da API:
ENDPOINTS de serviço (endereços)

Instalando o Swagger (Swashbuckle.AspNet Core)
Gerando a documentação dos serviços da API


Startup.cs
Configurando o Swagger para gerar a documentação do projeto API.

2 – Data Layer (Biblioteca de Classes .NET CORE)
Projeto voltado para desenvolvimento da camada de acesso a dados.

Instalando o EntityFramework
O EF deverá ser instalado tanto na camada de acesso a dados do projeto quanto na camada de apresentação (MVC ou API), pois deverá ser configurado na classe Startup.cs
Microsoft.EntityFrameworkCore v.2.1.1

Microsoft.EntityFrameworkCore.SqlServer v.2.1.1

Microsoft.EntityFrameworkCore.Tools v.2.1.1

Microsoft.EntityFrameworkCore.Design v.2.1.1

Modelagem de entidades
Diagrama de Classes

ORM – Object Relational Mapping
Mapeamento Objeto Relacional

/Mappings/EstoqueMapping.cs
Mapeamento da entidade Estoque

/Mappings/ProdutoMapping.cs
Mapeamento da entidade Produto

CONTINUA NA AULA 27

IBaseRepository.cs
Interface genérica para definir os métodos base do repositório.
Exemplo: Inserir, Alterar, Excluir, Consultar, ObterPorId, etc...

Expressões LAMBDA para execução
de consultas no banco de dados
Em EntityFramework podemos utilizar o recurso do LAMBDA para executar consultas na base de dados, substituindo o uso de SQL.
Iremos criar na interface IBaseRepository métodos que possam receber uma expressão lambda e então executar uma consulta na base de dados.


Classe de Contexto com o banco de dados
Trata-se de uma classe responsável por realizar a conexão
com o banco de dados através do EntityFramework.
Esta classe é chamada comumente de: DataContext

Repositório Genérico
Em EF, podemos implementar os métodos Inserir, Excluir, Alterar, Consultar etc de forma genérica, ou seja, de forma que sirvam para qualquer entidade do projeto.


Criando o banco de dados:
Pesquisador de objetos do SQLServer

appsettings.json
Mapeamento da string de conexão do banco de dados.

Adicionando referência no projeto Services para o projeto Data

Startup.cs

Migrations (CodeFirst)
Recurso do EF capaz de modificar a estrutura da base de dados conforme o mapeamento das entidades do projeto (criar tabelas, adicionar campos, modificar tabelas ou campos, etc)
CodeFirst → Define a ideia de que primeiro iremos criar classes de entidade, mapeamentos e depois então o EF gera / cria essas entidades ou campos no banco de dados de forma automática.

Será necessário criarmos uma classe que ficará responsável por executar o serviço de migration. Esta classe irá rodar como um programa local (Main)

Executando o Migrations
Terminal de comandos do NuGet
• Ferramentas / Gerenciador de Pacotes do NuGet / Console do Gerenciador de pacotes

Selecione como projeto padrão o Projeto.Data

Para executar o Migrations também é necessário colocar o Projeto.Data como projeto de inicialização da solution (somente para executar o Migrations)

PM> Add-Migration ProjetoAula27
To undo this action, use Remove-Migration.
PM> Update-Database
Applying migration '20200423003332_ProjetoAula27'.
Done.

CONTINUA NA AULA 28


MODELS
Criando classes de modelo para cadastro e edição de produto e estoque:

Startup.cs
Mapeamento de injeção de dependência para os repositórios de Estoque e Produto. (EstoqueRepository / ProdutoRepository)

/Controllers/EstoqueController.cs

CONTINUA NA AULA 29

Definindo todos os métodos da classe BaseRepository como métodos “virtual”, ou seja, métodos que irão permitir o uso de sobrescrita (OVERRIDE)

AutoMapper
Framework simples utilizado para mapeamento Objeto / Objeto que visa facilitar o processo de transferência de dados entre objetos (por exemplo a transferência dos dados de uma classe model para uma classe de entidade)

Instalando o AutoMapper no projeto Services 9.0.0
Gerenciar pacotes do NuGet

AutoMapper.Extensions.Microsoft.DependencyInjection 7.0.0

Registrando o AutoMapper no projeto .NET CORE
Startup.cs (Classe de inicialização do projeto)

/Mappings
Realizando o mapeamento das classes de Modelo para que possam transferir seus dados para as classes de entidade.

Criando classes de Modelo para retornar dados de consultas:
Neste caso, iremos criar 2 classes novas:
• EstoqueConsultaModel
• ProdutoConsultaModel

Criando uma classe de mapeamento do AutoMapper para mapear a transferência de dados das entidades para as models de consulta.

UnitOfWork
Padrão utilizado em projetos que trabalham com ORM para acesso a banco de dados. A ideia o UnitOfWork é criar uma classe onde possamos executar qualquer operação envolvendo os repositórios por meio de gerenciamento de transações (Commit e Rollback)
Primeiro, iremos criar uma interface chamada IUnitOfWork

CONTINUA AULA 30

UnitOfWork
Padrão utilizado para realizar gerenciamento de transações no projeto através do EntityFramework (Commit e Rollback)
Neste projeto, iremos criar um serviço na API para gravação de estoque e produtos em lote, ou seja, será uma requisição para a API onde o cliente deverá enviar os dados de um estoque e junto uma listagem de produtos.
A API deverá receber essas informações e executar uma transação onde será criado o Estoque e adicionado neste estoque todos os produtos enviados.
Primeiro passo:
Criando um ENDPOINT na API para executar o processo de gravação de estoque e produtos em lote (/api/Lote)

Criando classes de modelo para gravação do lote de produtos:
JSON request

AutoMapper
Fazendo o mapeamento para obter os dados das Models de Lote
e passá-los para as entidades Estoque e Produto.


