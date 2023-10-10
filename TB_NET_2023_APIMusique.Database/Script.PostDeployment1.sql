/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
INSERT INTO GENRE([NAME])
VALUES('Rap'),
      ('Rock'),
      ('Pop')

INSERT INTO TRACK([NAME],[DURATION],[GENRE_ID])
VALUES('Porteur saint',100,1),
      ('Beleiver',100,2),
      ('Moi non plus',100,3)

INSERT INTO ARTIST([NAME],[BIRTH_DATE],[DEATH_DATE])
VALUES ('Medine','1991-03-27',null),
       ('Imagine Dragon','1991-03-27',null),
       ('C''etait un appel à l''aide','1991-03-27',null)

INSERT INTO TRACK_ARTIST
VALUES (1,1,0),
       (2,2,0),
       (2,3,1),
       (3,3,0)