-- Criação do banco de dados
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'SinapseDB')
BEGIN
    CREATE DATABASE SinapseDB;
END
GO

USE SinapseDB;
GO

-- Tabela de Usuários
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Users')
BEGIN
    CREATE TABLE Users (
        UserId INT IDENTITY(1,1) PRIMARY KEY,
        Name NVARCHAR(100) NOT NULL,
        Email NVARCHAR(255) NOT NULL,
        PasswordHash NVARCHAR(255) NOT NULL,
        Biography NVARCHAR(500),
        ProfilePhotoUrl NVARCHAR(255),
        CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
        UpdatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
        CONSTRAINT UQ_Users_Email UNIQUE (Email)
    );

    -- Índice para busca por email (login) e nome (pesquisa)
    CREATE INDEX IX_Users_Email ON Users(Email);
    CREATE INDEX IX_Users_Name ON Users(Name);
END

-- Tabela de Comunidades
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Communities')
BEGIN
    CREATE TABLE Communities (
        CommunityId INT IDENTITY(1,1) PRIMARY KEY,
        Name NVARCHAR(100) NOT NULL,
        Hashtag NVARCHAR(50) NOT NULL,
        Description NVARCHAR(500),
        CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
        CreatedByUserId INT NOT NULL,
        CONSTRAINT UQ_Communities_Hashtag UNIQUE (Hashtag),
        CONSTRAINT FK_Communities_Users FOREIGN KEY (CreatedByUserId) 
            REFERENCES Users(UserId) ON DELETE NO ACTION
    );

    -- Índice para busca por hashtag
    CREATE INDEX IX_Communities_Hashtag ON Communities(Hashtag);
END

-- Tabela de Posts
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Posts')
BEGIN
    CREATE TABLE Posts (
        PostId INT IDENTITY(1,1) PRIMARY KEY,
        UserId INT NOT NULL,
        CommunityId INT NOT NULL,
        Content NVARCHAR(MAX) NOT NULL,
        ImageUrl NVARCHAR(255),
        CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
        UpdatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
        CONSTRAINT FK_Posts_Users FOREIGN KEY (UserId) 
            REFERENCES Users(UserId) ON DELETE NO ACTION,
        CONSTRAINT FK_Posts_Communities FOREIGN KEY (CommunityId) 
            REFERENCES Communities(CommunityId) ON DELETE NO ACTION
    );

    -- Índices para posts
    CREATE INDEX IX_Posts_UserId ON Posts(UserId);
    CREATE INDEX IX_Posts_CommunityId ON Posts(CommunityId);
    CREATE INDEX IX_Posts_CreatedAt ON Posts(CreatedAt);
END

-- Tabela de Curtidas
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Likes')
BEGIN
    CREATE TABLE Likes (
        LikeId INT IDENTITY(1,1) PRIMARY KEY,
        PostId INT NOT NULL,
        UserId INT NOT NULL,
        CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
        CONSTRAINT FK_Likes_Posts FOREIGN KEY (PostId) 
            REFERENCES Posts(PostId) ON DELETE CASCADE,
        CONSTRAINT FK_Likes_Users FOREIGN KEY (UserId) 
            REFERENCES Users(UserId) ON DELETE NO ACTION,
        CONSTRAINT UQ_Likes_PostUser UNIQUE (PostId, UserId)
    );
END

-- Tabela de Comentários
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Comments')
BEGIN
    CREATE TABLE Comments (
        CommentId INT IDENTITY(1,1) PRIMARY KEY,
        PostId INT NOT NULL,
        UserId INT NOT NULL,
        Content NVARCHAR(500) NOT NULL,
        CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
        UpdatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
        CONSTRAINT FK_Comments_Posts FOREIGN KEY (PostId) 
            REFERENCES Posts(PostId) ON DELETE CASCADE,
        CONSTRAINT FK_Comments_Users FOREIGN KEY (UserId) 
            REFERENCES Users(UserId) ON DELETE NO ACTION
    );
END

