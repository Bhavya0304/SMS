USE [BJBhavyaJoshi]
GO
/****** Object:  Table [dbo].[City]    Script Date: 4/28/2023 12:36:25 PM ******/
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
/****** Object:  Table [dbo].[Country]    Script Date: 4/28/2023 12:36:25 PM ******/
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
/****** Object:  Table [dbo].[SMS_User]    Script Date: 4/28/2023 12:36:25 PM ******/
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
/****** Object:  Table [dbo].[States]    Script Date: 4/28/2023 12:36:25 PM ******/
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
/****** Object:  Table [dbo].[Student]    Script Date: 4/28/2023 12:36:25 PM ******/
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
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[City] ON 

INSERT [dbo].[City] ([Id], [CityName], [StateId], [CountryId]) VALUES (6, N'Palanpur', 2, 1)
INSERT [dbo].[City] ([Id], [CityName], [StateId], [CountryId]) VALUES (7, N'Deesa', 2, 1)
INSERT [dbo].[City] ([Id], [CityName], [StateId], [CountryId]) VALUES (8, N'Siddhpur', 2, 1)
INSERT [dbo].[City] ([Id], [CityName], [StateId], [CountryId]) VALUES (9, N'Rajkot', 2, 1)
INSERT [dbo].[City] ([Id], [CityName], [StateId], [CountryId]) VALUES (10, N'Kuchh', 2, 1)
SET IDENTITY_INSERT [dbo].[City] OFF
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (1, N'Indiad')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (3, N'UAE')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (4, N'Cannada')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (5, N'Nepal')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (6, N'India1')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (7, N'India')
SET IDENTITY_INSERT [dbo].[Country] OFF
SET IDENTITY_INSERT [dbo].[SMS_User] ON 

INSERT [dbo].[SMS_User] ([Id], [Username], [Password], [Email], [CreatedOn], [UpdatedOn]) VALUES (1, N'admin', N'123456', N'admin@gmail.com', NULL, NULL)
SET IDENTITY_INSERT [dbo].[SMS_User] OFF
SET IDENTITY_INSERT [dbo].[States] ON 

INSERT [dbo].[States] ([Id], [StateName], [CountryId]) VALUES (1, N'Kerela', 1)
INSERT [dbo].[States] ([Id], [StateName], [CountryId]) VALUES (2, N'Gujarat', 1)
INSERT [dbo].[States] ([Id], [StateName], [CountryId]) VALUES (3, N'Maharastra', 1)
INSERT [dbo].[States] ([Id], [StateName], [CountryId]) VALUES (4, N'Goa', 1)
INSERT [dbo].[States] ([Id], [StateName], [CountryId]) VALUES (5, N'Rajasthan', 1)
SET IDENTITY_INSERT [dbo].[States] OFF
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Address], [MobileNo], [Email], [DOB], [Gender], [Country], [State], [City]) VALUES (3, N'Zenish', N'Patel', N'17, Agolo road yopin bhai', N'9510012644', N'zen@gmail.com', CAST(N'2002-02-02' AS Date), N'Female', 1, 2, 6)
SET IDENTITY_INSERT [dbo].[Student] OFF
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
/****** Object:  StoredProcedure [dbo].[getStudentData]    Script Date: 4/28/2023 12:36:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getStudentData]
(
	@id int = null
)
as
begin
	select S.*,C.CityName as CityName,Sa.StateName,CO.CountryName from Student S,City C,States Sa,Country CO where S.State = Sa.Id and CO.Id = S.Country and C.Id = S.City and (isnull(@id,'') = '' or @id = S.Id)
end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllUsers]    Script Date: 4/28/2023 12:36:26 PM ******/
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
/****** Object:  StoredProcedure [dbo].[sp_InsertIntoCity]    Script Date: 4/28/2023 12:36:26 PM ******/
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
/****** Object:  StoredProcedure [dbo].[sp_InsertIntoCountry]    Script Date: 4/28/2023 12:36:26 PM ******/
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
/****** Object:  StoredProcedure [dbo].[sp_InsertIntoState]    Script Date: 4/28/2023 12:36:26 PM ******/
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
/****** Object:  StoredProcedure [dbo].[sp_InsertIntoUser]    Script Date: 4/28/2023 12:36:26 PM ******/
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
/****** Object:  StoredProcedure [dbo].[sp_InsertIntoUserType]    Script Date: 4/28/2023 12:36:26 PM ******/
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
