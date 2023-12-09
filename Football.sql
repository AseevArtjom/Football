CREATE TABLE Player(
	[Id] INT PRIMARY KEY IDENTITY(1,1),
	[FullName] NVARCHAR(200) NOT NULL,
	[Country] NVARCHAR(100) NOT NULL,
	[Number] INT NOT NULL,
	[PosId] INT NOT NULL,
	[TeamId] INT NOT NULL,
	FOREIGN KEY (PosId) REFERENCES Position(Id),
	FOREIGN KEY (TeamId) REFERENCES Team(Id)
)

CREATE TABLE Position(
	[Id] INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Team(
	[Id] INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(100) NOT NULL,
	[Country] NVARCHAR(100) NOT NULL
)

CREATE TABLE [Match](
	[Id] INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(200) NOT NULL,
	[FirstTeamId] INT NOT NULL,
	[SecondTeamId] INT NOT NULL,
	[GoalsFirstTeam] INT NOT NULL,
	[GoalsSecondTeam] INT NOT NULL,
	[WhoGoal] INT NOT NULL,
	[PlayingDate] DATE NOT NULL,
	FOREIGN KEY (FirstTeamId) REFERENCES Team(Id),
	FOREIGN KEY (SecondTeamId) REFERENCES Team(Id),
	FOREIGN KEY (WhoGoal) REFERENCES Player(Id),
)

INSERT INTO Position(Name)
VALUES
('Goalkeeper'),
('Defenders'),
('MidFielders'),
('Attackers')

INSERT INTO Team(Name,Country)
VALUES
('Real Madrid','Spain'),
('FC Bayern Munchen','Germany'),
('FC Barcelona','Spain'),
('Liverpool','England'),
('PSG','French')

INSERT INTO Player(FullName,Country,Number,PosId,TeamId)
VALUES
('Tony Kroos','Germany',8,3,1),
('Jude Bellingham','England',22,3,1),
('Eder Gabriel Militao','Brazil',3,2,1),
('Harry Kane','England',10,4,2),
('Joshua Kimmich','Germany',6,3,2),
('Manuel Neuer','Germany',1,1,2)

INSERT INTO Match(Name, FirstTeamId, SecondTeamId, GoalsFirstTeam, GoalsSecondTeam, WhoGoal, PlayingDate)
VALUES ('Real Madrid - FC Bayern Munchen', 1, 2, 4, 2, 1, CONVERT(DATE, '2023-06-12', 23));


