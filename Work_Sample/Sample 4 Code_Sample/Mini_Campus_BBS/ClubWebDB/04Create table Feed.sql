USE [F:\WEB\PROGRAM\CLUBWEBDB\CLUBWEBDB.MDF]
GO

/****** Object:  Table [dbo].[Feed]    Script Date: 2014/1/15 12:16:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Feed](
	[FeedID] [int] IDENTITY(0,1) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[FeedText] [varchar](500) NOT NULL,
	[PosterID] [char](10) NOT NULL,
	[PostTime] [datetime] NOT NULL,
	[ImageID] [char](10) NULL,
	[FeedStatus] [bit] NOT NULL,
	[ImageStatus] [bit] NULL,
 CONSTRAINT [PK_Feed] PRIMARY KEY CLUSTERED 
(
	[FeedID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Feed]  WITH CHECK ADD  CONSTRAINT [FK_Feed_User] FOREIGN KEY([PosterID])
REFERENCES [dbo].[User] ([UserID])
GO

ALTER TABLE [dbo].[Feed] CHECK CONSTRAINT [FK_Feed_User]
GO


