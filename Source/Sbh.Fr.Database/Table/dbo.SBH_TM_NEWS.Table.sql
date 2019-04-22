SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SBH_TM_NEWS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TITLE] [varchar](100) NOT NULL,
	[DESCRIPTION] [varchar](max) NULL,
	[CATEGORY_ID] [int] NOT NULL,
	[FILE_IMAGE1] [varchar](100) NULL,
	[FILE_IMAGE2] [varchar](100) NULL,
	[FILE_IMAGE3] [varchar](100) NULL,
	[FILE_IMAGE4] [varchar](100) NULL,
	[TEMPLATE] [varchar](10) NULL,
	[CREATED_TIME] [datetime] NOT NULL,
	[CREATED_BY] [varchar](50) NOT NULL,
	[LAST_MODIFIED_TIME] [datetime] NULL,
	[LAST_MODIFIED_BY] [varchar](50) NULL,
	[ROW_STATUS] [int] NOT NULL,
 CONSTRAINT [PK__SBH_TM_N__3214EC27114D51EF] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[SBH_TM_NEWS] ADD  CONSTRAINT [DF__SBH_TM_NE__CREAT__0C85DE4D]  DEFAULT (sysdatetime()) FOR [CREATED_TIME]
GO
ALTER TABLE [dbo].[SBH_TM_NEWS] ADD  CONSTRAINT [DF__SBH_TM_NE__ROW_S__0D7A0286]  DEFAULT ((0)) FOR [ROW_STATUS]
GO
