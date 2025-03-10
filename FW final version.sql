USE [FindWorker]
GO
/****** Object:  Table [dbo].[Offer]    Script Date: 02.12.2024 11:17:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Offer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Id_Organization] [int] NOT NULL,
	[Heading] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[Id_user] [int] NULL,
	[Id_post] [int] NOT NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_Offer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Organization]    Script Date: 02.12.2024 11:17:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Organization](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameOrganization] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Phone] [nvarchar](50) NULL,
	[Email] [nvarchar](max) NULL,
	[PersonalAccount] [nvarchar](50) NULL,
	[Id_userrole] [int] NOT NULL,
	[Login] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_Organization] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 02.12.2024 11:17:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NamePost] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 02.12.2024 11:17:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[NumberPassport] [nvarchar](6) NOT NULL,
	[SerialPassport] [nvarchar](4) NOT NULL,
	[MiddleName] [nvarchar](50) NULL,
	[INN] [nvarchar](50) NOT NULL,
	[Id_userrole] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 02.12.2024 11:17:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Offer] ON 

INSERT [dbo].[Offer] ([Id], [Id_Organization], [Heading], [Description], [Id_user], [Id_post], [Active]) VALUES (14, 19, N'Требуется менеджер по продажам', N'Ищем активного и целеустремленного сотрудника на должность менеджера по продажам. Требуется умение работать с клиентами, вести переговоры и заключать сделки.', 7, 1, 1)
INSERT [dbo].[Offer] ([Id], [Id_Organization], [Heading], [Description], [Id_user], [Id_post], [Active]) VALUES (15, 20, N'Открыта вакансия программиста', N'Приглашаем разработчика с опытом работы в разработке веб-приложений. Основные технологии: C#, .NET, SQL. Возможность карьерного роста.', 8, 2, 0)
INSERT [dbo].[Offer] ([Id], [Id_Organization], [Heading], [Description], [Id_user], [Id_post], [Active]) VALUES (16, 21, N'Вакансия маркетолога', N'Нужен специалист по маркетингу с опытом работы в SMM и таргетированной рекламе. Обязанности: разработка маркетинговой стратегии, анализ эффективности.', 9, 3, 1)
INSERT [dbo].[Offer] ([Id], [Id_Organization], [Heading], [Description], [Id_user], [Id_post], [Active]) VALUES (17, 22, N'Требуется администратор офиса', N'Открыта вакансия администратора. Основные задачи: поддержание порядка в офисе, работа с документами, помощь руководителю.', 10, 4, 0)
INSERT [dbo].[Offer] ([Id], [Id_Organization], [Heading], [Description], [Id_user], [Id_post], [Active]) VALUES (18, 23, N'Вакансия дизайнера', N'Ищем креативного дизайнера для работы над рекламными проектами. Требуется владение Adobe Photoshop, Illustrator и базовые навыки 3D.', 11, 5, 1)
INSERT [dbo].[Offer] ([Id], [Id_Organization], [Heading], [Description], [Id_user], [Id_post], [Active]) VALUES (19, 24, N'Требуется бухгалтер', N'Приглашаем бухгалтера с опытом работы. Обязанности: ведение учета, подготовка отчетности, взаимодействие с налоговыми органами.', 12, 6, 0)
INSERT [dbo].[Offer] ([Id], [Id_Organization], [Heading], [Description], [Id_user], [Id_post], [Active]) VALUES (20, 25, N'Открыта вакансия HR-специалиста', N'Требуется HR-менеджер для подбора персонала, организации корпоративных мероприятий и адаптации новых сотрудников.', 13, 7, 1)
INSERT [dbo].[Offer] ([Id], [Id_Organization], [Heading], [Description], [Id_user], [Id_post], [Active]) VALUES (21, 26, N'Работа для аналитика данных', N'Нужен специалист по анализу данных. Требуются навыки работы с большими массивами данных, опыт использования Python и SQL.', 14, 8, 0)
INSERT [dbo].[Offer] ([Id], [Id_Organization], [Heading], [Description], [Id_user], [Id_post], [Active]) VALUES (22, 27, N'Требуется водитель', N'Ищем ответственного водителя для работы на служебном транспорте. Требуется наличие прав категории B и опыт вождения не менее 3 лет.', 15, 9, 1)
INSERT [dbo].[Offer] ([Id], [Id_Organization], [Heading], [Description], [Id_user], [Id_post], [Active]) VALUES (23, 28, N'Вакансия инженера', N'Приглашаем инженера по проектированию. Требуются навыки работы с AutoCAD, знание строительных норм и правил.', 16, 10, 0)
INSERT [dbo].[Offer] ([Id], [Id_Organization], [Heading], [Description], [Id_user], [Id_post], [Active]) VALUES (24, 29, N'Требуется копирайтер', N'Ищем специалиста для написания текстов. Основные задачи: создание уникального контента для сайтов, написание статей и рекламных слоганов.', 17, 11, 1)
INSERT [dbo].[Offer] ([Id], [Id_Organization], [Heading], [Description], [Id_user], [Id_post], [Active]) VALUES (25, 30, N'Вакансия фотографа', N'Нужен фотограф с опытом работы в студийной съемке. Задачи: проведение фотосессий, обработка фотографий, участие в рекламных проектах.', 18, 12, 0)
INSERT [dbo].[Offer] ([Id], [Id_Organization], [Heading], [Description], [Id_user], [Id_post], [Active]) VALUES (26, 31, N'Требуется курьер', N'Открыта вакансия курьера. Основные обязанности: доставка документов и посылок по городу. Требуется знание города.', 19, 13, 1)
INSERT [dbo].[Offer] ([Id], [Id_Organization], [Heading], [Description], [Id_user], [Id_post], [Active]) VALUES (27, 32, N'Вакансия менеджера проектов', N'Ищем менеджера для управления проектами. Требуются навыки планирования, ведения документации и общения с клиентами.', 20, 14, 0)
INSERT [dbo].[Offer] ([Id], [Id_Organization], [Heading], [Description], [Id_user], [Id_post], [Active]) VALUES (28, 33, N'Требуется официант', N'Ищем коммуникабельного официанта для работы в ресторане. Требуется внимательность и доброжелательность в общении с клиентами.', 21, 15, 1)
INSERT [dbo].[Offer] ([Id], [Id_Organization], [Heading], [Description], [Id_user], [Id_post], [Active]) VALUES (29, 34, N'Вакансия учителя английского', N'Приглашаем учителя английского языка для работы с детьми и взрослыми. Требуется знание методик преподавания.', 22, 16, 0)
INSERT [dbo].[Offer] ([Id], [Id_Organization], [Heading], [Description], [Id_user], [Id_post], [Active]) VALUES (30, 35, N'Требуется повар', N'Ищем повара для работы в кафе. Требуется опыт приготовления блюд европейской кухни, знание технологии приготовления.', 23, 17, 1)
INSERT [dbo].[Offer] ([Id], [Id_Organization], [Heading], [Description], [Id_user], [Id_post], [Active]) VALUES (31, 36, N'Открыта вакансия электрика', N'Приглашаем электрика для работы на производственном предприятии. Требуется опыт работы с электрооборудованием.', 24, 18, 0)
INSERT [dbo].[Offer] ([Id], [Id_Organization], [Heading], [Description], [Id_user], [Id_post], [Active]) VALUES (32, 37, N'Вакансия юриста', N'Нужен юрист для работы с договорами, ведения судебных дел и консультирования клиентов по правовым вопросам.', 25, 19, 1)
INSERT [dbo].[Offer] ([Id], [Id_Organization], [Heading], [Description], [Id_user], [Id_post], [Active]) VALUES (33, 38, N'Требуется ассистент руководителя', N'Ищем ассистента для выполнения административных задач, ведения календаря встреч и подготовки отчетов.', 26, 20, 0)
INSERT [dbo].[Offer] ([Id], [Id_Organization], [Heading], [Description], [Id_user], [Id_post], [Active]) VALUES (34, 39, N'Вакансия логиста', N'Открыта вакансия логиста. Основные задачи: организация перевозок, контроль за доставкой грузов, взаимодействие с перевозчиками.', 27, 1, 1)
INSERT [dbo].[Offer] ([Id], [Id_Organization], [Heading], [Description], [Id_user], [Id_post], [Active]) VALUES (35, 40, N'Работа для IT-специалиста', N'Ищем системного администратора для поддержки IT-инфраструктуры компании. Требуется знание сетевых технологий и операционных систем.', 28, 2, 0)
INSERT [dbo].[Offer] ([Id], [Id_Organization], [Heading], [Description], [Id_user], [Id_post], [Active]) VALUES (36, 41, N'Требуется тренер по фитнесу', N'Открыта вакансия тренера. Задачи: проведение групповых и персональных тренировок, составление программ тренировок.', 29, 3, 1)
INSERT [dbo].[Offer] ([Id], [Id_Organization], [Heading], [Description], [Id_user], [Id_post], [Active]) VALUES (37, 42, N'Вакансия менеджера по работе с клиентами', N'Ищем специалиста для работы с клиентами.
Основные задачи: консультирование, сопровождение сделок, работа с документацией.', 30, 4, 0)
INSERT [dbo].[Offer] ([Id], [Id_Organization], [Heading], [Description], [Id_user], [Id_post], [Active]) VALUES (38, 43, N'Требуется специалист по закупкам', N'Нужен менеджер по закупкам. Обязанности: поиск поставщиков, заключение контрактов, контроль поставок.', 31, 5, 1)
INSERT [dbo].[Offer] ([Id], [Id_Organization], [Heading], [Description], [Id_user], [Id_post], [Active]) VALUES (39, 44, N'Вакансия специалиста по контекстной рекламе', N'Ищем специалиста для настройки контекстной рекламы. Требуется опыт работы с Google Ads и Яндекс.Директ.', 32, 6, 0)
INSERT [dbo].[Offer] ([Id], [Id_Organization], [Heading], [Description], [Id_user], [Id_post], [Active]) VALUES (40, 19, N'Требуется специалист службы поддержки', N'Приглашаем сотрудника службы поддержки. Основные задачи: обработка обращений клиентов, решение технических вопросов.', 33, 7, 1)
INSERT [dbo].[Offer] ([Id], [Id_Organization], [Heading], [Description], [Id_user], [Id_post], [Active]) VALUES (41, 20, N'Открыта вакансия тренера по плаванию', N'Ищем инструктора по плаванию для проведения занятий с детьми и взрослыми. Требуется опыт тренерской работы.', 34, 8, 0)
SET IDENTITY_INSERT [dbo].[Offer] OFF
GO
SET IDENTITY_INSERT [dbo].[Organization] ON 

INSERT [dbo].[Organization] ([Id], [NameOrganization], [Description], [Address], [Phone], [Email], [PersonalAccount], [Id_userrole], [Login], [Password]) VALUES (2, N'ООО "АльфаТех"', N'АльфаТех – высокотехнологичная компания, специализирующаяся на разработке инновационных решений в области искусственного интеллекта и автоматизации производственных процессов. Мы стремимся к тому, чтобы наши продукты помогали бизнесу достигать новых высот эффективности.', N'г. Москва ', N'+7 (999) 111-22-33', N'AlphaTeh@mail.ru', N'40702810900000000001', 2, N'at_admin', N'AlphaTech123')
INSERT [dbo].[Organization] ([Id], [NameOrganization], [Description], [Address], [Phone], [Email], [PersonalAccount], [Id_userrole], [Login], [Password]) VALUES (5, N'ЗАО "БетаСофт"', N'БетаСофт – ведущий разработчик программного обеспечения для корпоративных клиентов. Наши решения охватывают широкий спектр задач: от управления проектами до анализа больших данных. Мы предлагаем гибкие и масштабируемые системы, адаптированные под нужды вашего бизнеса.
', N'г. Казань', N'+7 (888) 222-33-44', N'Betaaaa@gmail.com', N'40702920100000000002', 2, N'bs_manager', N'BetaSoft456')
INSERT [dbo].[Organization] ([Id], [NameOrganization], [Description], [Address], [Phone], [Email], [PersonalAccount], [Id_userrole], [Login], [Password]) VALUES (6, N'ИП "ГаммаЛинк"', N'ГаммаЛинк – поставщик телекоммуникационных услуг и решений для бизнеса. Наша цель – обеспечить надежное и высокоскоростное соединение между офисами и филиалами вашей компании, а также предоставить доступ к современным облачным сервисам.', N'г. Москва', N'+7 (777) 333-44-55', N'G_link@gmail.com', N'40817830100000000003', 2, N'gl_owner', N'GammaLink789')
INSERT [dbo].[Organization] ([Id], [NameOrganization], [Description], [Address], [Phone], [Email], [PersonalAccount], [Id_userrole], [Login], [Password]) VALUES (8, N'ООО "ДельтаСервис"', N'ДельтаСервис – профессиональная команда специалистов, предоставляющая услуги по техническому обслуживанию и ремонту оборудования различного назначения. Наш приоритет – качество обслуживания и минимизация простоев вашего производства.', N'г. Санкт-Петербург', N'+7 (666) 444-55-66', N'Delta@mail.ru', N'40703840100000000004', 2, N'ds_supervisor', N'DeltaServiceABC')
INSERT [dbo].[Organization] ([Id], [NameOrganization], [Description], [Address], [Phone], [Email], [PersonalAccount], [Id_userrole], [Login], [Password]) VALUES (9, N'ЗАО "ЭпсилонПро"', N'ЭпсилонПро – инжиниринговая компания, занимающаяся проектированием и внедрением сложных инженерных систем. Мы разрабатываем индивидуальные решения для промышленных предприятий, строительных объектов и городской инфраструктуры.', N'г. Казань', N'+7 (555) 555-66-77  ', N'Epsilll@mail.ru', N'40704950100000000005', 2, N'ep_director', N'EpsilonProXYZ')
INSERT [dbo].[Organization] ([Id], [NameOrganization], [Description], [Address], [Phone], [Email], [PersonalAccount], [Id_userrole], [Login], [Password]) VALUES (10, N'ООО "Зетакорп":', N'Зетакорп – консалтинговая компания, оказывающая полный комплекс услуг в области стратегического планирования, финансового анализа и оптимизации бизнес-процессов. Мы помогаем нашим клиентам принимать взвешенные решения и добиваться устойчивого роста.', N'г. Москва', N'+7 (444) 666-77-88', N'Z_corp@gmail.com', N'40705860100000000006', 2, N'zc_ceo', N'ZetaCorpAdmin')
INSERT [dbo].[Organization] ([Id], [NameOrganization], [Description], [Address], [Phone], [Email], [PersonalAccount], [Id_userrole], [Login], [Password]) VALUES (11, N'ООО "ТетаЛабс"', N'ТетаЛабс – научно-исследовательский центр, специализирующийся на проведении экспериментов и тестировании новых материалов и технологий. Мы сотрудничаем с ведущими университетами и промышленными предприятиями, обеспечивая высокий уровень точности и надежности наших исследований.', N'г. Санкт-Петербург', N'+7 (013) 451-42-43', N'tettalabs@mail.ru', N'40707880100000000008', 2, N'tl_labmanager', N'ThetaLabs123')
INSERT [dbo].[Organization] ([Id], [NameOrganization], [Description], [Address], [Phone], [Email], [PersonalAccount], [Id_userrole], [Login], [Password]) VALUES (12, N'ООО "КаппаСолюшнс"', N'КаппаСолюшнс – компания, предоставляющая услуги в области разработки и внедрения CRM-систем. Мы поможем вам организовать эффективное взаимодействие с клиентами, улучшить управление продажами и повысить лояльность потребителей.', N'г. Калининград', N'+7 (040) 343-14-15', N'Kappa_solut@gmail.com', N'40709900100000000010', 2, N'ks_solutionmanager', N'KappaSolutions789')
INSERT [dbo].[Organization] ([Id], [NameOrganization], [Description], [Address], [Phone], [Email], [PersonalAccount], [Id_userrole], [Login], [Password]) VALUES (13, N'АО "ЛямбдаГрупп"', N'ЛямбдаГрупп – многопрофильная холдинговая компания, объединяющая несколько направлений деятельности: производство, торговля, логистика и финансы. Мы стремимся к созданию синергии между нашими подразделениями, что позволяет нам предлагать клиентам лучшие условия сотрудничества.', N'г. Москва', N'+7 (100) 009-20-21', N'L_group@rambler.ru', N'40701810200000000011', 2, N'lg_groupadmin', N'LambdaGroupABC')
INSERT [dbo].[Organization] ([Id], [NameOrganization], [Description], [Address], [Phone], [Email], [PersonalAccount], [Id_userrole], [Login], [Password]) VALUES (15, N'ООО "КсиКоммьюникейшнс"', N'КсиКоммьюникейшнс – коммуникационное агентство, которое оказывает услуги в области PR, медиа-планирования и организации мероприятий. Мы работаем над тем, чтобы ваша компания получила максимально положительный имидж и доверие среди партнеров и клиентов.', N'г. Санкт_Петербург', N'+7 (050) 454-15-16', N'Ccommunicate@mail.ru', N'40704840500000000014', 2, N'xk_communicationmanager', N'XiCommunications456')
INSERT [dbo].[Organization] ([Id], [NameOrganization], [Description], [Address], [Phone], [Email], [PersonalAccount], [Id_userrole], [Login], [Password]) VALUES (19, N'ООО "ТехноЛидер"', N'Компания, занимающаяся разработкой инновационных технологий.', N'Москва, ул. Технологическая, д. 1', N'1234567890', N'contact@technoleader.com', N'123456789', 2, N'techlogin1', N'password1')
INSERT [dbo].[Organization] ([Id], [NameOrganization], [Description], [Address], [Phone], [Email], [PersonalAccount], [Id_userrole], [Login], [Password]) VALUES (20, N'ООО "ГлобалСтрой"', N'Компания, предоставляющая услуги в строительной сфере.', N'Санкт-Петербург, ул. Строителей, д. 2', N'1234567891', N'contact@globalstroy.com', N'234567890', 2, N'techlogin2', N'password2')
INSERT [dbo].[Organization] ([Id], [NameOrganization], [Description], [Address], [Phone], [Email], [PersonalAccount], [Id_userrole], [Login], [Password]) VALUES (21, N'ООО "ЛогистикПро"', N'Компания, предоставляющая логистические и транспортные услуги.', N'Новосибирск, ул. Транспортная, д. 3', N'1234567892', N'contact@logisticpro.com', N'345678901', 2, N'techlogin3', N'password3')
INSERT [dbo].[Organization] ([Id], [NameOrganization], [Description], [Address], [Phone], [Email], [PersonalAccount], [Id_userrole], [Login], [Password]) VALUES (22, N'ООО "Юридический Партнёр"', N'Компания, предоставляющая юридические услуги для бизнеса.', N'Екатеринбург, ул. Правовая, д. 4', N'1234567893', N'contact@jurpartner.com', N'456789012', 2, N'techlogin4', N'password4')
INSERT [dbo].[Organization] ([Id], [NameOrganization], [Description], [Address], [Phone], [Email], [PersonalAccount], [Id_userrole], [Login], [Password]) VALUES (23, N'ООО "СтройМаг"', N'Компания, специализирующаяся на продаже строительных материалов.', N'Казань, ул. Строителей, д. 5', N'1234567894', N'contact@stroymag.com', N'567890123', 2, N'techlogin5', N'password5')
INSERT [dbo].[Organization] ([Id], [NameOrganization], [Description], [Address], [Phone], [Email], [PersonalAccount], [Id_userrole], [Login], [Password]) VALUES (24, N'ООО "Мобайл Технологии"', N'Компания, разрабатывающая мобильные приложения и решения.', N'Нижний Новгород, ул. Мобильная, д. 6', N'1234567895', N'contact@mobiletech.com', N'678901234', 2, N'techlogin6', N'password6')
INSERT [dbo].[Organization] ([Id], [NameOrganization], [Description], [Address], [Phone], [Email], [PersonalAccount], [Id_userrole], [Login], [Password]) VALUES (25, N'ООО "АвтоСервис"', N'Компания, предоставляющая услуги по ремонту автомобилей и техническому обслуживанию.', N'Самара, ул. Автомобилистов, д. 7', N'1234567896', N'contact@autoservice.com', N'789012345', 2, N'techlogin7', N'password7')
INSERT [dbo].[Organization] ([Id], [NameOrganization], [Description], [Address], [Phone], [Email], [PersonalAccount], [Id_userrole], [Login], [Password]) VALUES (26, N'ООО "ЭлектроТехника"', N'Компания, занимающаяся продажей бытовой и промышленной электроники.', N'Краснодар, ул. Электрическая, д. 8', N'1234567897', N'contact@elektrotech.com', N'890123456', 2, N'techlogin8', N'password8')
INSERT [dbo].[Organization] ([Id], [NameOrganization], [Description], [Address], [Phone], [Email], [PersonalAccount], [Id_userrole], [Login], [Password]) VALUES (27, N'ООО "Мероприятия и События"', N'Компания, организующая мероприятия и деловые конференции.', N'Челябинск, ул. Событийная, д. 9', N'1234567898', N'contact@events.com', N'901234567', 2, N'techlogin9', N'password9')
INSERT [dbo].[Organization] ([Id], [NameOrganization], [Description], [Address], [Phone], [Email], [PersonalAccount], [Id_userrole], [Login], [Password]) VALUES (28, N'ООО "ГрадСтрой"', N'Компания, занимающаяся строительством жилых и коммерческих объектов.', N'Воронеж, ул. Строителей, д. 10', N'1234567899', N'contact@gradstroy.com', N'012345678', 2, N'techlogin10', N'password10')
INSERT [dbo].[Organization] ([Id], [NameOrganization], [Description], [Address], [Phone], [Email], [PersonalAccount], [Id_userrole], [Login], [Password]) VALUES (29, N'ООО "СигурТех"', N'Компания, предоставляющая услуги по охране и безопасности.', N'Ростов-на-Дону, ул. Безопасности, д. 11', N'1234567800', N'contact@sigurtech.com', N'123456780', 2, N'techlogin11', N'password11')
INSERT [dbo].[Organization] ([Id], [NameOrganization], [Description], [Address], [Phone], [Email], [PersonalAccount], [Id_userrole], [Login], [Password]) VALUES (30, N'ООО "Продукты Премиум"', N'Компания, специализирующаяся на продаже высококачественных продуктов питания.', N'Уфа, ул. Продовольственная, д. 12', N'1234567801', N'contact@premiumproducts.com', N'234567891', 2, N'techlogin12', N'password12')
INSERT [dbo].[Organization] ([Id], [NameOrganization], [Description], [Address], [Phone], [Email], [PersonalAccount], [Id_userrole], [Login], [Password]) VALUES (31, N'ООО "ТехноСервис"', N'Компания, предоставляющая услуги по ремонту и обслуживанию компьютерной техники.', N'Томск, ул. Электронная, д. 13', N'1234567802', N'contact@techservice.com', N'345678902', 2, N'techlogin13', N'password13')
INSERT [dbo].[Organization] ([Id], [NameOrganization], [Description], [Address], [Phone], [Email], [PersonalAccount], [Id_userrole], [Login], [Password]) VALUES (32, N'ООО "Туризм и Путешествия"', N'Компания, организующая туры и путешествия по России и за рубеж.', N'Рязань, ул. Туристическая, д. 14', N'1234567803', N'contact@tourismtravel.com', N'456789013', 2, N'techlogin14', N'password14')
INSERT [dbo].[Organization] ([Id], [NameOrganization], [Description], [Address], [Phone], [Email], [PersonalAccount], [Id_userrole], [Login], [Password]) VALUES (33, N'ООО "РемонтТех"', N'Компания, специализирующаяся на ремонте бытовой техники.', N'Тула, ул. Ремонтная, д. 15', N'1234567804', N'contact@remonttech.com', N'567890124', 2, N'techlogin15', N'password15')
INSERT [dbo].[Organization] ([Id], [NameOrganization], [Description], [Address], [Phone], [Email], [PersonalAccount], [Id_userrole], [Login], [Password]) VALUES (34, N'ООО "Дигиталь Системс"', N'Компания, занимающаяся разработкой IT-решений и систем автоматизации.', N'Красноярск, ул. Информационная, д. 16', N'1234567805', N'contact@digitalsystems.com', N'678901235', 2, N'techlogin16', N'password16')
INSERT [dbo].[Organization] ([Id], [NameOrganization], [Description], [Address], [Phone], [Email], [PersonalAccount], [Id_userrole], [Login], [Password]) VALUES (35, N'ООО "Солнечные Энергии"', N'Компания, занимающаяся установкой и обслуживанием солнечных панелей.', N'Иркутск, ул. Энергетическая, д. 17', N'1234567806', N'contact@solarenergy.com', N'789012346', 2, N'techlogin17', N'password17')
INSERT [dbo].[Organization] ([Id], [NameOrganization], [Description], [Address], [Phone], [Email], [PersonalAccount], [Id_userrole], [Login], [Password]) VALUES (36, N'ООО "МедикПро"', N'Компания, предоставляющая медицинские услуги и технику.', N'Чита, ул. Медицинская, д. 18', N'1234567807', N'contact@medicpro.com', N'890123457', 2, N'techlogin18', N'password18')
INSERT [dbo].[Organization] ([Id], [NameOrganization], [Description], [Address], [Phone], [Email], [PersonalAccount], [Id_userrole], [Login], [Password]) VALUES (37, N'ООО "Рекламный Мир"', N'Компания, предоставляющая рекламные и маркетинговые услуги.', N'Астрахань, ул. Рекламная, д. 19', N'1234567808', N'contact@adworld.com', N'901234568', 2, N'techlogin19', N'password19')
INSERT [dbo].[Organization] ([Id], [NameOrganization], [Description], [Address], [Phone], [Email], [PersonalAccount], [Id_userrole], [Login], [Password]) VALUES (38, N'ООО "Умный Дом"', N'Компания, занимающаяся установкой систем умного дома и автоматизации.', N'Владивосток, ул. Умная, д. 20', N'1234567809', N'contact@smart-home.com', N'012345679', 2, N'techlogin20', N'password20')
INSERT [dbo].[Organization] ([Id], [NameOrganization], [Description], [Address], [Phone], [Email], [PersonalAccount], [Id_userrole], [Login], [Password]) VALUES (39, N'ООО "Зеленая Планета"', N'Компания, занимающаяся производством экологически чистых товаров.', N'Хабаровск, ул. Экологическая, д. 21', N'1234567810', N'contact@greenplanet.com', N'123456680', 2, N'techlogin21', N'password21')
INSERT [dbo].[Organization] ([Id], [NameOrganization], [Description], [Address], [Phone], [Email], [PersonalAccount], [Id_userrole], [Login], [Password]) VALUES (40, N'ООО "Модный Образ"', N'Компания, предоставляющая услуги по разработке модных коллекций одежды.', N'Пермь, ул. Модная, д. 22', N'1234567811', N'contact@fashionstyle.com', N'234567892', 2, N'techlogin22', N'password22')
INSERT [dbo].[Organization] ([Id], [NameOrganization], [Description], [Address], [Phone], [Email], [PersonalAccount], [Id_userrole], [Login], [Password]) VALUES (41, N'ООО "ЭкоБизнес"', N'Компания, предоставляющая услуги по утилизации и переработке отходов.', N'Мурманск, ул. Эко, д. 23', N'1234567812', N'contact@ecobusiness.com', N'345678903', 2, N'techlogin23', N'password23')
INSERT [dbo].[Organization] ([Id], [NameOrganization], [Description], [Address], [Phone], [Email], [PersonalAccount], [Id_userrole], [Login], [Password]) VALUES (42, N'ООО "ФинансГрупп"', N'Компания, предлагающая финансовые и инвестиционные услуги.', N'Калуга, ул. Финансовая, д. 24', N'1234567813', N'contact@financegroup.com', N'456789014', 2, N'techlogin24', N'password24')
INSERT [dbo].[Organization] ([Id], [NameOrganization], [Description], [Address], [Phone], [Email], [PersonalAccount], [Id_userrole], [Login], [Password]) VALUES (43, N'ООО "КосмоТех"', N'Компания, работающая в области аэронавтики и космических исследований.', N'Сочи, ул. Космическая, д. 25', N'1234567814', N'contact@cosmotech.com', N'567890125', 2, N'techlogin25', N'password25')
INSERT [dbo].[Organization] ([Id], [NameOrganization], [Description], [Address], [Phone], [Email], [PersonalAccount], [Id_userrole], [Login], [Password]) VALUES (44, N'ООО "СветТех"', N'Компания, занимающаяся производством осветительных приборов.', N'Омск, ул. Светлая, д. 26', N'1234567815', N'contact@lighttech.com', N'678901236', 2, N'techlogin26', N'password26')
SET IDENTITY_INSERT [dbo].[Organization] OFF
GO
SET IDENTITY_INSERT [dbo].[Post] ON 

INSERT [dbo].[Post] ([Id], [NamePost]) VALUES (1, N'Курьер')
INSERT [dbo].[Post] ([Id], [NamePost]) VALUES (2, N'Водитель')
INSERT [dbo].[Post] ([Id], [NamePost]) VALUES (3, N'Продавец')
INSERT [dbo].[Post] ([Id], [NamePost]) VALUES (4, N'Кассир')
INSERT [dbo].[Post] ([Id], [NamePost]) VALUES (5, N'Администратор')
INSERT [dbo].[Post] ([Id], [NamePost]) VALUES (6, N'Оператор')
INSERT [dbo].[Post] ([Id], [NamePost]) VALUES (7, N'Программист')
INSERT [dbo].[Post] ([Id], [NamePost]) VALUES (8, N'Менеджер')
INSERT [dbo].[Post] ([Id], [NamePost]) VALUES (9, N'Строитель')
INSERT [dbo].[Post] ([Id], [NamePost]) VALUES (10, N'Сварщик')
INSERT [dbo].[Post] ([Id], [NamePost]) VALUES (11, N'Бухгалтер')
INSERT [dbo].[Post] ([Id], [NamePost]) VALUES (12, N'Инженер')
INSERT [dbo].[Post] ([Id], [NamePost]) VALUES (13, N'Директор')
INSERT [dbo].[Post] ([Id], [NamePost]) VALUES (14, N'Кладовщик')
INSERT [dbo].[Post] ([Id], [NamePost]) VALUES (15, N'Юрист')
INSERT [dbo].[Post] ([Id], [NamePost]) VALUES (16, N'Секретарь')
INSERT [dbo].[Post] ([Id], [NamePost]) VALUES (17, N'Дизайнер')
INSERT [dbo].[Post] ([Id], [NamePost]) VALUES (18, N'Уборщик')
INSERT [dbo].[Post] ([Id], [NamePost]) VALUES (19, N'Повар')
INSERT [dbo].[Post] ([Id], [NamePost]) VALUES (20, N'Экономист')
SET IDENTITY_INSERT [dbo].[Post] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Login], [Password], [FirstName], [LastName], [Phone], [Email], [NumberPassport], [SerialPassport], [MiddleName], [INN], [Id_userrole]) VALUES (1, N'FirstUser', N'FU123', N'Артем', N'Иванов', N'+7 (999) 121-22-33', N'Artem228@mail.ru', N'777777', N'5020', N'Михайлович', N'400000799910', 1)
INSERT [dbo].[User] ([Id], [Login], [Password], [FirstName], [LastName], [Phone], [Email], [NumberPassport], [SerialPassport], [MiddleName], [INN], [Id_userrole]) VALUES (2, N'Admin', N'Admin', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'1', 3)
INSERT [dbo].[User] ([Id], [Login], [Password], [FirstName], [LastName], [Phone], [Email], [NumberPassport], [SerialPassport], [MiddleName], [INN], [Id_userrole]) VALUES (7, N'IgorSmorodin', N'pipInstallPassword', N'Игорь', N'Смородин', N'+ 7 (900) 228-88-88', N'Igor_vishnya_20@mail.ru', N'234896', N'4720', N'Александрович', N'400000799912', 1)
INSERT [dbo].[User] ([Id], [Login], [Password], [FirstName], [LastName], [Phone], [Email], [NumberPassport], [SerialPassport], [MiddleName], [INN], [Id_userrole]) VALUES (8, N'login1', N'password1', N'Иван', N'Иванов', N'1234567890', N'ivan.ivanov@email.com', N'123456', N'1234', N'Иванович', N'123456789012', 1)
INSERT [dbo].[User] ([Id], [Login], [Password], [FirstName], [LastName], [Phone], [Email], [NumberPassport], [SerialPassport], [MiddleName], [INN], [Id_userrole]) VALUES (9, N'login2', N'password2', N'Мария', N'Петрова', N'1234567891', N'maria.petrov@email.com', N'234567', N'2345', N'Сергеевна', N'123456789013', 1)
INSERT [dbo].[User] ([Id], [Login], [Password], [FirstName], [LastName], [Phone], [Email], [NumberPassport], [SerialPassport], [MiddleName], [INN], [Id_userrole]) VALUES (10, N'login3', N'password3', N'Алексей', N'Сидоров', N'1234567892', N'alexey.sidorov@email.com', N'345678', N'3456', N'Анатольевич', N'123456789014', 1)
INSERT [dbo].[User] ([Id], [Login], [Password], [FirstName], [LastName], [Phone], [Email], [NumberPassport], [SerialPassport], [MiddleName], [INN], [Id_userrole]) VALUES (11, N'login4', N'password4', N'Елена', N'Кузнецова', N'1234567893', N'elena.kuznetsova@email.com', N'456789', N'4567', N'Владимировна', N'123456789015', 1)
INSERT [dbo].[User] ([Id], [Login], [Password], [FirstName], [LastName], [Phone], [Email], [NumberPassport], [SerialPassport], [MiddleName], [INN], [Id_userrole]) VALUES (12, N'login5', N'password5', N'Дмитрий', N'Морозов', N'1234567894', N'dmitriy.morozov@email.com', N'567890', N'5678', N'Александрович', N'123456789016', 1)
INSERT [dbo].[User] ([Id], [Login], [Password], [FirstName], [LastName], [Phone], [Email], [NumberPassport], [SerialPassport], [MiddleName], [INN], [Id_userrole]) VALUES (13, N'login6', N'password6', N'Светлана', N'Николаева', N'1234567895', N'svetlana.nikolaeva@email.com', N'678901', N'6789', N'Юрьевна', N'123456789017', 1)
INSERT [dbo].[User] ([Id], [Login], [Password], [FirstName], [LastName], [Phone], [Email], [NumberPassport], [SerialPassport], [MiddleName], [INN], [Id_userrole]) VALUES (14, N'login7', N'password7', N'Петр', N'Федоров', N'1234567896', N'peter.fedorov@email.com', N'789012', N'7890', N'Иванович', N'123456789018', 1)
INSERT [dbo].[User] ([Id], [Login], [Password], [FirstName], [LastName], [Phone], [Email], [NumberPassport], [SerialPassport], [MiddleName], [INN], [Id_userrole]) VALUES (15, N'login8', N'password8', N'Татьяна', N'Лебедева', N'1234567897', N'tatyana.lebedeva@email.com', N'890123', N'8901', N'Анатольевна', N'123456789019', 1)
INSERT [dbo].[User] ([Id], [Login], [Password], [FirstName], [LastName], [Phone], [Email], [NumberPassport], [SerialPassport], [MiddleName], [INN], [Id_userrole]) VALUES (16, N'login9', N'password9', N'Максим', N'Васильев', N'1234567898', N'maksim.vasiliev@email.com', N'901234', N'9012', N'Петрович', N'123456789020', 1)
INSERT [dbo].[User] ([Id], [Login], [Password], [FirstName], [LastName], [Phone], [Email], [NumberPassport], [SerialPassport], [MiddleName], [INN], [Id_userrole]) VALUES (17, N'login10', N'password10', N'Ольга', N'Гордеева', N'1234567899', N'olga.gordeva@email.com', N'012345', N'0123', N'Сергеевна', N'123456789021', 1)
INSERT [dbo].[User] ([Id], [Login], [Password], [FirstName], [LastName], [Phone], [Email], [NumberPassport], [SerialPassport], [MiddleName], [INN], [Id_userrole]) VALUES (18, N'login11', N'password11', N'Владимир', N'Тимофеев', N'1234567800', N'vladimir.timofeev@email.com', N'123457', N'1234', N'Юрьевич', N'123456789022', 1)
INSERT [dbo].[User] ([Id], [Login], [Password], [FirstName], [LastName], [Phone], [Email], [NumberPassport], [SerialPassport], [MiddleName], [INN], [Id_userrole]) VALUES (19, N'login12', N'password12', N'Анна', N'Романова', N'1234567801', N'anna.romanova@email.com', N'234568', N'2345', N'Петровна', N'123456789023', 1)
INSERT [dbo].[User] ([Id], [Login], [Password], [FirstName], [LastName], [Phone], [Email], [NumberPassport], [SerialPassport], [MiddleName], [INN], [Id_userrole]) VALUES (20, N'login13', N'password13', N'Сергей', N'Ковалев', N'1234567802', N'sergey.kovalev@email.com', N'345679', N'3456', N'Викторович', N'123456789024', 1)
INSERT [dbo].[User] ([Id], [Login], [Password], [FirstName], [LastName], [Phone], [Email], [NumberPassport], [SerialPassport], [MiddleName], [INN], [Id_userrole]) VALUES (21, N'login14', N'password14', N'Наталья', N'Попова', N'1234567803', N'natalya.popova@email.com', N'456780', N'4567', N'Александровна', N'123456789025', 1)
INSERT [dbo].[User] ([Id], [Login], [Password], [FirstName], [LastName], [Phone], [Email], [NumberPassport], [SerialPassport], [MiddleName], [INN], [Id_userrole]) VALUES (22, N'login15', N'password15', N'Роман', N'Ефимов', N'1234567804', N'roman.efimov@email.com', N'567891', N'5678', N'Николаевич', N'123456789026', 1)
INSERT [dbo].[User] ([Id], [Login], [Password], [FirstName], [LastName], [Phone], [Email], [NumberPassport], [SerialPassport], [MiddleName], [INN], [Id_userrole]) VALUES (23, N'login16', N'password16', N'Ирина', N'Соколова', N'1234567805', N'irina.sokolova@email.com', N'678902', N'6789', N'Вячеславовна', N'123456789027', 1)
INSERT [dbo].[User] ([Id], [Login], [Password], [FirstName], [LastName], [Phone], [Email], [NumberPassport], [SerialPassport], [MiddleName], [INN], [Id_userrole]) VALUES (24, N'login17', N'password17', N'Андрей', N'Климов', N'1234567806', N'andrey.klimov@email.com', N'789013', N'7890', N'Филиппович', N'123456789028', 1)
INSERT [dbo].[User] ([Id], [Login], [Password], [FirstName], [LastName], [Phone], [Email], [NumberPassport], [SerialPassport], [MiddleName], [INN], [Id_userrole]) VALUES (25, N'login18', N'password18', N'Виктория', N'Смирнова', N'1234567807', N'victoria.smirnova@email.com', N'890124', N'8901', N'Геннадьевна', N'123456789029', 1)
INSERT [dbo].[User] ([Id], [Login], [Password], [FirstName], [LastName], [Phone], [Email], [NumberPassport], [SerialPassport], [MiddleName], [INN], [Id_userrole]) VALUES (26, N'login19', N'password19', N'Евгений', N'Павлов', N'1234567808', N'evgeniy.pavlov@email.com', N'901235', N'9012', N'Сергеевич', N'123456789030', 1)
INSERT [dbo].[User] ([Id], [Login], [Password], [FirstName], [LastName], [Phone], [Email], [NumberPassport], [SerialPassport], [MiddleName], [INN], [Id_userrole]) VALUES (27, N'login20', N'password20', N'Екатерина', N'Маркова', N'1234567809', N'ekaterina.markova@email.com', N'012346', N'0123', N'Александровна', N'123456789031', 1)
INSERT [dbo].[User] ([Id], [Login], [Password], [FirstName], [LastName], [Phone], [Email], [NumberPassport], [SerialPassport], [MiddleName], [INN], [Id_userrole]) VALUES (28, N'login21', N'password21', N'Игорь', N'Шевченко', N'1234567810', N'igor.shevchenko@email.com', N'123457', N'1234', N'Геннадиевич', N'123456789032', 1)
INSERT [dbo].[User] ([Id], [Login], [Password], [FirstName], [LastName], [Phone], [Email], [NumberPassport], [SerialPassport], [MiddleName], [INN], [Id_userrole]) VALUES (29, N'login22', N'password22', N'Оксана', N'Фролова', N'1234567811', N'oksana.frolova@email.com', N'234568', N'2345', N'Федоровна', N'123456789033', 1)
INSERT [dbo].[User] ([Id], [Login], [Password], [FirstName], [LastName], [Phone], [Email], [NumberPassport], [SerialPassport], [MiddleName], [INN], [Id_userrole]) VALUES (30, N'login23', N'password23', N'Кирилл', N'Захаров', N'1234567812', N'kirill.zakharov@email.com', N'345679', N'3456', N'Михайлович', N'123456789034', 1)
INSERT [dbo].[User] ([Id], [Login], [Password], [FirstName], [LastName], [Phone], [Email], [NumberPassport], [SerialPassport], [MiddleName], [INN], [Id_userrole]) VALUES (31, N'login24', N'password24', N'Алина', N'Лукина', N'1234567813', N'alina.lukina@email.com', N'456780', N'4567', N'Владимировна', N'123456789035', 1)
INSERT [dbo].[User] ([Id], [Login], [Password], [FirstName], [LastName], [Phone], [Email], [NumberPassport], [SerialPassport], [MiddleName], [INN], [Id_userrole]) VALUES (32, N'login25', N'password25', N'Михаил', N'Воронов', N'1234567814', N'mikhail.voronov@email.com', N'567891', N'5678', N'Павлович', N'123456789036', 1)
INSERT [dbo].[User] ([Id], [Login], [Password], [FirstName], [LastName], [Phone], [Email], [NumberPassport], [SerialPassport], [MiddleName], [INN], [Id_userrole]) VALUES (33, N'login26', N'password26', N'Юлия', N'Нестерова', N'1234567815', N'yulia.nesterova@email.com', N'678902', N'6789', N'Дмитриевна', N'123456789037', 1)
INSERT [dbo].[User] ([Id], [Login], [Password], [FirstName], [LastName], [Phone], [Email], [NumberPassport], [SerialPassport], [MiddleName], [INN], [Id_userrole]) VALUES (34, N'login27', N'password27', N'Роман', N'Прокофьев', N'1234567816', N'roman.prokofiev@email.com', N'789013', N'7890', N'Ильич', N'123456789038', 1)
INSERT [dbo].[User] ([Id], [Login], [Password], [FirstName], [LastName], [Phone], [Email], [NumberPassport], [SerialPassport], [MiddleName], [INN], [Id_userrole]) VALUES (35, N'login28', N'password28', N'Тимур', N'Голубев', N'1234567817', N'timur.golubev@email.com', N'890124', N'8901', N'Аркадьевич', N'123456789039', 1)
INSERT [dbo].[User] ([Id], [Login], [Password], [FirstName], [LastName], [Phone], [Email], [NumberPassport], [SerialPassport], [MiddleName], [INN], [Id_userrole]) VALUES (36, N'login29', N'password29', N'Мариanna', N'Жукова', N'1234567818', N'marianna.zhukova@email.com', N'901235', N'9012', N'Анатольевна', N'123456789040', 1)
INSERT [dbo].[User] ([Id], [Login], [Password], [FirstName], [LastName], [Phone], [Email], [NumberPassport], [SerialPassport], [MiddleName], [INN], [Id_userrole]) VALUES (37, N'login30', N'password30', N'Максим', N'Козлов', N'1234567819', N'maksim.kozlov@email.com', N'012346', N'0123', N'Петрович', N'123456789041', 1)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
INSERT [dbo].[UserRole] ([Id], [Name]) VALUES (1, N'Соискатель')
INSERT [dbo].[UserRole] ([Id], [Name]) VALUES (2, N'Работодатель')
INSERT [dbo].[UserRole] ([Id], [Name]) VALUES (3, N'Администратор')
GO
ALTER TABLE [dbo].[Offer]  WITH CHECK ADD  CONSTRAINT [FK_Offer_Organization] FOREIGN KEY([Id_Organization])
REFERENCES [dbo].[Organization] ([Id])
GO
ALTER TABLE [dbo].[Offer] CHECK CONSTRAINT [FK_Offer_Organization]
GO
ALTER TABLE [dbo].[Offer]  WITH CHECK ADD  CONSTRAINT [FK_Offer_Post] FOREIGN KEY([Id_post])
REFERENCES [dbo].[Post] ([Id])
GO
ALTER TABLE [dbo].[Offer] CHECK CONSTRAINT [FK_Offer_Post]
GO
ALTER TABLE [dbo].[Offer]  WITH CHECK ADD  CONSTRAINT [FK_Offer_User] FOREIGN KEY([Id_user])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Offer] CHECK CONSTRAINT [FK_Offer_User]
GO
ALTER TABLE [dbo].[Organization]  WITH CHECK ADD  CONSTRAINT [FK_Organization_UserRole] FOREIGN KEY([Id_userrole])
REFERENCES [dbo].[UserRole] ([Id])
GO
ALTER TABLE [dbo].[Organization] CHECK CONSTRAINT [FK_Organization_UserRole]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_UserRole] FOREIGN KEY([Id_userrole])
REFERENCES [dbo].[UserRole] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_UserRole]
GO
