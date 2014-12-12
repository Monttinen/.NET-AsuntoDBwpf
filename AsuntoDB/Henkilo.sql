CREATE TABLE [dbo].[Henkilo]
(
	[Avain] INT NOT NULL PRIMARY KEY, 
	[Henkilonumero] NVARCHAR(50) NOT NULL,
    [Etunimi] NVARCHAR(50) NOT NULL, 
    [Sukunimi] NVARCHAR(50) NOT NULL, 
    [Syntymaaika] NVARCHAR(50) NULL, 
    [SukupuoliKoodi] INT NOT NULL, 
    [AsuntoAvain] INT NULL, 
    CONSTRAINT [FK_Henkilo_ToSukupuoli] FOREIGN KEY ([SukupuoliKoodi]) REFERENCES [Sukupuoli]([Avain]), 
    CONSTRAINT [FK_Henkilo_ToAsunto] FOREIGN KEY ([AsuntoAvain]) REFERENCES [Asunto]([Avain])
)
