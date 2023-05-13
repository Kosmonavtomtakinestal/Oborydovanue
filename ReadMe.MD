# курсовой проект на тему "сферу регистрации созданного оборудования и дальнейшая сдача его в аренду"

## выполнили студенты 323 группы макаров А.О., нигаматуллин А.Д.

### реализовано 4 программ с выводом дынных и выбором действий

USE [Arenda]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 29.04.2023 8:43:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Passport] [nvarchar](11) NULL,
	[Phone] [nvarchar](18) NULL,
	[Surname] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Patronymic] [nvarchar](50) NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compound]    Script Date: 29.04.2023 8:43:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compound](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdProduct] [int] NULL,
	[IdMaterial] [int] NULL,
	[Count] [int] NULL,
 CONSTRAINT [PK_Compound] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Delivered]    Script Date: 29.04.2023 8:43:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Delivered](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdDelivery] [int] NULL,
	[IdStoreemployee] [int] NULL,
	[DateTine] [date] NULL,
 CONSTRAINT [PK_Delivered] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Deliverier]    Script Date: 29.04.2023 8:43:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deliverier](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Surname] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Patronymic] [nvarchar](50) NULL,
 CONSTRAINT [PK_Deliverier] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Delivery]    Script Date: 29.04.2023 8:43:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Delivery](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BeginDateTime] [datetime] NULL,
	[IdPointOfIssue] [int] NULL,
	[IdDeliverier] [int] NULL,
 CONSTRAINT [PK_Delivery] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeliveryProducts]    Script Date: 29.04.2023 8:43:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeliveryProducts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdDelivery] [int] NULL,
	[IdStock] [int] NULL,
	[Count] [int] NULL,
 CONSTRAINT [PK_DeliveryProducts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Engineer]    Script Date: 29.04.2023 8:43:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Engineer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Surname] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Patronymic] [nvarchar](50) NULL,
 CONSTRAINT [PK_Engineer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Manager]    Script Date: 29.04.2023 8:43:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manager](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Surname] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Patronymic] [nvarchar](50) NULL,
 CONSTRAINT [PK_Manager] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Material]    Script Date: 29.04.2023 8:43:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Material](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Cost] [money] NULL,
	[Count] [int] NULL,
 CONSTRAINT [PK_Material] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 29.04.2023 8:43:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdMaterial] [int] NULL,
	[Count] [int] NULL,
	[IdEngineer] [int] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrganizationEmployee]    Script Date: 29.04.2023 8:43:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrganizationEmployee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_OrganizationEmployee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PointOfIssue]    Script Date: 29.04.2023 8:43:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PointOfIssue](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Addres] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_PointOfIssue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 29.04.2023 8:43:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
	[Discription] [nvarchar](max) NULL,
	[Photo] [varbinary](max) NULL,
	[Price] [nvarchar](50) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rent]    Script Date: 29.04.2023 8:43:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
	[RentTime] [int] NULL,
	[IdStoreEmployee] [int] NULL,
	[IdClient] [int] NULL,
	[IdStock] [int] NULL,
	[Returned] [bit] NULL,
 CONSTRAINT [PK_Rent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 29.04.2023 8:43:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 29.04.2023 8:43:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPoinOfIssue] [int] NULL,
	[IdProduct] [int] NULL,
	[Count] [int] NULL,
	[MinCreateCount] [int] NULL,
 CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StoreEmployee]    Script Date: 29.04.2023 8:43:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StoreEmployee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[IdpoinOfIssue] [int] NULL,
	[Surname] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Patronymic] [nvarchar](50) NULL,
 CONSTRAINT [PK_StoreEmployee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 29.04.2023 8:43:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
	[Phone] [nvarchar](11) NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supply]    Script Date: 29.04.2023 8:43:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supply](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdOrder] [int] NULL,
	[IdSupplier] [int] NULL,
	[IdManager] [int] NULL,
	[IdStatus] [int] NULL,
 CONSTRAINT [PK_Supply] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([Id], [Login], [Password], [Passport], [Phone], [Surname], [Name], [Patronymic]) VALUES (1, N'Cli1', N'1', N'9999999999', N'79191919191', N'Клиентов 1', N'Клиент 1', N'Клиентович')
