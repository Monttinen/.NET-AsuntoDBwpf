CREATE TABLE [dbo].[Asunto]
(
	[Avain] INT NOT NULL PRIMARY KEY, 
    [Asuntonumero] NVARCHAR(50) NOT NULL, 
    [Osoite] NVARCHAR(100) NULL, 
    [Pinta_ala] INT NOT NULL, 
    [Huonelukumaara] INT NOT NULL, 
    [AsuntotyyppiKoodi] INT NOT NULL, 
    [Omistusasunto] BIT NOT NULL, 
    CONSTRAINT [FK_Asunto_ToAsuntotyyppi] FOREIGN KEY ([AsuntotyyppiKoodi]) REFERENCES [Asuntotyyppi]([Avain])
)
