insert into Sukupuoli (Koodi, Selite) values
(0, 'ei tunneta'),
(1, 'mies'),
(2, 'nainen'),
(9, 'ei määritelty');

insert into Asuntotyyppi (Selite) values
('Rivitalohuoneisto'),
('Kerrostalohuoneisto'),
('Omakotitalo');

INSERT INTO Asunto (Asuntonumero, Osoite, Pinta_ala, Huonelukumaara, AsuntotyyppiKoodi, Omistusasunto) VALUES
(N'123', N'Omakatu 2', 100, 4, 3, 1),
(N'333', N'Katu 2', 90, 3, 2, 0),
(N'132', N'Tie 1', 120, 5, 3, 1),
(N'55', N'Tie 3', 60, 2, 1, 0);

INSERT INTO Henkilo (Henkilonumero, Etunimi, Sukunimi, Syntymaaika, SukupuoliKoodi, AsuntoAvain) VALUES
(N'23232', N'Tauto', N'Testari', N'12131988', 1, 1),
(N'32445', N'Reino', N'Reppunen', N'02071973', 1, 2),
(N'97822', N'Liisa', N'Leinonen', N'15091987', 2, NULL);