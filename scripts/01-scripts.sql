create database AluraFlix;

use AluraFlix;


CREATE TABLE Video (
    Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    Titulo NVARCHAR(255),
    Descricao TEXT,
    URL_Video NVARCHAR(255) NOT NULL,
);