# Checkpoint2_CSharp
---
### Integrantes 

👤 Djalma Moreira de Andrade Filho

👤 Felipe Paes de Barros Muller Carioba

👤 Lucas Rodrigues de Queiroz

👤 Otavio Santos de Lima Ferrao

👤 Victor Hugo de Paula

---

### Sistema de Controle de Estoque 
Esta aplicação foi desenvolvida para o gerenciamento de inventário de produtos, utilizando uma arquitetura distribuída em camadas.

---
 
## Tecnologias Utilizadas
 
- **C#** — Linguagem principal da aplicação
- **Windows Forms** — Framework para a interface desktop
- **.NET Framework** — Plataforma de execução
- **SQL Server** — Banco de dados relacional
- **System.Data.SqlClient** — Provedor ADO.NET para conexão com o SQL Server
- **Visual Studio 2022** — IDE de desenvolvimento

---

### Principais Funcionalidades
Gerenciamento de Produtos (CRUD): Permite a inclusão, listagem, atualização e exclusão de itens no banco de dados.

Interface Dinâmica: UI customizada com tema escuro e identidade visual institucional.

Filtragem de Dados: Sistema de busca por nome com atualização em tempo real do grid de resultados.

Persistência Relacional: Integração com SQL Server para armazenamento seguro e consistente das informações.

Validação e Tratamento de Erros: Mecanismos de captura de exceções para garantir a estabilidade durante falhas de conexão ou entrada de dados inválidos.

---

### Como Executar a Aplicação
1. Configuração do Banco de Dados

O sistema requer uma instância do Microsoft SQL Server. Para criar a estrutura necessária, abra o arquivo "Script_SQL_CP02.sql" no seu SQL Server Management Studio 20, após isso execute a query para criar a estrutura do banco de dados.

2. Configuração do Ambiente

No Visual Studio, localize o arquivo App.config dentro do projeto Fiap.Estoque.UI.

Ajuste a connectionString para o seu servidor.
```
	<connectionStrings>
		<add name="EstoqueDb"
			 connectionString="Server=NOME_DO_SERVIDOR;Database=DB_Djalma_RM_555530;Trusted_Connection=True;TrustServerCertificate=True;"
			 providerName="System.Data.SqlClient" />
	</connectionStrings>
```
3. Execução

Abra a solução Fiap.Estoque.sln no Visual Studio 2022.

Defina o projeto Fiap.Estoque.UI como Startup Project.

Compile e execute o projeto pressionando F5.

---

### Observações Adicionais

Arquitetura: O projeto está segmentado em camadas de Modelo (Model), Contratos (Contracts), Acesso a Dados (DAL), Lógica de Negócio (BLL) e Interface de Usuário (UI).

Dependências: Certifique-se de que o provedor System.Data.SqlClient esteja instalado via Gerenciador de Pacotes NuGet.

Versionamento: O repositório conta com um arquivo .gitignore otimizado para omitir arquivos binários (bin/, obj/) e configurações locais do Visual Studio (.vs/), mantendo apenas o código-fonte necessário para a construção do projeto.
