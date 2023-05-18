USE [master]
GO
/****** Object:  Database [BJBhavyaJoshi]    Script Date: 5/18/2023 3:30:18 PM ******/
CREATE DATABASE [BJBhavyaJoshi]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BJBhavyaJoshi', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BJBhavyaJoshi.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BJBhavyaJoshi_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BJBhavyaJoshi_log.ldf' , SIZE = 139264KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BJBhavyaJoshi] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BJBhavyaJoshi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BJBhavyaJoshi] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BJBhavyaJoshi] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BJBhavyaJoshi] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BJBhavyaJoshi] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BJBhavyaJoshi] SET ARITHABORT OFF 
GO
ALTER DATABASE [BJBhavyaJoshi] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BJBhavyaJoshi] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BJBhavyaJoshi] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BJBhavyaJoshi] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BJBhavyaJoshi] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BJBhavyaJoshi] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BJBhavyaJoshi] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BJBhavyaJoshi] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BJBhavyaJoshi] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BJBhavyaJoshi] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BJBhavyaJoshi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BJBhavyaJoshi] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BJBhavyaJoshi] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BJBhavyaJoshi] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BJBhavyaJoshi] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BJBhavyaJoshi] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BJBhavyaJoshi] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BJBhavyaJoshi] SET RECOVERY FULL 
GO
ALTER DATABASE [BJBhavyaJoshi] SET  MULTI_USER 
GO
ALTER DATABASE [BJBhavyaJoshi] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BJBhavyaJoshi] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BJBhavyaJoshi] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BJBhavyaJoshi] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BJBhavyaJoshi] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BJBhavyaJoshi] SET QUERY_STORE = OFF
GO
USE [BJBhavyaJoshi]
GO
/****** Object:  Schema [STUDENT]    Script Date: 5/18/2023 3:30:18 PM ******/
CREATE SCHEMA [STUDENT]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetMedicine]    Script Date: 5/18/2023 3:30:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[fn_GetMedicine](@Diagnosis int)
returns varchar(255)
as
begin
	declare @Medicine varchar(255);
	select @Medicine = isnull(M.MedicineName,'') from medicine M where M.DiagnosisId = @Diagnosis
	return @Medicine
