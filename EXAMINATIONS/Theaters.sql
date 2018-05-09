CREATE TABLE Cinemas
(
	id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	name VARCHAR(64),
	columns INT,
	rows INT
);

CREATE TABLE Genres
(
	id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	name VARCHAR(64)
);

CREATE TABLE Films
(
	id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	name VARCHAR(64),
	id_genre INT FOREIGN KEY REFERENCES Genres (id) ON UPDATE NO ACTION ON DELETE NO ACTION,
	duration INT
);

CREATE TABLE Sessions
(
	id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	id_film INT FOREIGN KEY REFERENCES Films (id) ON UPDATE NO ACTION ON DELETE NO ACTION,
	id_cinema INT FOREIGN KEY REFERENCES Cinemas (id) ON UPDATE NO ACTION ON DELETE NO ACTION,
	date DATE,
	time TIME,
	is_cancelled BIT DEFAULT 0
);

CREATE TABLE Users
(
	id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	login VARCHAR(256) UNIQUE,
	password VARCHAR(256),
	email VARCHAR(256),
	phone VARCHAR(24),
	is_admin BIT DEFAULT 0
);

CREATE TABLE Tickets
(
	id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	id_session INT FOREIGN KEY REFERENCES Sessions (id) ON UPDATE NO ACTION ON DELETE NO ACTION,
	id_user INT FOREIGN KEY REFERENCES Users (id) ON UPDATE NO ACTION ON DELETE NO ACTION,
	row INT,
	col INT,
	email VARCHAR(256),
	phone VARCHAR(24),
	unique_id VARCHAR(256),
	is_updated BIT DEFAULT 0
);

GO

CREATE TRIGGER onDeleteSession
ON Sessions
INSTEAD OF DELETE
AS
BEGIN
	DECLARE @i BIT;
	DECLARE @id INT;
	SELECT @id = id, @i = is_cancelled FROM DELETED;
	IF @i = 0
	BEGIN
		UPDATE Sessions SET is_cancelled = 1 WHERE id = @id;
	END
	ELSE
	BEGIN
		DELETE FROM Tickets WHERE id_session = @id;
		DELETE FROM Sessions WHERE id = @id;
	END
END

GO

INSERT INTO Genres(name) VALUES('Боевик');
INSERT INTO Genres(name) VALUES('Вестерн');
INSERT INTO Genres(name) VALUES('Детектив');
INSERT INTO Genres(name) VALUES('Драма');
INSERT INTO Genres(name) VALUES('Исторический');
INSERT INTO Genres(name) VALUES('Комедия');
INSERT INTO Genres(name) VALUES('Мелодрама');
INSERT INTO Genres(name) VALUES('Приключения');
INSERT INTO Genres(name) VALUES('Триллер');
INSERT INTO Genres(name) VALUES('Ужасы');
INSERT INTO Genres(name) VALUES('Фантастика');
insert into genres (name) VALUES ('asdasd');
insert into films (name, id_genre, duration) values ('Фильм 1', 1, 120);
insert into films (name, id_genre, duration) values ('Фильм 2', 1, 120);
insert into films (name, id_genre, duration) values ('Фильм 3', 1, 120);
insert into Cinemas (name, columns, rows) values ('Довженко', 5, 7);
INSERT INTO Cinemas(name, rows, columns) VALUES('Киев', 10, 8);
INSERT INTO Cinemas(name, rows, columns) VALUES('Флоренция', 9, 8);
INSERT INTO Cinemas(name, rows, columns) VALUES('Кинотеатр Старт', 12, 10);
INSERT INTO Cinemas(name, rows, columns) VALUES('Кинотеатр Лейпциг', 10, 8);
INSERT INTO Cinemas(name, rows, columns) VALUES('Супутник', 15, 10);
insert into Sessions (id_film, id_cinema, date, time, is_cancelled) values (1, 1, convert(datetime, '22.02.2018', 104), convert(datetime, '15:33', 104), 0)
insert into Sessions (id_film, id_cinema, date, time, is_cancelled) values (2, 1, convert(datetime, '23.02.2018', 104), convert(datetime, '15:33', 104), 0)
insert into Sessions (id_film, id_cinema, date, time, is_cancelled) values (3, 1, convert(datetime, '26.02.2018', 104), convert(datetime, '15:33', 104), 0)
insert into Users (login , password, is_admin, email, phone) values ('vovastrigh', '4D451AE63AA5C33E81E7A70C9A11AA66', 1, 'vova_strigh@list.ru', '+380664529582')
insert into Tickets (id_session, id_user, row, col) values (1, NULL, 1, 1)

drop table Tickets
drop table Sessions
drop table Cinemas
drop table Users
drop table Films
drop table Genres

drop trigger onDeleteSession

delete from films
delete from sessions where id = 2
delete from tickets
delete from users

select * from films
select * from cinemas
select * from users
select * from sessions
select * from tickets
UPDATE Tickets SET id_user = 4 WHERE (email = 'vova_strigh@list.ru' OR phone = '+380664529582') AND id_user IS NULL
SELECT Films.id, Films.name, Genres.name, Films.duration FROM Films, Genres WHERE Films.id_genre = Genres.id
UPDATE Tickets SET id_user = 4 WHERE email = 'vova_strigh@list.ru' OR phone = '+38 (066) 452-95-82' AND id_user IS NULL;
SELECT Sessions.id, Films.name, Genres.name, Cinemas.name, date, time, Films.duration, Cinemas.Rows, Cinemas.Columns  FROM Sessions, Films, Cinemas, Genres
WHERE Films.id = Sessions.id_film AND Genres.id = Films.id_genre AND Cinemas.id = Sessions.id_cinema AND Sessions.id = 1

UPDATE Cinemas SET rows = 5, columns = 10 WHERE id = 1

UPDATE Users SET password = '4D451AE63AA5C33E81E7A70C9A11AA66' WHERE id = 4

UPDATE Tickets SET row = 1, col = 1 WHERE id = 1

SELECT * FROM Tickets WHERE id_session = 1;

delete from sessions where id = 4;

SELECT Sessions.id, Films.name, Genres.name, Cinemas.name, Sessions.date, Sessions.time FROM Sessions, Films, Genres, Cinemas WHERE Session.id_film = Films.id, Films.id_genre = Genres.id, Session.id_cinema = Cinemas.id

SELECT Sessions.time FROM Sessions WHERE Sessions.id_cinema = 2 AND Sessions.id_film = 1 AND Sessions.date = convert(datetime, '26.02.2018', 104)

SELECT * FROM Sessions WHERE (Session.id = 0)

SELECT Sessions.id, Films.name, Genres.name, Cinemas.name, Sessions.date, Sessions.time FROM Sessions, Films, Genres, Cinemas WHERE Sessions.id_film = Films.id, Films.id_genre = Genres.id, Sessions.id_cinema = Cinemas.id