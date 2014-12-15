CREATE VIEW [dbo].[raportti_asukaskooste] AS 
SELECT t1.Selite as Asuntotyyppi, t1.Hlo_lkm as 'Henkilö lukumäärä', t1.HuoneLkm_ka as 'Huone lukumäärä ka.', t1.Pintaala_ka as 'Pinta-ala ka.',
coalesce(t2.Hlo_lkm_oma,0) as 'Henkilö lukumäärä omistusasunto',
coalesce(t2.HuoneLkm_ka_oma,0) as 'Huone lukumäärä ka. omistusasunto',
coalesce(t2.Pintaala_ka_oma,0) as 'Pinta-ala ka. omistusasunto'
FROM
(SELECT at.Selite, count( h.Avain ) as Hlo_lkm, avg(t.pinta_ala) as Pintaala_ka, avg(t.huonelukumaara) as HuoneLkm_ka
FROM Asuntotyyppi as at
INNER JOIN Asunto t ON t.AsuntotyyppiKoodi = at.Koodi
INNER JOIN Henkilo h on h.AsuntoAvain = t.Avain
WHERE t.Omistusasunto = 0
GROUP BY at.Selite) t1
LEFT JOIN
(SELECT at.Selite, count( oh.Avain ) as Hlo_lkm_oma, avg(ot.pinta_ala) as Pintaala_ka_oma, avg(ot.huonelukumaara) as HuoneLkm_ka_oma
FROM Asuntotyyppi as at
INNER JOIN Asunto ot ON ot.AsuntotyyppiKoodi = at.Koodi
INNER JOIN Henkilo oh on oh.AsuntoAvain = ot.Avain
WHERE ot.Omistusasunto = 1
GROUP BY at.Selite) t2
ON t1.Selite = t2.Selite

