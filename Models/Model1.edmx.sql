
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/12/2021 23:01:00
-- Generated from EDMX file: C:\Users\64249\source\repos\20S2_5032_A2_4\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Database1];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'patientSet'
CREATE TABLE [dbo].[patientSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [f_name] nvarchar(max)  NOT NULL,
    [l_name] nvarchar(max)  NOT NULL,
    [address] nvarchar(max)  NOT NULL,
    [phone] nvarchar(max)  NOT NULL,
    [email] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'clinicalSet'
CREATE TABLE [dbo].[clinicalSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [patientId] int  NOT NULL,
    [doctorId] int  NOT NULL
);
GO

-- Creating table 'doctorSet'
CREATE TABLE [dbo].[doctorSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [f_name] nvarchar(max)  NOT NULL,
    [l_name] nvarchar(max)  NOT NULL,
    [email] nvarchar(max)  NOT NULL,
    [phone] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'patientSet'
ALTER TABLE [dbo].[patientSet]
ADD CONSTRAINT [PK_patientSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'clinicalSet'
ALTER TABLE [dbo].[clinicalSet]
ADD CONSTRAINT [PK_clinicalSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'doctorSet'
ALTER TABLE [dbo].[doctorSet]
ADD CONSTRAINT [PK_doctorSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [patientId] in table 'clinicalSet'
ALTER TABLE [dbo].[clinicalSet]
ADD CONSTRAINT [FK_patientclinical]
    FOREIGN KEY ([patientId])
    REFERENCES [dbo].[patientSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_patientclinical'
CREATE INDEX [IX_FK_patientclinical]
ON [dbo].[clinicalSet]
    ([patientId]);
GO

-- Creating foreign key on [doctorId] in table 'clinicalSet'
ALTER TABLE [dbo].[clinicalSet]
ADD CONSTRAINT [FK_doctorclinical]
    FOREIGN KEY ([doctorId])
    REFERENCES [dbo].[doctorSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_doctorclinical'
CREATE INDEX [IX_FK_doctorclinical]
ON [dbo].[clinicalSet]
    ([doctorId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------