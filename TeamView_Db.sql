SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [bugInfo](
	[version] [varchar](15) NOT NULL,
	[bugNum] [varchar](20) NOT NULL,
	[bugStatus] [varchar](20) NULL,
	[dealMan] [varchar](20) NULL,
	[createdTime] [datetime] NOT NULL,
	[description] [varchar](200) NULL,
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
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [keyInfo](
	[keyName] [nchar](10) NOT NULL,
	[num] [bigint] NOT NULL,
 CONSTRAINT [PK_keyInfo] PRIMARY KEY CLUSTERED 
(
	[keyName] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [ChangeLog](
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
ALTER TABLE [bugInfo] ADD  CONSTRAINT [DF_bugInfo_createdTime]  DEFAULT (getdate()) FOR [createdTime]
GO
ALTER TABLE [bugInfo] ADD  CONSTRAINT [DF_bugInfo_size]  DEFAULT ((0)) FOR [size]
GO
ALTER TABLE [bugInfo] ADD  CONSTRAINT [DF_bugInfo_fired]  DEFAULT ((0)) FOR [fired]
GO
ALTER TABLE [bugInfo] ADD  CONSTRAINT [DF_bugInfo_timeStamp]  DEFAULT (getdate()) FOR [timeStamp]
GO
ALTER TABLE [bugInfo] ADD  CONSTRAINT [DF_bugInfo_priority]  DEFAULT ((4)) FOR [priority]
GO
ALTER TABLE [bugInfo] ADD  CONSTRAINT [DF_bugInfo_hardLevel]  DEFAULT ((0)) FOR [hardLevel]
GO
ALTER TABLE [ChangeLog] ADD  CONSTRAINT [DF_ChangeLog_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [ChangeLog] ADD  CONSTRAINT [DF_ChangeLog_LogTypeID]  DEFAULT ((0)) FOR [LogTypeID]
GO
ALTER TABLE [ChangeLog]  WITH CHECK ADD  CONSTRAINT [FK_ChangeLog_bugInfo] FOREIGN KEY([BugNum])
REFERENCES [bugInfo] ([bugNum])
GO
ALTER TABLE [ChangeLog] CHECK CONSTRAINT [FK_ChangeLog_bugInfo]
GO
