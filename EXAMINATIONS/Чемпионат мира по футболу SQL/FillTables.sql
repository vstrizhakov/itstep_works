INSERT INTO Coachs (Firstname, Lastname) VALUES('����', '��������');
INSERT INTO Coachs (Firstname, Lastname) VALUES('�������', '�����');
INSERT INTO Coachs (Firstname, Lastname) VALUES('�����', '�����');
INSERT INTO Coachs (Firstname, Lastname) VALUES('�������', '������');
INSERT INTO Coachs (Firstname, Lastname) VALUES('������', '�������');
INSERT INTO Coachs (Firstname, Lastname) VALUES('���', '���������');
INSERT INTO Coachs (Firstname, Lastname) VALUES('�����', '��������');
INSERT INTO Coachs (Firstname, Lastname) VALUES('�����', '������');

INSERT INTO Stadiums (Name, City) VALUES ('���������', '������');
INSERT INTO Stadiums (Name, City) VALUES ('���� �����������', '������-�����');
INSERT INTO Stadiums (Name, City) VALUES ('��������� ����������', '�������');
INSERT INTO Stadiums (Name, City) VALUES ('���� ��������', '�������');
INSERT INTO Stadiums (Name, City) VALUES ('����������� �������', '��������');
INSERT INTO Stadiums (Name, City) VALUES ('���������� �������', '������');
INSERT INTO Stadiums (Name, City) VALUES ('�����', '������');
INSERT INTO Stadiums (Name, City) VALUES ('���������', '�����������');

INSERT INTO Roles (name) VALUES('����������');
INSERT INTO Roles (name) VALUES('������������');
INSERT INTO Roles (name) VALUES('��������');
INSERT INTO Roles (name) VALUES('�������');

INSERT INTO Teams (name, id_coach, id_stadium) VALUES('���������', 1, 1);
INSERT INTO Teams (name, id_coach, id_stadium) VALUES('���� ������', 2, 2);
INSERT INTO Teams (name, id_coach, id_stadium) VALUES('��������� �������', 3, 3);
INSERT INTO Teams (name, id_coach, id_stadium) VALUES('�������', 4, 4);
INSERT INTO Teams (name, id_coach, id_stadium) VALUES('�������', 5, 5);
INSERT INTO Teams (name, id_coach, id_stadium) VALUES('�����������', 6, 6);
INSERT INTO Teams (name, id_coach, id_stadium) VALUES('�����', 7, 7);
INSERT INTO Teams (name, id_coach, id_stadium) VALUES('���������', 8, 8);

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