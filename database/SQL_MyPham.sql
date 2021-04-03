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

INSERT INTO KHACHHANG VALUES(N'Xuân Nhật','xuannhat2352@gmail.com','202cb962ac59075b964b07152d234b70','0961122501',N'72 Dương Đức Hiền')
INSERT INTO KHACHHANG VALUES(N'Phương Anh','phuonganh@gmail.com','202cb962ac59075b964b07152d234b70','0916272248',N'817 Lạc Long Quân')

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
-- Dưỡng da
INSERT INTO SANPHAM VALUES(N'Sáp Dưỡng Mềm Môi Vaseline Lip Therapy',100,50000,65000,1,'sp11.jpg',2,N'Được làm từ 100% pure petroleum jelly tức mỡ khoáng tinh khiết đã được thanh lọc, Vaseline Lip Therapy an toàn trên mọi làn da, có tác dụng làm mềm môi tức thì, ngay cả với môi đang bong tróc, nứt nẻ. 
Bạn có thể sử dụng em nó làm son dưỡng, hoặc bôi dày hơn để làm sleeping mask cho môi vẫn được. Sử dụng thường xuyên cùng tẩy tế bào chết cho môi định kỳ để đạt hiệu quả tốt hơn nhé!',N'Hủ')
INSERT INTO SANPHAM VALUES(N'Kem Dưỡng Cấp Ẩm Giúp Da Căng Mướt Dr.hometox Moisture Multi Cream',120,160000,195000,1,'sp12.jpg',2,N'Kem dưỡng cấp ẩm giúp da căng mướt Dr.hometox Moisture Multi Cream với công nghệ giữ ẩm và cấp ẩm hiện đại có thể đạt mức độ giữ ẩm đến hơn 6.000 lần so với các dòng kem dưỡng thông thường giúp làn da bạn luôn ở tình trạng đủ độ ẩm, tránh tình trạng khô và nứt nẻ trên da.',N'Cái')
INSERT INTO SANPHAM VALUES(N'Kem Dưỡng Ngừa Mụn Làm Dịu Da Gaston Cica Solution Balancing Cream',50,250000,400000,1,'sp13.jpg',2,N'Kem Dưỡng Gaston Cica Solution Balancing Cream còn là dưỡng chất vừa giúp cải thiện tình trạng da mụn và lỗ chân lông to; nhưng cũng đồng thời hỗ trợ cải thiện làn da sau mụn bằng cách cung cấp các dưỡng chất thẩm thấu vào sâu bên trong da; làm dịu tức thời mà không mang lại cảm giác bết rít cho da.',N'Cái')
-- Dưỡng thể
INSERT INTO SANPHAM VALUES(N'Tẩy Da Chết Toàn Thân Organic Shop Sugar Body Scrub',200,100000,160000,1,'sp14.jpg',3,N'Tẩy Da Chết Toàn Thân Organic Shop Coffee Sugar Body Scrub (Phiên Bản Châu Âu) là một dòng sản phẩm tẩy da chết hóa học thuộc thương hiệu nổi tiếng Organic Shop, với thành phần là các dưỡng chất cần thiết, vừa hỗ trợ tẩy tế bào chết cho da, vừa có khả năng dưỡng ẩm cho da.',N'Hủ')
INSERT INTO SANPHAM VALUES(N'Tinh Chất Dưỡng Và Phục Hồi Tóc Miseen Perfect Serum Original',100,120000,170000,1,'sp15.jpg',3,N'Tinh Chất Dưỡng Và Phục Hồi Tóc Miseen Perfect Serum Original (Mẫu Mới 2020) với mùi thơm nhẹ nhàng, dễ chịu giống như hương hoa hồng và mật ong, giúp chăm sóc tóc dễ gãy rụng trở nên mềm mại và rạng ngời.',N'Chai')
INSERT INTO SANPHAM VALUES(N'Dầu Gội Khô Girlz Only Dry Shampoo',100,50000,100000,1,'sp16.jpg',3,N'Dầu gội khô là một trong số những mỹ phẩm chăm sóc tóc cực kỳ tiện lợi cho những ai bận rộn, muốn làm sạch tóc nhanh gọn và tiết kiệm thời gian. Hiện nay, trên thị trường có không ít các loại dầu gội khô với nhiều mức giá khác nhau. Nhưng để đánh giá về chất lượng, có lẽ nên lựa chọn Dầu gội khô Girlz Only Dry Shampoo bạn nhé. Sản phẩm không chỉ làm sạch tóc một cách nhanh chóng, tiết kiệm thời gian mà còn giúp mái tóc thêm chắc khỏe hơn nhờ công thức sản xuất cực kỳ hiện đại, nhanh chóng hấp thụ bã nhờn trên tóc.',N'Chai')
INSERT INTO SANPHAM VALUES(N'Sơn Móng Tay 3CE Layering Nail Lacquer',200,150000,195000,1,'sp17.jpg',3,N'Sơn Móng Tay 3CE Layering Nail Lacquer với chất sơn mịn mượt và khô cực nhanh, khi apply sẽ cho cảm giác nước sơn đang lướt trên móng, thành phần chứa tinh chất nuôi dưỡng móng tay nên dù bạn có sơn chồng 2-3 lớp thì móng cũng vẫn luôn trong tình trạng khỏe khoắn, không gây ra hiện tượng vàng móng.',N'Bộ')
INSERT INTO SANPHAM VALUES(N'Nước Hoa Dạng Sáp Shi Mang Perfume',200,10000,30000,1,'sp18.jpg',3,N'Nước Hoa Dạng Sáp Shi Mang Perfume vừa tiện dụng, nhỏ xinh, hương bám lâu, đem lại sự khác biệt cho bạn, tôn nên nét cá tính của mỗi người, đặc biệt hương thơm có 10 mùi hương từ nhẹ nhàng, ngọt ngào đến cá tính cho các bạn lựa chọn.',N'Cái')
INSERT INTO SANPHAM VALUES(N'Xà Phòng Trị Thâm Vùng Nách Pelican',100,100000,180000,1,'sp19.jpg',3,N'Xà phòng trị thâm nách Pelican đem đến cho bạn gái làn da dưới cánh tay luôn sáng mịn, tự tin diện đồ theo đúng phong cách.',N'Cái')
-- Trang điểm
INSERT INTO SANPHAM VALUES(N'Son Kem Black Rouge Airfit Velvet Ver 5',200,50000,140000,1,'sp20.jpg',1,N'"BAM" còn có nghĩa là "Beauty and Midnight", những đôi môi quyến rũ với sắc son của Black Rouge Air Fit Velvet Tint Version 5 trong màn đêm - đây là BST mới nhất của nhà Black Rouge, đang khuấy đảo giới làm đẹp.',N'Thỏi')
INSERT INTO SANPHAM VALUES(N'Kem Lót Catrice Goodbye Pores',200,100000,150000,1,'sp21.jpg',1,N'Kem Lót Catrice Prime And Fine Poreless Blur Primer Goodbye Pores làm cho da mịn đẹp và đều màu, sáng hồng rạng rỡ. Thậm chí chỉ cần dùng một lớp kem lót cũng khiến da mặt mịn đẹp, sáng hồng mà không cần trang điểm thêm nhiều.',N'Cái')
INSERT INTO SANPHAM VALUES(N'Phấn Phủ Nén Kiềm Dầu Innisfree No Sebum Mineral Pact 8.5g',120,150000,240000,1,'sp22.jpg',1,N'Phấn Nén Kiềm Dầu Innisfree No Sebum Mineral Pact là loại phấn khoáng dạng bột, chiết xuất 100% từ bạc hà và hạt ngọc trai, có khả năng hút dầu rất tốt. Thành phần 100% thiên nhiên không chứa các chất độc hại cho da, không gây kích ứng hay dị ứng da, phù hợp với cả loại da mẫn cảm với các loại mỹ phẩm trang điểm.',N'Hủ')
INSERT INTO SANPHAM VALUES(N'Kẻ Mắt Nước Chống Trôi Black Rouge All Day Power Proof Pen Liner',150,100000,140000,1,'sp23.jpg',1,N'Black Rouge đã tung ra bộ sưu tập mùa hè với chủ đề Pool Party mà bạn không thể bỏ lỡ - Kẻ Mắt Black Rouge All day Power Proof Pen Liner với tông màu chủ đạo living coral hot nhất hiện nay, chống trôi suốt ngày dài.',N'Cây')
INSERT INTO SANPHAM VALUES(N'Phấn Nước Missha Velvet Finish Cushion SPF50+ PA+++',160,200000,260000,1,'sp24.jpg',1,N'Phấn Nước Missha Velvet Finish Cushion SPF50+ PA+++ có kết cấu mỏng mịn tự nhiên, khi apply sẽ tiệp hẳn vào da cho hiệu ứng mịn màng, không gây bết dính khó chịu cũng như gây ra hiện tượng bóng dầu. Độ che phủ cực cao, dễ dàng che đi những khuyết điểm, kể cả vùng da mụn, những vùng có lỗ chân lông to.',N'Cái')
INSERT INTO SANPHAM VALUES(N'Kem Che Khuyết Điểm Innisfree My Concealer Spot Cover',170,150000,210000,1,'sp25.jpg',1,N'Kem che khuyết điểm Innisfree My Concealer Spot Cover có thể che các khuyết điểm "rắc rối" nhất trên khuôn mặt như mụn thâm, mụn sưng đỏ, quầng thâm mắt, những vết sẹo, mụn lồi, các đốm đỏ, ...Với kết cấu dạng kem khá mịn, rất dễ tán, tạo độ mướt cho da, độ che phủ tốt an toàn với cả da nhạy cảm.',N'Cái')
INSERT INTO SANPHAM VALUES(N'Phấn Má Lâu Trôi Sivanna Colors So Chic Long-Lasting',100,50000,100000,1,'sp26.jpg',1,N'Với những cô nàng thường xuyên makeup, chắc chắn sẽ không thể thiếu một hộp phấn má, giúp cho nàng tự tin hơn với khuôn mặt của mình. Phấn Má Lâu Trôi Sivanna Colors So Chic Long-Lasting sẽ là một trong những lựa chọn phù hợp giúp cho gò má của bạn được xinh xắn hơn. Cùng tìm hiểu thêm những thông tin quan trọng về sản phẩm này, để quyết định lựa chọn và sử dụng được yên tâm hơn.',N'Cái')



--- CÂU LỆNH ---
SELECT * FROM NHANVIEN
SELECT * FROM KHACHHANG
SELECT * FROM SANPHAM
SELECT * FROM LOAISP
SELECT * FROM HOADON
SELECT * FROM CTHD