INSERT [dbo].[Client] ([Id], [Login], [Password], [Passport], [Phone], [Surname], [Name], [Patronymic]) VALUES (2, N'Cli2', N'1', N'9999999999', N'79292929292', N'Клиентов 2', N'Клиент 2', N'Клиентович')
INSERT [dbo].[Client] ([Id], [Login], [Password], [Passport], [Phone], [Surname], [Name], [Patronymic]) VALUES (3, N'Cli3', N'1', N'9999999999', N'79393939393', N'Клиентов 3', N'Клиент 3', N'Клиентович')
INSERT [dbo].[Client] ([Id], [Login], [Password], [Passport], [Phone], [Surname], [Name], [Patronymic]) VALUES (4, N'Cli4', N'1', N'9999999999', N'79494949494', N'Клиентов 4', N'Клиент 4', N'Клиентович')
INSERT [dbo].[Client] ([Id], [Login], [Password], [Passport], [Phone], [Surname], [Name], [Patronymic]) VALUES (5, N'Cli5', N'1', N'9999999999', N'79595959595', N'Клиентов 5', N'Клиент 5', N'Клиентович')
INSERT [dbo].[Client] ([Id], [Login], [Password], [Passport], [Phone], [Surname], [Name], [Patronymic]) VALUES (1006, N'1', N'1', N'1', N'1', N'1', N'1', N'1')
INSERT [dbo].[Client] ([Id], [Login], [Password], [Passport], [Phone], [Surname], [Name], [Patronymic]) VALUES (1007, N'jj', N'jj', N'j', N'j', N'j', N'j', N'j')
INSERT [dbo].[Client] ([Id], [Login], [Password], [Passport], [Phone], [Surname], [Name], [Patronymic]) VALUES (1008, N'test', N'test', N'9219-571995', N'+7 (919) 693 95-12', N'Нигаматуллин', N'Амир', N'Джалилевич')
SET IDENTITY_INSERT [dbo].[Client] OFF
GO
SET IDENTITY_INSERT [dbo].[Compound] ON 

INSERT [dbo].[Compound] ([Id], [IdProduct], [IdMaterial], [Count]) VALUES (1, 1, 1, 2)
INSERT [dbo].[Compound] ([Id], [IdProduct], [IdMaterial], [Count]) VALUES (2, 1, 2, 2)
INSERT [dbo].[Compound] ([Id], [IdProduct], [IdMaterial], [Count]) VALUES (3, 1, 3, 2)
INSERT [dbo].[Compound] ([Id], [IdProduct], [IdMaterial], [Count]) VALUES (4, 2, 4, 2)
INSERT [dbo].[Compound] ([Id], [IdProduct], [IdMaterial], [Count]) VALUES (5, 2, 5, 2)
INSERT [dbo].[Compound] ([Id], [IdProduct], [IdMaterial], [Count]) VALUES (6, 3, 1, 2)
INSERT [dbo].[Compound] ([Id], [IdProduct], [IdMaterial], [Count]) VALUES (7, 3, 2, 2)
INSERT [dbo].[Compound] ([Id], [IdProduct], [IdMaterial], [Count]) VALUES (8, 3, 3, 2)
INSERT [dbo].[Compound] ([Id], [IdProduct], [IdMaterial], [Count]) VALUES (9, 4, 4, 2)
INSERT [dbo].[Compound] ([Id], [IdProduct], [IdMaterial], [Count]) VALUES (10, 4, 5, 2)
SET IDENTITY_INSERT [dbo].[Compound] OFF
GO
SET IDENTITY_INSERT [dbo].[Delivered] ON 

