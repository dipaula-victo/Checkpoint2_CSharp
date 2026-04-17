-- =========================================================
-- Fiap.Estoque - Base semipronta para laboratório
-- SQL Server
-- =========================================================

IF DB_ID('FiapEstoqueDb') IS NULL
BEGIN
    CREATE DATABASE FiapEstoqueDb;
END
GO

USE FiapEstoqueDb;
GO

IF OBJECT_ID('dbo.Produto', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.Produto;
END
GO

CREATE TABLE dbo.Produto
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome NVARCHAR(150) NOT NULL,
    Preco DECIMAL(10,2) NOT NULL,
    Quantidade INT NOT NULL,
    Ativo BIT NOT NULL CONSTRAINT DF_Produto_Ativo DEFAULT(1),
    DataCadastro DATETIME NOT NULL CONSTRAINT DF_Produto_DataCadastro DEFAULT(GETDATE())
);
GO

IF OBJECT_ID('dbo.vw_Produto_Resumo', 'V') IS NOT NULL
BEGIN
    DROP VIEW dbo.vw_Produto_Resumo;
END
GO

CREATE VIEW dbo.vw_Produto_Resumo
AS
SELECT
    p.Id,
    p.Nome,
    p.Preco,
    p.Quantidade,
    CASE
        WHEN p.Quantidade < 5 THEN 'Estoque Baixo'
        ELSE 'OK'
    END AS StatusEstoque,
    p.DataCadastro
FROM dbo.Produto p
WHERE p.Ativo = 1;
GO

IF OBJECT_ID('dbo.sp_Produto_Inserir', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.sp_Produto_Inserir;
END
GO

CREATE PROCEDURE dbo.sp_Produto_Inserir
    @Nome NVARCHAR(150),
    @Preco DECIMAL(10,2),
    @Quantidade INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.Produto (Nome, Preco, Quantidade)
    VALUES (@Nome, @Preco, @Quantidade);
END
GO

IF OBJECT_ID('dbo.sp_Produto_Listar', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.sp_Produto_Listar;
END
GO

CREATE PROCEDURE dbo.sp_Produto_Listar
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        Id,
        Nome,
        Preco,
        Quantidade,
        StatusEstoque,
        DataCadastro
    FROM dbo.vw_Produto_Resumo
    ORDER BY Nome;
END
GO

IF OBJECT_ID('dbo.sp_Produto_BuscarPorNome', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.sp_Produto_BuscarPorNome;
END
GO

CREATE PROCEDURE dbo.sp_Produto_BuscarPorNome
    @Nome NVARCHAR(150)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        Id,
        Nome,
        Preco,
        Quantidade,
        StatusEstoque,
        DataCadastro
    FROM dbo.vw_Produto_Resumo
    WHERE Nome LIKE '%' + @Nome + '%'
    ORDER BY Nome;
END
GO

-- Procedure opcional para a próxima aula
IF OBJECT_ID('dbo.sp_Produto_AtualizarEstoque', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.sp_Produto_AtualizarEstoque;
END
GO

CREATE PROCEDURE dbo.sp_Produto_AtualizarEstoque
    @Id INT,
    @Quantidade INT,
    @Tipo CHAR(1) -- E = Entrada, S = Saída
AS
BEGIN
    SET NOCOUNT ON;

    IF @Tipo = 'E'
    BEGIN
        UPDATE dbo.Produto
        SET Quantidade = Quantidade + @Quantidade
        WHERE Id = @Id;
    END
    ELSE IF @Tipo = 'S'
    BEGIN
        UPDATE dbo.Produto
        SET Quantidade = Quantidade - @Quantidade
        WHERE Id = @Id
          AND Quantidade >= @Quantidade;
    END
END
GO
