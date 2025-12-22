-- Manifestos
SET
IDENTITY_INSERT Manifestos ON;

INSERT INTO Manifestos (Id, Numero, Tipo, Navio, PortoOrigem, PortoDestino, DateCreated, DateModified)
VALUES (1, 'IMP-2025-0001', 'Importacao', 'MV Atlas', 'CN SHANGHAI', 'BR SANTOS', SYSDATETIMEOFFSET(), NULL),
       (2, 'EXP-2025-0042', 'Exportacao', 'MV Poseidon', 'BR RIO GRANDE', 'NL ROTTERDAM', SYSDATETIMEOFFSET(), NULL),
       (3, 'IMP-2025-0099', 'Importacao', 'MV Hermes', 'US MIAMI', 'BR SANTOS', SYSDATETIMEOFFSET(), NULL);

SET
IDENTITY_INSERT Manifestos OFF;

-- Escalas
    
    SET
IDENTITY_INSERT Escalas ON;
INSERT INTO Escalas (Id, Navio, Porto, Status, Eta, Etb, Etd, DateCreated, DateModified)
VALUES (201, 'MV Atlas', 'BRRGD - RIO GRANDE', 'Prevista', '2025-08-27T05:00:00-03:00', NULL, NULL, SYSDATETIMEOFFSET(), NULL),
       (202, 'MV Atlas', 'BRITJ - ITAJAI', 'Cancelada', '2025-08-28T10:00:00-03:00', NULL, NULL, SYSDATETIMEOFFSET(), NULL),
       (203, 'MV Atlas', 'BRPNG - PARANAGUA', 'Prevista', '2025-08-29T21:00:00-03:00', NULL, NULL, SYSDATETIMEOFFSET(), NULL),
       (204, 'MV Atlas', 'BRSSZ - SANTOS', 'Prevista', '2025-08-31T08:00:00-03:00', NULL, NULL, SYSDATETIMEOFFSET(), NULL),

       (301, 'MV Poseidon', 'BRRGD - RIO GRANDE', 'Saiu', '2025-08-22T03:00:00-03:00', '2025-08-22T06:00:00-03:00',
        '2025-08-22T18:00:00-03:00', SYSDATETIMEOFFSET(), NULL),
       (302, 'MV Poseidon', 'BRITJ - ITAJAI', 'Atracada', '2025-08-24T06:00:00-03:00', '2025-08-24T07:30:00-03:00',
        NULL, SYSDATETIMEOFFSET(), NULL),
       (303, 'MV Poseidon', 'BRSSZ - SANTOS', 'Prevista', '2025-08-26T09:00:00-03:00', NULL, NULL, SYSDATETIMEOFFSET(), NULL);
SET
IDENTITY_INSERT Escalas OFF;