-- Tabela de Conexões (Amizades)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Connections')
BEGIN
    CREATE TABLE Connections (
        ConnectionId INT IDENTITY(1,1) PRIMARY KEY,
        RequesterId INT NOT NULL,
        AddresseeId INT NOT NULL,
        Status NVARCHAR(20) NOT NULL CHECK (Status IN ('Pending', 'Accepted', 'Rejected')),
        CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
        UpdatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
        CONSTRAINT FK_Connections_Requester FOREIGN KEY (RequesterId) 
            REFERENCES Users(UserId) ON DELETE NO ACTION,
        CONSTRAINT FK_Connections_Addressee FOREIGN KEY (AddresseeId) 
            REFERENCES Users(UserId) ON DELETE NO ACTION,
        CONSTRAINT UQ_Connections_Users UNIQUE (RequesterId, AddresseeId)
    );
END

-- Tabela de Mensagens Diretas
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'DirectMessages')
BEGIN
    CREATE TABLE DirectMessages (
        MessageId INT IDENTITY(1,1) PRIMARY KEY,
        SenderId INT NOT NULL,
        ReceiverId INT NOT NULL,
        Content NVARCHAR(MAX) NOT NULL,
        CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
        IsRead BIT NOT NULL DEFAULT 0,
        CONSTRAINT FK_DirectMessages_Sender FOREIGN KEY (SenderId) 
            REFERENCES Users(UserId) ON DELETE NO ACTION,
        CONSTRAINT FK_DirectMessages_Receiver FOREIGN KEY (ReceiverId) 
            REFERENCES Users(UserId) ON DELETE NO ACTION
    );

    -- Índices para mensagens
    CREATE INDEX IX_DirectMessages_SenderId ON DirectMessages(SenderId);
    CREATE INDEX IX_DirectMessages_ReceiverId ON DirectMessages(ReceiverId);
    CREATE INDEX IX_DirectMessages_CreatedAt ON DirectMessages(CreatedAt);
END

-- Tabela de Troca de Habilidades (SkillSwap)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'SkillSwaps')
BEGIN
    CREATE TABLE SkillSwaps (
        SkillSwapId INT IDENTITY(1,1) PRIMARY KEY,
        RequesterId INT NOT NULL,
        AddresseeId INT NOT NULL,
        Description NVARCHAR(500) NOT NULL,
        Status NVARCHAR(20) NOT NULL CHECK (Status IN ('Pending', 'Accepted', 'Rejected')),
        CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
        UpdatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
        CONSTRAINT FK_SkillSwaps_Requester FOREIGN KEY (RequesterId) 
            REFERENCES Users(UserId) ON DELETE NO ACTION,
        CONSTRAINT FK_SkillSwaps_Addressee FOREIGN KEY (AddresseeId) 
            REFERENCES Users(UserId) ON DELETE NO ACTION
    );
END

-- Tabela de Notificações
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Notifications')
BEGIN
    CREATE TABLE Notifications (
        NotificationId INT IDENTITY(1,1) PRIMARY KEY,
        UserId INT NOT NULL,
        Type NVARCHAR(50) NOT NULL,
        Content NVARCHAR(500) NOT NULL,
        RelatedId INT, -- ID do item relacionado (post, mensagem, etc.)
        IsRead BIT NOT NULL DEFAULT 0,
        CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
        CONSTRAINT FK_Notifications_Users FOREIGN KEY (UserId) 
            REFERENCES Users(UserId) ON DELETE CASCADE
    );

    -- Índices para notificações
    CREATE INDEX IX_Notifications_UserId ON Notifications(UserId);
    CREATE INDEX IX_Notifications_CreatedAt ON Notifications(CreatedAt);
END