INSERT [dbo].[Delivered] ([Id], [IdDelivery], [IdStoreemployee], [DateTine]) VALUES (1, 1, 1, CAST(N'2023-03-15' AS Date))
INSERT [dbo].[Delivered] ([Id], [IdDelivery], [IdStoreemployee], [DateTine]) VALUES (2, 2, 2, CAST(N'2023-03-15' AS Date))
INSERT [dbo].[Delivered] ([Id], [IdDelivery], [IdStoreemployee], [DateTine]) VALUES (3, 3, 3, CAST(N'2023-03-15' AS Date))
SET IDENTITY_INSERT [dbo].[Delivered] OFF
GO
SET IDENTITY_INSERT [dbo].[Deliverier] ON 

INSERT [dbo].[Deliverier] ([Id], [Login], [Password], [Surname], [Name], [Patronymic]) VALUES (1, N'Del1', N'1', N'Доставщиков 1', N'Доставщик 1', N'Доставщикович')
INSERT [dbo].[Deliverier] ([Id], [Login], [Password], [Surname], [Name], [Patronymic]) VALUES (2, N'Del2', N'1', N'Доставщиков 2', N'Доставщик 2', N'Доставщикович')
INSERT [dbo].[Deliverier] ([Id], [Login], [Password], [Surname], [Name], [Patronymic]) VALUES (3, N'Del3', N'1', N'Доставщиков 3', N'Доставщик 3', N'Доставщикович')
INSERT [dbo].[Deliverier] ([Id], [Login], [Password], [Surname], [Name], [Patronymic]) VALUES (4, N'Del4', N'1', N'Доставщиков 4', N'Доставщик 4', N'Доставщикович')
INSERT [dbo].[Deliverier] ([Id], [Login], [Password], [Surname], [Name], [Patronymic]) VALUES (5, N'Del5', N'1', N'Доставщиков 5', N'Доставщик 5', N'Доставщикович')
SET IDENTITY_INSERT [dbo].[Deliverier] OFF
GO
SET IDENTITY_INSERT [dbo].[Delivery] ON 

