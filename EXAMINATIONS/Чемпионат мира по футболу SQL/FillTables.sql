INSERT INTO Coachs (Firstname, Lastname) VALUES('Жозе', 'Моуринью');
INSERT INTO Coachs (Firstname, Lastname) VALUES('Зинедин', 'Зидан');
INSERT INTO Coachs (Firstname, Lastname) VALUES('Юрген', 'Клопп');
INSERT INTO Coachs (Firstname, Lastname) VALUES('Валерий', 'Карпин');
INSERT INTO Coachs (Firstname, Lastname) VALUES('Леонид', 'Слуцкий');
INSERT INTO Coachs (Firstname, Lastname) VALUES('Пеп', 'Гвардиола');
INSERT INTO Coachs (Firstname, Lastname) VALUES('Алекс', 'Фергюсон');
INSERT INTO Coachs (Firstname, Lastname) VALUES('Арсен', 'Венгер');

INSERT INTO Stadiums (Name, City) VALUES ('Австралия', 'Сидней');
INSERT INTO Stadiums (Name, City) VALUES ('Хосе Амальфитани', 'Буэнос-Айрес');
INSERT INTO Stadiums (Name, City) VALUES ('Мальвинас Архентинас', 'Мендоса');
INSERT INTO Stadiums (Name, City) VALUES ('Шато Каррерас', 'Кордова');
INSERT INTO Stadiums (Name, City) VALUES ('Олимпийский Стадион', 'Монреаль');
INSERT INTO Stadiums (Name, City) VALUES ('Шанхайский стадион', 'Шанхай');
INSERT INTO Stadiums (Name, City) VALUES ('Шахтёр', 'Донецк');
INSERT INTO Stadiums (Name, City) VALUES ('Локомотив', 'Симферополь');

INSERT INTO Roles (name) VALUES('Нападающий');
INSERT INTO Roles (name) VALUES('Полузащитник');
INSERT INTO Roles (name) VALUES('Защитник');
INSERT INTO Roles (name) VALUES('Вратарь');

INSERT INTO Teams (name, id_coach, id_stadium) VALUES('Барселона', 1, 1);
INSERT INTO Teams (name, id_coach, id_stadium) VALUES('Реал Мадрид', 2, 2);
INSERT INTO Teams (name, id_coach, id_stadium) VALUES('Манчестер Юнайтед', 3, 3);
INSERT INTO Teams (name, id_coach, id_stadium) VALUES('Ювентус', 4, 4);
INSERT INTO Teams (name, id_coach, id_stadium) VALUES('Бавария', 5, 5);
INSERT INTO Teams (name, id_coach, id_stadium) VALUES('Галатасарай', 6, 6);
INSERT INTO Teams (name, id_coach, id_stadium) VALUES('Милан', 7, 7);
INSERT INTO Teams (name, id_coach, id_stadium) VALUES('Ливерпуль', 8, 8);

INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Хусам', 'Хасан', 1, 1);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Клаудио', 'Суарес', 3, 1);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Джанлуиджи', 'Буффон', 1, 1);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Мухаммад', 'Ад-Даайя', 1, 1);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Иван', 'Уртадо', 4, 1);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Виталий', 'Астафьев', 2, 1);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Икер', 'Касильяс', 2, 1);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Коби', 'Джонс', 1, 1);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Ахмед', 'Хасан', 4, 1);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Мухаммад', 'Аль-Хилайви', 1, 1);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Аднан', 'Ат-Тальяни', 2, 1);

INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Бадер', 'Аль-Мутава', 3, 2);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Мартин', 'Рейм', 4, 2);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Лэндон', 'Донован', 2, 2);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Сами', 'Аль-Джабир', 1, 2);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Салман', 'Иса', 2, 2);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Эссам', 'Эль-Хадари', 4, 2);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Ясухито', 'Эндо', 1, 2);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Джавад', 'Некунам', 1, 2);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Лотар', 'Маттеус', 2, 2);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Али', 'Даеи', 1, 2);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Серхио', 'Рамос', 4, 2);
	
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Андерс', 'Свенссон', 2, 3);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Юнис', 'Махмуд', 3, 3);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Пауло', 'да Сильва', 4, 3);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Ахмед', 'Мубарак', 4, 3);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Криштиану', 'Роналду', 1, 3);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Мейнор', 'Фигероа', 1, 3);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Павел', 'Пардо', 1, 3);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Херардо', 'Торрадо', 1, 3);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Робби', 'Кин', 4, 3);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Дэниэл', 'Беннетт', 2, 3);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Мухаммад', 'Хусейн', 2, 3);

INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Андрес', 'Гуардадо', 1, 4);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Анатолий', 'Тимощук', 1, 4);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Томас', 'Равелли', 1, 4);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Марко', 'Кристал', 2, 4);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Хавьер', 'Санетти', 4, 4);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Абдулла', 'Зубромави', 4, 4);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Кафу', '', 2, 4);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Лилиан', 'Тюрам', 1, 4);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Фавзи', 'Башир', 2, 4);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Рафаэль', 'Маркес', 3, 4);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Габриэль', 'Гомес', 4, 4);
	
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Хавьер', 'Маскерано', 4, 5);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Клинт', 'Демпси', 1, 5);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Майкл', 'Брэдли', 2, 5);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Георгиос', 'Карагунис', 3, 5);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Амир', 'Шафи', 2, 5);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Шахрил', 'Исхак', 1, 5);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Амадо', 'Гевара', 4, 5);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Хусейн', 'Саид', 1, 5);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Вальтер', 'Сентено', 2, 5);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Яри', 'Литманен', 4, 5);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Ригобер', 'Сонг', 1, 5);
	
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Мирослав', 'Клозе', 4, 6);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Хон', 'Мён Бо', 4, 6);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Фабио', 'Каннаваро', 4, 6);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Валид', 'Али', 3, 6);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Ноэль', 'Вальядарес', 2, 6);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Чха', 'Бом Гын', 2, 6);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Джефф', 'Эйгус', 2, 6);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Доринел', 'Мунтяну', 1, 6);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Киатисук', 'Сенамуанг', 1, 6);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Андрес', 'Опер', 1, 6);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Хусейн', 'Сулеймани', 1, 6);

INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Шей', 'Гивен', 2, 7);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Дарио', 'Срна', 2, 7);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Башар Абдулла', '', 1, 7);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Хави', '', 4, 7);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Саркис', 'Овсепян', 3, 7);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Ибрагим', 'Хасан', 2, 7);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Ли', 'Ун Джэ', 1, 7);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Ким', 'Чельстрём', 4, 7);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Хайме', 'Пенедо', 2, 7);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Байхакки', 'Хайзан', 1, 7);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Уэсли', 'Снейдер', 1, 7);

INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Петер', 'Йеле', 1, 8);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Андреас', 'Исакссон', 2, 8);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Карлос', 'Руис', 4, 8);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Сауд', 'Харири', 1, 8);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Лукас', 'Подольски', 1, 8);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Петер', 'Шмейхель', 3, 8);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Хуан', 'Аранго', 2, 8);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Усама', 'Хавсави', 1, 8);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Марсело', 'Бальбоа', 1, 8);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Луиш', 'Фигу', 4, 8);
INSERT INTO Players (Firstname, Lastname, Id_Position, Id_Team)
	VALUES('Паоло', 'Мальдини', 2, 8);
	
INSERT INTO Tours (Name) VALUES('Тур 1');
INSERT INTO Tours (Name) VALUES('Тур 2');
INSERT INTO Tours (Name) VALUES('Тур 3');
INSERT INTO Tours (Name) VALUES('Тур 4');
INSERT INTO Tours (Name) VALUES('Тур 5');
INSERT INTO Tours (Name) VALUES('Тур 6');
INSERT INTO Tours (Name) VALUES('Тур 7');
INSERT INTO Tours (Name) VALUES('Тур 8');
INSERT INTO Tours (Name) VALUES('Тур 9');
INSERT INTO Tours (Name) VALUES('Тур 10');
INSERT INTO Tours (Name) VALUES('Тур 11');
INSERT INTO Tours (Name) VALUES('Тур 12');
INSERT INTO Tours (Name) VALUES('Тур 13');
INSERT INTO Tours (Name) VALUES('Тур 14');

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