-- Criação dos Triggers (apenas se não existirem)
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE name = 'TR_Users_UpdatedAt')
BEGIN
    EXEC('CREATE TRIGGER TR_Users_UpdatedAt
    ON Users
    AFTER UPDATE
    AS
    BEGIN
        UPDATE Users
        SET UpdatedAt = GETDATE()
        FROM Users u
        INNER JOIN inserted i ON u.UserId = i.UserId;
    END');
END

IF NOT EXISTS (SELECT * FROM sys.triggers WHERE name = 'TR_Posts_UpdatedAt')
BEGIN
    EXEC('CREATE TRIGGER TR_Posts_UpdatedAt
    ON Posts
    AFTER UPDATE
    AS
    BEGIN
        UPDATE Posts
        SET UpdatedAt = GETDATE()
        FROM Posts p
        INNER JOIN inserted i ON p.PostId = i.PostId;
    END');
END

IF NOT EXISTS (SELECT * FROM sys.triggers WHERE name = 'TR_Comments_UpdatedAt')
BEGIN
    EXEC('CREATE TRIGGER TR_Comments_UpdatedAt
    ON Comments
    AFTER UPDATE
    AS
    BEGIN
        UPDATE Comments
        SET UpdatedAt = GETDATE()
        FROM Comments c
        INNER JOIN inserted i ON c.CommentId = i.CommentId;
    END');
END

IF NOT EXISTS (SELECT * FROM sys.triggers WHERE name = 'TR_Comments_Notification')
BEGIN
    EXEC('CREATE TRIGGER TR_Comments_Notification
    ON Comments
    AFTER INSERT
    AS
    BEGIN
        INSERT INTO Notifications (UserId, Type, Content, RelatedId, CreatedAt)
        SELECT 
            p.UserId,
            ''Comment'',
            CONCAT(u.Name, '' comentou em sua publicação''),
            i.PostId,
            GETDATE()
        FROM inserted i
        INNER JOIN Posts p ON i.PostId = p.PostId
        INNER JOIN Users u ON i.UserId = u.UserId
        WHERE p.UserId != i.UserId;
    END');
END

IF NOT EXISTS (SELECT * FROM sys.triggers WHERE name = 'TR_Likes_Notification')
BEGIN
    EXEC('CREATE TRIGGER TR_Likes_Notification
    ON Likes
    AFTER INSERT
    AS
    BEGIN
        INSERT INTO Notifications (UserId, Type, Content, RelatedId, CreatedAt)
        SELECT 
            p.UserId,
            ''Like'',
            CONCAT(u.Name, '' curtiu sua publicação''),
            i.PostId,
            GETDATE()
        FROM inserted i
        INNER JOIN Posts p ON i.PostId = p.PostId
        INNER JOIN Users u ON i.UserId = u.UserId
        WHERE p.UserId != i.UserId;
    END');
END

IF NOT EXISTS (SELECT * FROM sys.triggers WHERE name = 'TR_DirectMessages_Notification')
BEGIN
    EXEC('CREATE TRIGGER TR_DirectMessages_Notification
    ON DirectMessages
    AFTER INSERT
    AS
    BEGIN
        INSERT INTO Notifications (UserId, Type, Content, RelatedId, CreatedAt)
        SELECT 
            i.ReceiverId,
            ''Message'',
            CONCAT(u.Name, '' enviou uma mensagem para você''),
            i.MessageId,
            GETDATE()
        FROM inserted i
        INNER JOIN Users u ON i.SenderId = u.UserId;
    END');
END

IF NOT EXISTS (SELECT * FROM sys.triggers WHERE name = 'TR_SkillSwaps_Notification')
BEGIN
    EXEC('CREATE TRIGGER TR_SkillSwaps_Notification
    ON SkillSwaps
    AFTER INSERT
    AS
    BEGIN
        INSERT INTO Notifications (UserId, Type, Content, RelatedId, CreatedAt)
        SELECT 
            i.AddresseeId,
            ''SkillSwap'',
            CONCAT(u.Name, '' enviou uma solicitação de troca de habilidades''),
            i.SkillSwapId,
            GETDATE()
        FROM inserted i
        INNER JOIN Users u ON i.RequesterId = u.UserId;
    END');
END

PRINT 'Banco de dados configurado com sucesso!'; 