end
GO
/****** Object:  UserDefinedFunction [dbo].[Fn_GetMedicineName]    Script Date: 5/18/2023 3:30:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[Fn_GetMedicineName]
(@Diagnosis varchar(100))

RETURNS varchar(100)
AS

BEGIN

	RETURN (SELECT MedicineName FROM Medicine 
	INNER JOIN Diagnosis 
	ON Diagnosis.Id=Medicine.DiagnosisId
	WHERE Diagnosis.DiagnosisDetails = @Diagnosis)
END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_getMeds]    Script Date: 5/18/2023 3:30:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[fn_getMeds](@patient int)
returns varchar(255)
as
begin
declare @meds varchar(255);	
declare @ids varchar(255);
select @ids =  stuff((
select (',' + cast(T.Diagnosis as varchar)) from TreatmentDetails T, [user] U where T.PatientId = U.ID and U.id = @patient for xml path('')),1,1,'')

select @meds = stuff((select ',' + MedicineName from medicine where DiagnosisId in 
(select Id from diagnosis where Id in (select value from string_split(@ids,',')))
 for xml path('')),1,1,'')
 return @meds
end
GO
/****** Object:  UserDefinedFunction [dbo].[fn_getMeds1]    Script Date: 5/18/2023 3:30:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[fn_getMeds1](@dia varchar(255))
returns varchar(255)
as
begin
declare @meds varchar(255);	
--declare @ids varchar(255);
--select @ids =  stuff((
--select (',' + cast(T.Diagnosis as varchar)) from TreatmentDetails T, [user] U where T.PatientId = U.ID and U.id = @patient for xml path('')),1,1,'')

select @meds = stuff((select ',' + MedicineName from medicine where DiagnosisId in 
(select Id from diagnosis where Id in (select value from string_split(@dia,',')))
 for xml path('')),1,1,'')
 return @meds
end
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetName]    Script Date: 5/18/2023 3:30:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[fn_GetName](@Id int)
returns varchar(255)
as
begin
	declare @Name varchar(255);
	select @Name = (U.firstName + ' ' + U.lastName)  from [User] U where U.Id = @Id
	return @Name
end
GO
/****** Object:  UserDefinedFunction [dbo].[fn_getSubject]    Script Date: 5/18/2023 3:30:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[fn_getSubject](@t_id INT)
     RETURNS VARCHAR(100)
     as
     BEGIN
        DECLARE @ANY VARCHAR(255)
        SET @ANY = '';
        SELECT 
     @ANY = @ANY  + (select subjectName from Subject where Id = value) + ','
FROM 
    Teacher t 
    left join Subject s on CAST(s.Id as varchar(20)) = t.TeacherSubject 
    CROSS APPLY STRING_SPLIT(t.TeacherSubject, ',') WHERE t.Id =@t_id;
	select @ANY = SUBSTRING(@ANY,1,(len(@ANY)-1));
    RETURN @ANY
END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_getTeacher]    Script Date: 5/18/2023 3:30:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[fn_getTeacher](@t_id INT)
     RETURNS VARCHAR(100)
     as
     BEGIN
        DECLARE @ANY VARCHAR(255)
        SET @ANY = '';
        SELECT 
     @ANY = @ANY  + (select (FirstName + ' ' + LastName) as TeacherName from Teacher where Id = value) + ','
FROM 
    Student S 
    left join Teacher T on CAST(T.Id as varchar(20)) = S.Teacher
    CROSS APPLY STRING_SPLIT(S.Teacher, ',') WHERE S.Id =@t_id;
	select @ANY = SUBSTRING(@ANY,1,(len(@ANY)-1));
    RETURN @ANY
END
GO
/****** Object:  Table [dbo].[City]    Script Date: 5/18/2023 3:30:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [varchar](255) NOT NULL,
	[StateId] [int] NULL,
	[CountryId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 5/18/2023 3:30:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Diagnosis]    Script Date: 5/18/2023 3:30:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Diagnosis](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DiagnosisDetails] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medicine]    Script Date: 5/18/2023 3:30:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicine](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MedicineName] [varchar](255) NOT NULL,
	[DiagnosisId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SMS_User]    Script Date: 5/18/2023 3:30:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SMS_User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](255) NOT NULL,
	[Password] [varchar](255) NULL,
	[Email] [varchar](255) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[States]    Script Date: 5/18/2023 3:30:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[States](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StateName] [varchar](255) NOT NULL,
	[CountryId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 5/18/2023 3:30:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](255) NOT NULL,
	[LastName] [varchar](255) NOT NULL,
	[Address] [varchar](max) NULL,
	[MobileNo] [varchar](50) NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[DOB] [date] NOT NULL,
	[Gender] [varchar](20) NOT NULL,
	[Country] [int] NULL,
	[State] [int] NULL,
	[City] [int] NULL,
	[Teacher] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 5/18/2023 3:30:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SubjectName] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 5/18/2023 3:30:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TeacherSubject] [varchar](255) NULL,
	[FirstName] [varchar](255) NULL,
	[LastName] [varchar](255) NULL,
	[Address] [varchar](max) NULL,
	[MobileNo] [varchar](25) NULL,
	[Email] [varchar](50) NULL,
	[DOB] [datetime] NULL,
	[Gender] [varchar](50) NULL,
	[Country] [int] NULL,
	[State] [int] NULL,
	[City] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TreatmentDetails]    Script Date: 5/18/2023 3:30:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TreatmentDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PatientId] [int] NULL,
	[DocterId] [int] NULL,
	[NurseId] [int] NULL,
	[Diagnosis] [varchar](255) NULL,
	[Prescription] [varchar](255) NULL,
	[TreatmentFee] [decimal](7, 2) NOT NULL,
	[DOT] [datetime] NULL,
	[Instruction] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 5/18/2023 3:30:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](255) NOT NULL,
	[LastName] [varchar](255) NOT NULL,
	[Email] [varchar](255) NULL,
	[Password] [varchar](255) NULL,
	[UserTypeId] [int] NULL,
	[Address] [varchar](max) NULL,
	[MobileNo] [varchar](50) NOT NULL,
	[CountryId] [int] NULL,
	[StateId] [int] NULL,
	[CityId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserType]    Script Date: 5/18/2023 3:30:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserTypeName] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[City] ON 

INSERT [dbo].[City] ([Id], [CityName], [StateId], [CountryId]) VALUES (14, N'Palanpur', 14, 4)
INSERT [dbo].[City] ([Id], [CityName], [StateId], [CountryId]) VALUES (15, N'Deesa', 14, 4)
INSERT [dbo].[City] ([Id], [CityName], [StateId], [CountryId]) VALUES (16, N'White Palace', 17, 6)
SET IDENTITY_INSERT [dbo].[City] OFF
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (4, N'India')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (6, N'USA')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (7, N'United States')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (8, N'Canada')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (9, N'Mexico')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (10, N'Brazil')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (11, N'Argentina')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (13, N'Dubai')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (14, N'Bhutan')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (15, N'China')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (16, N'Russia')
SET IDENTITY_INSERT [dbo].[Country] OFF
SET IDENTITY_INSERT [dbo].[Diagnosis] ON 

INSERT [dbo].[Diagnosis] ([Id], [DiagnosisDetails]) VALUES (1, N'Fever')
INSERT [dbo].[Diagnosis] ([Id], [DiagnosisDetails]) VALUES (2, N'Cold')
INSERT [dbo].[Diagnosis] ([Id], [DiagnosisDetails]) VALUES (3, N'Headache')
INSERT [dbo].[Diagnosis] ([Id], [DiagnosisDetails]) VALUES (4, N'Stomachache')
INSERT [dbo].[Diagnosis] ([Id], [DiagnosisDetails]) VALUES (5, N'Vomit')
SET IDENTITY_INSERT [dbo].[Diagnosis] OFF
SET IDENTITY_INSERT [dbo].[Medicine] ON 

INSERT [dbo].[Medicine] ([Id], [MedicineName], [DiagnosisId]) VALUES (1, N'DOLO600', 1)
INSERT [dbo].[Medicine] ([Id], [MedicineName], [DiagnosisId]) VALUES (2, N'Levocetirizine', 2)
INSERT [dbo].[Medicine] ([Id], [MedicineName], [DiagnosisId]) VALUES (3, N'Panadol', 3)
INSERT [dbo].[Medicine] ([Id], [MedicineName], [DiagnosisId]) VALUES (4, N'Liquiprine', 4)
INSERT [dbo].[Medicine] ([Id], [MedicineName], [DiagnosisId]) VALUES (5, N'Paracetemol', 5)
INSERT [dbo].[Medicine] ([Id], [MedicineName], [DiagnosisId]) VALUES (6, N'Naman', 1)
SET IDENTITY_INSERT [dbo].[Medicine] OFF
SET IDENTITY_INSERT [dbo].[SMS_User] ON 

INSERT [dbo].[SMS_User] ([Id], [Username], [Password], [Email], [CreatedOn], [UpdatedOn]) VALUES (1, N'admin', N'123456', N'admin@gmail.com', NULL, NULL)
INSERT [dbo].[SMS_User] ([Id], [Username], [Password], [Email], [CreatedOn], [UpdatedOn]) VALUES (2, N'bhavya0304', N'Bhavya@123', N'kingbhavya@gmail.com', NULL, NULL)
SET IDENTITY_INSERT [dbo].[SMS_User] OFF
SET IDENTITY_INSERT [dbo].[States] ON 

INSERT [dbo].[States] ([Id], [StateName], [CountryId]) VALUES (14, N'Gujarat', 4)
INSERT [dbo].[States] ([Id], [StateName], [CountryId]) VALUES (15, N'Maharashtra', 4)
INSERT [dbo].[States] ([Id], [StateName], [CountryId]) VALUES (16, N'Goa', 4)
INSERT [dbo].[States] ([Id], [StateName], [CountryId]) VALUES (17, N'Washington D.C', 6)
SET IDENTITY_INSERT [dbo].[States] OFF
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Address], [MobileNo], [Email], [DOB], [Gender], [Country], [State], [City], [Teacher]) VALUES (7, N'Bhavya', N'Joshi', N'17, Shukan 121', N'9510012644', N'kingbhavya@gmail.com', CAST(N'2002-01-02' AS Date), N'Male', 4, 14, 14, N'3,4')
SET IDENTITY_INSERT [dbo].[Student] OFF
SET IDENTITY_INSERT [dbo].[Subject] ON 

INSERT [dbo].[Subject] ([Id], [SubjectName]) VALUES (1, N'English')
INSERT [dbo].[Subject] ([Id], [SubjectName]) VALUES (2, N'Social Science')
INSERT [dbo].[Subject] ([Id], [SubjectName]) VALUES (3, N'History')
SET IDENTITY_INSERT [dbo].[Subject] OFF
SET IDENTITY_INSERT [dbo].[Teacher] ON 

INSERT [dbo].[Teacher] ([Id], [TeacherSubject], [FirstName], [LastName], [Address], [MobileNo], [Email], [DOB], [Gender], [Country], [State], [City]) VALUES (3, N'2', N'Vivek', N'Gadhvi', N'Ipandanda ', N'9510012654', N'vivanveer@gmail.com', CAST(N'2001-01-01T00:00:00.000' AS DateTime), N'Male', 6, 17, 16)
INSERT [dbo].[Teacher] ([Id], [TeacherSubject], [FirstName], [LastName], [Address], [MobileNo], [Email], [DOB], [Gender], [Country], [State], [City]) VALUES (4, N'1,2,3', N'Sunny ', N'Shah', N'agola road', N'1234567890', N'sunny@gmail.com', CAST(N'2002-01-02T00:00:00.000' AS DateTime), N'Male', 4, 14, 14)
SET IDENTITY_INSERT [dbo].[Teacher] OFF
SET IDENTITY_INSERT [dbo].[UserType] ON 

INSERT [dbo].[UserType] ([Id], [UserTypeName]) VALUES (1, N'Doctor')
INSERT [dbo].[UserType] ([Id], [UserTypeName]) VALUES (2, N'Patient')
INSERT [dbo].[UserType] ([Id], [UserTypeName]) VALUES (3, N'Nurse')
SET IDENTITY_INSERT [dbo].[UserType] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__User__A9D1053421055D9D]    Script Date: 5/18/2023 3:30:18 PM ******/
ALTER TABLE [dbo].[User] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SMS_User] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[SMS_User] ADD  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[City]  WITH CHECK ADD FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[City]  WITH CHECK ADD FOREIGN KEY([StateId])
REFERENCES [dbo].[States] ([Id])
GO
ALTER TABLE [dbo].[Medicine]  WITH CHECK ADD FOREIGN KEY([DiagnosisId])
REFERENCES [dbo].[Diagnosis] ([Id])
GO
ALTER TABLE [dbo].[States]  WITH CHECK ADD FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD FOREIGN KEY([City])
REFERENCES [dbo].[City] ([Id])
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD FOREIGN KEY([Country])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD FOREIGN KEY([State])
REFERENCES [dbo].[States] ([Id])
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD FOREIGN KEY([City])
REFERENCES [dbo].[City] ([Id])
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD FOREIGN KEY([Country])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD FOREIGN KEY([State])
REFERENCES [dbo].[States] ([Id])
GO
ALTER TABLE [dbo].[TreatmentDetails]  WITH CHECK ADD FOREIGN KEY([DocterId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[TreatmentDetails]  WITH CHECK ADD FOREIGN KEY([NurseId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[TreatmentDetails]  WITH CHECK ADD FOREIGN KEY([PatientId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD FOREIGN KEY([CityId])
REFERENCES [dbo].[City] ([Id])
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD FOREIGN KEY([StateId])
REFERENCES [dbo].[States] ([Id])
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD FOREIGN KEY([UserTypeId])
REFERENCES [dbo].[UserType] ([Id])
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [chk_len] CHECK  ((len([password])>=(8) AND len([password])<=(10)))
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [chk_len]
GO
/****** Object:  StoredProcedure [dbo].[getStudentData]    Script Date: 5/18/2023 3:30:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[getStudentData]
(
	@id int = null
)
as
begin
	select S.*,C.CityName as CityName,Sa.StateName,CO.CountryName,dbo.fn_getTeacher(S.Id) as TeacherName from Student S,City C,States Sa,Country CO where S.State = Sa.Id and CO.Id = S.Country and C.Id = S.City and (isnull(@id,'') = '' or @id = S.Id)
end
GO
/****** Object:  StoredProcedure [dbo].[getTeacherData]    Script Date: 5/18/2023 3:30:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getTeacherData]
(
	@id int = null
)
as
begin
	select T.*,C.CityName,CU.CountryName,S.StateName,dbo.fn_getSubject(T.Id) as Subjects from Teacher T, City C,[States] S, Country CU where T.City = C.Id and T.State = S.Id and CU.Id = T.Country and (isnull(@id,'') = '' or T.Id = @id)
end
GO
/****** Object:  StoredProcedure [dbo].[recordput]    Script Date: 5/18/2023 3:30:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[recordput]
	@value varchar(255)
 as
 begin
	select * from Country

 end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllUsers]    Script Date: 5/18/2023 3:30:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_GetAllUsers]
as
begin
	select * from [User] 
end
GO
/****** Object:  StoredProcedure [dbo].[sp_getDoctor]    Script Date: 5/18/2023 3:30:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_getDoctor](
	@Id int = null
)
as 
begin
	select 
		(U.FirstName + ' ' + U.LastName) as DoctorName,
		(CI.CityName + ',' + S.StateName + ',' + C.CountryName) as [Address],
		U.MobileNo
	from 
		[User] U,UserType UT,City CI,Country C,States S 
	where 
			U.CountryId = C.Id 
		and 
			U.StateId = S.Id 
		and 
			U.CityId = CI.Id 
		and  
			U.UserTypeId = UT.Id 
		and 
			UT.UserTypeName = 'Doctor'
		and		
			(isnull(@Id,'') = '' or @Id = U.Id) 
end
GO
/****** Object:  StoredProcedure [dbo].[SP_GetDoctors]    Script Date: 5/18/2023 3:30:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_GetDoctors]
@UserID INT = NULL 
AS
BEGIN
	IF(@UserID > 0)
	BEGIN
		SELECT ('Dr. ' + FirstName + LastName) AS DoctorName FROM dbo.[User]
		INNER JOIN dbo.UserType ON UserType.Id = [User].UserTypeId
		WHERE UserType.Id = 1 AND [User].Id = @UserID
    END
	ELSE 
	BEGIN
		SELECT CONCAT('Dr. ',FirstName,LastName) AS DoctorName FROM dbo.[User]
		INNER JOIN dbo.UserType ON UserType.Id = [User].UserTypeId
		WHERE UserType.Id = 1 --AND [User].Id = @UserID
	END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertIntoCity]    Script Date: 5/18/2023 3:30:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_InsertIntoCity](
@CityName varchar(255),
@CountryId int,
@StateId int
)
as 
begin
	insert into City values(@CityName,@StateId,@CountryId); 
end
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertIntoCountry]    Script Date: 5/18/2023 3:30:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_InsertIntoCountry](
@id int = null,
@CountryName varchar(255)
)
as 
begin
if(@id is not null)
begin
	insert into Country values(@CountryName) 
end
else
begin
	update Country set CountryName = @CountryName where id = @id
end
end
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertIntoDiagnosis]    Script Date: 5/18/2023 3:30:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_InsertIntoDiagnosis]
(
@DiagnosisDetails varchar(255)
)
as
begin
	insert into Diagnosis values(@DiagnosisDetails); 
end
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertIntoMedicine]    Script Date: 5/18/2023 3:30:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_InsertIntoMedicine]
(
@MedicineName varchar(255),
@DiagnosisId int
)
as
begin
	insert into Medicine values(@MedicineName,@DiagnosisId); 
end
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertIntoState]    Script Date: 5/18/2023 3:30:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_InsertIntoState](
@StateName varchar(255),
@CountryId int
)
as 
begin
	insert into States values(@StateName,@CountryId) 
end
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertIntoTreatment]    Script Date: 5/18/2023 3:30:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[sp_InsertIntoTreatment]
(
@PatientId int,
@DocterId int,
@NurseId int,
@Diagnosis varchar(255),
@Prescription varchar(255),
@TreatmentFee decimal(7,2),
@DOT datetime,
@Instruction nvarchar(max),
@TreatmentId int =null out
)
as
begin
	insert into TreatmentDetails values(@PatientId,@DocterId,@NurseId,@Diagnosis,@Prescription,@TreatmentFee,@DOT,@Instruction); 
	set @TreatmentId = scope_identity();
end
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertIntoUser]    Script Date: 5/18/2023 3:30:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_InsertIntoUser]
(
@FirstName varchar(255),
@LastName varchar(255),
@Email varchar(255),
@Password varchar(255),
@UserTypeId int,
@Address varchar(max),
@MobileNo varchar(50),
@CountryId int,
@StateId int,
@CityId int,
@UserId int =null out
)
as
begin
	insert into [User] values(@FirstName,@LastName,@Email,@Password,@UserTypeId,@Address,@MobileNo,@CountryId,@StateId,@CityId); 
	set @UserId = scope_identity();
end
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertIntoUserType]    Script Date: 5/18/2023 3:30:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_InsertIntoUserType](
@UserTypeName varchar(255)
)
as 
begin
	insert into UserType values(@UserTypeName); 
end
GO
/****** Object:  StoredProcedure [dbo].[sp_RegisterPatient]    Script Date: 5/18/2023 3:30:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[sp_RegisterPatient]
(
	@P_FirstName varchar(255),
	@P_LastName varchar(255),
	@P_Email varchar(255),
	@P_Password varchar(255),
	@P_Address varchar(max),
	@P_Mobile varchar(50),
	@P_StateId int,
	@P_CityId int,
	@P_CountryId int,
	@D_DoctorId int,
	@N_NurseId int,
	@T_Fee decimal(7,2),
	@T_DOT datetime,
	@I_Details varchar(max),
	@Dia varchar(255),
	@pre varchar(255)
)
as
begin
	declare @patientID int,@treatmentId int,@treatmentId2 int;
	-- registration of patient
	begin try
	begin tran
		exec sp_InsertIntoUser @P_FirstName,@P_LastName,@P_Email,@P_Password,2,@P_Address,@P_Mobile,@P_CountryId,@P_StateId,@P_CityId,@patientID out
		commit tran
	end try
	begin catch
		print 'Error in patient reg'
		rollback tran
	end catch

	-- registration for treatment
	begin try
	begin tran
		exec sp_InsertIntoTreatment @patientID,@D_DoctorId,@N_NurseId,@Dia,@pre,@T_Fee,@T_DOT,@I_Details,@treatmentId out
		select
		dbo.fn_GetName(T.PatientId) as PatientName, 
		dbo.fn_GetName(T.DocterId) as DoctorName, 
		dbo.fn_GetName(T.NurseId) as NurseName,
		dbo.fn_getMeds1(T.Diagnosis) ,
		T.TreatmentFee,
		T.DOT,
		(CI.CityName + ',' + S.StateName + ',' + C.CountryName) as [Address],
		U.MobileNo
		from TreatmentDetails T,[User] U,City CI,Country C,States S
		where T.Id = @treatmentId and U.Id = T.PatientId and 
		U.CountryId = C.Id 
		and 
			U.StateId = S.Id 
		and 
			U.CityId = CI.Id 
		commit tran
	end try
	begin catch
		--print 
		print 'Error in treatment reg'
		rollback tran
	end catch
end
GO
USE [master]
GO
ALTER DATABASE [BJBhavyaJoshi] SET  READ_WRITE 
GO
