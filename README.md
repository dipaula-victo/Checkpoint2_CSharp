# Checkpoint2_CSharp


### Sistema de Controle de Estoque 
Esta aplicação foi desenvolvida para o gerenciamento de inventário de produtos, utilizando uma arquitetura distribuída em camadas.

### Principais Funcionalidades
Gerenciamento de Produtos (CRUD): Permite a inclusão, listagem, atualização e exclusão de itens no banco de dados.

Interface Dinâmica: UI customizada com tema escuro e identidade visual institucional.

Filtragem de Dados: Sistema de busca por nome com atualização em tempo real do grid de resultados.

Persistência Relacional: Integração com SQL Server para armazenamento seguro e consistente das informações.

Validação e Tratamento de Erros: Mecanismos de captura de exceções para garantir a estabilidade durante falhas de conexão ou entrada de dados inválidos.

### Como Executar a Aplicação
1. Configuração do Banco de Dados
O sistema requer uma instância do Microsoft SQL Server. Para criar a estrutura necessária, execute o seguinte script, respeitando o padrão de nomenclatura obrigatório:

```
CREATE DATABASE DB_PrimeiroNomeDeUmAluno_RM_123456;
GO

USE DB_PrimeiroNomeDeUmAluno_RM_123456;
GO

CREATE TABLE Produto (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Preco DECIMAL(10,2) NOT NULL,
    Quantidade INT NOT NULL,
    Ativo BIT NOT NULL DEFAULT 1
);
```
2. Configuração do Ambiente
No Visual Studio, localize o arquivo App.config dentro do projeto Fiap.Estoque.UI.

Ajuste a connectionString para o seu servidor.
```
<connectionStrings>
    <add name="EstoqueDb" 
         connectionString="Data Source=NOME_DO_SERVIDOR;Initial Catalog=DB_PrimeiroNomeDeUmAluno_RM_123456;Integrated Security=True;TrustServerCertificate=True" 
         providerName="System.Data.SqlClient" />
</connectionStrings>
```
3. Execução
Abra a solução Fiap.Estoque.sln no Visual Studio 2022.

Defina o projeto Fiap.Estoque.UI como Startup Project.

Compile e execute o projeto pressionando F5.

### Observações Adicionais
Arquitetura: O projeto está segmentado em camadas de Modelo (Model), Contratos (Contracts), Acesso a Dados (DAL), Lógica de Negócio (BLL) e Interface de Usuário (UI).

Dependências: Certifique-se de que o provedor System.Data.SqlClient esteja instalado via Gerenciador de Pacotes NuGet.

Versionamento: O repositório conta com um arquivo .gitignore otimizado para omitir arquivos binários (bin/, obj/) e configurações locais do Visual Studio (.vs/), mantendo apenas o código-fonte necessário para a construção do projeto.