INSERT [dbo].[Delivery] ([Id], [BeginDateTime], [IdPointOfIssue], [IdDeliverier]) VALUES (1, CAST(N'2023-03-14T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Delivery] ([Id], [BeginDateTime], [IdPointOfIssue], [IdDeliverier]) VALUES (2, CAST(N'2023-03-14T00:00:00.000' AS DateTime), 2, 2)
INSERT [dbo].[Delivery] ([Id], [BeginDateTime], [IdPointOfIssue], [IdDeliverier]) VALUES (3, CAST(N'2023-03-14T00:00:00.000' AS DateTime), 3, 3)
INSERT [dbo].[Delivery] ([Id], [BeginDateTime], [IdPointOfIssue], [IdDeliverier]) VALUES (4, CAST(N'2023-03-29T12:00:27.977' AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[Delivery] OFF
GO
SET IDENTITY_INSERT [dbo].[DeliveryProducts] ON 

INSERT [dbo].[DeliveryProducts] ([Id], [IdDelivery], [IdStock], [Count]) VALUES (1, 1, 1, 10)
INSERT [dbo].[DeliveryProducts] ([Id], [IdDelivery], [IdStock], [Count]) VALUES (2, 1, 2, 10)
INSERT [dbo].[DeliveryProducts] ([Id], [IdDelivery], [IdStock], [Count]) VALUES (3, 1, 3, 10)
INSERT [dbo].[DeliveryProducts] ([Id], [IdDelivery], [IdStock], [Count]) VALUES (4, 2, 4, 10)
INSERT [dbo].[DeliveryProducts] ([Id], [IdDelivery], [IdStock], [Count]) VALUES (5, 2, 5, 10)
INSERT [dbo].[DeliveryProducts] ([Id], [IdDelivery], [IdStock], [Count]) VALUES (6, 3, 1, 10)
INSERT [dbo].[DeliveryProducts] ([Id], [IdDelivery], [IdStock], [Count]) VALUES (7, 3, 3, 10)
INSERT [dbo].[DeliveryProducts] ([Id], [IdDelivery], [IdStock], [Count]) VALUES (8, 4, 1, 10)
SET IDENTITY_INSERT [dbo].[DeliveryProducts] OFF
GO
SET IDENTITY_INSERT [dbo].[Engineer] ON 

INSERT [dbo].[Engineer] ([Id], [Login], [Password], [Surname], [Name], [Patronymic]) VALUES (1, N'Eng1', N'1', N'Инженеров 1', N'Инженер 1', N'Инженерович')
INSERT [dbo].[Engineer] ([Id], [Login], [Password], [Surname], [Name], [Patronymic]) VALUES (2, N'Eng2', N'1', N'Инженеров 2', N'Инженер 2', N'Инженерович')
INSERT [dbo].[Engineer] ([Id], [Login], [Password], [Surname], [Name], [Patronymic]) VALUES (3, N'Eng3', N'1', N'Инженеров 3', N'Инженер 3', N'Инженерович')
INSERT [dbo].[Engineer] ([Id], [Login], [Password], [Surname], [Name], [Patronymic]) VALUES (4, N'Eng4', N'1', N'Инженеров 4', N'Инженер 4', N'Инженерович')
INSERT [dbo].[Engineer] ([Id], [Login], [Password], [Surname], [Name], [Patronymic]) VALUES (5, N'Eng5', N'1', N'Инженеров 5', N'Инженер 5', N'Инженерович')
SET IDENTITY_INSERT [dbo].[Engineer] OFF
GO
SET IDENTITY_INSERT [dbo].[Manager] ON 

INSERT [dbo].[Manager] ([Id], [Login], [Password], [Surname], [Name], [Patronymic]) VALUES (1, N'Man1', N'1', N'Менеджеров 1', N'Менеджер 1', N'Менеджерович')
INSERT [dbo].[Manager] ([Id], [Login], [Password], [Surname], [Name], [Patronymic]) VALUES (2, N'Man2', N'1', N'Менеджеров 2', N'Менеджер 2', N'Менеджерович')
INSERT [dbo].[Manager] ([Id], [Login], [Password], [Surname], [Name], [Patronymic]) VALUES (3, N'Man3', N'1', N'Менеджеров 3', N'Менеджер 3', N'Менеджерович')
INSERT [dbo].[Manager] ([Id], [Login], [Password], [Surname], [Name], [Patronymic]) VALUES (4, N'Man4', N'1', N'Менеджеров 4', N'Менеджер 4', N'Менеджерович')
INSERT [dbo].[Manager] ([Id], [Login], [Password], [Surname], [Name], [Patronymic]) VALUES (5, N'Man5', N'1', N'Менеджеров 5', N'Менеджер 5', N'Менеджерович')
SET IDENTITY_INSERT [dbo].[Manager] OFF
GO
SET IDENTITY_INSERT [dbo].[Material] ON 

INSERT [dbo].[Material] ([Id], [Name], [Cost], [Count]) VALUES (1, N'Материал 1', 100.0000, 100)
INSERT [dbo].[Material] ([Id], [Name], [Cost], [Count]) VALUES (2, N'Материал 2', 100.0000, 100)
INSERT [dbo].[Material] ([Id], [Name], [Cost], [Count]) VALUES (3, N'Материал 3', 100.0000, 100)
INSERT [dbo].[Material] ([Id], [Name], [Cost], [Count]) VALUES (4, N'Материал 4', 100.0000, 100)
INSERT [dbo].[Material] ([Id], [Name], [Cost], [Count]) VALUES (5, N'Материал 5', 100.0000, 100)
SET IDENTITY_INSERT [dbo].[Material] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Id], [IdMaterial], [Count], [IdEngineer]) VALUES (1, 1, 10, 1)
INSERT [dbo].[Order] ([Id], [IdMaterial], [Count], [IdEngineer]) VALUES (2, 2, 10, 2)
INSERT [dbo].[Order] ([Id], [IdMaterial], [Count], [IdEngineer]) VALUES (3, 3, 10, 3)
INSERT [dbo].[Order] ([Id], [IdMaterial], [Count], [IdEngineer]) VALUES (4, 4, 10, 4)
INSERT [dbo].[Order] ([Id], [IdMaterial], [Count], [IdEngineer]) VALUES (5, 5, 10, 5)
INSERT [dbo].[Order] ([Id], [IdMaterial], [Count], [IdEngineer]) VALUES (6, 5, 4, 3)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[OrganizationEmployee] ON 

INSERT [dbo].[OrganizationEmployee] ([Id], [Login], [Password]) VALUES (1, N'Org1', N'1')
INSERT [dbo].[OrganizationEmployee] ([Id], [Login], [Password]) VALUES (2, N'Org2', N'1')
INSERT [dbo].[OrganizationEmployee] ([Id], [Login], [Password]) VALUES (3, N'Org3', N'1')
INSERT [dbo].[OrganizationEmployee] ([Id], [Login], [Password]) VALUES (4, N'Org4', N'1')
INSERT [dbo].[OrganizationEmployee] ([Id], [Login], [Password]) VALUES (5, N'Org5', N'1')
SET IDENTITY_INSERT [dbo].[OrganizationEmployee] OFF
GO
SET IDENTITY_INSERT [dbo].[PointOfIssue] ON 

INSERT [dbo].[PointOfIssue] ([Id], [Addres]) VALUES (1, N'ул. Бари Галеева, д. 3')
INSERT [dbo].[PointOfIssue] ([Id], [Addres]) VALUES (2, N'пр. Ямашева, д. 3')
INSERT [dbo].[PointOfIssue] ([Id], [Addres]) VALUES (3, N'ул. Чистопольска, д. 3')
SET IDENTITY_INSERT [dbo].[PointOfIssue] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [Name], [Discription], [Photo], [Price]) VALUES (1, N'Продукт 1', N'Описание', NULL, N'101')
INSERT [dbo].[Product] ([Id], [Name], [Discription], [Photo], [Price]) VALUES (2, N'Продукт 2', N'Описание', NULL, N'102')
INSERT [dbo].[Product] ([Id], [Name], [Discription], [Photo], [Price]) VALUES (3, N'Продукт 3', N'Описание', NULL, N'103')
INSERT [dbo].[Product] ([Id], [Name], [Discription], [Photo], [Price]) VALUES (4, N'Продукт 4', N'Описание', NULL, N'100')
INSERT [dbo].[Product] ([Id], [Name], [Discription], [Photo], [Price]) VALUES (5, N'Продукт 5', N'Описание', NULL, N'100')
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Rent] ON 

