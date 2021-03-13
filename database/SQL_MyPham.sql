CREATE DATABASE MYPHAM

DROP DATABASE MYPHAM

USE MYPHAM
GO
 
--- TẠO BẢNG ---
CREATE TABLE NHANVIEN
(
	TaiKhoan VARCHAR(200) PRIMARY KEY,
	MatKhau VARCHAR(MAX),
	TenNV NVARCHAR(MAX),
	Quyen BIT NOT NULL
)
CREATE TABLE LOAISP
(
	MaLoaiSP INT IDENTITY PRIMARY KEY,
	TenLoaiSP NVARCHAR(MAX),
	HinhAnh VARCHAR(MAX)
)
CREATE TABLE SANPHAM
(
	MaSP INT IDENTITY PRIMARY KEY,
	TenSP NVARCHAR(MAX),
	SoLuong INT DEFAULT 1,
	GiaBan INT, 
	GiaVon INT,
	TrangThai BIT DEFAULT 1,
	HinhAnh VARCHAR(MAX),
	MaLoai INT FOREIGN KEY (MaLoai) REFERENCES LOAISP(MaLoaiSP),
	MoTa NVARCHAR(MAX),
	DonViTinh NVARCHAR(50)
)
CREATE TABLE KHACHHANG
(
	MaKH INT IDENTITY PRIMARY KEY,
	TenKH NVARCHAR(MAX),
	Email VARCHAR(MAX),
	MatKhau VARCHAR(MAX),
	SDT CHAR(11),
	DiaChi NVARCHAR(MAX)
)
CREATE TABLE HOADON
(
	MaHD INT IDENTITY PRIMARY KEY,
	NgayLap DATE DEFAULT GETDATE(),
	NgayGiao DATE,
	DiaChiGiao NVARCHAR(MAX),
	MaKH INT FOREIGN KEY (MaKH) REFERENCES KHACHHANG(MaKH),
	TrangThai BIT DEFAULT 1,
	TongTien INT,
	TongSP INT DEFAULT 1
)
CREATE TABLE CTHD
(
	MaHD INT FOREIGN KEY (MaHD) REFERENCES HOADON(MaHD),
	MaSP INT FOREIGN KEY (MaSP) REFERENCES SANPHAM(MaSP),
	DonGia INT,
	SoLuong INT DEFAULT 1,
	PRIMARY KEY(MaHD, MaSP)
)

--- NHẬP LIỆU ---
INSERT INTO NHANVIEN VALUES('admin','202cb962ac59075b964b07152d234b70',N'Admin',1)
INSERT INTO NHANVIEN VALUES('phuonguyen','202cb962ac59075b964b07152d234b70',N'Phương Uyên',1)
INSERT INTO NHANVIEN VALUES('koco','202cb962ac59075b964b07152d234b70',N'Không có',0)

INSERT INTO LOAISP VALUES(N'Trang điểm','dm3.png')
INSERT INTO LOAISP VALUES(N'Dưỡng da','dm2.png')
INSERT INTO LOAISP VALUES(N'Dưỡng thể','dm4.png')
INSERT INTO LOAISP VALUES(N'Thực phẩm','dm1.png')

INSERT INTO KHACHHANG VALUES(N'Xuân Nhật','xuannhat2352@gmail.com','123','0961122501',N'72 Dương Đức Hiền')
INSERT INTO KHACHHANG VALUES(N'Phương Anh','phuonganh@gmail.com','123','0916272248',N'817 Lạc Long Quân')

