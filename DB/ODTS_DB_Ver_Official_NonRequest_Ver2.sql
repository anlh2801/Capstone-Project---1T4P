USE [master]
GO
/****** Object:  Database [ODTS_DB]    Script Date: 11/22/2018 12:54:10 PM ******/
CREATE DATABASE [ODTS_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ODTS_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\ODTS_DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ODTS_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\ODTS_DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
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
ALTER DATABASE [ODTS_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ODTS_DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ODTS_DB] SET QUERY_STORE = OFF
GO
USE [ODTS_DB]
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
/****** Object:  User [saa]    Script Date: 11/22/2018 12:54:12 PM ******/
CREATE USER [saa] FOR LOGIN [saa] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [saa]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [saa]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [saa]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [saa]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [saa]
GO
ALTER ROLE [db_datareader] ADD MEMBER [saa]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [saa]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 11/22/2018 12:54:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[AccountId] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Agency]    Script Date: 11/22/2018 12:54:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agency](
	[AgencyId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[AccountId] [int] NOT NULL,
	[AgencyName] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](250) NULL,
	[Telephone] [nvarchar](50) NULL,
	[IsDelete] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_Agency] PRIMARY KEY CLUSTERED 
(
	[AgencyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 11/22/2018 12:54:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[CompanyId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[PercentForITSupporterRate] [int] NULL,
	[PercentForITSupporterExp] [int] NULL,
	[PercentForITSupporterFamiliarWithAgency] [int] NULL,
	[IsDelete] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contract]    Script Date: 11/22/2018 12:54:12 PM ******/
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
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_Contract] PRIMARY KEY CLUSTERED 
(
	[ContractId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContractServiceITSupport]    Script Date: 11/22/2018 12:54:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContractServiceITSupport](
	[ContractServiceITSupportId] [int] IDENTITY(1,1) NOT NULL,
	[ContractId] [int] NOT NULL,
	[ServiceITSupportId] [int] NOT NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[IsDelete] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_ContractService_1] PRIMARY KEY CLUSTERED 
(
	[ContractServiceITSupportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Device]    Script Date: 11/22/2018 12:54:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Device](
	[DeviceId] [int] IDENTITY(1,1) NOT NULL,
	[AgencyId] [int] NOT NULL,
	[DeviceTypeId] [int] NOT NULL,
	[DeviceName] [nvarchar](50) NOT NULL,
	[DeviceCode] [nvarchar](50) NOT NULL,
	[GuarantyStartDate] [datetime] NULL,
	[GuarantyEndDate] [datetime] NULL,
	[Ip] [nvarchar](50) NULL,
	[Port] [nvarchar](50) NULL,
	[DeviceAccount] [nvarchar](50) NULL,
	[DevicePassword] [nvarchar](50) NULL,
	[SettingDate] [datetime] NULL,
	[Other] [nvarchar](max) NULL,
	[IsDelete] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_Device] PRIMARY KEY CLUSTERED 
(
	[DeviceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeviceType]    Script Date: 11/22/2018 12:54:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeviceType](
	[DeviceTypeId] [int] IDENTITY(1,1) NOT NULL,
	[ServiceId] [int] NOT NULL,
	[DeviceTypeName] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[IsDelete] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_DeviceType] PRIMARY KEY CLUSTERED 
(
	[DeviceTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Guideline]    Script Date: 11/22/2018 12:54:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Guideline](
	[GuidelineId] [int] IDENTITY(1,1) NOT NULL,
	[ServiceItemId] [int] NOT NULL,
	[GuidelineName] [nvarchar](max) NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_Guideline] PRIMARY KEY CLUSTERED 
(
	[GuidelineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ITSupporter]    Script Date: 11/22/2018 12:54:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ITSupporter](
	[ITSupporterId] [int] IDENTITY(1,1) NOT NULL,
	[ITSupporterName] [nvarchar](50) NOT NULL,
	[AccountId] [int] NOT NULL,
	[Telephone] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Gender] [int] NULL,
	[Address] [nvarchar](50) NULL,
	[RatingAVG] [float] NULL,
	[IsBusy] [bit] NULL,
	[IsOnline] [bit] NULL,
	[IsDelete] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_ITSupporter] PRIMARY KEY CLUSTERED 
(
	[ITSupporterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Request]    Script Date: 11/22/2018 12:54:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Request](
	[RequestId] [int] IDENTITY(1,1) NOT NULL,
	[AgencyId] [int] NOT NULL,
	[ServiceItemId] [int] NOT NULL,
	[RequestDesciption] [nvarchar](max) NULL,
	[RequestCategoryId] [int] NOT NULL,
	[RequestStatus] [int] NOT NULL,
	[RequestName] [nvarchar](50) NOT NULL,
	[Estimation] [float] NULL,
	[Phone] [nvarchar](50) NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[CurrentITSupporter_Id] [int] NULL,
	[Rating] [int] NULL,
	[Feedback] [nvarchar](max) NULL,
	[IsDelete] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_Ticket] PRIMARY KEY CLUSTERED 