INSERT [dbo].[Rent] ([Id], [Date], [RentTime], [IdStoreEmployee], [IdClient], [IdStock], [Returned]) VALUES (1, CAST(N'2023-03-15' AS Date), 4, 1, 1, 1, 1)
INSERT [dbo].[Rent] ([Id], [Date], [RentTime], [IdStoreEmployee], [IdClient], [IdStock], [Returned]) VALUES (2, CAST(N'2023-03-15' AS Date), 2, 2, 2, 2, 1)
INSERT [dbo].[Rent] ([Id], [Date], [RentTime], [IdStoreEmployee], [IdClient], [IdStock], [Returned]) VALUES (3, CAST(N'2023-03-15' AS Date), 3, 3, 3, 3, 0)
INSERT [dbo].[Rent] ([Id], [Date], [RentTime], [IdStoreEmployee], [IdClient], [IdStock], [Returned]) VALUES (4, CAST(N'2023-03-15' AS Date), 5, 1, 4, 4, 0)
INSERT [dbo].[Rent] ([Id], [Date], [RentTime], [IdStoreEmployee], [IdClient], [IdStock], [Returned]) VALUES (5, CAST(N'2023-03-15' AS Date), 3, 2, 5, 5, 0)
INSERT [dbo].[Rent] ([Id], [Date], [RentTime], [IdStoreEmployee], [IdClient], [IdStock], [Returned]) VALUES (6, CAST(N'2023-03-15' AS Date), 2, 1, 4, 6, 0)
INSERT [dbo].[Rent] ([Id], [Date], [RentTime], [IdStoreEmployee], [IdClient], [IdStock], [Returned]) VALUES (7, CAST(N'2023-04-03' AS Date), 2, 1, 1, 3, 0)
INSERT [dbo].[Rent] ([Id], [Date], [RentTime], [IdStoreEmployee], [IdClient], [IdStock], [Returned]) VALUES (8, CAST(N'2023-04-12' AS Date), 12, NULL, 1, 1, 0)
SET IDENTITY_INSERT [dbo].[Rent] OFF
GO
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([Id], [Title]) VALUES (1, N'Заказ принят у поставщика')
INSERT [dbo].[Status] ([Id], [Title]) VALUES (2, N'Заказ отправлен')
INSERT [dbo].[Status] ([Id], [Title]) VALUES (3, N'Заказ прибыл')
SET IDENTITY_INSERT [dbo].[Status] OFF
GO
SET IDENTITY_INSERT [dbo].[Stock] ON 

