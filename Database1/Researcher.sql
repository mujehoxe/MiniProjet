CREATE TABLE [dbo].[Researcher]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FullName] NCHAR(10) NULL, 
    [Specialty] NCHAR(10) NULL, 
    [TeamId] NCHAR(10) NULL, 
    [IsLead] BIT NULL DEFAULT 0
)
