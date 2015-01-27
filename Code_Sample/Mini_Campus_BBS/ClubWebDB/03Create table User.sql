USE [F:\WEB\PROGRAM\CLUBWEBDB\CLUBWEBDB.MDF]
GO

/****** Object:  Table [dbo].[User]    Script Date: 2014/1/15 12:17:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[User](
	[UserID] [char](10) NOT NULL,
	[UserName] [varchar](10) NOT NULL,
	[Password] [varchar](16) NOT NULL,
	[Identification] [bit] NOT NULL,
	[UserStatus] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_StudentReference] FOREIGN KEY([UserID])
REFERENCES [dbo].[StudentReference] ([StudentID])
GO

ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_StudentReference]
GO


