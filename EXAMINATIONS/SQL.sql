------------------------- ������� -------------------------
CREATE TABLE Players
(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Firstname VARCHAR(64),
	Lastname VARCHAR (64),
	Id_Position INT FOREIGN KEY
		REFERENCES Roles (Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	Id_Team INT FOREIGN KEY
		REFERENCES Teams (Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);

INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('�����', '�����', 1, 1);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('�������', '������', 3, 1);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('����������', '������', 1, 1);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('��������', '��-�����', 1, 1);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('����', '������', 4, 1);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('�������', '��������', 2, 1);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('����', '��������', 2, 1);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('����', '�����', 1, 1);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('�����', '�����', 4, 1);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('��������', '���-�������', 1, 1);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('�����', '��-�������', 2, 1);

INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('�����', '���-������', 3, 2);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('������', '����', 4, 2);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('������', '�������', 2, 2);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('����', '���-������', 1, 2);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('������', '���', 2, 2);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('�����', '���-������', 4, 2);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('�������', '����', 1, 2);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('������', '�������', 1, 2);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('�����', '�������', 2, 2);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('���', '����', 1, 2);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('������', '�����', 4, 2);
	
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('������', '��������', 2, 3);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('����', '������', 3, 3);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('�����', '�� ������', 4, 3);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('�����', '�������', 4, 3);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('���������', '�������', 1, 3);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('������', '�������', 1, 3);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('�����', '�����', 1, 3);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('�������', '�������', 1, 3);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('�����', '���', 4, 3);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('������', '�������', 2, 3);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('��������', '������', 2, 3);

INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('������', '��������', 1, 4);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('��������', '�������', 1, 4);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('�����', '�������', 1, 4);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('�����', '�������', 2, 4);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('������', '�������', 4, 4);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('�������', '���������', 4, 4);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('����', '', 2, 4);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('������', '�����', 1, 4);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('�����', '�����', 2, 4);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('�������', '������', 3, 4);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('��������', '�����', 4, 4);
	
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('������', '���������', 4, 5);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('�����', '������', 1, 5);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('�����', '������', 2, 5);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('��������', '���������', 3, 5);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('����', '����', 2, 5);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('������', '�����', 1, 5);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('�����', '������', 4, 5);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('������', '����', 1, 5);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('�������', '�������', 2, 5);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('���', '��������', 4, 5);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('�������', '����', 1, 5);
	
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('��������', '�����', 4, 6);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('���', '̸� ��', 4, 6);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('�����', '���������', 4, 6);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('�����', '���', 3, 6);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('�����', '����������', 2, 6);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('���', '��� ���', 2, 6);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('�����', '�����', 2, 6);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('�������', '�������', 1, 6);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('��������', '���������', 1, 6);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('������', '����', 1, 6);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('������', '���������', 1, 6);

INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('���', '�����', 2, 7);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('�����', '����', 2, 7);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('����� �������', '', 1, 7);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('����', '', 4, 7);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('������', '�������', 3, 7);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('�������', '�����', 2, 7);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('��', '�� ���', 1, 7);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('���', '��������', 4, 7);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('�����', '������', 2, 7);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('��������', '������', 1, 7);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('�����', '�������', 1, 7);

INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('�����', '����', 1, 8);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('�������', '��������', 2, 8);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('������', '����', 4, 8);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('����', '������', 1, 8);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('�����', '���������', 1, 8);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('�����', '��������', 3, 8);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('����', '������', 2, 8);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('�����', '�������', 1, 8);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('�������', '�������', 1, 8);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('����', '����', 4, 8);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('�����', '��������', 2, 8);

CREATE TABLE Teams
(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Name VARCHAR(64),
	Id_Coach INT FOREIGN KEY
		REFERENCES Coachs (Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	Id_Stadium INT FOREIGN KEY
		REFERENCES Stadiums (Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
);

INSERT INTO Teams (name, id_coach, id_stadium) VALUES('���������', 1, 1);
INSERT INTO Teams (name, id_coach, id_stadium) VALUES('���� ������', 2, 2);
INSERT INTO Teams (name, id_coach, id_stadium) VALUES('��������� �������', 3, 3);
INSERT INTO Teams (name, id_coach, id_stadium) VALUES('�������', 4, 4);
INSERT INTO Teams (name, id_coach, id_stadium) VALUES('�������', 5, 5);
INSERT INTO Teams (name, id_coach, id_stadium) VALUES('�����������', 6, 6);
INSERT INTO Teams (name, id_coach, id_stadium) VALUES('�����', 7, 7);
INSERT INTO Teams (name, id_coach, id_stadium) VALUES('���������', 8, 8);

CREATE TABLE Stadiums
(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Name VARCHAR(64),
	City VARCHAR(64)
);

INSERT INTO Stadiums (Name, City) VALUES ('���������', '������');
INSERT INTO Stadiums (Name, City) VALUES ('���� �����������', '������-�����');
INSERT INTO Stadiums (Name, City) VALUES ('��������� ����������', '�������');
INSERT INTO Stadiums (Name, City) VALUES ('���� ��������', '�������');
INSERT INTO Stadiums (Name, City) VALUES ('����������� �������', '��������');
INSERT INTO Stadiums (Name, City) VALUES ('���������� �������', '������');
INSERT INTO Stadiums (Name, City) VALUES ('�����', '������');
INSERT INTO Stadiums (Name, City) VALUES ('���������', '�����������');

CREATE TABLE Games
(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Id_HomeTeam INT FOREIGN KEY
		REFERENCES Teams (Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	Id_GuestTeam INT FOREIGN KEY
		REFERENCES Teams (Id)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	Id_Stadium INT FOREIGN KEY
		REFERENCES Stadiums (Id)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	Id_Tour INT FOREIGN KEY
		REFERENCES Tours (Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);

INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (1, 8, 1, 1);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (2, 7, 2, 1);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (3, 6, 3, 1);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (4, 5, 4, 1);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (1, 7, 1, 2);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (2, 6, 2, 2);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (3, 5, 3, 2);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (4, 8, 4, 2);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (1, 6, 1, 3);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (2, 5, 2, 3);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (3, 8, 3, 3);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (4, 7, 4, 3);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (1, 5, 1, 4);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (2, 8, 2, 4);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (3, 7, 3, 4);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (4, 6, 4, 4);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (1, 4, 1, 5);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (2, 3, 2, 5);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (5, 8, 5, 5);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (6, 7, 6, 5);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (1, 3, 1, 6);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (2, 4, 2, 6);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (5, 7, 5, 6);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (6, 8, 6, 6);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (1, 2, 1, 7);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (3, 4, 3, 7);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (5, 6, 5, 7);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (7, 8, 7, 7);

INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (8, 1, 8, 8);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (7, 2, 7, 8);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (6, 3, 6, 8);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (5, 4, 5, 8);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (7, 1, 7, 9);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (6, 2, 6, 9);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (5, 3, 5, 9);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (8, 4, 8, 9);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (6, 1, 6, 10);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (5, 2, 5, 10);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (8, 3, 8, 10);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (7, 4, 7, 10);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (5, 1, 5, 11);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (8, 2, 8, 11);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (7, 3, 7, 11);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (6, 4, 6, 11);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (4, 1, 4, 12);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (3, 2, 3, 12);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (8, 5, 8, 12);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (7, 6, 7, 12);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (3, 1, 3, 13);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (4, 2, 4, 13);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (7, 5, 7, 13);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (8, 6, 8, 13);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (2, 1, 2, 14);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (4, 3, 4, 14);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (6, 5, 6, 14);
INSERT INTO Games (Id_HomeTeam, Id_GuestTeam, Id_Stadium, Id_Tour) VALUES (8, 7, 8, 14);




CREATE TABLE Tours
(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Name VARCHAR(64)
);

INSERT INTO Tours (Name) VALUES('��� 1');
INSERT INTO Tours (Name) VALUES('��� 2');
INSERT INTO Tours (Name) VALUES('��� 3');
INSERT INTO Tours (Name) VALUES('��� 4');
INSERT INTO Tours (Name) VALUES('��� 5');
INSERT INTO Tours (Name) VALUES('��� 6');
INSERT INTO Tours (Name) VALUES('��� 7');
INSERT INTO Tours (Name) VALUES('��� 8');
INSERT INTO Tours (Name) VALUES('��� 9');
INSERT INTO Tours (Name) VALUES('��� 10');
INSERT INTO Tours (Name) VALUES('��� 11');
INSERT INTO Tours (Name) VALUES('��� 12');
INSERT INTO Tours (Name) VALUES('��� 13');
INSERT INTO Tours (Name) VALUES('��� 14');

CREATE TABLE Coachs
(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Firstname VARCHAR(64),
	Lastname VARCHAR(64)
);

INSERT INTO Coachs (Firstname, Lastname) VALUES('����', '��������');
INSERT INTO Coachs (Firstname, Lastname) VALUES('�������', '�����');
INSERT INTO Coachs (Firstname, Lastname) VALUES('�����', '�����');
INSERT INTO Coachs (Firstname, Lastname) VALUES('�������', '������');
INSERT INTO Coachs (Firstname, Lastname) VALUES('������', '�������');
INSERT INTO Coachs (Firstname, Lastname) VALUES('���', '���������');
INSERT INTO Coachs (Firstname, Lastname) VALUES('�����', '��������');
INSERT INTO Coachs (Firstname, Lastname) VALUES('�����', '������');

CREATE TABLE Roles
(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Name VARCHAR(64)
);

INSERT INTO Roles (name) VALUES('����������');
INSERT INTO Roles (name) VALUES('������������');
INSERT INTO Roles (name) VALUES('��������');
INSERT INTO Roles (name) VALUES('�������');

CREATE TABLE Goals
(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Id_Game INT FOREIGN KEY
		REFERENCES Games (Id)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	Id_Player INT FOREIGN KEY
		REFERENCES Players (Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);

DECLARE @randGame int;
SELECT @randGame = RAND()*(56-1)+1;

DECLARE @randPlayer int;
SELECT @randPlayer = RAND()*(11-1)+1;


DECLARE @player_id int;
SELECT @player_id = Players.Id
FROM Players, Teams, Games
WHERE Teams.Id = Games.Id_GuestTeam
	AND Games.Id = @randGame
	AND Players.Id_Team = Teams.Id
	AND Players.Id = Teams.Id * 11 - @randPlayer

	PRINT STR(@player_id)

INSERT INTO Goals (id_game, id_player) VALUES(@randGame,@player_id);

select * from goals
select Players.Firstname
from goals, Games, players
where goals.id_game = Games.id
	and Games.Id_HomeTeam = players.id_team
	and goals.Id_Player = players.id

	select * from goals
-------------------- ����� ���������� --------------------
GO
-- ���������� ���������� ������� (�����������) �������� �����
alter FUNCTION GetTeamGoals
(
	@teamname varchar(64)
)
RETURNS @res table
(
	team varchar(64),
	pos int,
	neg int
)
AS
BEGIN
	-- �������
	DECLARE @pos int;
	SELECT @pos = COUNT(*)
	FROM Teams, Goals, Games, Players
	WHERE Goals.Id_Game = Games.Id
		AND Goals.Id_Player = Players.Id
		AND (Games.Id_HomeTeam = Players.Id_Team OR Games.Id_GuestTeam = Players.Id_Team)
		AND Players.Id_Team = Teams.Id
		AND Teams.Name = @teamname
	GROUP BY Teams.Name;
	-- �����������
	DECLARE @neg int;
	SELECT @neg = COUNT(*)
	FROM Teams AS T1, Teams AS T2, Goals, Games, Players
	WHERE Goals.Id_Game = Games.Id
		AND Goals.Id_Player = Players.Id
		AND Players.Id_Team = T2.Id
		AND T1.Name = @teamname
		AND T2.Id != T1.Id
		AND (
			(Games.Id_HomeTeam = T2.Id AND Games.Id_GuestTeam = T1.Id)
			OR
			(Games.Id_HomeTeam = T1.Id AND Games.Id_GuestTeam = T2.Id)
		);
	IF @pos IS NULL
		SET @pos = 0;
	IF @neg IS NULL
		SET @neg = 0;
	INSERT INTO @res (team, pos, neg) VALUES (@teamname, @pos, @neg);
	RETURN;
END;

GO

SELECT * FROM GetTeamGoals('�������');

SELECT *
	FROM GetTotalResultsForAllTours()

GO
-- ������� ������� ����������� ���������� � ������� ���������� �� �������
alter FUNCTION AttackRate
( @teamname varchar(64) )
RETURNS @res table
(
	Player int,
	Goals int
)
AS
BEGIN
	IF @teamname = ''
	BEGIN
		INSERT @res
		SELECT Players.Id AS Player, COUNT(*) AS Goals
		FROM Goals, Players, Roles
		WHERE Goals.Id_Player = Players.Id
			AND Players.Id_Position = Roles.Id
			AND Roles.Name = '����������'
		GROUP BY Players.Id
	END
	ELSE
	BEGIN
		INSERT @res
		SELECT Players.Id AS Player, COUNT(*) AS Goals
		FROM Goals, Players, Roles, Teams, Games
		WHERE Goals.Id_Player = Players.Id
			AND Players.Id_Position = Roles.Id
			AND Roles.Name = '����������'
			AND Goals.Id_Game = Games.Id
			AND (Games.Id_GuestTeam = Teams.Id OR Games.Id_HomeTeam = Teams.Id)
			AND Teams.Name = @teamname
		GROUP BY Players.Id
	END
	RETURN;
END

GO

CREATE FUNCTION GetBestAttack
(
	@teamname AS VARCHAR(64) = null
)
RETURNS @res table
(
	team varchar(64),
	player varchar(128),
	goals int
)
AS
BEGIN
	INSERT @res
	SELECT Teams.Name, Players.Firstname + ' ' + Players.Lastname, AttackRate.Goals
	FROM AttackRate(@teamname), Teams, Players
	WHERE AttackRate.Goals = (SELECT MAX(AttackRate.Goals) FROM AttackRate(@teamname))
		AND Teams.Id = Players.Id_Team 
		AND Players.Id = AttackRate.Player;
	RETURN;
END

GO

SELECT * FROM GetBestAttack('')

GO
-- ������� ������� �������
CREATE VIEW GoalkeeperRate
AS
SELECT Players.Id AS Player, COUNT(*) AS Goals
FROM Goals, Players, Roles
WHERE Goals.Id_Player = Players.Id
	AND Players.Id_Position = Roles.Id
	AND Roles.Name = '�������'
GROUP BY Players.Id

GO

CREATE FUNCTION GetBestGoalkeeper()
RETURNS @res table
(
	team varchar(64),
	player varchar(128),
	goals int
)
AS
BEGIN
	INSERT @res
	SELECT Teams.Name, Players.Firstname + ' ' + Players.Lastname, GoalkeeperRate.Goals
	FROM Teams, Players, GoalkeeperRate
	WHERE Teams.Id = Players.Id_Team
		AND GoalkeeperRate.Goals = (SELECT MAX(Goals) FROM GoalkeeperRate)
		AND GoalkeeperRate.Player = Players.Id
	RETURN;
END

GO

SELECT * FROM GetBestGoalkeeper()

GO
-- ���������� ��������� ��������� ������� �� ��������� ����
alter FUNCTION GetTeamGoalsByTour
(
	@teamname varchar(64),
	@tour varchar(64)
)
RETURNS @res table
(
	team varchar(64),
	team2 varchar(64),
	pos int,
	neg int,
	points int
)
AS
BEGIN
	SELECT @teamname = Teams.Name FROM Teams WHERE Teams.Name = @teamname;
	IF @teamname IS NULL
		RETURN;
	-- �������
	DECLARE @pos int;
	SELECT @pos = COUNT(*)
	FROM Teams, Goals, Games, Players, Tours
	WHERE Goals.Id_Game = Games.Id
		AND Goals.Id_Player = Players.Id
		AND (Games.Id_HomeTeam = Players.Id_Team OR Games.Id_GuestTeam = Players.Id_Team)
		AND Players.Id_Team = Teams.Id
		AND Teams.Name = @teamname
		AND Games.Id_Tour = Tours.Id
		AND Tours.Name = @tour
	GROUP BY Teams.Name;
	-- �����������
	DECLARE @neg int;
	SELECT @neg = COUNT(*)
	FROM Teams AS T1, Teams AS T2, Goals, Games, Players, Tours
	WHERE Goals.Id_Game = Games.Id
		AND Goals.Id_Player = Players.Id
		AND Players.Id_Team = T2.Id
		AND T1.Name = @teamname
		AND T2.Id != T1.Id
		AND (
			(Games.Id_HomeTeam = T2.Id AND Games.Id_GuestTeam = T1.Id)
			OR
			(Games.Id_HomeTeam = T1.Id AND Games.Id_GuestTeam = T2.Id)
		)
		AND Games.Id_Tour = Tours.Id
		AND Tours.Name = @tour;
	IF @pos IS NULL
		SET @pos = 0;
	IF @neg IS NULL
		SET @neg = 0;

	DECLARE @points int = 0;
	IF @pos > @neg 
		SET @points = 3;
	ELSE IF @pos = @neg
		SET @points = 1;

	DECLARE @team2 VARCHAR(64);
	SELECT @team2 = T2.Name
	FROM Teams AS T1, Teams AS T2, Games, Tours
	WHERE 
		 T1.Name = @teamname
		AND T2.Id != T1.Id
		AND (
			(Games.Id_HomeTeam = T2.Id AND Games.Id_GuestTeam = T1.Id)
			OR
			(Games.Id_HomeTeam = T1.Id AND Games.Id_GuestTeam = T2.Id)
		)
		AND Games.Id_Tour = Tours.Id
		AND Tours.Name = @tour;

	INSERT INTO @res (team, team2, pos, neg, points) VALUES (@teamname, @team2, @pos, @neg, @points);
	RETURN;
END

GO

select * from GetTeamGoalsByTour('�������','��� 7');

GO

CREATE FUNCTION GetTeamsResultsByTour
(
	@tour varchar(64)
)
RETURNS @res table
(
	team VARCHAR(64),
	pos int,
	neg int,
	points int
)
AS
BEGIN
	DECLARE @teamsnumber int;
	SELECT @teamsnumber = COUNT(*)
	FROM Teams;

	DECLARE @i int = 1;
	WHILE (@i <= @teamsnumber)
	BEGIN
		DECLARE @team VARCHAR(64);
		SELECT @team = Teams.Name FROM Teams WHERE Teams.Id = @i;
		
		SET @i = @i + 1;
		IF @team IS NULL
		BEGIN
			SET @teamsnumber = @teamsnumber + 1;
			CONTINUE;
		END

		DECLARE @pos int;
		DECLARE @neg int;
		SELECT @pos = GTGBT.pos, @neg = GTGBT.neg
		FROM GetTeamGoalsByTour(@team, @tour) AS GTGBT;

		DECLARE @points int = 0;
		IF @pos > @neg 
			SET @points = 3;
		ELSE IF @pos = @neg
			SET @points = 1;

		INSERT INTO @res (team, pos, neg, points) VALUES (@team, @pos, @neg, @points);
	END
	RETURN;
END

GO

CREATE FUNCTION SortedResultTable
(
	@tour VARCHAR(64)
)
RETURNS @res table
(
	id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	team VARCHAR(64),
	pos int,
	neg int,
	points int
)
AS
BEGIN
	INSERT @res
	SELECT * FROM GetTeamsResultsByTour(@tour) ORDER BY points DESC;
	RETURN;
END

GO

CREATE FUNCTION GetTeamTournamentPositionByTour
(
	@team VARCHAR(64),
	@tour VARCHAR(64)
)
RETURNS @res table
(
	team VARCHAR(64),
	position INT
)
AS
BEGIN
	INSERT @res
	SELECT SRT.team, SRT.id FROM SortedResultTable(@tour) AS SRT WHERE  SRT.team = @team;
	RETURN;
END

GO

SELECT * FROM GetTeamTournamentPositionByTour('�����', '��� 1');

GO

-- ������� ���������� ���������� ������� �� ������� ����

CREATE FUNCTION GetTeamResultsForEveryTours
(
	@team VARCHAR(64)
)
RETURNS @res table
(
	tour VARCHAR(64),
	team VARCHAR(64),
	team2 VARCHAR(64),	
	pos int,
	neg int,
	points int
)
AS
BEGIN
	DECLARE @isExist int;
	SELECT @isExist = Teams.Id FROM Teams WHERE Teams.Name = @team;

	IF @isExist IS NULL
	BEGIN
		RETURN;
	END

	DECLARE @toursnumber int = 0;
	SELECT @toursnumber = COUNT(*) FROM Tours;
	
	DECLARE @i int = 1;
	WHILE (@i <= @toursnumber)
	BEGIN
		DECLARE @tourname VARCHAR(64);
		SELECT @tourname = Tours.Name FROM Tours WHERE Tours.id = @i;

		SET @i = @i + 1;
		IF @tourname IS NULL
		BEGIN
			SET @toursnumber = @toursnumber + 1;
			CONTINUE;
		END

		INSERT @res
		SELECT @tourname, *
		FROM GetTeamGoalsByTour(@team, @tourname);
	END
	RETURN;
END

GO

SELECT * FROM GetTeamResultsForEveryTours('���������')

GO
-- ������� ��������� ���� ��������

CREATE FUNCTION GetResultsForAllTours()
RETURNS @res table
(
	team VARCHAR(64),
	pos int,
	neg int,
	points int
)
AS
BEGIN
	DECLARE @toursnumber int = 0;
	SELECT @toursnumber = COUNT(*) FROM Tours;

	DECLARE @i int = 1;
	WHILE (@i <= @toursnumber)
	BEGIN
		DECLARE @tour VARCHAR(64);
		SELECT @tour = Tours.Name FROM Tours WHERE Tours.Id = @i;

		SET @i = @i + 1;
		IF @tour IS NULL
		BEGIN
			SET @toursnumber = @toursnumber + 1;
			CONTINUE;
		END

		INSERT @res
		SELECT *
		FROM GetTeamsResultsByTour(@tour);
	END
	RETURN;
END

GO

CREATE FUNCTION GetTotalResultsForAllTours()
RETURNS @res table
(
	team VARCHAR(64),
	pos int,
	neg int,
	points int
)
AS
BEGIN
	INSERT @res
	SELECT team, SUM(pos), SUM(neg), SUM(points) FROM GetResultsForAllTours() GROUP BY team;
	RETURN;
END

GO

CREATE FUNCTION GetWinner()
RETURNS @res table
(
	tour VARCHAR(64),
	team1 VARCHAR(64),
	teams2 varchar(64),
	pos int,
	net int,
	points int
)
AS
BEGIN
	DECLARE @team VARCHAR(64);
	SElECT @team = team
	FROM GetTotalResultsForAllTours()
	WHERE points = (SELECT MAX(points) FROM GetTotalResultsForAllTours());
	
	INSERT @res
	SELECT * FROM GetTeamResultsForEveryTours(@team);
	RETURN;
END

GO

SELECT * FROM GetWinner();

GO
-- ������� ��� �������, �������� ���������� ���������� �����

CREATE FUNCTION GetTeamWithMaxGoals()
RETURNS VARCHAR(64)
AS
BEGIN
	DECLARE @team VARCHAR(64);
	SELECT @team = team
	FROM GetTotalResultsForAllTours() AS A
	WHERE pos = (SELECT MAX(pos) FROM GetTotalResultsForAllTours() AS B)
	RETURN @team;
END

GO

DECLARE @res varchar(64);
EXECUTE @res = GetTeamWithMaxGoals;
PRINT @res

GO

CREATE TRIGGER onAddGame
ON Games
INSTEAD OF INSERT
AS
BEGIN
	DECLARE @id int;
	DECLARE @team1 int;
	DECLARE @team2 int;
	DECLARE @id_stadium int
	DECLARE @id_tour int;
	SELECT @team1 = Id_HomeTeam,
		@team2 = Id_GuestTeam,
		@id = id,
		@id_stadium = Id_Stadium,
		@id_tour = Id_Tour
	FROM INSERTED

	IF @team1 != @team2
		INSERT INTO Games (id, Id_GuestTeam, Id_HomeTeam, Id_Stadium, Id_Tour)
			VALUES (@id, @team1, @team2, @id_stadium, @id_tour);
END

GO