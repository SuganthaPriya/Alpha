
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/20/2018 18:06:55
-- Generated from EDMX file: C:\Users\M1047455\Desktop\TrainerConsultancy\TrainerConsultancy\Models\TrainerProjection.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TrainerConsultancy];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Trainer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Trainer];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Projections'
CREATE TABLE [dbo].[Projections] (
    [ProjectionID] int IDENTITY(1,1) NOT NULL,
    [VendorID] int  NULL,
    [TrainerID] int  NULL,
    [ProjectFrom] datetime  NULL,
    [ProjectTo] datetime  NULL
);
GO

-- Creating table 'Trainers'
CREATE TABLE [dbo].[Trainers] (
    [TrainerID] int IDENTITY(1,1) NOT NULL,
    [TrainerName] nvarchar(50)  NULL,
    [Experience] int  NULL,
    [Location] nvarchar(50)  NULL,
    [AvailableFrom] datetime  NULL,
    [AvailableTo] datetime  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ProjectionID] in table 'Projections'
ALTER TABLE [dbo].[Projections]
ADD CONSTRAINT [PK_Projections]
    PRIMARY KEY CLUSTERED ([ProjectionID] ASC);
GO

-- Creating primary key on [TrainerID] in table 'Trainers'
ALTER TABLE [dbo].[Trainers]
ADD CONSTRAINT [PK_Trainers]
    PRIMARY KEY CLUSTERED ([TrainerID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [TrainerID] in table 'Projections'
ALTER TABLE [dbo].[Projections]
ADD CONSTRAINT [FK_Projection_Trainer]
    FOREIGN KEY ([TrainerID])
    REFERENCES [dbo].[Trainers]
        ([TrainerID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Projection_Trainer'
CREATE INDEX [IX_FK_Projection_Trainer]
ON [dbo].[Projections]
    ([TrainerID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------