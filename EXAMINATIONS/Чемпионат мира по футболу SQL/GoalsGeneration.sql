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