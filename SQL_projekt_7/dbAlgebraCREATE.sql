CREATE DATABASE dbAlgebra
GO

USE dbAlgebra
GO 

CREATE TABLE tblDrzave
(
	IdDrzave INT PRIMARY KEY
				IDENTITY (1 , 1),
	Naziv VARCHAR(50) NOT NULL
)

CREATE TABLE tblGradovi
(
	IdGrada INT PRIMARY KEY
				IDENTITY (1 , 1),
	Naziv VARCHAR(50) NOT NULL,
	IdDrzave INT FOREIGN KEY  
				REFERENCES tblDrzave(IdDrzave)
)

CREATE TABLE tblTecajevi
(
	IdTecaj INT PRIMARY KEY
				IDENTITY (1 , 1),
	Naziv VARCHAR(50) NOT NULL,
	Opis VARCHAR(50) NOT NULL
)

CREATE TABLE tblPolaznici
(
	IdPolaznik INT PRIMARY KEY
					IDENTITY (1 , 1),
	Ime VARCHAR(50) NOT NULL,
	Prezime VARCHAR(50) NOT NULL,
	Email VARCHAR(50) NOT NULL,
	IdGrada INT FOREIGN KEY
				REFERENCES tblGradovi(IdGrada)
)

CREATE TABLE tblUpisi
(
	IdUpisi INT PRIMARY KEY
				IDENTITY(1 ,1 ),
	DatumUpisa DATETIME NOT NULL,
	IdTecaj INT FOREIGN KEY
				REFERENCES tblTecajevi(IdTecaj),
	IdPolaznik INT FOREIGN KEY 
				REFERENCES tblPolaznici(IdPolaznik)		
)
