ALTER TABLE [dbo].[Musicas]
ALTER COLUMN [Titulo] VARCHAR(255) COLLATE SQL_Latin1_General_CP1_CI_AI NOT NULL;

-- Legião Urbana (ID: e2a8c3d8-74be-4a64-85b4-5c9b74a355b2)
INSERT INTO [DB_InfnetMusic].[dbo].[Musicas] ([Id], [Titulo], [BandaId])
VALUES
    (NEWID(), 'Eduardo e Mônica', 'e2a8c3d8-74be-4a64-85b4-5c9b74a355b2'),
    (NEWID(), 'Faroeste Caboclo', 'e2a8c3d8-74be-4a64-85b4-5c9b74a355b2'),
    (NEWID(), 'Tempo Perdido', 'e2a8c3d8-74be-4a64-85b4-5c9b74a355b2');

-- Titãs (ID: f9c1b2a3-65d4-4e87-98fc-3d5b7a9e6c4d)
INSERT INTO [DB_InfnetMusic].[dbo].[Musicas] ([Id], [Titulo], [BandaId])
VALUES
    (NEWID(), 'Epitáfio', 'f9c1b2a3-65d4-4e87-98fc-3d5b7a9e6c4d'),
    (NEWID(), 'Flores', 'f9c1b2a3-65d4-4e87-98fc-3d5b7a9e6c4d'),
    (NEWID(), 'Polícia', 'f9c1b2a3-65d4-4e87-98fc-3d5b7a9e6c4d');

-- Os Paralamas do Sucesso (ID: a1d9e8c7-3b2a-4f6e-8d5c-9a7b3e1d6f8c)
INSERT INTO [DB_InfnetMusic].[dbo].[Musicas] ([Id], [Titulo], [BandaId])
VALUES
    (NEWID(), 'Meu Erro', 'a1d9e8c7-3b2a-4f6e-8d5c-9a7b3e1d6f8c'),
    (NEWID(), 'Lanterna dos Afogados', 'a1d9e8c7-3b2a-4f6e-8d5c-9a7b3e1d6f8c'),
    (NEWID(), 'Aonde Quer Que Eu Vá', 'a1d9e8c7-3b2a-4f6e-8d5c-9a7b3e1d6f8c');

-- Sepultura (ID: c6b5a4d3-8e7f-4c9a-b2d1-6f8c5e9a3b7d)
INSERT INTO [DB_InfnetMusic].[dbo].[Musicas] ([Id], [Titulo], [BandaId])
VALUES
    (NEWID(), 'Roots Bloody Roots', 'c6b5a4d3-8e7f-4c9a-b2d1-6f8c5e9a3b7d'),
    (NEWID(), 'Refuse/Resist', 'c6b5a4d3-8e7f-4c9a-b2d1-6f8c5e9a3b7d'),
    (NEWID(), 'Territory', 'c6b5a4d3-8e7f-4c9a-b2d1-6f8c5e9a3b7d');

-- Charlie Brown Jr. (ID: d8e7f6a5-4c3b-4a9e-8d6c-2b9a7e4d1f5b)
INSERT INTO [DB_InfnetMusic].[dbo].[Musicas] ([Id], [Titulo], [BandaId])
VALUES
    (NEWID(), 'Papo Reto', 'd8e7f6a5-4c3b-4a9e-8d6c-2b9a7e4d1f5b'),
    (NEWID(), 'Zóio de Lula', 'd8e7f6a5-4c3b-4a9e-8d6c-2b9a7e4d1f5b'),
    (NEWID(), 'Céu Azul', 'd8e7f6a5-4c3b-4a9e-8d6c-2b9a7e4d1f5b');

-- The Beatles (ID: b3a2c1d9-9e8d-4f7c-a6b5-8e4d2c1b9a7f)
INSERT INTO [DB_InfnetMusic].[dbo].[Musicas] ([Id], [Titulo], [BandaId])
VALUES
    (NEWID(), 'Hey Jude', 'b3a2c1d9-9e8d-4f7c-a6b5-8e4d2c1b9a7f'),
    (NEWID(), 'Let It Be', 'b3a2c1d9-9e8d-4f7c-a6b5-8e4d2c1b9a7f'),
    (NEWID(), 'Come Together', 'b3a2c1d9-9e8d-4f7c-a6b5-8e4d2c1b9a7f');

-- Queen (ID: f4d3e2c1-7b6a-4d9e-8c5b-1a9f8e7d6c3b)
INSERT INTO [DB_InfnetMusic].[dbo].[Musicas] ([Id], [Titulo], [BandaId])
VALUES
    (NEWID(), 'Bohemian Rhapsody', 'f4d3e2c1-7b6a-4d9e-8c5b-1a9f8e7d6c3b'),
    (NEWID(), 'We Will Rock You', 'f4d3e2c1-7b6a-4d9e-8c5b-1a9f8e7d6c3b'),
    (NEWID(), 'Don''t Stop Me Now', 'f4d3e2c1-7b6a-4d9e-8c5b-1a9f8e7d6c3b');

-- Led Zeppelin (ID: a9f8e7d6-5c4b-4a3e-b2d1-9c8b7a6e5d4f)
INSERT INTO [DB_InfnetMusic].[dbo].[Musicas] ([Id], [Titulo], [BandaId])
VALUES
    (NEWID(), 'Stairway to Heaven', 'a9f8e7d6-5c4b-4a3e-b2d1-9c8b7a6e5d4f'),
    (NEWID(), 'Whole Lotta Love', 'a9f8e7d6-5c4b-4a3e-b2d1-9c8b7a6e5d4f'),
    (NEWID(), 'Black Dog', 'a9f8e7d6-5c4b-4a3e-b2d1-9c8b7a6e5d4f');

-- The Rolling Stones (ID: e7d6c5b4-2a19-4f8e-9d6c-3b9a8e7d5c2a)
INSERT INTO [DB_InfnetMusic].[dbo].[Musicas] ([Id], [Titulo], [BandaId])
VALUES
    (NEWID(), '(I Can''t Get No) Satisfaction', 'e7d6c5b4-2a19-4f8e-9d6c-3b9a8e7d5c2a'),
    (NEWID(), 'Paint It, Black', 'e7d6c5b4-2a19-4f8e-9d6c-3b9a8e7d5c2a'),
    (NEWID(), 'Gimme Shelter', 'e7d6c5b4-2a19-4f8e-9d6c-3b9a8e7d5c2a');

-- AC/DC (ID: c1b9a8e7-6d5c-4b4a-a3e2-7f6d5c4b3a19)
INSERT INTO [DB_InfnetMusic].[dbo].[Musicas] ([Id], [Titulo], [BandaId])
VALUES
    (NEWID(), 'Thunderstruck', 'c1b9a8e7-6d5c-4b4a-a3e2-7f6d5c4b3a19'),
    (NEWID(), 'Back in Black', 'c1b9a8e7-6d5c-4b4a-a3e2-7f6d5c4b3a19'),
    (NEWID(), 'Highway to Hell', 'c1b9a8e7-6d5c-4b4a-a3e2-7f6d5c4b3a19');