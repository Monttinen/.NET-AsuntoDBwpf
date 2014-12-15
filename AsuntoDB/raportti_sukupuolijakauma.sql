CREATE VIEW [dbo].[raportti_sukupuolijakauma]
	AS SELECT s.Selite as Sukupuoli, a.Omistusasunto, count(h.Avain) as Asukkaita
FROM Sukupuoli AS s
INNER JOIN Henkilo AS h ON h.SukupuoliKoodi = s.Koodi
INNER JOIN Asunto AS a ON a.Avain = h.AsuntoAvain

GROUP BY s.Selite, a.Omistusasunto
