USE [master]
GO
/****** Object:  Database [ODTS_DB]    Script Date: 10/10/2018 8:01:02 CH ******/
CREATE DATABASE [ODTS_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ODTS_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ODTS_DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ODTS_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ODTS_DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ODTS_DB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ODTS_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ODTS_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ODTS_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ODTS_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ODTS_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ODTS_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ODTS_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ODTS_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ODTS_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ODTS_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ODTS_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ODTS_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ODTS_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ODTS_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ODTS_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ODTS_DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ODTS_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ODTS_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ODTS_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ODTS_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ODTS_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ODTS_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ODTS_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ODTS_DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ODTS_DB] SET  MULTI_USER 
GO
ALTER DATABASE [ODTS_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ODTS_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ODTS_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ODTS_DB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ODTS_DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ODTS_DB] SET QUERY_STORE = OFF
GO
USE [ODTS_DB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [ODTS_DB]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 10/10/2018 8:01:02 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[AccountId] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[IsDelete] [bit] NOT NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Agency]    Script Date: 10/10/2018 8:01:02 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agency](
	[AgencyId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NULL,
	[AccountId] [int] NOT NULL,
	[AgencyName] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](250) NULL,
	[Telephone] [nvarchar](50) NULL,
	[IsDelete] [bit] NOT NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_Agency] PRIMARY KEY CLUSTERED 
