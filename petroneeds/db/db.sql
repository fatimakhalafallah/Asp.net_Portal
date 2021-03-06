/****** Object:  Table [dbo].[tbl_News]    Script Date: 08/07/2013 16:02:30 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_News]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_News]
GO
/****** Object:  Table [dbo].[User_Check]    Script Date: 08/07/2013 16:02:30 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User_Check]') AND type in (N'U'))
DROP TABLE [dbo].[User_Check]
GO
/****** Object:  Table [dbo].[tbl_WebMenu]    Script Date: 08/07/2013 16:02:30 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_WebMenu]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_WebMenu]
GO
/****** Object:  Table [dbo].[tbl_WebMenu]    Script Date: 08/07/2013 16:02:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_WebMenu]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_WebMenu](
	[MenuID] [bigint] NULL,
	[MenuName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MenuLocation] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ParentID] [bigint] NULL
)
END
GO
INSERT [dbo].[tbl_WebMenu] ([MenuID], [MenuName], [MenuLocation], [ParentID]) VALUES (1, N'Human Resource', N'#', 0)
INSERT [dbo].[tbl_WebMenu] ([MenuID], [MenuName], [MenuLocation], [ParentID]) VALUES (11, N'Leave Request', N'~/UsersArea/leave.aspx', 1)
INSERT [dbo].[tbl_WebMenu] ([MenuID], [MenuName], [MenuLocation], [ParentID]) VALUES (12, N'Travel Request', N'~/UsersArea/Travel.aspx', 1)
INSERT [dbo].[tbl_WebMenu] ([MenuID], [MenuName], [MenuLocation], [ParentID]) VALUES (13, N'Salary Advance', N'~/UsersArea/Salary_Advance.aspx', 1)
INSERT [dbo].[tbl_WebMenu] ([MenuID], [MenuName], [MenuLocation], [ParentID]) VALUES (14, N'Recruitment', N'~/UsersArea/Recruitment.aspx', 1)
INSERT [dbo].[tbl_WebMenu] ([MenuID], [MenuName], [MenuLocation], [ParentID]) VALUES (2, N'Information Technology', N'#', 0)
INSERT [dbo].[tbl_WebMenu] ([MenuID], [MenuName], [MenuLocation], [ParentID]) VALUES (21, N'Hardware', NULL, 2)
INSERT [dbo].[tbl_WebMenu] ([MenuID], [MenuName], [MenuLocation], [ParentID]) VALUES (22, N'Software', NULL, 2)
/****** Object:  Table [dbo].[User_Check]    Script Date: 08/07/2013 16:02:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User_Check]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[User_Check](
	[EmpNumber] [bigint] NULL,
	[MenuID] [bigint] NULL,
	[Status] [int] NULL
)
END
GO
INSERT [dbo].[User_Check] ([EmpNumber], [MenuID], [Status]) VALUES (8080, 1, 1)
INSERT [dbo].[User_Check] ([EmpNumber], [MenuID], [Status]) VALUES (8080, 11, 1)
INSERT [dbo].[User_Check] ([EmpNumber], [MenuID], [Status]) VALUES (8080, 12, 1)
INSERT [dbo].[User_Check] ([EmpNumber], [MenuID], [Status]) VALUES (8080, 13, 1)
INSERT [dbo].[User_Check] ([EmpNumber], [MenuID], [Status]) VALUES (8080, 14, 1)
INSERT [dbo].[User_Check] ([EmpNumber], [MenuID], [Status]) VALUES (8080, 2, 1)
INSERT [dbo].[User_Check] ([EmpNumber], [MenuID], [Status]) VALUES (8080, 21, 0)
INSERT [dbo].[User_Check] ([EmpNumber], [MenuID], [Status]) VALUES (8080, 22, 0)
/****** Object:  Table [dbo].[tbl_News]    Script Date: 08/07/2013 16:02:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_News]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_News](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[NewTitle] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[newsDetail] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[dateCreated] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[image] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[status] [bigint] NULL,
 CONSTRAINT [PK_tbl_News] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[tbl_News] ON
INSERT [dbo].[tbl_News] ([id], [NewTitle], [newsDetail], [dateCreated], [image], [status]) VALUES (1, N'AC Milan''s Mario Balotelli banned for three matches', N' The 22-year-old had already picked up a one-match suspension after being shown his fourth yellow of the season in the 2-2 draw. The 22-year-old had already picked up a one-match suspension after being shown his fourth yellow of the season in the 2-2 draw. The 22-year-old had already picked up a one-match suspension after being shown his fourth yellow of the season in the 2-2 draw. The 22-year-old had already picked up a one-match suspension after being shown his fourth yellow of the season in the 2-2 draw. The 22-year-old had already picked up a one-match suspension after being shown his fourth yellow of the season in the 2-2 draw. The 22-year-old had already picked up a one-match suspension after being shown his fourth yellow of the season in the 2-2 draw. The 22-year-old had already picked up a one-match suspension after being shown his fourth yellow of the season in the 2-2 draw.', N'11-4-2013', N'~/news_image/Chrysanthemum.jpg', 0)
INSERT [dbo].[tbl_News] ([id], [NewTitle], [newsDetail], [dateCreated], [image], [status]) VALUES (2, N'Borussia Dortmund scored twice in injury time to snatch a dramatic Champions League victory over Malaga and secure a place in the semi-finals. ', N' Substitute Eliseu looked to have scored Malaga''s winner before the late goals.  Substitute Eliseu looked to have scored Malaga''s winner before the late goals.  Substitute Eliseu looked to have scored Malaga''s winner before the late goals. Substitute Eliseu looked to have scored Malaga''s winner before the late goals. Substitute Eliseu looked to have scored Malaga''s winner before the late goals. Substitute Eliseu looked to have scored Malaga''s winner before the late goals. Substitute Eliseu looked to have scored Malaga''s winner before the late goals. Substitute Eliseu looked to have scored Malaga''s winner before the late goals. Substitute Eliseu looked to have scored Malaga''s winner before the late goals.', N'12-4-2013', N'~/news_image/Chrysanthemum.jpg', 0)
INSERT [dbo].[tbl_News] ([id], [NewTitle], [newsDetail], [dateCreated], [image], [status]) VALUES (3, N'aabbvvvv', N'asdfgggggggggggggggggg', N'07-08-2013', N'~/news_image/a-to-b.jpg', 0)
SET IDENTITY_INSERT [dbo].[tbl_News] OFF
