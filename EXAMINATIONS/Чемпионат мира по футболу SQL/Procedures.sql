-- Подсчитать количество забитых (пропущенных) командой голов
CREATE FUNCTION GetTeamGoals
(
	@teamname varchar(64)
)
RETURNS @res TABLE
(
	team varchar(64),
	pos int,
	neg int
)
AS
BEGIN
	-- Забитые
	DECLARE @pos int;
	SELECT @pos = COUNT(*)
	FROM Teams, Goals, Games, Players
	WHERE Goals.Id_Game = Games.Id
		AND Goals.Id_Player = Players.Id
		AND (Games.Id_HomeTeam = Players.Id_Team OR Games.Id_GuestTeam = Players.Id_Team)
		AND Players.Id_Team = Teams.Id
		AND Teams.Name = @teamname
	GROUP BY Teams.Name;
	-- Пропущенные
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

SELECT * FROM GetTeamGoals('Бавария');

GO
-- Вывести лучшего нападающего чемпионата и лучшего нападющего по команде
CREATE FUNCTION AttackRate
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
			AND Roles.Name = 'Нападающий'
		GROUP BY Players.Id
	END
	ELSE
	BEGIN
		INSERT @res
		SELECT Players.Id AS Player, COUNT(*) AS Goals
		FROM Goals, Players, Roles, Teams, Games
		WHERE Goals.Id_Player = Players.Id
			AND Players.Id_Position = Roles.Id
			AND Roles.Name = 'Нападающий'
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
-- Вывести лучшего вратаря
CREATE VIEW GoalkeeperRate
AS
SELECT Players.Id AS Player, COUNT(*) AS Goals
FROM Goals, Players, Roles
WHERE Goals.Id_Player = Players.Id
	AND Players.Id_Position = Roles.Id
	AND Roles.Name = 'Вратарь'
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

SELECT * FROM GetBestGoalkeeper();

GO
-- Определить турнирное положение команды по заданному туру
CREATE FUNCTION GetTeamGoalsByTour
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
	-- Забитые
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
	-- Пропущенные
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

select * from GetTeamGoalsByTour('бавария','тур 7');

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

SELECT * FROM GetTeamTournamentPositionByTour('милан', 'Тур 1');

GO

-- Вывести результаты конкретной команды по каждому туру

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

SELECT * FROM GetTeamResultsForEveryTours('Ливерпуль');

GO
-- Вывести турнирный путь чемпиона

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
-- Вывести имя команды, забившей наибольшее количество голов

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