INSERT [dbo].[Stock] ([Id], [IdPoinOfIssue], [IdProduct], [Count], [MinCreateCount]) VALUES (1, 1, 1, 10, 0)
INSERT [dbo].[Stock] ([Id], [IdPoinOfIssue], [IdProduct], [Count], [MinCreateCount]) VALUES (2, 1, 2, 10, 0)
INSERT [dbo].[Stock] ([Id], [IdPoinOfIssue], [IdProduct], [Count], [MinCreateCount]) VALUES (3, 1, 3, 10, 0)
INSERT [dbo].[Stock] ([Id], [IdPoinOfIssue], [IdProduct], [Count], [MinCreateCount]) VALUES (4, 2, 4, 10, 0)
INSERT [dbo].[Stock] ([Id], [IdPoinOfIssue], [IdProduct], [Count], [MinCreateCount]) VALUES (5, 2, 5, 10, 0)
INSERT [dbo].[Stock] ([Id], [IdPoinOfIssue], [IdProduct], [Count], [MinCreateCount]) VALUES (6, 3, 1, 10, 0)
INSERT [dbo].[Stock] ([Id], [IdPoinOfIssue], [IdProduct], [Count], [MinCreateCount]) VALUES (7, 3, 3, 10, 0)
SET IDENTITY_INSERT [dbo].[Stock] OFF
GO
SET IDENTITY_INSERT [dbo].[StoreEmployee] ON 

INSERT [dbo].[StoreEmployee] ([Id], [Login], [Password], [IdpoinOfIssue], [Surname], [Name], [Patronymic]) VALUES (1, N'StE1', N'1', 1, N'Кассиров 1', N'Кассир 1', N'Кассирович')
INSERT [dbo].[StoreEmployee] ([Id], [Login], [Password], [IdpoinOfIssue], [Surname], [Name], [Patronymic]) VALUES (2, N'StE2', N'1', 2, N'Кассиров 2', N'Кассир 2', N'Кассирович')
INSERT [dbo].[StoreEmployee] ([Id], [Login], [Password], [IdpoinOfIssue], [Surname], [Name], [Patronymic]) VALUES (3, N'StE3', N'1', 3, N'Кассиров 3', N'Кассир 3', N'Кассирович')
SET IDENTITY_INSERT [dbo].[StoreEmployee] OFF
GO
SET IDENTITY_INSERT [dbo].[Supplier] ON 

INSERT [dbo].[Supplier] ([Id], [Name], [Phone]) VALUES (1, N'Поставщик 1', N'79999999991')
INSERT [dbo].[Supplier] ([Id], [Name], [Phone]) VALUES (2, N'Поставщик 2', N'79999999992')
INSERT [dbo].[Supplier] ([Id], [Name], [Phone]) VALUES (3, N'Поставщик 3', N'79999999993')
INSERT [dbo].[Supplier] ([Id], [Name], [Phone]) VALUES (4, N'Поставщик 4', N'79999999994')
INSERT [dbo].[Supplier] ([Id], [Name], [Phone]) VALUES (5, N'Поставщик 5', N'79999999995')
SET IDENTITY_INSERT [dbo].[Supplier] OFF
GO
SET IDENTITY_INSERT [dbo].[Supply] ON 

