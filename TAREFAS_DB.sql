CREATE DATABASE ListaDeTarefas
GO
USE ListaDeTarefas
GO

CREATE TABLE Tarefa (
    Id INT PRIMARY KEY IDENTITY,
    Descricao VARCHAR(255) NOT NULL
);

INSERT INTO Tarefa ('Limpar o quarto')
INSERT INTO Tarefa ('Passear com o dog')