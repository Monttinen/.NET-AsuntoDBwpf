insert into Sukupuoli (Avain, Koodi, Selite) values
(0, 0, 'ei tunneta'),
(1, 1, 'mies'),
(2, 2, 'nainen'),
(9, 9, 'ei määritelty');

insert into Asuntotyyppi (Avain, Koodi, Selite) values
(0, 0, 'Rivitalohuoneisto'),
(1, 1, 'Kerrostalohuoneisto'),
(2, 2, 'Omakotitalo');

INSERT INTO Asunto (Avain, Asuntonumero, Osoite, Pinta_ala, Huonelukumaara, AsuntotyyppiKoodi, Omistusasunto) VALUES
(0, N'123', N'Omakatu 2', 100, 4, 2, 1),
(1, N'333', N'Katu 2', 90, 3, 1, 0),
(2, N'132', N'Tie 1', 120, 5, 2, 1),
(3, N'55', N'Tie 3', 60, 2, 0, 0);

INSERT INTO Henkilo (Avain, Henkilonumero, Etunimi, Sukunimi, Syntymaaika, SukupuoliKoodi, AsuntoAvain) VALUES
(0, N'23232', N'Tauto', N'Testari', N'12131988', 1, 1),
(1, N'32445', N'Reino', N'Reppunen', N'02071973', 1, 2),
(2, N'97822', N'Liisa', N'Leinonen', N'15091987', 2, NULL);