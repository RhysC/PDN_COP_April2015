CREATE TABLE [Employee](
       [Id] [int] IDENTITY(1,1) NOT NULL,
       [Name] [varchar](255) NULL,
       [Email] [varchar](255) NULL
CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
       [Id] ASC
)
)

GO

GRANT INSERT, UPDATE, DELETE ON [Employee] TO [employeemanagementuser]
GO
