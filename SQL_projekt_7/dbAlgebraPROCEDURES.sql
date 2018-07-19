CREATE PROC DohvatiPolaznike 
AS
SELECT * FROM tblPolaznici
GO;

CREATE PROC DohvatiPolaznika @IdPolaznika INT
AS
SELECT * FROM tblPolaznici WHERE IdPolaznik = @IdPolaznika
GO;

CREATE PROC KreirajPolaznika @Ime VARCHAR(50), @Prezime VARCHAR(50), @Email NVARCHAR(50)
AS
INSERT INTO tblPolaznici  VALUES (@Ime , @Prezime, @Email, NULL)
SELECT SCOPE_IDENTITY()
GO;

CREATE PROC IzbrisiPolaznika @IdPolaznika INT 
AS
DELETE FROM tblUpisi WHERE IdPolaznik = @IdPolaznika
DELETE FROM tblPolaznici WHERE IdPolaznik = @IdPolaznika
GO;

CREATE PROC UrediPolaznika @IdPolaznika INT, @Ime VARCHAR(50), @Prezime VARCHAR(50), @Email NVARCHAR(50)
AS
UPDATE  tblPolaznici  SET Ime=@Ime , Prezime=@Prezime, Email=@Email, IdGrada = null 
WHERE IdPolaznik = @IdPolaznika
GO;

CREATE PROC DohvatiTecajeve
AS
SELECT * FROM tblTecajevi
GO;

CREATE PROC DohvatiTecaj @IdTecaj INT
AS
SELECT * FROM tblTecajevi WHERE IdTecaj = @IdTecaj
GO;

CREATE PROC KreirajTecaj @Naziv VARCHAR(50), @Opis VARCHAR(50)
AS 
INSERT INTO tblTecajevi VALUES (@Naziv , @Opis)
GO;

CREATE PROC IzbrisiTecaj @IdTecaj INT 
AS
DELETE FROM tblUpisi WHERE IdTecaj = @IdTecaj
DELETE FROM tblTecajevi WHERE IdTecaj = @IdTecaj
GO;

CREATE PROC UrediTecaj @IdTecaj INT, @Naziv VARCHAR(50), @Opis VARCHAR(50)
AS
UPDATE tblTecajevi SET Naziv=@Naziv, Opis=@Opis
WHERE IdTecaj=@IdTecaj
GO;

CREATE PROC KreirajUpis @IdTecaj INT, @IdPolaznik INT, @DatumUpisa DATE 
AS 
INSERT INTO tblUpisi VALUES (@DatumUpisa,@IdTecaj,@IdPolaznik)
GO;

CREATE PROC UpisiMasterDetails 
AS
SELECT u.DatumUpisa, p.Ime, p.Prezime, p.Email, t.Naziv, t.Opis
FROM tblUpisi AS u
INNER JOIN tblPolaznici as p ON u.IdPolaznik = p.IdPolaznik
INNER JOIN tblTecajevi as t ON u.IdTecaj = t.IdTecaj
GO;