INSERT [dbo].[Supply] ([Id], [IdOrder], [IdSupplier], [IdManager], [IdStatus]) VALUES (1, 1, 1, 1, 3)
INSERT [dbo].[Supply] ([Id], [IdOrder], [IdSupplier], [IdManager], [IdStatus]) VALUES (2, 2, 2, 2, 3)
INSERT [dbo].[Supply] ([Id], [IdOrder], [IdSupplier], [IdManager], [IdStatus]) VALUES (3, 3, 3, 3, 3)
INSERT [dbo].[Supply] ([Id], [IdOrder], [IdSupplier], [IdManager], [IdStatus]) VALUES (4, 4, 2, 1, 1)
INSERT [dbo].[Supply] ([Id], [IdOrder], [IdSupplier], [IdManager], [IdStatus]) VALUES (5, 5, 2, 1, 1)
INSERT [dbo].[Supply] ([Id], [IdOrder], [IdSupplier], [IdManager], [IdStatus]) VALUES (6, 6, 5, 1, 1)
SET IDENTITY_INSERT [dbo].[Supply] OFF
GO
ALTER TABLE [dbo].[Compound]  WITH CHECK ADD  CONSTRAINT [FK_Compound_Material] FOREIGN KEY([IdMaterial])
REFERENCES [dbo].[Material] ([Id])
GO
ALTER TABLE [dbo].[Compound] CHECK CONSTRAINT [FK_Compound_Material]
GO
ALTER TABLE [dbo].[Compound]  WITH CHECK ADD  CONSTRAINT [FK_Compound_Product] FOREIGN KEY([IdProduct])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[Compound] CHECK CONSTRAINT [FK_Compound_Product]
GO
ALTER TABLE [dbo].[Delivered]  WITH CHECK ADD  CONSTRAINT [FK_Delivered_Delivery] FOREIGN KEY([IdDelivery])
REFERENCES [dbo].[Delivery] ([Id])
GO
ALTER TABLE [dbo].[Delivered] CHECK CONSTRAINT [FK_Delivered_Delivery]
GO
ALTER TABLE [dbo].[Delivered]  WITH CHECK ADD  CONSTRAINT [FK_Delivered_StoreEmployee] FOREIGN KEY([IdStoreemployee])
REFERENCES [dbo].[StoreEmployee] ([Id])
GO
ALTER TABLE [dbo].[Delivered] CHECK CONSTRAINT [FK_Delivered_StoreEmployee]
GO
ALTER TABLE [dbo].[Delivery]  WITH CHECK ADD  CONSTRAINT [FK_Delivery_Deliverier] FOREIGN KEY([IdDeliverier])
REFERENCES [dbo].[Deliverier] ([Id])
GO
ALTER TABLE [dbo].[Delivery] CHECK CONSTRAINT [FK_Delivery_Deliverier]
GO
ALTER TABLE [dbo].[Delivery]  WITH CHECK ADD  CONSTRAINT [FK_Delivery_PointOfIssue] FOREIGN KEY([IdPointOfIssue])
REFERENCES [dbo].[PointOfIssue] ([Id])
GO
ALTER TABLE [dbo].[Delivery] CHECK CONSTRAINT [FK_Delivery_PointOfIssue]
GO
ALTER TABLE [dbo].[DeliveryProducts]  WITH CHECK ADD  CONSTRAINT [FK_DeliveryProducts_Delivery] FOREIGN KEY([IdDelivery])
REFERENCES [dbo].[Delivery] ([Id])
GO
ALTER TABLE [dbo].[DeliveryProducts] CHECK CONSTRAINT [FK_DeliveryProducts_Delivery]
GO
ALTER TABLE [dbo].[DeliveryProducts]  WITH CHECK ADD  CONSTRAINT [FK_DeliveryProducts_Stock] FOREIGN KEY([IdStock])
REFERENCES [dbo].[Stock] ([Id])
GO
ALTER TABLE [dbo].[DeliveryProducts] CHECK CONSTRAINT [FK_DeliveryProducts_Stock]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Engineer] FOREIGN KEY([IdEngineer])
REFERENCES [dbo].[Engineer] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Engineer]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Material] FOREIGN KEY([IdMaterial])
REFERENCES [dbo].[Material] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Material]
GO
ALTER TABLE [dbo].[Rent]  WITH CHECK ADD  CONSTRAINT [FK_Rent_Client] FOREIGN KEY([IdClient])
REFERENCES [dbo].[Client] ([Id])
GO
ALTER TABLE [dbo].[Rent] CHECK CONSTRAINT [FK_Rent_Client]
GO
ALTER TABLE [dbo].[Rent]  WITH CHECK ADD  CONSTRAINT [FK_Rent_Stock] FOREIGN KEY([IdStock])
REFERENCES [dbo].[Stock] ([Id])
GO
ALTER TABLE [dbo].[Rent] CHECK CONSTRAINT [FK_Rent_Stock]
GO
ALTER TABLE [dbo].[Rent]  WITH CHECK ADD  CONSTRAINT [FK_Rent_StoreEmployee] FOREIGN KEY([IdStoreEmployee])
REFERENCES [dbo].[StoreEmployee] ([Id])
GO
ALTER TABLE [dbo].[Rent] CHECK CONSTRAINT [FK_Rent_StoreEmployee]
GO
ALTER TABLE [dbo].[Stock]  WITH CHECK ADD  CONSTRAINT [FK_Stock_PointOfIssue] FOREIGN KEY([IdPoinOfIssue])
REFERENCES [dbo].[PointOfIssue] ([Id])
GO
ALTER TABLE [dbo].[Stock] CHECK CONSTRAINT [FK_Stock_PointOfIssue]
GO
ALTER TABLE [dbo].[Stock]  WITH CHECK ADD  CONSTRAINT [FK_Stock_Product] FOREIGN KEY([IdProduct])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[Stock] CHECK CONSTRAINT [FK_Stock_Product]
GO
ALTER TABLE [dbo].[StoreEmployee]  WITH CHECK ADD  CONSTRAINT [FK_StoreEmployee_PointOfIssue] FOREIGN KEY([IdpoinOfIssue])
REFERENCES [dbo].[PointOfIssue] ([Id])
GO
ALTER TABLE [dbo].[StoreEmployee] CHECK CONSTRAINT [FK_StoreEmployee_PointOfIssue]
GO
ALTER TABLE [dbo].[Supply]  WITH CHECK ADD  CONSTRAINT [FK_Supply_Manager] FOREIGN KEY([IdManager])
REFERENCES [dbo].[Manager] ([Id])
GO
ALTER TABLE [dbo].[Supply] CHECK CONSTRAINT [FK_Supply_Manager]
GO
ALTER TABLE [dbo].[Supply]  WITH CHECK ADD  CONSTRAINT [FK_Supply_Order] FOREIGN KEY([IdOrder])
REFERENCES [dbo].[Order] ([Id])
GO
ALTER TABLE [dbo].[Supply] CHECK CONSTRAINT [FK_Supply_Order]
GO
ALTER TABLE [dbo].[Supply]  WITH CHECK ADD  CONSTRAINT [FK_Supply_Status] FOREIGN KEY([IdStatus])
REFERENCES [dbo].[Status] ([Id])
GO
ALTER TABLE [dbo].[Supply] CHECK CONSTRAINT [FK_Supply_Status]
GO
ALTER TABLE [dbo].[Supply]  WITH CHECK ADD  CONSTRAINT [FK_Supply_Supplier] FOREIGN KEY([IdSupplier])
REFERENCES [dbo].[Supplier] ([Id])
GO
ALTER TABLE [dbo].[Supply] CHECK CONSTRAINT [FK_Supply_Supplier]
GO