(
	[RequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequestCategory]    Script Date: 11/22/2018 12:54:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestCategory](
	[RequestCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[RequestCategoryName] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[IsDelete] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_RequestCategory] PRIMARY KEY CLUSTERED 
(
	[RequestCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequestHistory]    Script Date: 11/22/2018 12:54:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestHistory](
	[RequestHistoryId] [int] IDENTITY(1,1) NOT NULL,
	[RequestId] [int] NOT NULL,
	[Pre_It_SupporterId] [int] NULL,
	[Pre_Status] [int] NULL,
	[IsITSupportAccept] [bit] NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[IsDelete] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_TicketHistory] PRIMARY KEY CLUSTERED 
(
	[RequestHistoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequestTask]    Script Date: 11/22/2018 12:54:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestTask](
	[RequestTaskId] [int] IDENTITY(1,1) NOT NULL,
	[RequestId] [int] NOT NULL,
	[TaskDetails] [nvarchar](max) NULL,
	[TaskStatus] [int] NULL,
	[CreateByITSupporter] [int] NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[Priority] [int] NULL,
	[PreTaskCondition] [int] NULL,
	[IsDelete] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[RequestTaskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 11/22/2018 12:54:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceItem]    Script Date: 11/22/2018 12:54:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceItem](
	[ServiceItemId] [int] IDENTITY(1,1) NOT NULL,
	[ServiceITSupportId] [int] NOT NULL,
	[ServiceItemName] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[IsDelete] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_ServiceItem] PRIMARY KEY CLUSTERED 
(
	[ServiceItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceITSupport]    Script Date: 11/22/2018 12:54:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceITSupport](
	[ServiceITSupportId] [int] IDENTITY(1,1) NOT NULL,
	[ServiceName] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[IsDelete] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[ServiceITSupportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Skill]    Script Date: 11/22/2018 12:54:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Skill](
	[SkillId] [int] IDENTITY(1,1) NOT NULL,
	[ITSupporterId] [int] NOT NULL,
	[ServiceITSupportId] [int] NULL,
	[MonthExperience] [int] NULL,
	[IsDelete] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_Skill_1] PRIMARY KEY CLUSTERED 
(
	[SkillId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ticket]    Script Date: 11/22/2018 12:54:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ticket](
	[TicketId] [int] IDENTITY(1,1) NOT NULL,
	[RequestId] [int] NOT NULL,
	[DeviceId] [int] NOT NULL,
	[Desciption] [nvarchar](max) NULL,
	[IsDelete] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_TicketDetail] PRIMARY KEY CLUSTERED 
(
	[TicketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([AccountId], [RoleId], [Username], [Password], [IsDelete], [CreateDate], [UpdateDate]) VALUES (1, 3, N'c', N'c', 0, CAST(N'2018-10-03T00:00:00.000' AS DateTime), CAST(N'2018-10-03T00:00:00.000' AS DateTime))
INSERT [dbo].[Account] ([AccountId], [RoleId], [Username], [Password], [IsDelete], [CreateDate], [UpdateDate]) VALUES (2, 2, N'lehongan', N'123456', 0, CAST(N'2018-10-03T00:00:00.000' AS DateTime), CAST(N'2018-11-22T11:40:45.297' AS DateTime))
INSERT [dbo].[Account] ([AccountId], [RoleId], [Username], [Password], [IsDelete], [CreateDate], [UpdateDate]) VALUES (3, 1, N'admin', N'123456', 0, CAST(N'2018-10-03T00:00:00.000' AS DateTime), CAST(N'2018-10-03T00:00:00.000' AS DateTime))
INSERT [dbo].[Account] ([AccountId], [RoleId], [Username], [Password], [IsDelete], [CreateDate], [UpdateDate]) VALUES (6, 2, N'tienpp', N'123456', 0, CAST(N'2018-10-17T00:00:00.000' AS DateTime), CAST(N'2018-11-22T11:41:00.937' AS DateTime))
INSERT [dbo].[Account] ([AccountId], [RoleId], [Username], [Password], [IsDelete], [CreateDate], [UpdateDate]) VALUES (9, 2, N'longdo', N'123456', 0, CAST(N'2018-10-19T14:26:40.347' AS DateTime), CAST(N'2018-11-22T11:41:17.237' AS DateTime))
INSERT [dbo].[Account] ([AccountId], [RoleId], [Username], [Password], [IsDelete], [CreateDate], [UpdateDate]) VALUES (10, 3, N'unideli', N'123456', 0, CAST(N'2018-10-19T14:27:32.647' AS DateTime), CAST(N'2018-10-19T14:54:11.220' AS DateTime))
INSERT [dbo].[Account] ([AccountId], [RoleId], [Username], [Password], [IsDelete], [CreateDate], [UpdateDate]) VALUES (12, 2, N'chien', N'123456', 0, CAST(N'2018-01-01T00:00:00.000' AS DateTime), CAST(N'2018-11-22T11:42:11.663' AS DateTime))
INSERT [dbo].[Account] ([AccountId], [RoleId], [Username], [Password], [IsDelete], [CreateDate], [UpdateDate]) VALUES (35, 3, N'coffehouse01', N'123456', 0, CAST(N'2018-11-10T19:03:28.653' AS DateTime), CAST(N'2018-11-20T20:22:02.377' AS DateTime))
INSERT [dbo].[Account] ([AccountId], [RoleId], [Username], [Password], [IsDelete], [CreateDate], [UpdateDate]) VALUES (36, 3, N'Ananas', N'123456', 0, CAST(N'2018-11-11T18:36:10.070' AS DateTime), CAST(N'2018-11-20T20:23:00.237' AS DateTime))
INSERT [dbo].[Account] ([AccountId], [RoleId], [Username], [Password], [IsDelete], [CreateDate], [UpdateDate]) VALUES (37, 3, N'coffehouse02', N'123456', 0, CAST(N'2018-11-13T02:16:30.407' AS DateTime), CAST(N'2018-11-14T13:24:39.630' AS DateTime))
SET IDENTITY_INSERT [dbo].[Account] OFF
SET IDENTITY_INSERT [dbo].[Agency] ON 

INSERT [dbo].[Agency] ([AgencyId], [CompanyId], [AccountId], [AgencyName], [Address], [Telephone], [IsDelete], [CreateDate], [UpdateDate]) VALUES (3, 1, 1, N'Passio 47 TCV', N'47 Trần Cao Vânn', N'0966167423', 0, CAST(N'2018-10-03T00:00:00.000' AS DateTime), CAST(N'2018-10-17T15:57:28.977' AS DateTime))
INSERT [dbo].[Agency] ([AgencyId], [CompanyId], [AccountId], [AgencyName], [Address], [Telephone], [IsDelete], [CreateDate], [UpdateDate]) VALUES (17, 2, 10, N'Uni deli', N'Biệt thự Liên Phương, QTSC', N'03899620', 0, CAST(N'2018-01-01T00:00:00.000' AS DateTime), CAST(N'2018-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Agency] ([AgencyId], [CompanyId], [AccountId], [AgencyName], [Address], [Telephone], [IsDelete], [CreateDate], [UpdateDate]) VALUES (31, 6, 35, N'The Coffee House - Chi nhánh số 1', N'88 Ngô Tất Tố, Quận Bình Thạnh', N'0397934468', 0, CAST(N'2018-11-10T19:37:50.840' AS DateTime), CAST(N'2018-11-14T13:25:58.667' AS DateTime))
INSERT [dbo].[Agency] ([AgencyId], [CompanyId], [AccountId], [AgencyName], [Address], [Telephone], [IsDelete], [CreateDate], [UpdateDate]) VALUES (32, 13, 36, N'Ananas Chi Nhánh 01', N'20 Nguyễn Đức Cảnh, tp Buôn Ma Thuột.', N'01696791999', 0, CAST(N'2018-11-11T18:37:45.783' AS DateTime), CAST(N'2018-11-14T13:13:04.323' AS DateTime))
SET IDENTITY_INSERT [dbo].[Agency] OFF
SET IDENTITY_INSERT [dbo].[Company] ON 

INSERT [dbo].[Company] ([CompanyId], [CompanyName], [Description], [PercentForITSupporterRate], [PercentForITSupporterExp], [PercentForITSupporterFamiliarWithAgency], [IsDelete], [CreateDate], [UpdateDate]) VALUES (1, N'Passio', N'Coffee ', 30, 30, 40, 0, CAST(N'2018-09-25T00:00:00.000' AS DateTime), CAST(N'2018-11-14T14:36:55.220' AS DateTime))
INSERT [dbo].[Company] ([CompanyId], [CompanyName], [Description], [PercentForITSupporterRate], [PercentForITSupporterExp], [PercentForITSupporterFamiliarWithAgency], [IsDelete], [CreateDate], [UpdateDate]) VALUES (2, N'Uni space', N'Coffee', 10, 8, 8, 0, CAST(N'2018-01-02T00:00:00.000' AS DateTime), CAST(N'2018-11-12T22:32:53.090' AS DateTime))
INSERT [dbo].[Company] ([CompanyId], [CompanyName], [Description], [PercentForITSupporterRate], [PercentForITSupporterExp], [PercentForITSupporterFamiliarWithAgency], [IsDelete], [CreateDate], [UpdateDate]) VALUES (6, N'The Coffe House', N'Coffee', 12, 23, 33, 0, CAST(N'2018-11-08T10:41:11.747' AS DateTime), CAST(N'2018-11-10T15:28:14.917' AS DateTime))
INSERT [dbo].[Company] ([CompanyId], [CompanyName], [Description], [PercentForITSupporterRate], [PercentForITSupporterExp], [PercentForITSupporterFamiliarWithAgency], [IsDelete], [CreateDate], [UpdateDate]) VALUES (13, N'Ananas', N'Sneaker', 18, 20, 40, 0, CAST(N'2018-11-11T18:31:02.983' AS DateTime), CAST(N'2018-11-11T20:11:22.240' AS DateTime))
SET IDENTITY_INSERT [dbo].[Company] OFF
SET IDENTITY_INSERT [dbo].[Contract] ON 

INSERT [dbo].[Contract] ([ContractId], [CompanyId], [ContractName], [StartDate], [EndDate], [IsDelete], [CreateDate], [UpdateDate]) VALUES (1, 1, N'Hợp Đồng Bao Gồm 4 Wifi , 3 Camera và 2 Pos.', CAST(N'2018-10-17T00:00:00.000' AS DateTime), CAST(N'2019-01-01T00:00:00.000' AS DateTime), 0, CAST(N'2018-10-17T00:00:00.000' AS DateTime), CAST(N'2018-11-22T11:10:32.850' AS DateTime))
INSERT [dbo].[Contract] ([ContractId], [CompanyId], [ContractName], [StartDate], [EndDate], [IsDelete], [CreateDate], [UpdateDate]) VALUES (30, 6, N'Hợp Đồng Bao Gồm 1 Wifi và 2 Camera.', CAST(N'2018-12-04T00:00:00.000' AS DateTime), CAST(N'2018-11-13T00:00:00.000' AS DateTime), 0, CAST(N'2018-11-12T16:21:13.020' AS DateTime), CAST(N'2018-11-22T11:07:50.247' AS DateTime))
INSERT [dbo].[Contract] ([ContractId], [CompanyId], [ContractName], [StartDate], [EndDate], [IsDelete], [CreateDate], [UpdateDate]) VALUES (33, 2, N'Hợp Đồng Bao Gồm 1 Wifi , 1 Pos và 1 Camera.', CAST(N'2018-12-04T00:00:00.000' AS DateTime), CAST(N'2018-12-08T00:00:00.000' AS DateTime), 0, CAST(N'2018-11-12T16:34:57.803' AS DateTime), CAST(N'2018-11-22T11:08:25.500' AS DateTime))
SET IDENTITY_INSERT [dbo].[Contract] OFF
SET IDENTITY_INSERT [dbo].[ContractServiceITSupport] ON 

INSERT [dbo].[ContractServiceITSupport] ([ContractServiceITSupportId], [ContractId], [ServiceITSupportId], [StartDate], [EndDate], [IsDelete], [CreateDate], [UpdateDate]) VALUES (1, 1, 1, CAST(N'2018-10-10T00:00:00.000' AS DateTime), CAST(N'2019-01-01T00:00:00.000' AS DateTime), 0, CAST(N'2018-10-10T00:00:00.000' AS DateTime), CAST(N'2018-10-10T00:00:00.000' AS DateTime))
INSERT [dbo].[ContractServiceITSupport] ([ContractServiceITSupportId], [ContractId], [ServiceITSupportId], [StartDate], [EndDate], [IsDelete], [CreateDate], [UpdateDate]) VALUES (3, 1, 3, CAST(N'2018-10-10T00:00:00.000' AS DateTime), CAST(N'2019-01-01T00:00:00.000' AS DateTime), 0, CAST(N'2018-10-10T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[ContractServiceITSupport] ([ContractServiceITSupportId], [ContractId], [ServiceITSupportId], [StartDate], [EndDate], [IsDelete], [CreateDate], [UpdateDate]) VALUES (4, 33, 1, CAST(N'2018-12-04T00:00:00.000' AS DateTime), CAST(N'2018-12-08T00:00:00.000' AS DateTime), 0, CAST(N'2018-11-12T16:35:24.647' AS DateTime), CAST(N'2018-11-12T16:35:25.050' AS DateTime))
INSERT [dbo].[ContractServiceITSupport] ([ContractServiceITSupportId], [ContractId], [ServiceITSupportId], [StartDate], [EndDate], [IsDelete], [CreateDate], [UpdateDate]) VALUES (5, 33, 2, CAST(N'2018-12-04T00:00:00.000' AS DateTime), CAST(N'2018-12-08T00:00:00.000' AS DateTime), 0, CAST(N'2018-11-12T16:35:33.183' AS DateTime), CAST(N'2018-11-12T16:35:33.610' AS DateTime))
INSERT [dbo].[ContractServiceITSupport] ([ContractServiceITSupportId], [ContractId], [ServiceITSupportId], [StartDate], [EndDate], [IsDelete], [CreateDate], [UpdateDate]) VALUES (19, 30, 1, CAST(N'2018-11-14T00:00:00.000' AS DateTime), CAST(N'2019-11-14T00:00:00.000' AS DateTime), 0, CAST(N'2018-11-14T14:57:22.327' AS DateTime), CAST(N'2018-11-14T14:57:22.327' AS DateTime))
INSERT [dbo].[ContractServiceITSupport] ([ContractServiceITSupportId], [ContractId], [ServiceITSupportId], [StartDate], [EndDate], [IsDelete], [CreateDate], [UpdateDate]) VALUES (20, 30, 2, CAST(N'2018-11-14T00:00:00.000' AS DateTime), CAST(N'2019-11-14T00:00:00.000' AS DateTime), 0, CAST(N'2018-11-14T14:57:22.333' AS DateTime), CAST(N'2018-11-14T14:57:22.333' AS DateTime))
INSERT [dbo].[ContractServiceITSupport] ([ContractServiceITSupportId], [ContractId], [ServiceITSupportId], [StartDate], [EndDate], [IsDelete], [CreateDate], [UpdateDate]) VALUES (22, 33, 3, CAST(N'2018-12-04T00:00:00.000' AS DateTime), CAST(N'2018-12-08T00:00:00.000' AS DateTime), 0, CAST(N'2018-11-22T11:08:25.330' AS DateTime), CAST(N'2018-11-22T11:08:25.330' AS DateTime))
INSERT [dbo].[ContractServiceITSupport] ([ContractServiceITSupportId], [ContractId], [ServiceITSupportId], [StartDate], [EndDate], [IsDelete], [CreateDate], [UpdateDate]) VALUES (23, 1, 2, CAST(N'2018-10-17T00:00:00.000' AS DateTime), CAST(N'2019-01-01T00:00:00.000' AS DateTime), 0, CAST(N'2018-11-22T11:10:32.687' AS DateTime), CAST(N'2018-11-22T11:10:32.687' AS DateTime))
SET IDENTITY_INSERT [dbo].[ContractServiceITSupport] OFF
SET IDENTITY_INSERT [dbo].[Device] ON 

INSERT [dbo].[Device] ([DeviceId], [AgencyId], [DeviceTypeId], [DeviceName], [DeviceCode], [GuarantyStartDate], [GuarantyEndDate], [Ip], [Port], [DeviceAccount], [DevicePassword], [SettingDate], [Other], [IsDelete], [CreateDate], [UpdateDate]) VALUES (3, 3, 1, N'Router Tenda', N'W9960', CAST(N'2018-10-17T00:00:00.000' AS DateTime), CAST(N'2019-10-17T00:00:00.000' AS DateTime), N'192.168.3.25', N'80', N'admin', N'admin', CAST(N'2018-10-17T00:00:00.000' AS DateTime), N'no', 0, CAST(N'2018-10-03T00:00:00.000' AS DateTime), CAST(N'2018-10-03T00:00:00.000' AS DateTime))
INSERT [dbo].[Device] ([DeviceId], [AgencyId], [DeviceTypeId], [DeviceName], [DeviceCode], [GuarantyStartDate], [GuarantyEndDate], [Ip], [Port], [DeviceAccount], [DevicePassword], [SettingDate], [Other], [IsDelete], [CreateDate], [UpdateDate]) VALUES (4, 3, 2, N'Camera HikVision', N'C12203', CAST(N'2018-10-17T00:00:00.000' AS DateTime), CAST(N'2019-10-17T00:00:00.000' AS DateTime), N'192.168.23.3', N'81', N'admin', N'admin', CAST(N'2018-10-17T00:00:00.000' AS DateTime), N'no', 0, CAST(N'2018-10-10T00:00:00.000' AS DateTime), CAST(N'2018-10-10T00:00:00.000' AS DateTime))
INSERT [dbo].[Device] ([DeviceId], [AgencyId], [DeviceTypeId], [DeviceName], [DeviceCode], [GuarantyStartDate], [GuarantyEndDate], [Ip], [Port], [DeviceAccount], [DevicePassword], [SettingDate], [Other], [IsDelete], [CreateDate], [UpdateDate]) VALUES (8, 17, 4, N'POS Sunmi', N'P00DDS', CAST(N'2018-10-17T00:00:00.000' AS DateTime), CAST(N'2019-10-17T00:00:00.000' AS DateTime), N'6.3.11.5', N'80', N'admin', N'admin', CAST(N'2018-10-17T00:00:00.000' AS DateTime), N'sadasd', 0, CAST(N'2018-10-10T00:00:00.000' AS DateTime), CAST(N'2018-10-10T00:00:00.000' AS DateTime))
INSERT [dbo].[Device] ([DeviceId], [AgencyId], [DeviceTypeId], [DeviceName], [DeviceCode], [GuarantyStartDate], [GuarantyEndDate], [Ip], [Port], [DeviceAccount], [DevicePassword], [SettingDate], [Other], [IsDelete], [CreateDate], [UpdateDate]) VALUES (19, 3, 4, N'POS115', N'PKADS85', CAST(N'2018-10-23T00:00:00.000' AS DateTime), CAST(N'2018-10-31T00:00:00.000' AS DateTime), N'35.35.145.1', N'80', N'1', N'1', CAST(N'2018-10-30T00:00:00.000' AS DateTime), N'1', 0, CAST(N'2018-10-19T11:04:42.640' AS DateTime), CAST(N'2018-10-19T11:04:42.640' AS DateTime))
INSERT [dbo].[Device] ([DeviceId], [AgencyId], [DeviceTypeId], [DeviceName], [DeviceCode], [GuarantyStartDate], [GuarantyEndDate], [Ip], [Port], [DeviceAccount], [DevicePassword], [SettingDate], [Other], [IsDelete], [CreateDate], [UpdateDate]) VALUES (20, 3, 4, N'Pos Sentos', N'PUUns20', CAST(N'2018-10-24T00:00:00.000' AS DateTime), CAST(N'2018-10-31T00:00:00.000' AS DateTime), N'85.3.3.15', N'80', N'1', N'1', CAST(N'2018-10-16T00:00:00.000' AS DateTime), N'1', 0, CAST(N'2018-10-19T12:02:55.720' AS DateTime), CAST(N'2018-10-19T12:02:55.720' AS DateTime))
INSERT [dbo].[Device] ([DeviceId], [AgencyId], [DeviceTypeId], [DeviceName], [DeviceCode], [GuarantyStartDate], [GuarantyEndDate], [Ip], [Port], [DeviceAccount], [DevicePassword], [SettingDate], [Other], [IsDelete], [CreateDate], [UpdateDate]) VALUES (21, 17, 2, N'Camera A350', N'C1120CS', CAST(N'2018-10-23T00:00:00.000' AS DateTime), CAST(N'2018-10-24T00:00:00.000' AS DateTime), N'65.3.12.50', N'80', N'1', N'1', CAST(N'2018-10-29T00:00:00.000' AS DateTime), N'1', 0, CAST(N'2018-10-19T12:04:49.127' AS DateTime), CAST(N'2018-10-19T12:04:49.127' AS DateTime))
INSERT [dbo].[Device] ([DeviceId], [AgencyId], [DeviceTypeId], [DeviceName], [DeviceCode], [GuarantyStartDate], [GuarantyEndDate], [Ip], [Port], [DeviceAccount], [DevicePassword], [SettingDate], [Other], [IsDelete], [CreateDate], [UpdateDate]) VALUES (22, 3, 1, N'Router Tenda A15', N'WI9982Ws', CAST(N'2018-10-25T00:00:00.000' AS DateTime), CAST(N'2018-10-24T00:00:00.000' AS DateTime), N'96.2.15.3', N'80', N'132312', N'132312', CAST(N'2018-10-30T00:00:00.000' AS DateTime), N'213321123123123', 0, CAST(N'2018-10-19T13:21:01.840' AS DateTime), CAST(N'2018-10-19T13:21:01.840' AS DateTime))
INSERT [dbo].[Device] ([DeviceId], [AgencyId], [DeviceTypeId], [DeviceName], [DeviceCode], [GuarantyStartDate], [GuarantyEndDate], [Ip], [Port], [DeviceAccount], [DevicePassword], [SettingDate], [Other], [IsDelete], [CreateDate], [UpdateDate]) VALUES (23, 3, 1, N'Router TP Link A35', N'WF63JSK', CAST(N'2018-11-07T00:00:00.000' AS DateTime), CAST(N'2018-10-29T00:00:00.000' AS DateTime), N'9.3.33.12', N'85', N'1', N'1', CAST(N'2018-11-06T00:00:00.000' AS DateTime), N'1', 0, CAST(N'2018-10-19T15:18:23.970' AS DateTime), CAST(N'2018-10-19T15:18:23.970' AS DateTime))
INSERT [dbo].[Device] ([DeviceId], [AgencyId], [DeviceTypeId], [DeviceName], [DeviceCode], [GuarantyStartDate], [GuarantyEndDate], [Ip], [Port], [DeviceAccount], [DevicePassword], [SettingDate], [Other], [IsDelete], [CreateDate], [UpdateDate]) VALUES (24, 17, 1, N'Router Toto link J15', N'W996SD2', CAST(N'2018-11-06T00:00:00.000' AS DateTime), CAST(N'2018-10-22T00:00:00.000' AS DateTime), N'14.2.6.33', N'82', N'1', N'1', CAST(N'2018-10-30T00:00:00.000' AS DateTime), N'1', 0, CAST(N'2018-10-19T15:20:24.967' AS DateTime), CAST(N'2018-10-19T15:20:24.967' AS DateTime))
INSERT [dbo].[Device] ([DeviceId], [AgencyId], [DeviceTypeId], [DeviceName], [DeviceCode], [GuarantyStartDate], [GuarantyEndDate], [Ip], [Port], [DeviceAccount], [DevicePassword], [SettingDate], [Other], [IsDelete], [CreateDate], [UpdateDate]) VALUES (25, 3, 2, N'Camera Y996', N'C236CFC', CAST(N'2018-10-30T00:00:00.000' AS DateTime), CAST(N'2018-10-30T00:00:00.000' AS DateTime), N'12.321.3', N'88', N'1', N'1', CAST(N'2018-11-05T00:00:00.000' AS DateTime), N'1', 0, CAST(N'2018-10-19T15:21:12.977' AS DateTime), CAST(N'2018-10-19T15:21:12.977' AS DateTime))
INSERT [dbo].[Device] ([DeviceId], [AgencyId], [DeviceTypeId], [DeviceName], [DeviceCode], [GuarantyStartDate], [GuarantyEndDate], [Ip], [Port], [DeviceAccount], [DevicePassword], [SettingDate], [Other], [IsDelete], [CreateDate], [UpdateDate]) VALUES (26, 3, 2, N'Camera Xiaomi RES5', N'C9960SD', CAST(N'2018-11-06T00:00:00.000' AS DateTime), CAST(N'2018-10-23T00:00:00.000' AS DateTime), N'14.2.33.5', N'74', N'1', N'1', CAST(N'2018-11-02T00:00:00.000' AS DateTime), N'1', 0, CAST(N'2018-10-19T15:22:10.133' AS DateTime), CAST(N'2018-10-19T15:22:10.133' AS DateTime))
INSERT [dbo].[Device] ([DeviceId], [AgencyId], [DeviceTypeId], [DeviceName], [DeviceCode], [GuarantyStartDate], [GuarantyEndDate], [Ip], [Port], [DeviceAccount], [DevicePassword], [SettingDate], [Other], [IsDelete], [CreateDate], [UpdateDate]) VALUES (31, 3, 1, N'Router Toto Link 150', N'W12CXFDc', CAST(N'2018-11-30T00:00:00.000' AS DateTime), CAST(N'2018-11-15T00:00:00.000' AS DateTime), N'12.33.15.12', N'81', N'ádasdasd', N'ádasdsad', CAST(N'2018-11-29T00:00:00.000' AS DateTime), N'ádasdasdasđsa', 0, CAST(N'2018-11-08T18:17:22.457' AS DateTime), CAST(N'2018-11-08T18:17:22.457' AS DateTime))
INSERT [dbo].[Device] ([DeviceId], [AgencyId], [DeviceTypeId], [DeviceName], [DeviceCode], [GuarantyStartDate], [GuarantyEndDate], [Ip], [Port], [DeviceAccount], [DevicePassword], [SettingDate], [Other], [IsDelete], [CreateDate], [UpdateDate]) VALUES (43, 31, 1, N'Router TENDA N301 300Mbps Wireless N', N'N301', CAST(N'2018-11-14T00:00:00.000' AS DateTime), CAST(N'2019-10-31T00:00:00.000' AS DateTime), N'192.168.5.135', N'80', N'admin', N'admin', CAST(N'2018-11-14T00:00:00.000' AS DateTime), N'Wifi trên tầng 1', 0, CAST(N'2018-11-14T13:37:35.253' AS DateTime), CAST(N'2018-11-14T13:37:35.253' AS DateTime))
INSERT [dbo].[Device] ([DeviceId], [AgencyId], [DeviceTypeId], [DeviceName], [DeviceCode], [GuarantyStartDate], [GuarantyEndDate], [Ip], [Port], [DeviceAccount], [DevicePassword], [SettingDate], [Other], [IsDelete], [CreateDate], [UpdateDate]) VALUES (44, 31, 2, N'Camera KBVISION KX-S2001CA4', N'KX-S2001CA4ED', CAST(N'2018-11-14T00:00:00.000' AS DateTime), CAST(N'2019-11-27T00:00:00.000' AS DateTime), N'192.168.5.36', N'80', N'admin', N'admin', CAST(N'2018-11-14T00:00:00.000' AS DateTime), N'Camera hồng ngoại 2.0 Megapixel ', 0, CAST(N'2018-11-14T13:41:49.730' AS DateTime), CAST(N'2018-11-14T13:47:01.847' AS DateTime))
INSERT [dbo].[Device] ([DeviceId], [AgencyId], [DeviceTypeId], [DeviceName], [DeviceCode], [GuarantyStartDate], [GuarantyEndDate], [Ip], [Port], [DeviceAccount], [DevicePassword], [SettingDate], [Other], [IsDelete], [CreateDate], [UpdateDate]) VALUES (45, 31, 2, N'Camera KBVISION KX-S2001CA4', N'KX-S2001CA4', CAST(N'2018-11-14T00:00:00.000' AS DateTime), CAST(N'2019-10-31T00:00:00.000' AS DateTime), N'192.168.5.37', N'80', N'admin', N'admin', CAST(N'2018-11-14T00:00:00.000' AS DateTime), N'Camera hồng ngoại 2.0 Megapixel ', 0, CAST(N'2018-11-14T13:47:43.883' AS DateTime), CAST(N'2018-11-14T13:47:52.180' AS DateTime))
SET IDENTITY_INSERT [dbo].[Device] OFF
SET IDENTITY_INSERT [dbo].[DeviceType] ON 

INSERT [dbo].[DeviceType] ([DeviceTypeId], [ServiceId], [DeviceTypeName], [Description], [IsDelete], [CreateDate], [UpdateDate]) VALUES (1, 1, N'Wifi', N'Thiết bị wifi', 0, CAST(N'2018-10-03T00:00:00.000' AS DateTime), CAST(N'2018-11-11T19:51:22.117' AS DateTime))
INSERT [dbo].[DeviceType] ([DeviceTypeId], [ServiceId], [DeviceTypeName], [Description], [IsDelete], [CreateDate], [UpdateDate]) VALUES (2, 2, N'Camera', N'Bao gồm các thiết bị Camera', 0, CAST(N'2018-10-03T00:00:00.000' AS DateTime), CAST(N'2018-11-10T17:40:53.573' AS DateTime))
INSERT [dbo].[DeviceType] ([DeviceTypeId], [ServiceId], [DeviceTypeName], [Description], [IsDelete], [CreateDate], [UpdateDate]) VALUES (4, 3, N'Pos', N'Máy tính tiền', 0, CAST(N'2018-10-10T00:00:00.000' AS DateTime), CAST(N'2018-11-10T13:22:36.113' AS DateTime))
INSERT [dbo].[DeviceType] ([DeviceTypeId], [ServiceId], [DeviceTypeName], [Description], [IsDelete], [CreateDate], [UpdateDate]) VALUES (10, 14, N'Windows', N'Win 7, 8 , 10', 0, CAST(N'2018-11-10T17:52:06.687' AS DateTime), CAST(N'2018-11-10T17:53:18.743' AS DateTime))
SET IDENTITY_INSERT [dbo].[DeviceType] OFF
SET IDENTITY_INSERT [dbo].[Guideline] ON 

INSERT [dbo].[Guideline] ([GuidelineId], [ServiceItemId], [GuidelineName], [IsDelete], [CreateDate], [UpdateDate]) VALUES (1, 1, N'Kiểm tra phần cứng', 0, CAST(N'2018-10-08T00:00:00.000' AS DateTime), CAST(N'2018-11-14T17:28:42.167' AS DateTime))
INSERT [dbo].[Guideline] ([GuidelineId], [ServiceItemId], [GuidelineName], [IsDelete], [CreateDate], [UpdateDate]) VALUES (3, 1, N'Kiểm tra hợp đồng mạng', 0, CAST(N'2018-10-10T00:00:00.000' AS DateTime), CAST(N'2018-10-10T00:00:00.000' AS DateTime))
INSERT [dbo].[Guideline] ([GuidelineId], [ServiceItemId], [GuidelineName], [IsDelete], [CreateDate], [UpdateDate]) VALUES (5, 1, N'Kiểm tra kết nối cáp', 0, CAST(N'2018-11-10T00:00:00.000' AS DateTime), CAST(N'2018-10-10T00:00:00.000' AS DateTime))
INSERT [dbo].[Guideline] ([GuidelineId], [ServiceItemId], [GuidelineName], [IsDelete], [CreateDate], [UpdateDate]) VALUES (6, 6, N'Kiểm tra kết nối cáp', 0, CAST(N'2018-11-14T17:28:52.357' AS DateTime), CAST(N'2018-10-10T00:00:00.000' AS DateTime))
INSERT [dbo].[Guideline] ([GuidelineId], [ServiceItemId], [GuidelineName], [IsDelete], [CreateDate], [UpdateDate]) VALUES (7, 7, N'Kiểm tra kết nối nhà mạng', 0, CAST(N'2018-11-15T11:35:47.523' AS DateTime), CAST(N'2018-11-22T11:20:11.507' AS DateTime))
INSERT [dbo].[Guideline] ([GuidelineId], [ServiceItemId], [GuidelineName], [IsDelete], [CreateDate], [UpdateDate]) VALUES (8, 7, N'Kiểm tra IP', 0, CAST(N'2018-11-15T11:36:35.473' AS DateTime), CAST(N'2018-10-10T00:00:00.000' AS DateTime))
INSERT [dbo].[Guideline] ([GuidelineId], [ServiceItemId], [GuidelineName], [IsDelete], [CreateDate], [UpdateDate]) VALUES (9, 6, N'Reset router', 0, CAST(N'2018-11-22T11:16:33.170' AS DateTime), CAST(N'2018-11-22T11:16:33.170' AS DateTime))
INSERT [dbo].[Guideline] ([GuidelineId], [ServiceItemId], [GuidelineName], [IsDelete], [CreateDate], [UpdateDate]) VALUES (10, 6, N'Đặt router tránh xa các thiết bị không dây, kim loại', 0, CAST(N'2018-11-22T11:16:47.090' AS DateTime), CAST(N'2018-11-22T11:16:47.090' AS DateTime))
INSERT [dbo].[Guideline] ([GuidelineId], [ServiceItemId], [GuidelineName], [IsDelete], [CreateDate], [UpdateDate]) VALUES (11, 6, N'Loại bỏ các phần mềm độc hại ra khỏi thiết bị', 0, CAST(N'2018-11-22T11:17:53.430' AS DateTime), CAST(N'2018-11-22T11:17:53.430' AS DateTime))
INSERT [dbo].[Guideline] ([GuidelineId], [ServiceItemId], [GuidelineName], [IsDelete], [CreateDate], [UpdateDate]) VALUES (12, 6, N'Tắt bớt các ứng dụng chạy nền', 0, CAST(N'2018-11-22T11:18:19.907' AS DateTime), CAST(N'2018-11-22T11:18:19.907' AS DateTime))
INSERT [dbo].[Guideline] ([GuidelineId], [ServiceItemId], [GuidelineName], [IsDelete], [CreateDate], [UpdateDate]) VALUES (13, 7, N'Khởi Động Lại Router Wifi', 0, CAST(N'2018-11-22T11:20:22.577' AS DateTime), CAST(N'2018-11-22T11:21:31.790' AS DateTime))
INSERT [dbo].[Guideline] ([GuidelineId], [ServiceItemId], [GuidelineName], [IsDelete], [CreateDate], [UpdateDate]) VALUES (14, 7, N'Xóa Và Thêm Lại Mạng Wifi', 0, CAST(N'2018-11-22T11:22:03.870' AS DateTime), CAST(N'2018-11-22T11:22:03.870' AS DateTime))
INSERT [dbo].[Guideline] ([GuidelineId], [ServiceItemId], [GuidelineName], [IsDelete], [CreateDate], [UpdateDate]) VALUES (15, 7, N'Kiểm Tra Cài Đặt Router Wifi', 0, CAST(N'2018-11-22T11:22:43.413' AS DateTime), CAST(N'2018-11-22T11:22:43.413' AS DateTime))
INSERT [dbo].[Guideline] ([GuidelineId], [ServiceItemId], [GuidelineName], [IsDelete], [CreateDate], [UpdateDate]) VALUES (16, 7, N'Cài Đặt Lại Driver Card Mạng', 0, CAST(N'2018-11-22T11:22:58.387' AS DateTime), CAST(N'2018-11-22T11:22:58.387' AS DateTime))
INSERT [dbo].[Guideline] ([GuidelineId], [ServiceItemId], [GuidelineName], [IsDelete], [CreateDate], [UpdateDate]) VALUES (17, 5, N'kiểm tra dây điện/ Kết nối', 0, CAST(N'2018-11-22T11:27:22.970' AS DateTime), CAST(N'2018-11-22T11:27:22.970' AS DateTime))
INSERT [dbo].[Guideline] ([GuidelineId], [ServiceItemId], [GuidelineName], [IsDelete], [CreateDate], [UpdateDate]) VALUES (18, 5, N'Khởi động lại ứng dụng của máy Pos', 0, CAST(N'2018-11-22T11:27:45.687' AS DateTime), CAST(N'2018-11-22T11:27:45.687' AS DateTime))
INSERT [dbo].[Guideline] ([GuidelineId], [ServiceItemId], [GuidelineName], [IsDelete], [CreateDate], [UpdateDate]) VALUES (19, 5, N'Kiểm tra máy in bill có bị lỗi không.', 0, CAST(N'2018-11-22T11:28:15.760' AS DateTime), CAST(N'2018-11-22T11:28:15.760' AS DateTime))
INSERT [dbo].[Guideline] ([GuidelineId], [ServiceItemId], [GuidelineName], [IsDelete], [CreateDate], [UpdateDate]) VALUES (20, 19, N'Xác minh nguồn cung cấp năng lượng chuyển đổi điện áp được thiết lập một cách chính xác', 0, CAST(N'2018-11-22T11:35:41.130' AS DateTime), CAST(N'2018-11-22T11:35:41.130' AS DateTime))
INSERT [dbo].[Guideline] ([GuidelineId], [ServiceItemId], [GuidelineName], [IsDelete], [CreateDate], [UpdateDate]) VALUES (21, 19, N' Kiểm tra kết nối cáp điện có bị ngắt kết nối với máy tính', 0, CAST(N'2018-11-22T11:35:58.077' AS DateTime), CAST(N'2018-11-22T11:35:58.077' AS DateTime))
INSERT [dbo].[Guideline] ([GuidelineId], [ServiceItemId], [GuidelineName], [IsDelete], [CreateDate], [UpdateDate]) VALUES (22, 19, N' Thay thế dây và cáp điện của máy tính', 0, CAST(N'2018-11-22T11:36:10.433' AS DateTime), CAST(N'2018-11-22T11:36:10.433' AS DateTime))
INSERT [dbo].[Guideline] ([GuidelineId], [ServiceItemId], [GuidelineName], [IsDelete], [CreateDate], [UpdateDate]) VALUES (23, 19, N'Thực hiện một thử nghiệm thông qua bóng đèn thắp sáng để xác minh nguồn cấp điện vẫn hiện hữu trên các bức tường có đường dây cáp điện', 0, CAST(N'2018-11-22T11:36:25.160' AS DateTime), CAST(N'2018-11-22T11:36:25.160' AS DateTime))
INSERT [dbo].[Guideline] ([GuidelineId], [ServiceItemId], [GuidelineName], [IsDelete], [CreateDate], [UpdateDate]) VALUES (24, 19, N'Kiểm tra bộ nguồn cung cấp điện được gắn trong máy tính', 0, CAST(N'2018-11-22T11:36:56.630' AS DateTime), CAST(N'2018-11-22T11:36:56.630' AS DateTime))
INSERT [dbo].[Guideline] ([GuidelineId], [ServiceItemId], [GuidelineName], [IsDelete], [CreateDate], [UpdateDate]) VALUES (25, 19, N'Kiểm tra nút nguồn điện trên mặt trước vỏ thùng máy tính của bạn', 0, CAST(N'2018-11-22T11:37:16.587' AS DateTime), CAST(N'2018-11-22T11:37:16.587' AS DateTime))
INSERT [dbo].[Guideline] ([GuidelineId], [ServiceItemId], [GuidelineName], [IsDelete], [CreateDate], [UpdateDate]) VALUES (26, 19, N'Thay thế bo mạch chủ của bạn', 0, CAST(N'2018-11-22T11:37:26.447' AS DateTime), CAST(N'2018-11-22T11:37:26.447' AS DateTime))
SET IDENTITY_INSERT [dbo].[Guideline] OFF
SET IDENTITY_INSERT [dbo].[ITSupporter] ON 

INSERT [dbo].[ITSupporter] ([ITSupporterId], [ITSupporterName], [AccountId], [Telephone], [Email], [Gender], [Address], [RatingAVG], [IsBusy], [IsOnline], [IsDelete], [CreateDate], [UpdateDate]) VALUES (1, N'Lê Hồng Ân', 2, N'0152012421', N'anlh@gmail.com', 1, N'742 Lê Đức Thọ', 0, 1, 1, 0, CAST(N'2018-10-03T00:00:00.000' AS DateTime), CAST(N'2018-11-22T12:36:46.237' AS DateTime))
INSERT [dbo].[ITSupporter] ([ITSupporterId], [ITSupporterName], [AccountId], [Telephone], [Email], [Gender], [Address], [RatingAVG], [IsBusy], [IsOnline], [IsDelete], [CreateDate], [UpdateDate]) VALUES (2, N'Phạm Phú Tiến', 6, N'0916512300', N'tienpp@gmail.com', 1, N'341 Tỉnh lộ 10', 0, 1, 1, 0, CAST(N'2018-10-17T00:00:00.000' AS DateTime), CAST(N'2018-11-22T11:41:01.107' AS DateTime))
INSERT [dbo].[ITSupporter] ([ITSupporterId], [ITSupporterName], [AccountId], [Telephone], [Email], [Gender], [Address], [RatingAVG], [IsBusy], [IsOnline], [IsDelete], [CreateDate], [UpdateDate]) VALUES (3, N'Đỗ Hoàng Long', 9, N'02322205', N'longdo@gmail.com', 1, N'69 Bình Thạnh', 0, 1, 1, 0, CAST(N'2018-10-17T00:00:00.000' AS DateTime), CAST(N'2018-11-22T12:26:54.203' AS DateTime))
INSERT [dbo].[ITSupporter] ([ITSupporterId], [ITSupporterName], [AccountId], [Telephone], [Email], [Gender], [Address], [RatingAVG], [IsBusy], [IsOnline], [IsDelete], [CreateDate], [UpdateDate]) VALUES (5, N'Ngô Thanh Chiến', 12, N'0773909125', N'chienntse62036@gmail.com', 1, N'8 CMT7', 0, 0, 0, 0, CAST(N'2018-01-01T00:00:00.000' AS DateTime), CAST(N'2018-11-22T11:42:11.850' AS DateTime))
SET IDENTITY_INSERT [dbo].[ITSupporter] OFF
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

INSERT [dbo].[ServiceItem] ([ServiceItemId], [ServiceITSupportId], [ServiceItemName], [Description], [IsDelete], [CreateDate], [UpdateDate]) VALUES (1, 1, N'Wifi không vào được', N'Wifi của bạn không vào được? Bạn không biết làm gì để sửa chúng! Hãy để chúng tôi giúp bạn', 0, CAST(N'2018-10-03T00:00:00.000' AS DateTime), CAST(N'2018-11-14T11:35:39.433' AS DateTime))
INSERT [dbo].[ServiceItem] ([ServiceItemId], [ServiceITSupportId], [ServiceItemName], [Description], [IsDelete], [CreateDate], [UpdateDate]) VALUES (3, 2, N'Camera không hiện màu', N'Camera của bạn không hiển thị màu đươc? \nBạn không biết làm gì để sửa chúng! Hãy để chúng tôi giúp bạn', 0, CAST(N'2018-10-10T00:00:00.000' AS DateTime), CAST(N'2018-10-10T00:00:00.000' AS DateTime))
INSERT [dbo].[ServiceItem] ([ServiceItemId], [ServiceITSupportId], [ServiceItemName], [Description], [IsDelete], [CreateDate], [UpdateDate]) VALUES (5, 3, N'Sửa chữa máy POS  không in được.', N'Máy POS của bạn bị hư! Hãy để chúng tôi giúp bạn', 0, CAST(N'2018-10-10T00:00:00.000' AS DateTime), CAST(N'2018-11-22T11:26:30.800' AS DateTime))
INSERT [dbo].[ServiceItem] ([ServiceItemId], [ServiceITSupportId], [ServiceItemName], [Description], [IsDelete], [CreateDate], [UpdateDate]) VALUES (6, 1, N'Wifi chậm', N'Wifi bạn chậm quá! Hãy để chúng tôi giúp cho nhé', 0, CAST(N'2018-10-19T00:00:00.000' AS DateTime), CAST(N'2018-10-19T00:00:00.000' AS DateTime))
INSERT [dbo].[ServiceItem] ([ServiceItemId], [ServiceITSupportId], [ServiceItemName], [Description], [IsDelete], [CreateDate], [UpdateDate]) VALUES (7, 1, N'Wifi mất kết nối', NULL, 0, CAST(N'2018-11-14T10:49:26.603' AS DateTime), NULL)
INSERT [dbo].[ServiceItem] ([ServiceItemId], [ServiceITSupportId], [ServiceItemName], [Description], [IsDelete], [CreateDate], [UpdateDate]) VALUES (19, 14, N'Mở máy tính không lên', N'Máy tính không lên màn hình hoặc không phản hồi khi bấm nút nguồn khởi động.', 0, CAST(N'2018-11-22T11:31:56.207' AS DateTime), CAST(N'2018-11-22T11:38:57.223' AS DateTime))
SET IDENTITY_INSERT [dbo].[ServiceItem] OFF
SET IDENTITY_INSERT [dbo].[ServiceITSupport] ON 

INSERT [dbo].[ServiceITSupport] ([ServiceITSupportId], [ServiceName], [Description], [IsDelete], [CreateDate], [UpdateDate]) VALUES (1, N'WIFI', N'Sửa wifi', 0, CAST(N'2018-10-03T00:00:00.000' AS DateTime), CAST(N'2018-11-10T17:30:26.070' AS DateTime))
INSERT [dbo].[ServiceITSupport] ([ServiceITSupportId], [ServiceName], [Description], [IsDelete], [CreateDate], [UpdateDate]) VALUES (2, N'CAMERA', N'Sửa Camera', 0, CAST(N'2018-10-10T00:00:00.000' AS DateTime), CAST(N'2018-11-10T17:31:11.937' AS DateTime))
INSERT [dbo].[ServiceITSupport] ([ServiceITSupportId], [ServiceName], [Description], [IsDelete], [CreateDate], [UpdateDate]) VALUES (3, N'POS', N'Sửa máy tính tiền', 0, CAST(N'2018-10-10T00:00:00.000' AS DateTime), CAST(N'2018-11-10T17:30:58.057' AS DateTime))
INSERT [dbo].[ServiceITSupport] ([ServiceITSupportId], [ServiceName], [Description], [IsDelete], [CreateDate], [UpdateDate]) VALUES (14, N'SOFTWARE', N'Sửa phầm mềm cho quán', 0, CAST(N'2018-11-13T01:58:31.967' AS DateTime), CAST(N'2018-11-13T14:03:18.180' AS DateTime))
SET IDENTITY_INSERT [dbo].[ServiceITSupport] OFF
SET IDENTITY_INSERT [dbo].[Skill] ON 

INSERT [dbo].[Skill] ([SkillId], [ITSupporterId], [ServiceITSupportId], [MonthExperience], [IsDelete], [CreateDate], [UpdateDate]) VALUES (1, 1, 1, 10, 0, CAST(N'2018-10-10T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Skill] ([SkillId], [ITSupporterId], [ServiceITSupportId], [MonthExperience], [IsDelete], [CreateDate], [UpdateDate]) VALUES (2, 2, 1, 7, 0, CAST(N'2018-10-10T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Skill] ([SkillId], [ITSupporterId], [ServiceITSupportId], [MonthExperience], [IsDelete], [CreateDate], [UpdateDate]) VALUES (4, 3, 1, 3, 0, CAST(N'2018-10-10T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Skill] ([SkillId], [ITSupporterId], [ServiceITSupportId], [MonthExperience], [IsDelete], [CreateDate], [UpdateDate]) VALUES (5, 5, 1, 11, 0, CAST(N'2018-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Skill] ([SkillId], [ITSupporterId], [ServiceITSupportId], [MonthExperience], [IsDelete], [CreateDate], [UpdateDate]) VALUES (12, 1, 3, 3, 0, CAST(N'2018-11-22T11:40:23.610' AS DateTime), CAST(N'2018-11-22T11:40:23.610' AS DateTime))
INSERT [dbo].[Skill] ([SkillId], [ITSupporterId], [ServiceITSupportId], [MonthExperience], [IsDelete], [CreateDate], [UpdateDate]) VALUES (13, 2, 2, 3, 0, CAST(N'2018-11-22T11:40:57.077' AS DateTime), CAST(N'2018-11-22T11:40:57.077' AS DateTime))
INSERT [dbo].[Skill] ([SkillId], [ITSupporterId], [ServiceITSupportId], [MonthExperience], [IsDelete], [CreateDate], [UpdateDate]) VALUES (14, 3, 14, 4, 0, CAST(N'2018-11-22T11:41:14.797' AS DateTime), CAST(N'2018-11-22T11:41:14.797' AS DateTime))
INSERT [dbo].[Skill] ([SkillId], [ITSupporterId], [ServiceITSupportId], [MonthExperience], [IsDelete], [CreateDate], [UpdateDate]) VALUES (15, 5, 3, 5, 0, CAST(N'2018-11-22T11:41:40.563' AS DateTime), CAST(N'2018-11-22T11:41:40.563' AS DateTime))
SET IDENTITY_INSERT [dbo].[Skill] OFF
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
ALTER TABLE [dbo].[ContractServiceITSupport]  WITH CHECK ADD  CONSTRAINT [FK_ContractServiceITSupport_Contract] FOREIGN KEY([ContractId])
REFERENCES [dbo].[Contract] ([ContractId])
GO
ALTER TABLE [dbo].[ContractServiceITSupport] CHECK CONSTRAINT [FK_ContractServiceITSupport_Contract]
GO
ALTER TABLE [dbo].[ContractServiceITSupport]  WITH CHECK ADD  CONSTRAINT [FK_ContractServiceITSupport_ServiceITSupport] FOREIGN KEY([ServiceITSupportId])
REFERENCES [dbo].[ServiceITSupport] ([ServiceITSupportId])
GO
ALTER TABLE [dbo].[ContractServiceITSupport] CHECK CONSTRAINT [FK_ContractServiceITSupport_ServiceITSupport]
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
ALTER TABLE [dbo].[DeviceType]  WITH CHECK ADD  CONSTRAINT [FK_DeviceType_ServiceITSupport] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[ServiceITSupport] ([ServiceITSupportId])
GO
ALTER TABLE [dbo].[DeviceType] CHECK CONSTRAINT [FK_DeviceType_ServiceITSupport]
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
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_Request_ITSupporter] FOREIGN KEY([CurrentITSupporter_Id])
REFERENCES [dbo].[ITSupporter] ([ITSupporterId])
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_Request_ITSupporter]
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_Request_RequestCategory] FOREIGN KEY([RequestCategoryId])
REFERENCES [dbo].[RequestCategory] ([RequestCategoryId])
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_Request_RequestCategory]
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_Request_ServiceItem] FOREIGN KEY([ServiceItemId])
REFERENCES [dbo].[ServiceItem] ([ServiceItemId])
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_Request_ServiceItem]
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_Agency] FOREIGN KEY([AgencyId])
REFERENCES [dbo].[Agency] ([AgencyId])
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_Ticket_Agency]
GO
ALTER TABLE [dbo].[RequestHistory]  WITH CHECK ADD  CONSTRAINT [FK_TicketHistory_ITSupporter] FOREIGN KEY([Pre_It_SupporterId])
REFERENCES [dbo].[ITSupporter] ([ITSupporterId])
GO
ALTER TABLE [dbo].[RequestHistory] CHECK CONSTRAINT [FK_TicketHistory_ITSupporter]
GO
ALTER TABLE [dbo].[RequestHistory]  WITH CHECK ADD  CONSTRAINT [FK_TicketHistory_Request] FOREIGN KEY([RequestId])
REFERENCES [dbo].[Request] ([RequestId])
GO
ALTER TABLE [dbo].[RequestHistory] CHECK CONSTRAINT [FK_TicketHistory_Request]
GO
ALTER TABLE [dbo].[RequestTask]  WITH CHECK ADD  CONSTRAINT [FK_RequestTask_Request] FOREIGN KEY([RequestId])
REFERENCES [dbo].[Request] ([RequestId])
GO
ALTER TABLE [dbo].[RequestTask] CHECK CONSTRAINT [FK_RequestTask_Request]
GO
ALTER TABLE [dbo].[ServiceItem]  WITH CHECK ADD  CONSTRAINT [FK_ServiceItem_Service] FOREIGN KEY([ServiceITSupportId])
REFERENCES [dbo].[ServiceITSupport] ([ServiceITSupportId])
GO
ALTER TABLE [dbo].[ServiceItem] CHECK CONSTRAINT [FK_ServiceItem_Service]
GO
ALTER TABLE [dbo].[Skill]  WITH CHECK ADD  CONSTRAINT [FK_Skill_ITSupporter] FOREIGN KEY([ITSupporterId])
REFERENCES [dbo].[ITSupporter] ([ITSupporterId])
GO
ALTER TABLE [dbo].[Skill] CHECK CONSTRAINT [FK_Skill_ITSupporter]
GO
ALTER TABLE [dbo].[Skill]  WITH CHECK ADD  CONSTRAINT [FK_Skill_ServiceITSupport] FOREIGN KEY([ServiceITSupportId])
REFERENCES [dbo].[ServiceITSupport] ([ServiceITSupportId])
GO
ALTER TABLE [dbo].[Skill] CHECK CONSTRAINT [FK_Skill_ServiceITSupport]
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
USE [master]
GO
ALTER DATABASE [ODTS_DB] SET  READ_WRITE 
GO
