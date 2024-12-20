USE [DOTRONGHUY_CNTT1_2210900029_Project2]
GO
/****** Object:  Table [dbo].[chi_tiet_gio_hang]    Script Date: 10/28/2024 3:54:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chi_tiet_gio_hang](
	[ma_gio_hang] [int] NOT NULL,
	[ma_xe] [int] NOT NULL,
	[so_luong] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_gio_hang] ASC,
	[ma_xe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[danh_muc_xe_hoi]    Script Date: 10/28/2024 3:54:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[danh_muc_xe_hoi](
	[ma_xe] [int] IDENTITY(1,1) NOT NULL,
	[ten_xe] [varchar](100) NULL,
	[hang_xe] [varchar](50) NULL,
	[gia_ban] [decimal](10, 2) NULL,
	[mo_ta] [text] NULL,
	[so_luong] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_xe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[don_hang]    Script Date: 10/28/2024 3:54:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[don_hang](
	[ma_dh] [int] IDENTITY(1,1) NOT NULL,
	[ma_kh] [int] NULL,
	[tong_tien] [decimal](10, 2) NULL,
	[ngay_dat] [datetime] NULL,
	[trang_thai] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_dh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[gio_hang]    Script Date: 10/28/2024 3:54:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[gio_hang](
	[ma_gio_hang] [int] IDENTITY(1,1) NOT NULL,
	[ma_kh] [int] NULL,
	[ngay_tao] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_gio_hang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[khach_hang]    Script Date: 10/28/2024 3:54:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[khach_hang](
	[ma_kh] [int] IDENTITY(1,1) NOT NULL,
	[ho_ten] [varchar](100) NULL,
	[tai_khoan] [varchar](50) NULL,
	[mat_khau] [varchar](32) NULL,
	[dia_chi] [varchar](200) NULL,
	[dien_thoai] [varchar](10) NULL,
	[email] [varchar](50) NULL,
	[ngay_sinh] [datetime] NULL,
	[ngay_cap_nhat] [datetime] NULL,
	[gioi_tinh] [tinyint] NULL,
	[tich_diem] [int] NULL,
	[trang_thai] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_kh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[quan_tri]    Script Date: 10/28/2024 3:54:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[quan_tri](
	[tai_khoan] [varchar](50) NOT NULL,
	[mat_khau] [varchar](32) NULL,
	[trang_thai] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[tai_khoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[thanh_toan]    Script Date: 10/28/2024 3:54:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[thanh_toan](
	[ma_thanh_toan] [int] IDENTITY(1,1) NOT NULL,
	[ma_dh] [int] NULL,
	[ngay_thanh_toan] [datetime] NULL,
	[tong_tien] [decimal](10, 2) NULL,
	[phuong_thuc] [varchar](50) NULL,
	[trang_thai] [tinyint] NULL,
	[mo_ta] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_thanh_toan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__khach_ha__ABA0D02722C013B1]    Script Date: 10/28/2024 3:54:34 PM ******/
