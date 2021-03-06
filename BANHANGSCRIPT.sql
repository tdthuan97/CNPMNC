USE [BANHANGDB]
GO
ALTER TABLE [dbo].[SANPHAM] DROP CONSTRAINT [FK_SANPHAM_NHACUNGCAP]
GO
ALTER TABLE [dbo].[SANPHAM] DROP CONSTRAINT [FK_SANPHAM_LOAISANPHAM]
GO
ALTER TABLE [dbo].[NHACUNGCAP] DROP CONSTRAINT [FK_NHACUNGCAP_LOAISANPHAM]
GO
ALTER TABLE [dbo].[DONHANG] DROP CONSTRAINT [FK_DONHANG_KHACHHANG]
GO
ALTER TABLE [dbo].[CHITIETDONHANG] DROP CONSTRAINT [FK_CHITIETDONHANG_TINHTRANG]
GO
ALTER TABLE [dbo].[CHITIETDONHANG] DROP CONSTRAINT [FK_CHITIETDONHANG_SANPHAM]
GO
ALTER TABLE [dbo].[CHITIETDONHANG] DROP CONSTRAINT [FK_CHITIETDONHANG_DONHANG]
GO
/****** Object:  Table [dbo].[TINHTRANG]    Script Date: 5/23/2018 12:12:53 PM ******/
DROP TABLE [dbo].[TINHTRANG]
GO
/****** Object:  Table [dbo].[SANPHAM]    Script Date: 5/23/2018 12:12:53 PM ******/
DROP TABLE [dbo].[SANPHAM]
GO
/****** Object:  Table [dbo].[NHACUNGCAP]    Script Date: 5/23/2018 12:12:53 PM ******/
DROP TABLE [dbo].[NHACUNGCAP]
GO
/****** Object:  Table [dbo].[LOAISANPHAM]    Script Date: 5/23/2018 12:12:53 PM ******/
DROP TABLE [dbo].[LOAISANPHAM]
GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 5/23/2018 12:12:53 PM ******/
DROP TABLE [dbo].[KHACHHANG]
GO
/****** Object:  Table [dbo].[DONHANG]    Script Date: 5/23/2018 12:12:53 PM ******/
DROP TABLE [dbo].[DONHANG]
GO
/****** Object:  Table [dbo].[CHITIETDONHANG]    Script Date: 5/23/2018 12:12:53 PM ******/
DROP TABLE [dbo].[CHITIETDONHANG]
GO
/****** Object:  Table [dbo].[ADMIN]    Script Date: 5/23/2018 12:12:53 PM ******/
DROP TABLE [dbo].[ADMIN]
GO
/****** Object:  Table [dbo].[ADMIN]    Script Date: 5/23/2018 12:12:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ADMIN](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[useradmin] [varchar](15) NOT NULL,
	[passadmin] [varchar](15) NOT NULL,
	[hoten] [nvarchar](50) NULL,
 CONSTRAINT [PK_ADMIN] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CHITIETDONHANG]    Script Date: 5/23/2018 12:12:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHITIETDONHANG](
	[mactdh] [int] IDENTITY(1,1) NOT NULL,
	[mahd] [int] NOT NULL,
	[masp] [int] NOT NULL,
	[soluong] [int] NULL,
	[thanhtien] [money] NULL,
	[ngaygiaodukien] [smalldatetime] NULL,
	[ngaygiaothat] [smalldatetime] NULL,
	[matinhtrang] [int] NOT NULL,
 CONSTRAINT [PK_CHITIETDONHANG] PRIMARY KEY CLUSTERED 
(
	[mactdh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DONHANG]    Script Date: 5/23/2018 12:12:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DONHANG](
	[mahd] [int] IDENTITY(1,1) NOT NULL,
	[makh] [int] NOT NULL,
	[ngaytao] [smalldatetime] NULL,
	[trigia] [money] NULL,
 CONSTRAINT [PK_DONHANG] PRIMARY KEY CLUSTERED 
(
	[mahd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 5/23/2018 12:12:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[makh] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](15) NOT NULL,
	[password] [varchar](15) NOT NULL,
	[hoten] [nvarchar](50) NOT NULL,
	[gioitinh] [bit] NULL,
	[diachi] [nvarchar](50) NOT NULL,
	[email] [varchar](50) NULL,
	[sdt] [varchar](15) NOT NULL,
 CONSTRAINT [PK_KHACHHANG] PRIMARY KEY CLUSTERED 
(
	[makh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAISANPHAM]    Script Date: 5/23/2018 12:12:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAISANPHAM](
	[maloai] [int] IDENTITY(1,1) NOT NULL,
	[tenloai] [nvarchar](50) NOT NULL,
	[trangthai] [bit] NULL,
 CONSTRAINT [PK_LOAISANPHAM] PRIMARY KEY CLUSTERED 
(
	[maloai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHACUNGCAP]    Script Date: 5/23/2018 12:12:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHACUNGCAP](
	[mancc] [int] IDENTITY(1,1) NOT NULL,
	[tenncc] [nvarchar](50) NOT NULL,
	[diachi] [nvarchar](50) NULL,
	[maloai] [int] NOT NULL,
	[trangthai] [bit] NULL,
 CONSTRAINT [PK_NHACUNGCAP] PRIMARY KEY CLUSTERED 
(
	[mancc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SANPHAM]    Script Date: 5/23/2018 12:12:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SANPHAM](
	[masanpham] [int] IDENTITY(1,1) NOT NULL,
	[tensanpham] [nvarchar](50) NOT NULL,
	[gia] [money] NOT NULL,
	[mota] [ntext] NOT NULL,
	[hinh] [varchar](50) NOT NULL,
	[ngaycapnhat] [smalldatetime] NULL,
	[maloai] [int] NOT NULL,
	[mancc] [int] NOT NULL,
	[trangthai] [bit] NULL,
 CONSTRAINT [PK_SANPHAM] PRIMARY KEY CLUSTERED 
(
	[masanpham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TINHTRANG]    Script Date: 5/23/2018 12:12:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TINHTRANG](
	[matinhtrang] [int] IDENTITY(1,1) NOT NULL,
	[tentinhtrang] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TINHTRANG] PRIMARY KEY CLUSTERED 
(
	[matinhtrang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ADMIN] ON 

INSERT [dbo].[ADMIN] ([id], [useradmin], [passadmin], [hoten]) VALUES (1, N'tdthuan97', N'123', N'Trần Đức Thuận')
INSERT [dbo].[ADMIN] ([id], [useradmin], [passadmin], [hoten]) VALUES (3, N'tungle', N'123', N'Lê Cẩm Tùng')
SET IDENTITY_INSERT [dbo].[ADMIN] OFF
SET IDENTITY_INSERT [dbo].[CHITIETDONHANG] ON 

INSERT [dbo].[CHITIETDONHANG] ([mactdh], [mahd], [masp], [soluong], [thanhtien], [ngaygiaodukien], [ngaygiaothat], [matinhtrang]) VALUES (1, 1, 1, 5, 32500000.0000, CAST(N'2018-04-30T00:00:00' AS SmallDateTime), NULL, 1)
INSERT [dbo].[CHITIETDONHANG] ([mactdh], [mahd], [masp], [soluong], [thanhtien], [ngaygiaodukien], [ngaygiaothat], [matinhtrang]) VALUES (4, 2, 1, 2, 13000000.0000, CAST(N'2018-04-23T00:00:00' AS SmallDateTime), NULL, 1)
INSERT [dbo].[CHITIETDONHANG] ([mactdh], [mahd], [masp], [soluong], [thanhtien], [ngaygiaodukien], [ngaygiaothat], [matinhtrang]) VALUES (5, 3, 4, 1, 21500000.0000, CAST(N'2018-04-30T00:00:00' AS SmallDateTime), NULL, 1)
INSERT [dbo].[CHITIETDONHANG] ([mactdh], [mahd], [masp], [soluong], [thanhtien], [ngaygiaodukien], [ngaygiaothat], [matinhtrang]) VALUES (6, 3, 1, 3, 19500000.0000, CAST(N'2018-04-30T00:00:00' AS SmallDateTime), NULL, 1)
INSERT [dbo].[CHITIETDONHANG] ([mactdh], [mahd], [masp], [soluong], [thanhtien], [ngaygiaodukien], [ngaygiaothat], [matinhtrang]) VALUES (7, 4, 13, 1, 5500000.0000, CAST(N'2018-04-27T00:00:00' AS SmallDateTime), NULL, 2)
INSERT [dbo].[CHITIETDONHANG] ([mactdh], [mahd], [masp], [soluong], [thanhtien], [ngaygiaodukien], [ngaygiaothat], [matinhtrang]) VALUES (8, 4, 8, 2, 3700000.0000, CAST(N'2018-04-27T00:00:00' AS SmallDateTime), NULL, 2)
INSERT [dbo].[CHITIETDONHANG] ([mactdh], [mahd], [masp], [soluong], [thanhtien], [ngaygiaodukien], [ngaygiaothat], [matinhtrang]) VALUES (9, 4, 7, 1, 1550000.0000, CAST(N'2018-04-27T00:00:00' AS SmallDateTime), NULL, 2)
INSERT [dbo].[CHITIETDONHANG] ([mactdh], [mahd], [masp], [soluong], [thanhtien], [ngaygiaodukien], [ngaygiaothat], [matinhtrang]) VALUES (10, 5, 5, 1, 19490000.0000, CAST(N'2018-05-02T00:00:00' AS SmallDateTime), NULL, 1)
INSERT [dbo].[CHITIETDONHANG] ([mactdh], [mahd], [masp], [soluong], [thanhtien], [ngaygiaodukien], [ngaygiaothat], [matinhtrang]) VALUES (11, 6, 6, 3, 3912000.0000, CAST(N'2018-05-03T00:00:00' AS SmallDateTime), NULL, 1)
INSERT [dbo].[CHITIETDONHANG] ([mactdh], [mahd], [masp], [soluong], [thanhtien], [ngaygiaodukien], [ngaygiaothat], [matinhtrang]) VALUES (12, 7, 1, 1, 6990000.0000, CAST(N'2018-05-07T00:00:00' AS SmallDateTime), NULL, 1)
INSERT [dbo].[CHITIETDONHANG] ([mactdh], [mahd], [masp], [soluong], [thanhtien], [ngaygiaodukien], [ngaygiaothat], [matinhtrang]) VALUES (13, 8, 5, 1, 19490000.0000, CAST(N'2018-05-06T00:00:00' AS SmallDateTime), NULL, 1)
INSERT [dbo].[CHITIETDONHANG] ([mactdh], [mahd], [masp], [soluong], [thanhtien], [ngaygiaodukien], [ngaygiaothat], [matinhtrang]) VALUES (14, 9, 3, 2, 33000000.0000, CAST(N'2018-05-12T00:00:00' AS SmallDateTime), CAST(N'2018-05-04T07:37:00' AS SmallDateTime), 3)
INSERT [dbo].[CHITIETDONHANG] ([mactdh], [mahd], [masp], [soluong], [thanhtien], [ngaygiaodukien], [ngaygiaothat], [matinhtrang]) VALUES (15, 9, 2, 1, 16990000.0000, CAST(N'2018-05-12T00:00:00' AS SmallDateTime), NULL, 1)
SET IDENTITY_INSERT [dbo].[CHITIETDONHANG] OFF
SET IDENTITY_INSERT [dbo].[DONHANG] ON 

INSERT [dbo].[DONHANG] ([mahd], [makh], [ngaytao], [trigia]) VALUES (1, 1, CAST(N'2018-04-19T11:15:00' AS SmallDateTime), 32500000.0000)
INSERT [dbo].[DONHANG] ([mahd], [makh], [ngaytao], [trigia]) VALUES (2, 1, CAST(N'2018-04-20T10:35:00' AS SmallDateTime), 13000000.0000)
INSERT [dbo].[DONHANG] ([mahd], [makh], [ngaytao], [trigia]) VALUES (3, 1, CAST(N'2018-04-23T11:54:00' AS SmallDateTime), 41000000.0000)
INSERT [dbo].[DONHANG] ([mahd], [makh], [ngaytao], [trigia]) VALUES (4, 3, CAST(N'2018-04-24T21:47:00' AS SmallDateTime), 10750000.0000)
INSERT [dbo].[DONHANG] ([mahd], [makh], [ngaytao], [trigia]) VALUES (5, 5, CAST(N'2018-04-30T22:06:00' AS SmallDateTime), 19490000.0000)
INSERT [dbo].[DONHANG] ([mahd], [makh], [ngaytao], [trigia]) VALUES (6, 5, CAST(N'2018-04-30T22:11:00' AS SmallDateTime), 3912000.0000)
INSERT [dbo].[DONHANG] ([mahd], [makh], [ngaytao], [trigia]) VALUES (7, 1, CAST(N'2018-05-04T07:28:00' AS SmallDateTime), 6990000.0000)
INSERT [dbo].[DONHANG] ([mahd], [makh], [ngaytao], [trigia]) VALUES (8, 6, CAST(N'2018-05-04T07:34:00' AS SmallDateTime), 19490000.0000)
INSERT [dbo].[DONHANG] ([mahd], [makh], [ngaytao], [trigia]) VALUES (9, 6, CAST(N'2018-05-04T07:35:00' AS SmallDateTime), 49990000.0000)
SET IDENTITY_INSERT [dbo].[DONHANG] OFF
SET IDENTITY_INSERT [dbo].[KHACHHANG] ON 

INSERT [dbo].[KHACHHANG] ([makh], [username], [password], [hoten], [gioitinh], [diachi], [email], [sdt]) VALUES (1, N'tdthuan97', N'123', N'Trần Đức Thuận', 1, N'Sài Gòn', N'', N'0909123123')
INSERT [dbo].[KHACHHANG] ([makh], [username], [password], [hoten], [gioitinh], [diachi], [email], [sdt]) VALUES (2, N'bbb', N'123', N'Nguyễn Thị B', 0, N'1A Thành Thái', N'', N'0909123456')
INSERT [dbo].[KHACHHANG] ([makh], [username], [password], [hoten], [gioitinh], [diachi], [email], [sdt]) VALUES (3, N'aaa', N'123', N'Nguyễn Anh Tuấn', 1, N'3A Thành Thái P9 Q10', N'ooo@gmail.com', N'113')
INSERT [dbo].[KHACHHANG] ([makh], [username], [password], [hoten], [gioitinh], [diachi], [email], [sdt]) VALUES (4, N'zzz', N'123', N'Nam Cam', NULL, N'Tù Côn Đảo', N'', N'115')
INSERT [dbo].[KHACHHANG] ([makh], [username], [password], [hoten], [gioitinh], [diachi], [email], [sdt]) VALUES (5, N'np', N'1234', N'phuong', 0, N'480 nguyentriphuong', N'nhuphuong268@gmail.com', N'909771982')
INSERT [dbo].[KHACHHANG] ([makh], [username], [password], [hoten], [gioitinh], [diachi], [email], [sdt]) VALUES (6, N'tuan', N'123', N'Tuan', NULL, N'aa', N'aa', N'111')
INSERT [dbo].[KHACHHANG] ([makh], [username], [password], [hoten], [gioitinh], [diachi], [email], [sdt]) VALUES (8, N'eee', N'justforuD1', N'Trần Văn É', NULL, N'xxx', N'', N'123456789')
SET IDENTITY_INSERT [dbo].[KHACHHANG] OFF
SET IDENTITY_INSERT [dbo].[LOAISANPHAM] ON 

INSERT [dbo].[LOAISANPHAM] ([maloai], [tenloai], [trangthai]) VALUES (1, N'Điện Thoại - Máy Tính Bảng', 1)
INSERT [dbo].[LOAISANPHAM] ([maloai], [tenloai], [trangthai]) VALUES (2, N'Tivi - Thiết Bị Nghe Nhìn', 1)
INSERT [dbo].[LOAISANPHAM] ([maloai], [tenloai], [trangthai]) VALUES (3, N'Laptop - Thiết Bị IT', 1)
INSERT [dbo].[LOAISANPHAM] ([maloai], [tenloai], [trangthai]) VALUES (4, N'Máy Ảnh - Quay Phim', 1)
INSERT [dbo].[LOAISANPHAM] ([maloai], [tenloai], [trangthai]) VALUES (5, N'Đồ Chơi, Mẹ & Bé', 1)
INSERT [dbo].[LOAISANPHAM] ([maloai], [tenloai], [trangthai]) VALUES (6, N'Thời Trang - Phụ Kiện', 1)
INSERT [dbo].[LOAISANPHAM] ([maloai], [tenloai], [trangthai]) VALUES (7, N'Xe Máy, Ô tô, Xe đạp', 1)
INSERT [dbo].[LOAISANPHAM] ([maloai], [tenloai], [trangthai]) VALUES (8, N'Nhà Cửa Đời Sống', 1)
INSERT [dbo].[LOAISANPHAM] ([maloai], [tenloai], [trangthai]) VALUES (9, N'Thể Thao - Dã Ngoại', 1)
INSERT [dbo].[LOAISANPHAM] ([maloai], [tenloai], [trangthai]) VALUES (10, N'Sách', 1)
INSERT [dbo].[LOAISANPHAM] ([maloai], [tenloai], [trangthai]) VALUES (28, N'Làm Đẹp - Sức Khỏe', 1)
SET IDENTITY_INSERT [dbo].[LOAISANPHAM] OFF
SET IDENTITY_INSERT [dbo].[NHACUNGCAP] ON 

INSERT [dbo].[NHACUNGCAP] ([mancc], [tenncc], [diachi], [maloai], [trangthai]) VALUES (1, N'Viễn Tin Sài Gòn', N'88 Ngô Gia Tự', 1, 1)
INSERT [dbo].[NHACUNGCAP] ([mancc], [tenncc], [diachi], [maloai], [trangthai]) VALUES (2, N'Mac&More', N'22B Nguyễn Tri Phương', 1, 1)
INSERT [dbo].[NHACUNGCAP] ([mancc], [tenncc], [diachi], [maloai], [trangthai]) VALUES (3, N'Viễn Thịnh', N'11A Nguyễn Huệ', 1, 1)
INSERT [dbo].[NHACUNGCAP] ([mancc], [tenncc], [diachi], [maloai], [trangthai]) VALUES (4, N'Điện Máy Xanh', N'44A Ngô Gia Tự', 2, 1)
INSERT [dbo].[NHACUNGCAP] ([mancc], [tenncc], [diachi], [maloai], [trangthai]) VALUES (5, N'Tiki Trading', N'55B Nguyễn Tri Phương', 2, 1)
INSERT [dbo].[NHACUNGCAP] ([mancc], [tenncc], [diachi], [maloai], [trangthai]) VALUES (6, N'Vân Phong', N'99A Nguyễn Huệ', 2, 1)
INSERT [dbo].[NHACUNGCAP] ([mancc], [tenncc], [diachi], [maloai], [trangthai]) VALUES (7, N'Đồ Họa Việt', N'222A Ngô Gia Tự', 3, 1)
INSERT [dbo].[NHACUNGCAP] ([mancc], [tenncc], [diachi], [maloai], [trangthai]) VALUES (8, N'Tin Học - Viễn Thông', N'555B Nguyễn Tri Phương', 3, 1)
INSERT [dbo].[NHACUNGCAP] ([mancc], [tenncc], [diachi], [maloai], [trangthai]) VALUES (9, N'9AM', N'123A Nguyễn Huệ', 3, 1)
INSERT [dbo].[NHACUNGCAP] ([mancc], [tenncc], [diachi], [maloai], [trangthai]) VALUES (10, N'Thiết Bị Thông Minh', N'19A Ngô Gia Tự', 4, 1)
INSERT [dbo].[NHACUNGCAP] ([mancc], [tenncc], [diachi], [maloai], [trangthai]) VALUES (11, N'TechTown', N'221B Nguyễn Tri Phương', 4, 1)
INSERT [dbo].[NHACUNGCAP] ([mancc], [tenncc], [diachi], [maloai], [trangthai]) VALUES (12, N'Gia Hiệp ', N'433A Nguyễn Huệ', 4, 1)
INSERT [dbo].[NHACUNGCAP] ([mancc], [tenncc], [diachi], [maloai], [trangthai]) VALUES (13, N'Nhựa Chợ Lớn', N'1A Thành Thái', 5, 1)
INSERT [dbo].[NHACUNGCAP] ([mancc], [tenncc], [diachi], [maloai], [trangthai]) VALUES (14, N'BabyShop', N'22B Sư Vạn Hành', 5, 1)
INSERT [dbo].[NHACUNGCAP] ([mancc], [tenncc], [diachi], [maloai], [trangthai]) VALUES (15, N'Tini Shop', N'11A Thành Thái', 6, 1)
INSERT [dbo].[NHACUNGCAP] ([mancc], [tenncc], [diachi], [maloai], [trangthai]) VALUES (16, N'LaTa', N'221B Sư Vạn Hành', 6, 1)
INSERT [dbo].[NHACUNGCAP] ([mancc], [tenncc], [diachi], [maloai], [trangthai]) VALUES (17, N'Phúc Nguyên', N'123A Thành Thái', 7, 1)
INSERT [dbo].[NHACUNGCAP] ([mancc], [tenncc], [diachi], [maloai], [trangthai]) VALUES (18, N'Sportslink', N'223B Sư Vạn Hành', 7, 1)
INSERT [dbo].[NHACUNGCAP] ([mancc], [tenncc], [diachi], [maloai], [trangthai]) VALUES (19, N'Phú Mỹ', N'99A Thành Thái', 8, 1)
INSERT [dbo].[NHACUNGCAP] ([mancc], [tenncc], [diachi], [maloai], [trangthai]) VALUES (20, N'Asama', N'44B Sư Vạn Hành', 8, 1)
INSERT [dbo].[NHACUNGCAP] ([mancc], [tenncc], [diachi], [maloai], [trangthai]) VALUES (21, N'Addidas', N'33A Thành Thái', 9, 1)
INSERT [dbo].[NHACUNGCAP] ([mancc], [tenncc], [diachi], [maloai], [trangthai]) VALUES (22, N'Nike', N'113B Sư Vạn Hành', 9, 1)
INSERT [dbo].[NHACUNGCAP] ([mancc], [tenncc], [diachi], [maloai], [trangthai]) VALUES (23, N'Nhà Sách Nhân Văn', N'99A Thành Thái', 10, 1)
INSERT [dbo].[NHACUNGCAP] ([mancc], [tenncc], [diachi], [maloai], [trangthai]) VALUES (24, N'Đại Học Quốc Gia', N'115B Sư Vạn Hành', 10, 1)
INSERT [dbo].[NHACUNGCAP] ([mancc], [tenncc], [diachi], [maloai], [trangthai]) VALUES (29, N'Giant', N'113 Phạm Văn Đồng', 7, 1)
SET IDENTITY_INSERT [dbo].[NHACUNGCAP] OFF
SET IDENTITY_INSERT [dbo].[SANPHAM] ON 

INSERT [dbo].[SANPHAM] ([masanpham], [tensanpham], [gia], [mota], [hinh], [ngaycapnhat], [maloai], [mancc], [trangthai]) VALUES (1, N'IPhone 8', 6990000.0000, N'iPhone 8 64GB có thiết kế mới độc đáo từ thủy tinh và chip xử lý nhanh nhất, mạnh mẽ nhất cũng với nhiều tính năng ưu việt cho bạn trải nghiệm mới mẻ.', N'ip8.jpg', CAST(N'2018-05-02T18:13:00' AS SmallDateTime), 1, 1, 1)
INSERT [dbo].[SANPHAM] ([masanpham], [tensanpham], [gia], [mota], [hinh], [ngaycapnhat], [maloai], [mancc], [trangthai]) VALUES (2, N'iPad Pro', 16990000.0000, N'Đặc điểm nổi bật của iPad Pro 10.5 inch Wifi 64GB (2017)  Tìm hiểu thêm Tìm hiểu thêm Tìm hiểu thêm iPad Pro 10.5 inch Wifi 64GB (2017) với kích thước màn hình nhỏ hơn, viền màn hình siêu mỏng cùng hiệu năng mạnh mẽ sẽ đáp ứng tốt cho bạn trong mọi nhu cầu sử dụng hằng ngày.', N'ipad.jpg', CAST(N'2018-04-20T00:00:00' AS SmallDateTime), 1, 3, 1)
INSERT [dbo].[SANPHAM] ([masanpham], [tensanpham], [gia], [mota], [hinh], [ngaycapnhat], [maloai], [mancc], [trangthai]) VALUES (3, N'Samsung Galaxy S8', 16500000.0000, N'Galaxy S8 với thiết kế nhỏ gọn, màn hình siêu mỏng', N'ssgs8.png', CAST(N'2018-04-30T21:58:00' AS SmallDateTime), 1, 3, 1)
INSERT [dbo].[SANPHAM] ([masanpham], [tensanpham], [gia], [mota], [hinh], [ngaycapnhat], [maloai], [mancc], [trangthai]) VALUES (4, N'Máy Ảnh Mirrorless Canon', 21500000.0000, N'Độ phân giải 24.2 MP. Cảm biến hình ảnh CMOS. Bộ xử lý ảnh: DIGIC 7. Màn hình LCD 3.0" (xoay lật góc 180 độ / 45 độ). Chụp liên tục ảnh: 9 ảnh / giây. ISO 128000 ( mở rộng đến 25600 ). Hỗ trợ Wi-Fi / NFC / Bluetooth', N'mayanh.jpg', CAST(N'2018-04-25T11:24:00' AS SmallDateTime), 4, 12, 1)
INSERT [dbo].[SANPHAM] ([masanpham], [tensanpham], [gia], [mota], [hinh], [ngaycapnhat], [maloai], [mancc], [trangthai]) VALUES (5, N'Macbook Air 2017', 19490000.0000, N'Chip: Intel Core i5 Dual-core 1.8GHz. RAM: 8GB 1600MHZ. Ổ cứng 128GB. Intel HD Graphics 6000. Màn hình 13.3 inch (990 x 1440 pixels). Hệ điều hành macOS. Pin Li-Po 54 Wh', N'macbook.jpg', CAST(N'2018-04-22T00:00:00' AS SmallDateTime), 3, 8, 1)
INSERT [dbo].[SANPHAM] ([masanpham], [tensanpham], [gia], [mota], [hinh], [ngaycapnhat], [maloai], [mancc], [trangthai]) VALUES (6, N'Java Programming 24', 1304000.0000, N'Hướng dẫn lập trình ngôn ngữ Java chuyên ngành công nghệ phần mềm', N'java.jpg', CAST(N'2018-04-22T00:00:00' AS SmallDateTime), 10, 24, 1)
INSERT [dbo].[SANPHAM] ([masanpham], [tensanpham], [gia], [mota], [hinh], [ngaycapnhat], [maloai], [mancc], [trangthai]) VALUES (7, N'Adiddas Barricade 7', 1550000.0000, N'Giày tennis, di chuyên dễ dàng trên mọi măt sân, không đau chân', N'giayaddidas.jpg', CAST(N'2018-04-22T00:00:00' AS SmallDateTime), 9, 21, 1)
INSERT [dbo].[SANPHAM] ([masanpham], [tensanpham], [gia], [mota], [hinh], [ngaycapnhat], [maloai], [mancc], [trangthai]) VALUES (8, N'Mắt kính EKOI', 1850000.0000, N'Dùng cho xe ROAD, MTB. Chống tia cực tim. Trọng lượng 35g', N'ekoiglass.jpg', CAST(N'2018-04-22T18:36:00' AS SmallDateTime), 6, 16, 1)
INSERT [dbo].[SANPHAM] ([masanpham], [tensanpham], [gia], [mota], [hinh], [ngaycapnhat], [maloai], [mancc], [trangthai]) VALUES (9, N'PROPEL ADVANCED 1 - 2018', 48500000.0000, N'Khung sườn Advanced-grade Composite. Group Ul 6800. Bánh PR2 Carbon', N'giant.jpg', CAST(N'2018-04-22T19:26:00' AS SmallDateTime), 7, 18, 1)
INSERT [dbo].[SANPHAM] ([masanpham], [tensanpham], [gia], [mota], [hinh], [ngaycapnhat], [maloai], [mancc], [trangthai]) VALUES (10, N'PROPEL ADVANCED 2 - 2018', 41300000.0000, N'Khung sườn Advanced-Grade Composite. Group 105. Bánh PR2 Carbon', N'giant1.jpg', CAST(N'2018-04-22T00:00:00' AS SmallDateTime), 7, 18, 1)
INSERT [dbo].[SANPHAM] ([masanpham], [tensanpham], [gia], [mota], [hinh], [ngaycapnhat], [maloai], [mancc], [trangthai]) VALUES (12, N'Sữa Bột Nestle NAN Optipro 4', 350000.0000, N'Hộp 900gr. Sản phẩm dành cho trẻ từ 2 - 6 tuổi. Cung cấp hệ dưỡng chất đầy đủ cho trẻ.', N'sua.jpg', CAST(N'2018-04-23T22:04:00' AS SmallDateTime), 5, 14, 1)
INSERT [dbo].[SANPHAM] ([masanpham], [tensanpham], [gia], [mota], [hinh], [ngaycapnhat], [maloai], [mancc], [trangthai]) VALUES (13, N'Kính RADAR EV', 5500000.0000, N'Kính đua xe đạp oakley, chống tia cực tim, bảo vệ mắt khỏi bụi. Made in USA.', N'kinh.png', CAST(N'2018-05-02T12:01:00' AS SmallDateTime), 6, 16, 1)
INSERT [dbo].[SANPHAM] ([masanpham], [tensanpham], [gia], [mota], [hinh], [ngaycapnhat], [maloai], [mancc], [trangthai]) VALUES (14, N'Nón bảo hiểm Giro', 1200000.0000, N'Nón bảo hiểm bảo vệ đầu chắc chắn dành cho xe đạp đua chuyên nghiệp.', N'giro.jpg', CAST(N'2018-05-01T21:25:00' AS SmallDateTime), 7, 17, 1)
INSERT [dbo].[SANPHAM] ([masanpham], [tensanpham], [gia], [mota], [hinh], [ngaycapnhat], [maloai], [mancc], [trangthai]) VALUES (15, N'Groupama-FDJ', 195000000.0000, N'Frame: Lapierre Xelius SL of Disc, Pulsium (Disc), Aircode SL, Aerostorm (TT). Groep: Shimano Dura-Ace Di2. Wielen: Shimano Dura-Ace.', N'la.jpg', CAST(N'2018-05-02T07:25:00' AS SmallDateTime), 7, 18, 1)
SET IDENTITY_INSERT [dbo].[SANPHAM] OFF
SET IDENTITY_INSERT [dbo].[TINHTRANG] ON 

INSERT [dbo].[TINHTRANG] ([matinhtrang], [tentinhtrang]) VALUES (1, N'Nhận đơn hàng')
INSERT [dbo].[TINHTRANG] ([matinhtrang], [tentinhtrang]) VALUES (2, N'Đang giao hàng')
INSERT [dbo].[TINHTRANG] ([matinhtrang], [tentinhtrang]) VALUES (3, N'Đã giao hàng và thanh toán')
INSERT [dbo].[TINHTRANG] ([matinhtrang], [tentinhtrang]) VALUES (4, N'Hủy đơn hàng')
SET IDENTITY_INSERT [dbo].[TINHTRANG] OFF
ALTER TABLE [dbo].[CHITIETDONHANG]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETDONHANG_DONHANG] FOREIGN KEY([mahd])
REFERENCES [dbo].[DONHANG] ([mahd])
GO
ALTER TABLE [dbo].[CHITIETDONHANG] CHECK CONSTRAINT [FK_CHITIETDONHANG_DONHANG]
GO
ALTER TABLE [dbo].[CHITIETDONHANG]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETDONHANG_SANPHAM] FOREIGN KEY([masp])
REFERENCES [dbo].[SANPHAM] ([masanpham])
GO
ALTER TABLE [dbo].[CHITIETDONHANG] CHECK CONSTRAINT [FK_CHITIETDONHANG_SANPHAM]
GO
ALTER TABLE [dbo].[CHITIETDONHANG]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETDONHANG_TINHTRANG] FOREIGN KEY([matinhtrang])
REFERENCES [dbo].[TINHTRANG] ([matinhtrang])
GO
ALTER TABLE [dbo].[CHITIETDONHANG] CHECK CONSTRAINT [FK_CHITIETDONHANG_TINHTRANG]
GO
ALTER TABLE [dbo].[DONHANG]  WITH CHECK ADD  CONSTRAINT [FK_DONHANG_KHACHHANG] FOREIGN KEY([makh])
REFERENCES [dbo].[KHACHHANG] ([makh])
GO
ALTER TABLE [dbo].[DONHANG] CHECK CONSTRAINT [FK_DONHANG_KHACHHANG]
GO
ALTER TABLE [dbo].[NHACUNGCAP]  WITH CHECK ADD  CONSTRAINT [FK_NHACUNGCAP_LOAISANPHAM] FOREIGN KEY([maloai])
REFERENCES [dbo].[LOAISANPHAM] ([maloai])
GO
ALTER TABLE [dbo].[NHACUNGCAP] CHECK CONSTRAINT [FK_NHACUNGCAP_LOAISANPHAM]
GO
ALTER TABLE [dbo].[SANPHAM]  WITH CHECK ADD  CONSTRAINT [FK_SANPHAM_LOAISANPHAM] FOREIGN KEY([maloai])
REFERENCES [dbo].[LOAISANPHAM] ([maloai])
GO
ALTER TABLE [dbo].[SANPHAM] CHECK CONSTRAINT [FK_SANPHAM_LOAISANPHAM]
GO
ALTER TABLE [dbo].[SANPHAM]  WITH CHECK ADD  CONSTRAINT [FK_SANPHAM_NHACUNGCAP] FOREIGN KEY([mancc])
REFERENCES [dbo].[NHACUNGCAP] ([mancc])
GO
ALTER TABLE [dbo].[SANPHAM] CHECK CONSTRAINT [FK_SANPHAM_NHACUNGCAP]
GO
