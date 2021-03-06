USE [master]
GO
/****** Object:  Database [ODTS_DB]    Script Date: 11/21/2018 1:30:53 PM ******/
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
/****** Object:  User [saa]    Script Date: 11/21/2018 1:30:54 PM ******/
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
/****** Object:  Table [dbo].[Account]    Script Date: 11/21/2018 1:30:55 PM ******/
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
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Agency]    Script Date: 11/21/2018 1:30:55 PM ******/
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
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_Agency] PRIMARY KEY CLUSTERED 
(
	[AgencyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 11/21/2018 1:30:55 PM ******/
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
/****** Object:  Table [dbo].[Contract]    Script Date: 11/21/2018 1:30:55 PM ******/
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
/****** Object:  Table [dbo].[ContractServiceITSupport]    Script Date: 11/21/2018 1:30:55 PM ******/
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
	[IsDelete] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_ContractService_1] PRIMARY KEY CLUSTERED 
(
	[ContractServiceITSupportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Device]    Script Date: 11/21/2018 1:30:55 PM ******/
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
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_Device] PRIMARY KEY CLUSTERED 
(
	[DeviceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeviceType]    Script Date: 11/21/2018 1:30:56 PM ******/
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
/****** Object:  Table [dbo].[Guideline]    Script Date: 11/21/2018 1:30:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Guideline](
	[GuidelineId] [int] IDENTITY(1,1) NOT NULL,
	[ServiceItemId] [int] NOT NULL,
	[GuidelineName] [nvarchar](max) NULL,
	[IsDelete] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_Guideline] PRIMARY KEY CLUSTERED 
(
	[GuidelineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ITSupporter]    Script Date: 11/21/2018 1:30:56 PM ******/
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
/****** Object:  Table [dbo].[Request]    Script Date: 11/21/2018 1:30:56 PM ******/
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
/****** Object:  Table [dbo].[RequestCategory]    Script Date: 11/21/2018 1:30:56 PM ******/
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
/****** Object:  Table [dbo].[RequestHistory]    Script Date: 11/21/2018 1:30:56 PM ******/
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
/****** Object:  Table [dbo].[RequestTask]    Script Date: 11/21/2018 1:30:57 PM ******/
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
/****** Object:  Table [dbo].[Role]    Script Date: 11/21/2018 1:30:57 PM ******/
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
/****** Object:  Table [dbo].[ServiceItem]    Script Date: 11/21/2018 1:30:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceItem](
	[ServiceItemId] [int] IDENTITY(1,1) NOT NULL,
	[ServiceITSupportId] [int] NOT NULL,
	[ServiceItemName] [nvarchar](50) NULL,
	[Price] [float] NULL,
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
/****** Object:  Table [dbo].[ServiceITSupport]    Script Date: 11/21/2018 1:30:57 PM ******/
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
/****** Object:  Table [dbo].[Skill]    Script Date: 11/21/2018 1:30:57 PM ******/
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
/****** Object:  Table [dbo].[Ticket]    Script Date: 11/21/2018 1:30:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ticket](
	[TicketId] [int] IDENTITY(1,1) NOT NULL,
	[RequestId] [int] NOT NULL,
	[DeviceId] [int] NOT NULL,
	[Desciption] [nvarchar](max) NULL,
	[Current_TicketStatus] [int] NULL,
	[CurrentITSupporter_Id] [int] NULL,
	[StartTime] [datetime] NULL,
	[Endtime] [datetime] NULL,
	[IsDelete] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_TicketDetail] PRIMARY KEY CLUSTERED 
(
	[TicketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
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
