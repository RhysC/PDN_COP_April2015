CREATE TABLE [Employee](
       [Id] [int] IDENTITY(1,1) NOT NULL,
       [Name] [varchar](255) NOT NULL,
       [Email] [varchar](255) NOT NULL
CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
       [Id] ASC
)
)

GO

GRANT SELECT, INSERT, UPDATE, DELETE ON [Employee] TO [employeemanagementuser]
GO
