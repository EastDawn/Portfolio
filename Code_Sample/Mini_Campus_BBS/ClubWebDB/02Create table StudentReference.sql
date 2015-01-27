USE [F:\WEB\PROGRAM\CLUBWEBDB\CLUBWEBDB.MDF]
GO

/****** Object:  Table [dbo].[StudentReference]    Script Date: 2014/1/15 12:16:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[StudentReference](
	[StudentID] [char](10) NOT NULL,
	[StudentName] [varchar](10) NOT NULL,
 CONSTRAINT [PK_StudentReference] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


