
CREATE DATABASE [QuanLyNhanSu]
GO
USE [QuanLyNhanSu]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChucVu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenCV] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HopDong]    Script Date: 4/7/2023 17:51:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HopDong](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdNV] [int] NULL,
	[LoaiHD] [int] NULL,
	[NgayKi] [datetime] NULL,
	[NgayKT] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 4/7/2023 17:51:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](255) NULL,
	[Email] [varchar](255) NULL,
	[SDT] [varchar](10) NULL,
	[GioiTinh] [bit] NULL,
	[NgaySinh] [datetime] NULL,
	[QueQuan] [nvarchar](max) NULL,
	[DanToc] [nvarchar](max) NULL,
	[BacLuong] [int] NULL,
	[ChuyenNganh] [nvarchar](max) NULL,
	[IdTDHV] [int] NULL,
	[IdPB] [int] NULL,
	[IdTK] [int] NULL,
	[Luong] [money] NULL,
	[STK] [varchar](50) NULL,
	[NganHang] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhongBan]    Script Date: 4/7/2023 17:51:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhongBan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenPhongBan] [nvarchar](100) NULL,
	[SDT] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 4/7/2023 17:51:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenDangNhap] [varchar](255) NULL,
	[MatKhau] [varchar](255) NULL,
	[TinhTrang] [bit] NULL,
	[IdCV] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrinhDoHocVan]    Script Date: 4/7/2023 17:51:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrinhDoHocVan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TrinhDo] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ChucVu] ON 

INSERT [dbo].[ChucVu] ([Id], [TenCV]) VALUES (1, N'Trưởng phòng')
INSERT [dbo].[ChucVu] ([Id], [TenCV]) VALUES (2, N'Phó phòng')
INSERT [dbo].[ChucVu] ([Id], [TenCV]) VALUES (3, N'Nhân viên')
INSERT [dbo].[ChucVu] ([Id], [TenCV]) VALUES (4, N'Leader')
SET IDENTITY_INSERT [dbo].[ChucVu] OFF
GO
SET IDENTITY_INSERT [dbo].[HopDong] ON 

INSERT [dbo].[HopDong] ([Id], [IdNV], [LoaiHD], [NgayKi], [NgayKT]) VALUES (2, 5, 1, CAST(N'2022-12-12T00:00:00.000' AS DateTime), CAST(N'2023-12-12T00:00:00.000' AS DateTime))
INSERT [dbo].[HopDong] ([Id], [IdNV], [LoaiHD], [NgayKi], [NgayKT]) VALUES (3, 5, 2, CAST(N'2022-12-12T00:00:00.000' AS DateTime), CAST(N'2023-12-12T00:00:00.000' AS DateTime))
INSERT [dbo].[HopDong] ([Id], [IdNV], [LoaiHD], [NgayKi], [NgayKT]) VALUES (4, 1, 2, CAST(N'2022-12-12T00:00:00.000' AS DateTime), CAST(N'2023-12-12T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[HopDong] OFF
GO
SET IDENTITY_INSERT [dbo].[NhanVien] ON 

INSERT [dbo].[NhanVien] ([Id], [HoTen], [Email], [SDT], [GioiTinh], [NgaySinh], [QueQuan], [DanToc], [BacLuong], [ChuyenNganh], [IdTDHV], [IdPB], [IdTK], [Luong], [STK], [NganHang]) VALUES (1, N'Hưng Đẹp Trai', N'thanhhung169@gmail.com', N'0866952668', 1, CAST(N'1998-04-04T00:00:00.000' AS DateTime), N'Hưng yên', N'Kinh', 2, N'Công nghệ thông tin', 3, 1, 1, 8500000.0000, N'0491000165505', N'Vietcombank')
INSERT [dbo].[NhanVien] ([Id], [HoTen], [Email], [SDT], [GioiTinh], [NgaySinh], [QueQuan], [DanToc], [BacLuong], [ChuyenNganh], [IdTDHV], [IdPB], [IdTK], [Luong], [STK], [NganHang]) VALUES (5, N'Thành Hưngg', N'hunghung111@gmail.com', N'0866952661', 0, CAST(N'1992-12-12T00:00:00.000' AS DateTime), N'hưng yên', N'kinh', 2, N'công nghệ thông tin', 3, 3, 5, 12000000.0000, N'23445654654', N'VietTinBank')
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
GO
SET IDENTITY_INSERT [dbo].[PhongBan] ON 

INSERT [dbo].[PhongBan] ([Id], [TenPhongBan], [SDT]) VALUES (1, N'Nhân sự', N'18009567')
INSERT [dbo].[PhongBan] ([Id], [TenPhongBan], [SDT]) VALUES (2, N'Hành chính', N'18009898')
INSERT [dbo].[PhongBan] ([Id], [TenPhongBan], [SDT]) VALUES (3, N'Kỹ thuật', N'18006666')
INSERT [dbo].[PhongBan] ([Id], [TenPhongBan], [SDT]) VALUES (4, N'Kế toán', N'18001111')
SET IDENTITY_INSERT [dbo].[PhongBan] OFF
GO
SET IDENTITY_INSERT [dbo].[TaiKhoan] ON 

INSERT [dbo].[TaiKhoan] ([Id], [TenDangNhap], [MatKhau], [TinhTrang], [IdCV]) VALUES (1, N'admin', N'123', 1, 1)
INSERT [dbo].[TaiKhoan] ([Id], [TenDangNhap], [MatKhau], [TinhTrang], [IdCV]) VALUES (5, N'hunghung111@gmail.com', N'quanlynhansu123@', 1, 1)
SET IDENTITY_INSERT [dbo].[TaiKhoan] OFF
GO
SET IDENTITY_INSERT [dbo].[TrinhDoHocVan] ON 

INSERT [dbo].[TrinhDoHocVan] ([Id], [TrinhDo]) VALUES (1, N'Tiến sĩ')
INSERT [dbo].[TrinhDoHocVan] ([Id], [TrinhDo]) VALUES (2, N'Thạc sĩ')
INSERT [dbo].[TrinhDoHocVan] ([Id], [TrinhDo]) VALUES (3, N'Cao học')
INSERT [dbo].[TrinhDoHocVan] ([Id], [TrinhDo]) VALUES (4, N'Đại học')
INSERT [dbo].[TrinhDoHocVan] ([Id], [TrinhDo]) VALUES (5, N'Cao đẳng')
SET IDENTITY_INSERT [dbo].[TrinhDoHocVan] OFF
GO
ALTER TABLE [dbo].[HopDong]  WITH CHECK ADD FOREIGN KEY([IdNV])
REFERENCES [dbo].[NhanVien] ([Id])
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD FOREIGN KEY([IdPB])
REFERENCES [dbo].[PhongBan] ([Id])
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD FOREIGN KEY([IdTDHV])
REFERENCES [dbo].[TrinhDoHocVan] ([Id])
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD FOREIGN KEY([IdTK])
REFERENCES [dbo].[TaiKhoan] ([Id])
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD FOREIGN KEY([IdCV])
REFERENCES [dbo].[ChucVu] ([Id])
GO
USE [master]
GO
ALTER DATABASE [QuanLyNhanSu] SET  READ_WRITE 
GO
