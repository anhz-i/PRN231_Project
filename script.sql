USE [master]
GO
/****** Object:  Database [Quizlet_Project]    Script Date: 07-Nov-23 12:45:04 AM ******/
CREATE DATABASE [Quizlet_Project]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PRM392_Project', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PRM392_Project.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PRM392_Project_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PRM392_Project_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Quizlet_Project] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Quizlet_Project].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Quizlet_Project] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Quizlet_Project] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Quizlet_Project] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Quizlet_Project] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Quizlet_Project] SET ARITHABORT OFF 
GO
ALTER DATABASE [Quizlet_Project] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Quizlet_Project] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Quizlet_Project] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Quizlet_Project] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Quizlet_Project] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Quizlet_Project] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Quizlet_Project] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Quizlet_Project] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Quizlet_Project] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Quizlet_Project] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Quizlet_Project] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Quizlet_Project] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Quizlet_Project] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Quizlet_Project] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Quizlet_Project] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Quizlet_Project] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Quizlet_Project] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Quizlet_Project] SET RECOVERY FULL 
GO
ALTER DATABASE [Quizlet_Project] SET  MULTI_USER 
GO
ALTER DATABASE [Quizlet_Project] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Quizlet_Project] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Quizlet_Project] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Quizlet_Project] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Quizlet_Project] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Quizlet_Project] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Quizlet_Project', N'ON'
GO
ALTER DATABASE [Quizlet_Project] SET QUERY_STORE = OFF
GO
USE [Quizlet_Project]
GO
/****** Object:  Table [dbo].[ChatGPT]    Script Date: 07-Nov-23 12:45:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChatGPT](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NULL,
	[Question] [nvarchar](1000) NOT NULL,
	[Answer] [nvarchar](1000) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[Count] [int] NOT NULL,
	[IsImportant] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Class_Member]    Script Date: 07-Nov-23 12:45:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class_Member](
	[UpdateDate] [datetime] NULL,
	[CreatedDate] [datetime] NULL,
	[ClassId] [bigint] NOT NULL,
	[MemberId] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ClassId] ASC,
	[MemberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Class_Set]    Script Date: 07-Nov-23 12:45:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class_Set](
	[UpdateDate] [datetime] NULL,
	[CreatedDate] [datetime] NULL,
	[ClassId] [bigint] NOT NULL,
	[SetId] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SetId] ASC,
	[ClassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Classes]    Script Date: 07-Nov-23 12:45:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classes](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[Description] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FlashCards]    Script Date: 07-Nov-23 12:45:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FlashCards](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SetsId] [bigint] NULL,
	[Question] [nvarchar](1000) NOT NULL,
	[Answer] [nvarchar](1000) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[IsImportant] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Folder]    Script Date: 07-Nov-23 12:45:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Folder](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[Description] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FolderDetail]    Script Date: 07-Nov-23 12:45:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FolderDetail](
	[CreatedDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[SetId] [bigint] NOT NULL,
	[FolderId] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SetId] ASC,
	[FolderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 07-Nov-23 12:45:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](100) NOT NULL,
	[Description] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudySets]    Script Date: 07-Nov-23 12:45:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudySets](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[Description] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 07-Nov-23 12:45:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Password] [varchar](200) NOT NULL,
	[Username] [varchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User_FlashCard]    Script Date: 07-Nov-23 12:45:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_FlashCard](
	[UserId] [bigint] NOT NULL,
	[FlashCardId] [bigint] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[IsImportant] [bit] NULL,
	[IsStudied] [bit] NULL,
	[IsRemembered] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[FlashCardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User_Role]    Script Date: 07-Nov-23 12:45:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Role](
	[UserId] [bigint] NOT NULL,
	[RoleId] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User_StudySet]    Script Date: 07-Nov-23 12:45:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_StudySet](
	[UserId] [bigint] NOT NULL,
	[SetId] [bigint] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[CreatedDate] [datetime] NULL,
	[isFavorite] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[SetId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ChatGPT]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Class_Member]  WITH CHECK ADD FOREIGN KEY([ClassId])
REFERENCES [dbo].[Classes] ([Id])
GO
ALTER TABLE [dbo].[Class_Member]  WITH CHECK ADD FOREIGN KEY([MemberId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Class_Set]  WITH CHECK ADD FOREIGN KEY([ClassId])
REFERENCES [dbo].[Classes] ([Id])
GO
ALTER TABLE [dbo].[Class_Set]  WITH CHECK ADD FOREIGN KEY([SetId])
REFERENCES [dbo].[StudySets] ([Id])
GO
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FlashCards]  WITH CHECK ADD FOREIGN KEY([SetsId])
REFERENCES [dbo].[StudySets] ([Id])
GO
ALTER TABLE [dbo].[Folder]  WITH CHECK ADD FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[FolderDetail]  WITH CHECK ADD FOREIGN KEY([FolderId])
REFERENCES [dbo].[Folder] ([Id])
GO
ALTER TABLE [dbo].[FolderDetail]  WITH CHECK ADD FOREIGN KEY([SetId])
REFERENCES [dbo].[StudySets] ([Id])
GO
ALTER TABLE [dbo].[StudySets]  WITH CHECK ADD FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[User_FlashCard]  WITH CHECK ADD FOREIGN KEY([FlashCardId])
REFERENCES [dbo].[FlashCards] ([Id])
GO
ALTER TABLE [dbo].[User_FlashCard]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[User_Role]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[User_Role]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[User_StudySet]  WITH CHECK ADD FOREIGN KEY([SetId])
REFERENCES [dbo].[StudySets] ([Id])
GO
ALTER TABLE [dbo].[User_StudySet]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
USE [master]
GO
ALTER DATABASE [Quizlet_Project] SET  READ_WRITE 
GO
