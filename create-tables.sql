-- Create a new table called '[ApplicationLog]' in schema '[dbo]'
-- Drop  table if  exists
IF OBJECT_ID('[dbo].[RequestLog]', 'U') IS NOT NULL
DROP TABLE [dbo].[RequestLog]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[RequestLog]
(
    [Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, -- Primary Key column
    [RequestedAt] DATETIME  NULL DEFAULT(getdate()),
    [JsonRequest] NVARCHAR(MAX) NOT NULL,
    [JsonResponse] NVARCHAR(MAX) NOT NULL
);
GO