ALTER TABLE [dbo].[khach_hang] ADD UNIQUE NONCLUSTERED 
(
	[tai_khoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[gio_hang] ADD  DEFAULT (getdate()) FOR [ngay_tao]
GO
ALTER TABLE [dbo].[khach_hang] ADD  DEFAULT (getdate()) FOR [ngay_cap_nhat]
GO
ALTER TABLE [dbo].[khach_hang] ADD  DEFAULT ((0)) FOR [tich_diem]
GO
ALTER TABLE [dbo].[thanh_toan] ADD  DEFAULT (getdate()) FOR [ngay_thanh_toan]
GO
ALTER TABLE [dbo].[chi_tiet_gio_hang]  WITH CHECK ADD FOREIGN KEY([ma_gio_hang])
REFERENCES [dbo].[gio_hang] ([ma_gio_hang])
GO
ALTER TABLE [dbo].[chi_tiet_gio_hang]  WITH CHECK ADD FOREIGN KEY([ma_xe])
REFERENCES [dbo].[danh_muc_xe_hoi] ([ma_xe])
GO
ALTER TABLE [dbo].[don_hang]  WITH CHECK ADD FOREIGN KEY([ma_kh])
REFERENCES [dbo].[khach_hang] ([ma_kh])
GO
ALTER TABLE [dbo].[gio_hang]  WITH CHECK ADD FOREIGN KEY([ma_kh])
REFERENCES [dbo].[khach_hang] ([ma_kh])
GO
ALTER TABLE [dbo].[thanh_toan]  WITH CHECK ADD FOREIGN KEY([ma_dh])
REFERENCES [dbo].[don_hang] ([ma_dh])

ALTER TABLE [dbo].[quan_tri]
ADD [isAdmin] [bit] DEFAULT (0) NOT NULL;

ALTER TABLE [dbo].[khach_hang]
ADD CONSTRAINT UQ_khach_hang_tai_khoan_mat_khau UNIQUE ([tai_khoan], [mat_khau]);

ALTER TABLE [dbo].[danh_muc_xe_hoi]
ADD [anh] VARCHAR(255) NULL;

ALTER TABLE [dbo].[khach_hang]
ADD [isAdmin] BIT DEFAULT 1;


CREATE TABLE [dbo].[user_auth] (
    [tai_khoan] VARCHAR(50) NOT NULL PRIMARY KEY,
    [mat_khau] VARCHAR(32) NOT NULL,
    [isAdmin] BIT DEFAULT 1 -- 1 là user, 0 là admin
);

-- Liên kết bảng khach_hang với user_auth
ALTER TABLE [dbo].[khach_hang]
ADD CONSTRAINT FK_khach_hang_user_auth FOREIGN KEY (tai_khoan)
REFERENCES [dbo].[user_auth] (tai_khoan);

-- Liên kết bảng quan_tri với user_auth
ALTER TABLE [dbo].[quan_tri]
ADD CONSTRAINT FK_quan_tri_user_auth FOREIGN KEY (tai_khoan)
REFERENCES [dbo].[user_auth] (tai_khoan);

SELECT tai_khoan 
FROM quan_tri 
WHERE tai_khoan NOT IN (SELECT tai_khoan FROM user_auth);

INSERT INTO user_auth (tai_khoan, mat_khau, isAdmin)
SELECT tai_khoan, mat_khau, 0 -- 0 là admin
FROM quan_tri
WHERE tai_khoan NOT IN (SELECT tai_khoan FROM user_auth);

ALTER TABLE [dbo].[quan_tri]
ADD CONSTRAINT FK_quan_tri_user_auth FOREIGN KEY (tai_khoan)
REFERENCES [dbo].[user_auth] (tai_khoan);

INSERT INTO dbo.khach_hang (ho_ten, tai_khoan, mat_khau, dia_chi, dien_thoai, email, ngay_sinh, ngay_cap_nhat, gioi_tinh, tich_diem, trang_thai)
VALUES ('Đỗ Trọng Huy', 'tronghuy', '123456', 'Hà Nội', '0123456789', 'tronghuy@gmail.com', '2004-10-20', GETDATE(), 1, 0, 1);

INSERT INTO dbo.user_auth (tai_khoan, mat_khau)
VALUES ('tronghuy', '123456');


ALTER TABLE chi_tiet_gio_hang
ADD ten_xe NVARCHAR(255),
    hang_xe NVARCHAR(255),
    anh NVARCHAR(255),
    gia_ban DECIMAL(18, 2);

select*From khach_hang
go
select*from chi_tiet_gio_hang
select*from don_hang
go
SELECT * 
FROM don_hang
WHERE ma_kh = 2 AND trang_thai = 1;
go
SELECT * 
FROM chi_tiet_gio_hang
WHERE ma_gio_hang = 2;
go
SELECT c.ten_xe, c.hang_xe, c.gia_ban, ct.so_luong, ct.anh
FROM chi_tiet_gio_hang ct
JOIN danh_muc_xe_hoi c ON ct.ma_xe = c.ma_xe
WHERE ct.ma_gio_hang = 2;
go
SELECT * FROM don_hang WHERE ma_kh = 1;

ALTER TABLE [dbo].[chi_tiet_gio_hang]  WITH CHECK ADD FOREIGN KEY([ma_xe])
REFERENCES [dbo].[danh_muc_xe_hoi] ([ma_xe])

ALTER TABLE [dbo].[chi_tiet_gio_hang]  WITH CHECK ADD FOREIGN KEY([ma_gio_hang])
REFERENCES [dbo].[gio_hang] ([ma_gio_hang])


ALTER TABLE chi_tiet_gio_hang
ADD CONSTRAINT FK_ma_xe
FOREIGN KEY (ma_xe) REFERENCES danh_muc_xe_hoi(ma_xe);