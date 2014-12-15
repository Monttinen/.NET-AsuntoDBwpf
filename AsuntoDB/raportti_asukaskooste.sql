CREATE VIEW [dbo].[raportti_asukaskooste] AS 
(SELECT at.Selite as Asuntotyyppi, count( h.Avain ) as Hlo_lkm, avg(t.pinta_ala) as Pintaala_ka, avg(t.huonelukumaara) as HuoneLkm_ka
FROM Asuntotyyppi as at
INNER JOIN Asunto t ON t.AsuntotyyppiKoodi = at.Koodi
INNER JOIN Henkilo h on h.AsuntoAvain = t.Avain
WHERE t.Omistusasunto = 0
GROUP BY at.Selite)
UNION ALL
(SELECT (at.Selite+ ' omistus') as Asuntotyyppi, count( oh.Avain ) as Hlo_lkm, avg(ot.pinta_ala) as Pintaala_ka, avg(ot.huonelukumaara) as HuoneLkm_ka
FROM Asuntotyyppi as at
INNER JOIN Asunto ot ON ot.AsuntotyyppiKoodi = at.Koodi
INNER JOIN Henkilo oh on oh.AsuntoAvain = ot.Avain
WHERE ot.Omistusasunto = 1
GROUP BY at.Selite)

