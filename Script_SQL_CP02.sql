IF DB_ID('DB_Djalma_RM_555530') IS NULL
BEGIN
    CREATE DATABASE DB_Djalma_RM_555530;
END
GO

USE DB_Djalma_RM_555530;
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
    p.Ativo,
    CASE
        WHEN p.Quantidade = 0 THEN 'Sem estoque'
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
        Ativo,
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
        Ativo,
        StatusEstoque,
        DataCadastro
    FROM dbo.vw_Produto_Resumo
    WHERE Nome LIKE '%' + @Nome + '%'
    ORDER BY Nome;
END
GO

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
        IF EXISTS (SELECT 1 FROM dbo.Produto WHERE Id = @Id AND Quantidade >= @Quantidade)
        BEGIN
            UPDATE dbo.Produto
            SET Quantidade = Quantidade - @Quantidade
            WHERE Id = @Id;
        END
        ELSE
        BEGIN
            THROW 50001, 'Saída inválida: estoque insuficiente ou produto inexistente.', 1;
        END
    END
END
GO

IF OBJECT_ID('dbo.sp_Produto_Remover', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.sp_Produto_Remover;
END
GO

CREATE PROCEDURE dbo.sp_Produto_Remover
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    
    DELETE FROM dbo.Produto
    WHERE Id = @Id;
END
GO

INSERT INTO dbo.Produto (Nome, Preco, Quantidade, Ativo)
VALUES
('Notebook', 3500.00, 7, 1),
('Mouse Gamer', 180.00, 12, 1),
('Teclado Mecânico', 420.00, 4, 1),
('Monitor 24', 980.00, 2, 1);
GO

EXEC dbo.sp_Produto_Listar;
GO