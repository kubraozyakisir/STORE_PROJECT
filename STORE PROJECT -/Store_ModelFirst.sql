USE [master]
GO
/****** Object:  Database [STORE]    Script Date: 9.03.2022 18:32:55 ******/
CREATE DATABASE [STORE]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'STORE', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\STORE.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'STORE_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\STORE_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [STORE] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [STORE].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [STORE] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [STORE] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [STORE] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [STORE] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [STORE] SET ARITHABORT OFF 
GO
ALTER DATABASE [STORE] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [STORE] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [STORE] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [STORE] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [STORE] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [STORE] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [STORE] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [STORE] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [STORE] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [STORE] SET  DISABLE_BROKER 
GO
ALTER DATABASE [STORE] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [STORE] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [STORE] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [STORE] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [STORE] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [STORE] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [STORE] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [STORE] SET RECOVERY FULL 
GO
ALTER DATABASE [STORE] SET  MULTI_USER 
GO
ALTER DATABASE [STORE] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [STORE] SET DB_CHAINING OFF 
GO
ALTER DATABASE [STORE] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [STORE] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [STORE] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [STORE] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [STORE] SET QUERY_STORE = OFF
GO
USE [STORE]
GO
/****** Object:  Table [dbo].[Bolum]    Script Date: 9.03.2022 18:32:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bolum](
	[BolumNo] [int] IDENTITY(1,1) NOT NULL,
	[BolumAdi] [varchar](50) NULL,
	[BolumUrunSayisi] [int] NULL,
	[SorumluNo] [int] NULL,
 CONSTRAINT [PK_Bolum] PRIMARY KEY CLUSTERED 
(
	[BolumNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kullanicilar]    Script Date: 9.03.2022 18:32:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kullanicilar](
	[KullaniciNo] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciAdSoyad] [varchar](50) NULL,
	[Sifre] [varchar](50) NULL,
 CONSTRAINT [PK_Kullanicilar] PRIMARY KEY CLUSTERED 
(
	[KullaniciNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Magaza]    Script Date: 9.03.2022 18:32:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Magaza](
	[MagazaNo] [int] IDENTITY(1,1) NOT NULL,
	[MagazaAdi] [varchar](50) NULL,
	[MagazaCiro] [money] NULL,
	[MagazaAdres] [varchar](50) NULL,
	[SevkiyatTarih] [date] NULL,
	[SevkiyatGunu] [varchar](50) NULL,
 CONSTRAINT [PK_Magaza] PRIMARY KEY CLUSTERED 
(
	[MagazaNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Malzeme]    Script Date: 9.03.2022 18:32:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Malzeme](
	[MalzemeNo] [int] IDENTITY(1,1) NOT NULL,
	[MagazaNo] [int] NULL,
	[MalzemeAdi] [varchar](50) NULL,
	[MalzemeAdet] [int] NULL,
	[MalzemeBirimFiyat] [money] NULL,
	[MalzemeKod] [int] NULL,
	[MalzemeAciklama] [varchar](50) NULL,
 CONSTRAINT [PK_Malzeme] PRIMARY KEY CLUSTERED 
(
	[MalzemeNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sorumluluk]    Script Date: 9.03.2022 18:32:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sorumluluk](
	[SorumlulukNo] [int] IDENTITY(1,1) NOT NULL,
	[MagazaNo] [int] NULL,
	[SorumluAdi] [varchar](50) NULL,
	[SorumluMaas] [money] NULL,
	[SorumluPrim] [money] NULL,
	[SorumluVardiya] [int] NULL,
 CONSTRAINT [PK_Sorumluluk] PRIMARY KEY CLUSTERED 
(
	[SorumlulukNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Bolum] ON 

INSERT [dbo].[Bolum] ([BolumNo], [BolumAdi], [BolumUrunSayisi], [SorumluNo]) VALUES (5, N'KADIN', 5000, 11)
INSERT [dbo].[Bolum] ([BolumNo], [BolumAdi], [BolumUrunSayisi], [SorumluNo]) VALUES (6, N'ERKEK', 4500, 13)
INSERT [dbo].[Bolum] ([BolumNo], [BolumAdi], [BolumUrunSayisi], [SorumluNo]) VALUES (7, N'DIVIDED', 3800, 14)
INSERT [dbo].[Bolum] ([BolumNo], [BolumAdi], [BolumUrunSayisi], [SorumluNo]) VALUES (9, N'ÇOCUK', 2500, 13)
SET IDENTITY_INSERT [dbo].[Bolum] OFF
GO
SET IDENTITY_INSERT [dbo].[Kullanicilar] ON 

INSERT [dbo].[Kullanicilar] ([KullaniciNo], [KullaniciAdSoyad], [Sifre]) VALUES (1, N'kubraoz', N'51598')
SET IDENTITY_INSERT [dbo].[Kullanicilar] OFF
GO
SET IDENTITY_INSERT [dbo].[Magaza] ON 

INSERT [dbo].[Magaza] ([MagazaNo], [MagazaAdi], [MagazaCiro], [MagazaAdres], [SevkiyatTarih], [SevkiyatGunu]) VALUES (3, N'PULL&BEAR', 15000.0000, N'PİAZZA', CAST(N'2022-02-24' AS Date), N'Salı,Pazar')
INSERT [dbo].[Magaza] ([MagazaNo], [MagazaAdi], [MagazaCiro], [MagazaAdres], [SevkiyatTarih], [SevkiyatGunu]) VALUES (4, N'STRADIVARIUS', 965000.0000, N'PİAZZA', CAST(N'2022-02-26' AS Date), N'Pazar,Cuma')
INSERT [dbo].[Magaza] ([MagazaNo], [MagazaAdi], [MagazaCiro], [MagazaAdres], [SevkiyatTarih], [SevkiyatGunu]) VALUES (5, N'KOTON', 956200.0000, N'NATILIUS', CAST(N'2022-02-09' AS Date), N'Pazartesi,Perşembe')
INSERT [dbo].[Magaza] ([MagazaNo], [MagazaAdi], [MagazaCiro], [MagazaAdres], [SevkiyatTarih], [SevkiyatGunu]) VALUES (6, N'OXXO', 85000.0000, N'PİAZZA', CAST(N'2022-02-09' AS Date), N'Salı,Pazar')
INSERT [dbo].[Magaza] ([MagazaNo], [MagazaAdi], [MagazaCiro], [MagazaAdres], [SevkiyatTarih], [SevkiyatGunu]) VALUES (7, N'MAVİ', 962500.0000, N'BEYOĞLU', CAST(N'2022-02-09' AS Date), N'Pazartesi,Perşembe')
INSERT [dbo].[Magaza] ([MagazaNo], [MagazaAdi], [MagazaCiro], [MagazaAdres], [SevkiyatTarih], [SevkiyatGunu]) VALUES (8, N'YVES ROCHA', 956000.0000, N'ZORLU CENTER', CAST(N'2022-02-25' AS Date), N'Pazartesi,Perşembe')
SET IDENTITY_INSERT [dbo].[Magaza] OFF
GO
SET IDENTITY_INSERT [dbo].[Malzeme] ON 

INSERT [dbo].[Malzeme] ([MalzemeNo], [MagazaNo], [MalzemeAdi], [MalzemeAdet], [MalzemeBirimFiyat], [MalzemeKod], [MalzemeAciklama]) VALUES (2, 3, N'Keten Şort', 100, 150.0000, 12311, N'******************')
INSERT [dbo].[Malzeme] ([MalzemeNo], [MagazaNo], [MalzemeAdi], [MalzemeAdet], [MalzemeBirimFiyat], [MalzemeKod], [MalzemeAciklama]) VALUES (3, 3, N'Basic Short', 80, 50.0000, 12245, N'%100 Basic')
SET IDENTITY_INSERT [dbo].[Malzeme] OFF
GO
SET IDENTITY_INSERT [dbo].[Sorumluluk] ON 

INSERT [dbo].[Sorumluluk] ([SorumlulukNo], [MagazaNo], [SorumluAdi], [SorumluMaas], [SorumluPrim], [SorumluVardiya]) VALUES (11, 5, N'AYDAN ÇINAR', 18000.0000, 6500.0000, 1)
INSERT [dbo].[Sorumluluk] ([SorumlulukNo], [MagazaNo], [SorumluAdi], [SorumluMaas], [SorumluPrim], [SorumluVardiya]) VALUES (12, 6, N'MELİSA MERT', 11000.0000, 6000.0000, 2)
INSERT [dbo].[Sorumluluk] ([SorumlulukNo], [MagazaNo], [SorumluAdi], [SorumluMaas], [SorumluPrim], [SorumluVardiya]) VALUES (13, 4, N'VOLKAN KOLÇAK', 12000.0000, 3000.0000, 1)
INSERT [dbo].[Sorumluluk] ([SorumlulukNo], [MagazaNo], [SorumluAdi], [SorumluMaas], [SorumluPrim], [SorumluVardiya]) VALUES (14, 4, N'NAZLI GÜNER', 12000.0000, 3000.0000, 1)
SET IDENTITY_INSERT [dbo].[Sorumluluk] OFF
GO
ALTER TABLE [dbo].[Bolum]  WITH CHECK ADD  CONSTRAINT [FK_Bolum_Sorumluluk] FOREIGN KEY([SorumluNo])
REFERENCES [dbo].[Sorumluluk] ([SorumlulukNo])
GO
ALTER TABLE [dbo].[Bolum] CHECK CONSTRAINT [FK_Bolum_Sorumluluk]
GO
ALTER TABLE [dbo].[Bolum]  WITH CHECK ADD  CONSTRAINT [FK_SorumluNo] FOREIGN KEY([SorumluNo])
REFERENCES [dbo].[Sorumluluk] ([SorumlulukNo])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bolum] CHECK CONSTRAINT [FK_SorumluNo]
GO
ALTER TABLE [dbo].[Malzeme]  WITH CHECK ADD  CONSTRAINT [FK_Malzeme_Magaza] FOREIGN KEY([MagazaNo])
REFERENCES [dbo].[Magaza] ([MagazaNo])
GO
ALTER TABLE [dbo].[Malzeme] CHECK CONSTRAINT [FK_Malzeme_Magaza]
GO
ALTER TABLE [dbo].[Malzeme]  WITH CHECK ADD  CONSTRAINT [FK_storeno] FOREIGN KEY([MagazaNo])
REFERENCES [dbo].[Magaza] ([MagazaNo])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Malzeme] CHECK CONSTRAINT [FK_storeno]
GO
ALTER TABLE [dbo].[Sorumluluk]  WITH CHECK ADD  CONSTRAINT [FK_Sorumluluk_Magaza] FOREIGN KEY([MagazaNo])
REFERENCES [dbo].[Magaza] ([MagazaNo])
GO
ALTER TABLE [dbo].[Sorumluluk] CHECK CONSTRAINT [FK_Sorumluluk_Magaza]
GO
ALTER TABLE [dbo].[Sorumluluk]  WITH CHECK ADD  CONSTRAINT [FKSstoreno] FOREIGN KEY([MagazaNo])
REFERENCES [dbo].[Magaza] ([MagazaNo])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Sorumluluk] CHECK CONSTRAINT [FKSstoreno]
GO
USE [master]
GO
ALTER DATABASE [STORE] SET  READ_WRITE 
GO
