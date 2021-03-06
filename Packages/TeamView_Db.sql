USE [TeamView_Db]
GO
/****** Object:  Table [dbo].[bugInfo]    Script Date: 03/30/2012 10:46:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[bugInfo](
	[version] [varchar](15) NOT NULL,
	[bugNum] [varchar](20) NOT NULL,
	[bugStatus] [varchar](20) NULL,
	[dealMan] [varchar](20) NULL,
	[createdTime] [datetime] NOT NULL,
	[description] [varchar](500) NULL,
	[size] [int] NOT NULL,
	[fired] [int] NOT NULL,
	[timeStamp] [datetime] NOT NULL,
	[priority] [smallint] NOT NULL,
	[hardLevel] [smallint] NOT NULL,
	[latestStartTime] [datetime] NULL,
	[Doc] [image] NULL,
 CONSTRAINT [PK_bugInfo] PRIMARY KEY CLUSTERED 
(
	[bugNum] ASC
) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[keyInfo]    Script Date: 03/30/2012 10:46:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[keyInfo](
	[keyName] [nchar](10) NOT NULL,
	[num] [bigint] NOT NULL,
 CONSTRAINT [PK_keyInfo] PRIMARY KEY CLUSTERED 
(
	[keyName] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChangeLog]    Script Date: 03/30/2012 10:46:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ChangeLog](
	[LogID] [bigint] IDENTITY(1,1) NOT NULL,
	[BugNum] [varchar](20) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[Description] [varchar](80) NOT NULL,
	[LogTypeID] [int] NOT NULL,
 CONSTRAINT [PK_ChangeLog] PRIMARY KEY CLUSTERED 
(
	[LogID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Default [DF_bugInfo_createdTime]    Script Date: 03/30/2012 10:46:00 ******/
ALTER TABLE [dbo].[bugInfo] ADD  CONSTRAINT [DF_bugInfo_createdTime]  DEFAULT (getdate()) FOR [createdTime]
GO
/****** Object:  Default [DF_bugInfo_size]    Script Date: 03/30/2012 10:46:00 ******/
ALTER TABLE [dbo].[bugInfo] ADD  CONSTRAINT [DF_bugInfo_size]  DEFAULT ((0)) FOR [size]
GO
/****** Object:  Default [DF_bugInfo_fired]    Script Date: 03/30/2012 10:46:00 ******/
ALTER TABLE [dbo].[bugInfo] ADD  CONSTRAINT [DF_bugInfo_fired]  DEFAULT ((0)) FOR [fired]
GO
/****** Object:  Default [DF_bugInfo_timeStamp]    Script Date: 03/30/2012 10:46:00 ******/
ALTER TABLE [dbo].[bugInfo] ADD  CONSTRAINT [DF_bugInfo_timeStamp]  DEFAULT (getdate()) FOR [timeStamp]
GO
/****** Object:  Default [DF_bugInfo_priority]    Script Date: 03/30/2012 10:46:00 ******/
ALTER TABLE [dbo].[bugInfo] ADD  CONSTRAINT [DF_bugInfo_priority]  DEFAULT ((4)) FOR [priority]
GO
/****** Object:  Default [DF_bugInfo_hardLevel]    Script Date: 03/30/2012 10:46:00 ******/
ALTER TABLE [dbo].[bugInfo] ADD  CONSTRAINT [DF_bugInfo_hardLevel]  DEFAULT ((0)) FOR [hardLevel]
GO
/****** Object:  Default [DF_ChangeLog_CreateDate]    Script Date: 03/30/2012 10:46:00 ******/
ALTER TABLE [dbo].[ChangeLog] ADD  CONSTRAINT [DF_ChangeLog_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
/****** Object:  Default [DF_ChangeLog_LogTypeID]    Script Date: 03/30/2012 10:46:00 ******/
ALTER TABLE [dbo].[ChangeLog] ADD  CONSTRAINT [DF_ChangeLog_LogTypeID]  DEFAULT ((0)) FOR [LogTypeID]
GO
/****** Object:  ForeignKey [FK_ChangeLog_bugInfo]    Script Date: 03/30/2012 10:46:00 ******/
ALTER TABLE [dbo].[ChangeLog]  WITH CHECK ADD  CONSTRAINT [FK_ChangeLog_bugInfo] FOREIGN KEY([BugNum])
REFERENCES [dbo].[bugInfo] ([bugNum])
GO
ALTER TABLE [dbo].[ChangeLog] CHECK CONSTRAINT [FK_ChangeLog_bugInfo]
GO