INSERT INTO SANPHAM VALUES(N'Son môi MERZY',120,99000,80000,1,'sp1.jpg',1,N'Cùng Lam Thảo đón đầu xu hướng với sự quay lại mới toanh của Son Kem Lì Merzy Velvet Tint Season 3 sớm nhất Việt Nam, với toàn những tông màu hot trend nhất hiện nay sẵn sàng đốn tim các tình yêu từ cái nhìn đầu tiên<br/>
Zoom thật kĩ từng màu cùng Lam Thảo với Merzy Velvet Tint Season 3, toàn những tông màu son hot trend nhất dễ dùng nhất hiện nay, giúp đôi môi nàng trở nên tươi tắn trẻ trung nhưng không kém phần quyến rũ đâu nha.<br/>Để có thể mạnh tay sở hữu em ấy đầu tiên thì như đã khẳng định bên trên, sự quay trở lại lần này của Merzy Velvet Tint Season 3 toàn những màu đỉnh cao hợp với mọi làn da của các bạn, giờ thì Lam Thảo sẽ "phân tích" từng em màu của em ấy nha.<br/>
V13. Ambition: Cam nude trendy cuốn hút<br/>
V14. Passion: Hồng đất MLBB tự nhiên trẻ trung<br/>
V15. Challenge: Cam ánh nâu ấm áp mềm mại<br/>
V16. Independence: Đỏ Chili classic thời thượng<br/>
V17. Confidence: Đỏ gạch mạnh mẽ quyến rũ<br/>
V18. Diversity : Nâu đất Chocolate cá tính thu hút',N'Thỏi')
INSERT INTO SANPHAM VALUES(N'Mặt Nạ Giấy Thải Độc Giúp Da Hấp Thụ Derm All Matrix Epidermal Detoxifying Mask',150,95000,60000,1,'sp02.jpg',2,N'Derm-all Matrix là thương hiệu nổi tiếng trong làng skincare với dòng mặt nạ collagen thần thánh, gần đây Derm-all Matrix cho ra mắt thêm dòng Epidermal Detoxifying Mask giúp loại bỏ các chất độc hại từ lớp biểu bì để thúc đẩy quá trình dưỡng ẩm cho da và cung cấp độ ẩm vào sâu bên trong da.<br/>Hướng dẫn sử dụng Mặt Nạ Thải Độc Giúp Da Hấp Thụ Derm All Matrix Epidermal Detoxifying Mask<br/>
Dòng mặt nạ này có thiết kế khá độc đáo, phần mặt nạ giấy và tinh chất được chia thành 2 phần riêng biệt, giúp duy trì chất lượng của mặt nạ trước khi sử dụng.<br/>
Bước 1: Sau khi rửa mặt sạch, bạn dùng hai tay xoa mạnh phần giữa của túi 5 đến 10 lần rồi để tinh chất di chuyển về phía tấm khăn.<br/>
Bước 2: Chờ 1 đến 2 phút để tấm hấp thụ tinh chất tốt và chuyển sang dạng gel.<br/>
Bước 3: Đắp mặt nạ lên mặt và tháo tấm lưới đỡ.<br/>
Bước 4: Lấy mặt nạ ra sau 15 phút, massage nhẹ nhàng để dưỡng chất thẩm thấu vào da.<br/>
Bước 5: Sau khi rửa sạch da bằng nước ấm, thoa toner lên da và dưỡng ẩm với mặt nạ Derm All Matrix Facial Dermal Care Mask.<br/>
Sau khi loại bỏ các chất bẩn gây hại trên da với Mặt Nạ Thải Độc Giúp Da Hấp Thụ Derm All Matrix Epidermal Detoxifying Mask, làn da của bạn được thông thoáng và có thể hấp thụ các dưỡng chất nhanh chóng và hiệu quả hơn. Vì thế, khi bạn tiếp tục sử dụng Mặt Nạ Dưỡng Da Derm All Matrix Facial Dermal Care Mask trong khi ngủ, hàng rào bảo vệ da sẽ được tăng cường hơn nhiều lần.<br/>
Để mang lại hiệu quả dưỡng da tốt nhất, mỗi tuần bạn nên dùng mặt nạ Facial Dermal Care Mask 3 lần và Epidermal Detoxifying Mask 1 lần trong vòng 8 tuần liên tục. Bạn sẽ cảm nhận được sự khác biệt trên làn da của mình.',N'Cái')
 INSERT INTO SANPHAM VALUES(N'Son môi ROMAND',140,)

--- CÂU LỆNH ---
SELECT * FROM NHANVIEN
SELECT * FROM KHACHHANG
SELECT * FROM SANPHAM
SELECT * FROM LOAISP
SELECT * FROM HOADON
SELECT * FROM CTHD