(
	[AgencyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 10/10/2018 8:01:02 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[CompanyId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[IsDelete] [bit] NOT NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contract]    Script Date: 10/10/2018 8:01:02 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contract](
	[ContractId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[ContractName] [nvarchar](50) NOT NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[IsDelete] [bit] NOT NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_Contract] PRIMARY KEY CLUSTERED 
(
	[ContractId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContractServiceITSupport]    Script Date: 10/10/2018 8:01:02 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContractServiceITSupport](
	[ContractServiceITSupportId] [int] IDENTITY(1,1) NOT NULL,
	[ContractId] [int] NOT NULL,
	[ServiceITSupportId] [int] NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[IsDelete] [bit] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_ContractService_1] PRIMARY KEY CLUSTERED 
(
	[ContractServiceITSupportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Device]    Script Date: 10/10/2018 8:01:02 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Device](
	[DeviceId] [int] IDENTITY(1,1) NOT NULL,
	[AgencyId] [int] NOT NULL,
	[DeviceTypeId] [int] NOT NULL,
	[DeviceName] [nvarchar](50) NOT NULL,
	[DeviceCode] [nvarchar](50) NULL,
	[GuarantyStartDate] [datetime] NULL,
	[GuarantyEndDate] [datetime] NULL,
	[Ip] [nvarchar](50) NULL,
	[Port] [nvarchar](50) NULL,
	[DeviceAccount] [nvarchar](50) NULL,
	[DevicePassword] [nvarchar](50) NULL,
	[SettingDate] [datetime] NULL,
	[Other] [nvarchar](max) NULL,
	[IsDelete] [bit] NOT NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_Device] PRIMARY KEY CLUSTERED 
(
	[DeviceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeviceType]    Script Date: 10/10/2018 8:01:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeviceType](
	[DeviceTypeId] [int] IDENTITY(1,1) NOT NULL,
	[DeviceTypeName] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[IsDelete] [bit] NOT NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_DeviceType] PRIMARY KEY CLUSTERED 
(
	[DeviceTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Guideline]    Script Date: 10/10/2018 8:01:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Guideline](
	[GuidelineId] [int] IDENTITY(1,1) NOT NULL,
	[ServiceItemId] [int] NULL,
	[GuidelineName] [nvarchar](50) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [date] NULL,
	[IsDelete] [bit] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_Guideline] PRIMARY KEY CLUSTERED 
(
	[GuidelineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ITSupporter]    Script Date: 10/10/2018 8:01:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ITSupporter](
	[ITSupporterId] [int] IDENTITY(1,1) NOT NULL,
	[ITSupporterName] [nvarchar](50) NULL,
	[AccountId] [int] NULL,
	[Telephone] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Gender] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[RatingAVG] [float] NULL,
	[IsBusy] [bit] NULL,
	[IsDelete] [bit] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_ITSupporter] PRIMARY KEY CLUSTERED 
(
	[ITSupporterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Request]    Script Date: 10/10/2018 8:01:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Request](
	[RequestId] [int] IDENTITY(1,1) NOT NULL,
	[AgencyId] [int] NOT NULL,
	[RequestCategoryId] [int] NOT NULL,
	[RequestStatus] [int] NOT NULL,
	[RequestName] [nvarchar](50) NOT NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[Feedback] [nvarchar](max) NULL,
	[IsDelete] [bit] NOT NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_Ticket] PRIMARY KEY CLUSTERED 
(
	[RequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequestCategory]    Script Date: 10/10/2018 8:01:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestCategory](
	[RequestCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[RequestCategoryName] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[IsDelete] [bit] NOT NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_RequestCategory] PRIMARY KEY CLUSTERED 
(
	[RequestCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 10/10/2018 8:01:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceItem]    Script Date: 10/10/2018 8:01:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceItem](
	[ServiceItemId] [int] IDENTITY(1,1) NOT NULL,
	[ServiceId] [int] NULL,
	[IssueName] [nvarchar](50) NULL,
	[Price] [float] NULL,
	[IsDelete] [bit] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_ServiceItem] PRIMARY KEY CLUSTERED 
(
	[ServiceItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceITSupport]    Script Date: 10/10/2018 8:01:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceITSupport](
	[ServiceITSupportId] [int] IDENTITY(1,1) NOT NULL,
	[ServiceName] [nvarchar](50) NULL,
	[Description] [nchar](10) NULL,
	[IsDelete] [bit] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[ServiceITSupportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Skill]    Script Date: 10/10/2018 8:01:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Skill](
	[SkillId] [int] IDENTITY(1,1) NOT NULL,
	[ITSupportId] [int] NOT NULL,
	[ServiceItemId] [int] NULL,
	[MonthExperience] [int] NULL,
	[IsDelete] [bit] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_Skill_1] PRIMARY KEY CLUSTERED 
(
	[SkillId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ticket]    Script Date: 10/10/2018 8:01:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ticket](
	[TicketId] [int] IDENTITY(1,1) NOT NULL,
	[ServiceItemId] [int] NOT NULL,
	[RequestId] [int] NOT NULL,
	[DeviceId] [int] NOT NULL,
	[Desciption] [nvarchar](max) NULL,
	[Current_TicketStatus] [int] NULL,
	[CurrentITSupporter_Id] [int] NOT NULL,
	[Rating] [int] NULL,
	[Estimation] [float] NULL,
	[StartTime] [datetime] NULL,
	[Endtime] [datetime] NULL,
	[IsDelete] [bit] NOT NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_TicketDetail] PRIMARY KEY CLUSTERED 
(
	[TicketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TicketHistory]    Script Date: 10/10/2018 8:01:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TicketHistory](
	[TicketHistoryId] [int] IDENTITY(1,1) NOT NULL,
	[TicketId] [int] NOT NULL,
	[Pre_It_SupporterId] [int] NULL,
	[Pre_Status] [int] NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[IsDelete] [bit] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_TicketHistory] PRIMARY KEY CLUSTERED 
(
	[TicketHistoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TicketTask]    Script Date: 10/10/2018 8:01:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TicketTask](
	[TicketTaskId] [int] IDENTITY(1,1) NOT NULL,
	[TicketId] [int] NOT NULL,
	[TaskStatus] [int] NULL,
	[CreateByITSupporter] [int] NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[Priority] [int] NULL,
	[PreTaskCondition] [int] NULL,
	[IsDelete] [bit] NOT NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[TicketTaskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([AccountId], [RoleId], [Username], [Password], [IsDelete], [CreateDate], [UpdateDate]) VALUES (1, 3, N'47TCV', N'123456', 0, CAST(N'2018-10-03T00:00:00.000' AS DateTime), CAST(N'2018-10-03T00:00:00.000' AS DateTime))
INSERT [dbo].[Account] ([AccountId], [RoleId], [Username], [Password], [IsDelete], [CreateDate], [UpdateDate]) VALUES (2, 2, N'lehongan', N'123456', 0, CAST(N'2018-10-03T00:00:00.000' AS DateTime), CAST(N'2018-10-03T00:00:00.000' AS DateTime))
INSERT [dbo].[Account] ([AccountId], [RoleId], [Username], [Password], [IsDelete], [CreateDate], [UpdateDate]) VALUES (3, 1, N'admin', N'123456', 0, CAST(N'2018-10-03T00:00:00.000' AS DateTime), CAST(N'2018-10-03T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Account] OFF
SET IDENTITY_INSERT [dbo].[Agency] ON 

INSERT [dbo].[Agency] ([AgencyId], [CompanyId], [AccountId], [AgencyName], [Address], [Telephone], [IsDelete], [CreateDate], [UpdateDate]) VALUES (3, 1, 1, N'Passio 47 Trần Cao Vân', N'47 Trần Cao Vân', NULL, 0, CAST(N'2018-10-03T00:00:00.000' AS DateTime), CAST(N'2018-10-03T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Agency] OFF
SET IDENTITY_INSERT [dbo].[Company] ON 

INSERT [dbo].[Company] ([CompanyId], [CompanyName], [Description], [IsDelete], [CreateDate], [UpdateDate]) VALUES (1, N'Passio', N'Coffee ', 0, CAST(N'2018-09-25T00:00:00.000' AS DateTime), CAST(N'2018-06-09T00:00:00.000' AS DateTime))
INSERT [dbo].[Company] ([CompanyId], [CompanyName], [Description], [IsDelete], [CreateDate], [UpdateDate]) VALUES (2, N'Uni space', N'Coffee', 0, CAST(N'2018-01-02T00:00:00.000' AS DateTime), CAST(N'2018-06-06T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Company] OFF
SET IDENTITY_INSERT [dbo].[Device] ON 

INSERT [dbo].[Device] ([DeviceId], [AgencyId], [DeviceTypeId], [DeviceName], [DeviceCode], [GuarantyStartDate], [GuarantyEndDate], [Ip], [Port], [DeviceAccount], [DevicePassword], [SettingDate], [Other], [IsDelete], [CreateDate], [UpdateDate]) VALUES (3, 3, 1, N'Wifi Tenda', N'123885', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'2018-10-03T00:00:00.000' AS DateTime), CAST(N'2018-10-03T00:00:00.000' AS DateTime))
INSERT [dbo].[Device] ([DeviceId], [AgencyId], [DeviceTypeId], [DeviceName], [DeviceCode], [GuarantyStartDate], [GuarantyEndDate], [Ip], [Port], [DeviceAccount], [DevicePassword], [SettingDate], [Other], [IsDelete], [CreateDate], [UpdateDate]) VALUES (4, 3, 2, N'Camera HikVision', N'123456', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'2018-10-10T00:00:00.000' AS DateTime), CAST(N'2018-10-10T00:00:00.000' AS DateTime))
INSERT [dbo].[Device] ([DeviceId], [AgencyId], [DeviceTypeId], [DeviceName], [DeviceCode], [GuarantyStartDate], [GuarantyEndDate], [Ip], [Port], [DeviceAccount], [DevicePassword], [SettingDate], [Other], [IsDelete], [CreateDate], [UpdateDate]) VALUES (8, 3, 4, N'Pos Sunmi', N'12345', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'2018-10-10T00:00:00.000' AS DateTime), CAST(N'2018-10-10T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Device] OFF
SET IDENTITY_INSERT [dbo].[DeviceType] ON 

INSERT [dbo].[DeviceType] ([DeviceTypeId], [DeviceTypeName], [Description], [IsDelete], [CreateDate], [UpdateDate]) VALUES (1, N'Wifi', NULL, 1, CAST(N'2018-10-03T00:00:00.000' AS DateTime), CAST(N'2018-10-03T00:00:00.000' AS DateTime))
INSERT [dbo].[DeviceType] ([DeviceTypeId], [DeviceTypeName], [Description], [IsDelete], [CreateDate], [UpdateDate]) VALUES (2, N'Camera', NULL, 1, CAST(N'2018-10-03T00:00:00.000' AS DateTime), CAST(N'2018-10-03T00:00:00.000' AS DateTime))
INSERT [dbo].[DeviceType] ([DeviceTypeId], [DeviceTypeName], [Description], [IsDelete], [CreateDate], [UpdateDate]) VALUES (4, N'Pos', NULL, 0, CAST(N'2018-10-10T00:00:00.000' AS DateTime), CAST(N'2018-10-10T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[DeviceType] OFF
SET IDENTITY_INSERT [dbo].[Guideline] ON 

INSERT [dbo].[Guideline] ([GuidelineId], [ServiceItemId], [GuidelineName], [StartDate], [EndDate], [IsDelete], [CreateDate], [UpdateDate]) VALUES (1, 1, N'Something', NULL, NULL, 0, CAST(N'2018-10-08T00:00:00.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Guideline] OFF
SET IDENTITY_INSERT [dbo].[ITSupporter] ON 

INSERT [dbo].[ITSupporter] ([ITSupporterId], [ITSupporterName], [AccountId], [Telephone], [Email], [Gender], [Address], [RatingAVG], [IsBusy], [IsDelete], [CreateDate], [UpdateDate]) VALUES (1, N'Lê Hồng Ân', 2, N'Lê Hồng Ân', N'anlh@gmail.com', N'1', N'742 Lê Đức Thọ', 2.5, NULL, 0, CAST(N'2018-10-03T00:00:00.000' AS DateTime), CAST(N'2018-10-08T18:30:54.340' AS DateTime))
SET IDENTITY_INSERT [dbo].[ITSupporter] OFF
SET IDENTITY_INSERT [dbo].[Request] ON 

INSERT [dbo].[Request] ([RequestId], [AgencyId], [RequestCategoryId], [RequestStatus], [RequestName], [StartDate], [EndDate], [Feedback], [IsDelete], [CreateDate], [UpdateDate]) VALUES (3, 3, 3, 1, N'Wifi báo hỏng', CAST(N'2018-10-02T00:00:00.000' AS DateTime), CAST(N'2018-10-03T00:00:00.000' AS DateTime), NULL, 0, CAST(N'2018-10-02T00:00:00.000' AS DateTime), CAST(N'2018-10-03T00:00:00.000' AS DateTime))
INSERT [dbo].[Request] ([RequestId], [AgencyId], [RequestCategoryId], [RequestStatus], [RequestName], [StartDate], [EndDate], [Feedback], [IsDelete], [CreateDate], [UpdateDate]) VALUES (5, 3, 3, 1, N'Camera báo hỏng', CAST(N'2018-10-10T00:00:00.000' AS DateTime), CAST(N'2018-10-10T00:00:00.000' AS DateTime), NULL, 0, CAST(N'2018-10-10T00:00:00.000' AS DateTime), CAST(N'2018-10-10T00:00:00.000' AS DateTime))
INSERT [dbo].[Request] ([RequestId], [AgencyId], [RequestCategoryId], [RequestStatus], [RequestName], [StartDate], [EndDate], [Feedback], [IsDelete], [CreateDate], [UpdateDate]) VALUES (7, 3, 4, 1, N'Lắp máy Pos', CAST(N'2018-10-10T00:00:00.000' AS DateTime), CAST(N'2018-10-10T00:00:00.000' AS DateTime), NULL, 0, CAST(N'2018-10-10T00:00:00.000' AS DateTime), CAST(N'2018-10-10T00:00:00.000' AS DateTime))
INSERT [dbo].[Request] ([RequestId], [AgencyId], [RequestCategoryId], [RequestStatus], [RequestName], [StartDate], [EndDate], [Feedback], [IsDelete], [CreateDate], [UpdateDate]) VALUES (10, 3, 3, 1, N'Wifi báo hỏng', NULL, NULL, NULL, 0, NULL, NULL)
INSERT [dbo].[Request] ([RequestId], [AgencyId], [RequestCategoryId], [RequestStatus], [RequestName], [StartDate], [EndDate], [Feedback], [IsDelete], [CreateDate], [UpdateDate]) VALUES (11, 3, 3, 1, N'Wifi báo hỏng', NULL, NULL, NULL, 0, NULL, NULL)
INSERT [dbo].[Request] ([RequestId], [AgencyId], [RequestCategoryId], [RequestStatus], [RequestName], [StartDate], [EndDate], [Feedback], [IsDelete], [CreateDate], [UpdateDate]) VALUES (12, 3, 3, 1, N'Wifi báo hỏng', NULL, NULL, NULL, 0, NULL, NULL)
INSERT [dbo].[Request] ([RequestId], [AgencyId], [RequestCategoryId], [RequestStatus], [RequestName], [StartDate], [EndDate], [Feedback], [IsDelete], [CreateDate], [UpdateDate]) VALUES (13, 3, 3, 1, N'Wifi báo hỏng', NULL, NULL, NULL, 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Request] OFF
SET IDENTITY_INSERT [dbo].[RequestCategory] ON 

INSERT [dbo].[RequestCategory] ([RequestCategoryId], [RequestCategoryName], [Description], [IsDelete], [CreateDate], [UpdateDate]) VALUES (3, N'Sửa chữa', NULL, 0, CAST(N'2018-10-06T00:00:00.000' AS DateTime), CAST(N'2018-10-06T00:00:00.000' AS DateTime))
INSERT [dbo].[RequestCategory] ([RequestCategoryId], [RequestCategoryName], [Description], [IsDelete], [CreateDate], [UpdateDate]) VALUES (4, N'Lắp đặt mới', NULL, 0, CAST(N'2018-10-06T00:00:00.000' AS DateTime), CAST(N'2018-10-06T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[RequestCategory] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleId], [RoleName], [IsDelete], [CreateDate], [UpdateDate]) VALUES (1, N'Admin', 0, CAST(N'2018-10-03T00:00:00.000' AS DateTime), CAST(N'2018-10-03T00:00:00.000' AS DateTime))
INSERT [dbo].[Role] ([RoleId], [RoleName], [IsDelete], [CreateDate], [UpdateDate]) VALUES (2, N'ITSupporter', 0, CAST(N'2018-10-03T00:00:00.000' AS DateTime), CAST(N'2018-10-03T00:00:00.000' AS DateTime))
INSERT [dbo].[Role] ([RoleId], [RoleName], [IsDelete], [CreateDate], [UpdateDate]) VALUES (3, N'Agency', 0, CAST(N'2018-10-03T00:00:00.000' AS DateTime), CAST(N'2018-10-03T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[ServiceItem] ON 

INSERT [dbo].[ServiceItem] ([ServiceItemId], [ServiceId], [IssueName], [Price], [IsDelete], [CreateDate], [UpdateDate]) VALUES (1, 1, N'Wifi không vào được', 125000, 0, CAST(N'2018-10-03T00:00:00.000' AS DateTime), CAST(N'2018-10-03T00:00:00.000' AS DateTime))
INSERT [dbo].[ServiceItem] ([ServiceItemId], [ServiceId], [IssueName], [Price], [IsDelete], [CreateDate], [UpdateDate]) VALUES (3, 2, N'Camera không hiện màu', 100000, 0, CAST(N'2018-10-10T00:00:00.000' AS DateTime), CAST(N'2018-10-10T00:00:00.000' AS DateTime))
INSERT [dbo].[ServiceItem] ([ServiceItemId], [ServiceId], [IssueName], [Price], [IsDelete], [CreateDate], [UpdateDate]) VALUES (5, 3, N'Lắp máy Pos mới', 10000000, 0, CAST(N'2018-10-10T00:00:00.000' AS DateTime), CAST(N'2018-10-10T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[ServiceItem] OFF
SET IDENTITY_INSERT [dbo].[ServiceITSupport] ON 

INSERT [dbo].[ServiceITSupport] ([ServiceITSupportId], [ServiceName], [Description], [IsDelete], [CreateDate], [UpdateDate]) VALUES (1, N'Wifi', NULL, 0, CAST(N'2018-10-03T00:00:00.000' AS DateTime), CAST(N'2018-10-03T00:00:00.000' AS DateTime))
INSERT [dbo].[ServiceITSupport] ([ServiceITSupportId], [ServiceName], [Description], [IsDelete], [CreateDate], [UpdateDate]) VALUES (2, N'Camera', NULL, 0, CAST(N'2018-10-10T00:00:00.000' AS DateTime), CAST(N'2018-10-10T00:00:00.000' AS DateTime))
INSERT [dbo].[ServiceITSupport] ([ServiceITSupportId], [ServiceName], [Description], [IsDelete], [CreateDate], [UpdateDate]) VALUES (3, N'Pos', NULL, 0, CAST(N'2018-10-10T00:00:00.000' AS DateTime), CAST(N'2018-10-10T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[ServiceITSupport] OFF
SET IDENTITY_INSERT [dbo].[Ticket] ON 

INSERT [dbo].[Ticket] ([TicketId], [ServiceItemId], [RequestId], [DeviceId], [Desciption], [Current_TicketStatus], [CurrentITSupporter_Id], [Rating], [Estimation], [StartTime], [Endtime], [IsDelete], [CreateDate], [UpdateDate]) VALUES (2, 1, 3, 3, N'Dc nha ba', 1, 1, 1, 3, NULL, NULL, 0, CAST(N'2018-10-03T00:00:00.000' AS DateTime), CAST(N'2018-10-03T00:00:00.000' AS DateTime))
INSERT [dbo].[Ticket] ([TicketId], [ServiceItemId], [RequestId], [DeviceId], [Desciption], [Current_TicketStatus], [CurrentITSupporter_Id], [Rating], [Estimation], [StartTime], [Endtime], [IsDelete], [CreateDate], [UpdateDate]) VALUES (3, 3, 3, 4, N'haizzzz', 1, 1, NULL, NULL, NULL, NULL, 0, NULL, NULL)
INSERT [dbo].[Ticket] ([TicketId], [ServiceItemId], [RequestId], [DeviceId], [Desciption], [Current_TicketStatus], [CurrentITSupporter_Id], [Rating], [Estimation], [StartTime], [Endtime], [IsDelete], [CreateDate], [UpdateDate]) VALUES (6, 5, 3, 8, N'haizzzz', NULL, 1, NULL, NULL, NULL, NULL, 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Ticket] OFF
SET IDENTITY_INSERT [dbo].[TicketTask] ON 

INSERT [dbo].[TicketTask] ([TicketTaskId], [TicketId], [TaskStatus], [CreateByITSupporter], [StartTime], [EndTime], [Priority], [PreTaskCondition], [IsDelete], [CreateDate], [UpdateDate]) VALUES (1, 2, 1, 1, CAST(N'2018-10-08T00:00:00.000' AS DateTime), CAST(N'2018-10-08T00:00:00.000' AS DateTime), 1, 0, 0, CAST(N'2018-10-08T19:45:32.297' AS DateTime), NULL)
INSERT [dbo].[TicketTask] ([TicketTaskId], [TicketId], [TaskStatus], [CreateByITSupporter], [StartTime], [EndTime], [Priority], [PreTaskCondition], [IsDelete], [CreateDate], [UpdateDate]) VALUES (2, 2, 1, 1, CAST(N'2018-10-09T00:00:00.000' AS DateTime), CAST(N'2018-10-10T00:00:00.000' AS DateTime), 2, 0, 0, CAST(N'2018-10-08T19:45:38.827' AS DateTime), NULL)
INSERT [dbo].[TicketTask] ([TicketTaskId], [TicketId], [TaskStatus], [CreateByITSupporter], [StartTime], [EndTime], [Priority], [PreTaskCondition], [IsDelete], [CreateDate], [UpdateDate]) VALUES (3, 2, 1, 1, CAST(N'2018-10-08T00:00:00.000' AS DateTime), CAST(N'2018-10-08T00:00:00.000' AS DateTime), 1, 0, 0, CAST(N'2018-10-08T19:45:43.637' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[TicketTask] OFF
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Role]
GO
ALTER TABLE [dbo].[Agency]  WITH CHECK ADD  CONSTRAINT [FK_Agency_Account] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([AccountId])
GO
ALTER TABLE [dbo].[Agency] CHECK CONSTRAINT [FK_Agency_Account]
GO
ALTER TABLE [dbo].[Agency]  WITH CHECK ADD  CONSTRAINT [FK_Agency_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([CompanyId])
GO
ALTER TABLE [dbo].[Agency] CHECK CONSTRAINT [FK_Agency_Company]
GO
ALTER TABLE [dbo].[Contract]  WITH CHECK ADD  CONSTRAINT [FK_Contract_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([CompanyId])
GO
ALTER TABLE [dbo].[Contract] CHECK CONSTRAINT [FK_Contract_Company]
GO
ALTER TABLE [dbo].[ContractServiceITSupport]  WITH CHECK ADD  CONSTRAINT [FK_ContractService_Contract] FOREIGN KEY([ContractId])
REFERENCES [dbo].[Contract] ([ContractId])
GO
ALTER TABLE [dbo].[ContractServiceITSupport] CHECK CONSTRAINT [FK_ContractService_Contract]
GO
ALTER TABLE [dbo].[ContractServiceITSupport]  WITH CHECK ADD  CONSTRAINT [FK_ContractService_Service] FOREIGN KEY([ServiceITSupportId])
REFERENCES [dbo].[ServiceITSupport] ([ServiceITSupportId])
GO
ALTER TABLE [dbo].[ContractServiceITSupport] CHECK CONSTRAINT [FK_ContractService_Service]
GO
ALTER TABLE [dbo].[Device]  WITH CHECK ADD  CONSTRAINT [FK_Device_Agency] FOREIGN KEY([AgencyId])
REFERENCES [dbo].[Agency] ([AgencyId])
GO
ALTER TABLE [dbo].[Device] CHECK CONSTRAINT [FK_Device_Agency]
GO
ALTER TABLE [dbo].[Device]  WITH CHECK ADD  CONSTRAINT [FK_Device_DeviceType] FOREIGN KEY([DeviceTypeId])
REFERENCES [dbo].[DeviceType] ([DeviceTypeId])
GO
ALTER TABLE [dbo].[Device] CHECK CONSTRAINT [FK_Device_DeviceType]
GO
ALTER TABLE [dbo].[Guideline]  WITH CHECK ADD  CONSTRAINT [FK_Guideline_ServiceItem] FOREIGN KEY([ServiceItemId])
REFERENCES [dbo].[ServiceItem] ([ServiceItemId])
GO
ALTER TABLE [dbo].[Guideline] CHECK CONSTRAINT [FK_Guideline_ServiceItem]
GO
ALTER TABLE [dbo].[ITSupporter]  WITH CHECK ADD  CONSTRAINT [FK_ITSupporter_Account] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([AccountId])
GO
ALTER TABLE [dbo].[ITSupporter] CHECK CONSTRAINT [FK_ITSupporter_Account]
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_Request_RequestCategory] FOREIGN KEY([RequestCategoryId])
REFERENCES [dbo].[RequestCategory] ([RequestCategoryId])
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_Request_RequestCategory]
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_Agency] FOREIGN KEY([AgencyId])
REFERENCES [dbo].[Agency] ([AgencyId])
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_Ticket_Agency]
GO
ALTER TABLE [dbo].[ServiceItem]  WITH CHECK ADD  CONSTRAINT [FK_ServiceItem_Service] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[ServiceITSupport] ([ServiceITSupportId])
GO
ALTER TABLE [dbo].[ServiceItem] CHECK CONSTRAINT [FK_ServiceItem_Service]
GO
ALTER TABLE [dbo].[Skill]  WITH CHECK ADD  CONSTRAINT [FK_Skill_ITSupporter] FOREIGN KEY([ITSupportId])
REFERENCES [dbo].[ITSupporter] ([ITSupporterId])
GO
ALTER TABLE [dbo].[Skill] CHECK CONSTRAINT [FK_Skill_ITSupporter]
GO
ALTER TABLE [dbo].[Skill]  WITH CHECK ADD  CONSTRAINT [FK_Skill_ServiceItem] FOREIGN KEY([ServiceItemId])
REFERENCES [dbo].[ServiceItem] ([ServiceItemId])
GO
ALTER TABLE [dbo].[Skill] CHECK CONSTRAINT [FK_Skill_ServiceItem]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_Request] FOREIGN KEY([RequestId])
REFERENCES [dbo].[Request] ([RequestId])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_Request]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_TicketDetail_Device] FOREIGN KEY([DeviceId])
REFERENCES [dbo].[Device] ([DeviceId])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_TicketDetail_Device]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_TicketDetail_ITSupporter] FOREIGN KEY([CurrentITSupporter_Id])
REFERENCES [dbo].[ITSupporter] ([ITSupporterId])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_TicketDetail_ITSupporter]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_TicketDetail_ServiceItem] FOREIGN KEY([ServiceItemId])
REFERENCES [dbo].[ServiceItem] ([ServiceItemId])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_TicketDetail_ServiceItem]
GO
ALTER TABLE [dbo].[TicketHistory]  WITH CHECK ADD  CONSTRAINT [FK_TicketHistory_ITSupporter] FOREIGN KEY([Pre_It_SupporterId])
REFERENCES [dbo].[ITSupporter] ([ITSupporterId])
GO
ALTER TABLE [dbo].[TicketHistory] CHECK CONSTRAINT [FK_TicketHistory_ITSupporter]
GO
ALTER TABLE [dbo].[TicketHistory]  WITH CHECK ADD  CONSTRAINT [FK_TicketHistory_Ticket] FOREIGN KEY([TicketId])
REFERENCES [dbo].[Ticket] ([TicketId])
GO
ALTER TABLE [dbo].[TicketHistory] CHECK CONSTRAINT [FK_TicketHistory_Ticket]
GO
ALTER TABLE [dbo].[TicketTask]  WITH CHECK ADD  CONSTRAINT [FK_TicketTask_Ticket] FOREIGN KEY([TicketId])
REFERENCES [dbo].[Ticket] ([TicketId])
GO
ALTER TABLE [dbo].[TicketTask] CHECK CONSTRAINT [FK_TicketTask_Ticket]
GO
USE [master]
GO
ALTER DATABASE [ODTS_DB] SET  READ_WRITE 
GO
