USE [F:\WEB\PROGRAM\CLUBWEBDB\CLUBWEBDB.MDF]
GO

/****** Object:  Table [dbo].[Comment]    Script Date: 2014/1/15 12:15:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Comment](
	[FeedID] [int] NOT NULL,
	[CommentNumber] [int] IDENTITY(0,1) NOT NULL,
	[CommentText] [varchar](120) NOT NULL,
	[CommenterID] [char](10) NOT NULL,
	[CommentTime] [datetime] NOT NULL,
	[CommentStatus] [bit] NOT NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[FeedID] ASC,
	[CommentNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Feed] FOREIGN KEY([FeedID])
REFERENCES [dbo].[Feed] ([FeedID])
GO

ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Feed]
GO

ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_User] FOREIGN KEY([CommenterID])
REFERENCES [dbo].[User] ([UserID])
GO

ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_User]
GO


