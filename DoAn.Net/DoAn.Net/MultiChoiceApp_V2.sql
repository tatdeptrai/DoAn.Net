CREATE DATABASE QL_THITRACNGHIEM3
GO
USE QL_THITRACNGHIEM3
GO
CREATE TABLE VaiTro
(
	MaVaiTro char(10) NOT NULL,
	TenVaiTro nvarchar(150) NOT NULL,
	CONSTRAINT PK_VaiTro PRIMARY KEY (MaVaiTro)
)
GO
CREATE TABLE NguoiDung
(
	MaNguoiDung int IDENTITY NOT NULL,
	Ho nvarchar(250) NOT NULL,
	Ten nvarchar(150) NOT NULL,
	Username varchar(150) NOT NULL,
	MatKhau varchar(150) NOT NULL,
	Email varchar(150) NOT NULL,
	MaVaiTro char(10),
	CONSTRAINT PK_NguoiDung PRIMARY KEY (MaNguoiDung),
	CONSTRAINT FK_Nguoidung_Vaitro FOREIGN KEY (MaVaiTro) REFERENCES VaiTro(MaVaiTro) 
)
GO
CREATE TABLE MonHoc
(
	MaMonHoc char(10) NOT NULL,
	TenMonHoc nvarchar(150) NOT NULL,
	CONSTRAINT PK_MonHoc PRIMARY KEY (MaMonHoc),
	CONSTRAINT UNI_MonHoc UNIQUE (TenMonHoc)
)
GO
CREATE TABLE CauHoi
(
	MaCauHoi char(10) NOT NULL,
	NoiDungVanBan nvarchar(MAX) NOT NULL,
	MucDo nvarchar(150) NOT NULL,
	MaMonHoc char(10),
	CONSTRAINT PK_CauHoi PRIMARY KEY (MaCauHoi),
	CONSTRAINT FK_CauHoi_MonHoc FOREIGN KEY (MaMonHoc) REFERENCES MonHoc(MaMonHoc) 
	ON DELETE CASCADE ON UPDATE CASCADE
)
GO
CREATE TABLE LuaChon
(
    MaLuaChon char(10) NOT NULL,
    MaCauHoi char(10),
    DapAnA nvarchar(MAX),
    DapAnB nvarchar(MAX),
    DapAnC nvarchar(MAX),
    DapAnD nvarchar(MAX),
    DapAnDung char(2) NOT NULL,
    CONSTRAINT PK_LuaChon PRIMARY KEY (MaLuaChon),
    CONSTRAINT FK_LuaChon_CauHoi FOREIGN KEY (MaCauHoi) REFERENCES CauHoi(MaCauHoi)
    ON DELETE CASCADE ON UPDATE CASCADE
)

--function lựa chọn 
--function lambaithi

CREATE TABLE DeThi
(
	MaDeThi char(10) NOT NULL,
	TenDeThi nvarchar(150) NOT NULL,
	MucDo nvarchar(150) NOT NULL,
	ThoiGianLamBai int NOT NULL,
	NgayTao datetime NOT NULL,
	MaMonHoc char(10),
	CONSTRAINT PK_DeThi PRIMARY KEY (MaDeThi),
	CONSTRAINT FK_DeThi_MonHoc FOREIGN KEY (MaMonHoc) REFERENCES MonHoc(MaMonHoc) ON DELETE CASCADE ON UPDATE CASCADE
)
GO
CREATE TABLE ChiTietDeThi
(
	MaDeThi char(10) NOT NULL,
	MaCauHoi char(10) NOT NULL,
	CONSTRAINT PK_ChiTietDeThi PRIMARY KEY (MaDeThi, MaCauHoi),
	CONSTRAINT FK_ChiTietDeThi_DeThi FOREIGN KEY (MaDeThi) REFERENCES DeThi(MaDeThi),
	CONSTRAINT FK_ChiTietDeThi_CauHoi FOREIGN KEY (MaCauHoi) REFERENCES CauHoi(MaCauHoi)
) 
GO
CREATE TABLE KetQua
(
	MaNguoiDung int NOT NULL,
	MaDeThi char(10) NOT NULL,
	LanThi int NOT NULL,
	Diem decimal(18, 2),
	ThoiGianBatDau datetime,
	ThoiGianKetThuc datetime,
	CONSTRAINT PK_KetQua PRIMARY KEY (MaNguoiDung, MaDeThi, LanThi),
	CONSTRAINT FK_KetQua_NguoiDung FOREIGN KEY (MaNguoiDung) REFERENCES NguoiDung(MaNguoiDung),
	CONSTRAINT FK_KetQua_DeThi FOREIGN KEY (MaDeThi) REFERENCES DeThi(MaDeThi)
)
GO

CREATE TABLE DapAnCuaNguoiDung
(
	MaDA int IDENTITY NOT NULL,
	MaNguoiDung int,
	MaDeThi char(10),
	LanThi int,
	MaCauHoi char(10),
	DapAnSV char(2),
	CONSTRAINT PK_DapAnCuaNguoiDung PRIMARY KEY (MaDA),
	CONSTRAINT FK_DapAnCuaNguoiDung_KetQua FOREIGN KEY (MaNguoiDung, MaDeThi, LanThi) REFERENCES KetQua(MaNguoiDung, MaDeThi, LanThi),
	CONSTRAINT FK_DapAnCuaNguoiDung_CauHoi FOREIGN KEY (MaCauHoi) REFERENCES CauHoi(MaCauHoi)
)
GO
INSERT INTO VaiTro VALUES ('AD', N'Quản trị viên (Admin)')
INSERT INTO VaiTro VALUES ('SV', N'Sinh viên') 
GO
INSERT INTO MonHoc VALUES ('MH001', N'Lập Trình OOP')
INSERT INTO MonHoc VALUES ('MH002', N'Mạng Máy Tính')
INSERT INTO MonHoc VALUES ('MH003', N'Kiến Trúc Máy Tính')
INSERT INTO MonHoc VALUES ('MH004', N'Hệ Điều Hành')

GO
SELECT * FROM MonHoc ORDER BY MaMonHoc
GO
INSERT INTO DeThi VALUES ('DT001', N'Đề 01 (Lập Trình OOP)', N'Dễ', '30', '2023-11-09', 'MH001')
INSERT INTO DeThi VALUES ('DT002', N'Đề 02 (Lập Trình OOP)', N'Trung Bình', '60', '2023-11-09', 'MH001')
INSERT INTO DeThi VALUES ('DT003', N'Đề 03 (Lập Trình OOP)', N'Trung Bình', '60', '2023-11-09', 'MH001')
INSERT INTO DeThi VALUES ('DT004', N'Đề 04 (Lập Trình OOP)', N'Khó', '75', '2023-11-09', 'MH001')
INSERT INTO DeThi VALUES ('DT005', N'Đề 01 (Mạng Máy Tính)', N'Dễ', '30', '2023-11-09', 'MH002')
INSERT INTO DeThi VALUES ('DT006', N'Đề 02 (Mạng Máy Tính)', N'Trung Bình', '60', '2023-11-09', 'MH002')
INSERT INTO DeThi VALUES ('DT007', N'Đề 03 (Mạng Máy Tính)', N'Trung Bình', '60', '2023-11-09', 'MH002')
INSERT INTO DeThi VALUES ('DT008', N'Đề 04 (Mạng Máy Tính)', N'Khó', '75', '2023-11-09', 'MH002')
INSERT INTO DeThi VALUES ('DT009', N'Đề 01 (Kiến Trúc Máy Tính)', N'Dễ', '30', '2023-11-09', 'MH003')
INSERT INTO DeThi VALUES ('DT010', N'Đề 02 (Kiến Trúc Máy Tính)', N'Trung Bình', '60', '2023-11-09', 'MH003')
INSERT INTO DeThi VALUES ('DT011', N'Đề 03 (Kiến Trúc Máy Tính)', N'Trung Bình', '60', '2023-11-09', 'MH003')
INSERT INTO DeThi VALUES ('DT012', N'Đề 04 (Kiến Trúc Máy Tính)', N'Khó', '75', '2023-11-09', 'MH003')
INSERT INTO DeThi VALUES ('DT013', N'Đề 01 (Hệ Điều Hành)', N'Dễ', '30', '2023-11-09', 'MH004')
INSERT INTO DeThi VALUES ('DT014', N'Đề 02 (Hệ Điều Hành)', N'Trung Bình', '60', '2023-11-09', 'MH004')
INSERT INTO DeThi VALUES ('DT015', N'Đề 03 (Hệ Điều Hành)', N'Trung Bình', '60', '2023-11-09', 'MH004')
INSERT INTO DeThi VALUES ('DT016', N'Đề 04 (Hệ Điều Hành)', N'Khó', '75', '2023-11-09', 'MH004')
select * from dethi
GO
CREATE FUNCTION GetQuestionsAndOptions(@MaMonHoc char(10), @MaDeThi char(10))
RETURNS TABLE
AS
RETURN
(
    SELECT 
        ROW_NUMBER() OVER (ORDER BY CH.MaCauHoi) AS STT,
        CH.NoiDungVanBan,
        LC.DapAnA,
        LC.DapAnB,
        LC.DapAnC,
        LC.DapAnD,
        LC.DapAnDung,
		LC.MaCauHoi
		
    FROM CauHoi CH
    INNER JOIN LuaChon LC ON CH.MaCauHoi = LC.MaCauHoi
    INNER JOIN ChiTietDeThi CTD ON CH.MaCauHoi = CTD.MaCauHoi
    WHERE CH.MaMonHoc = @MaMonHoc
    AND CTD.MaDeThi = @MaDeThi
);
GO
select * from dbo.GetQuestionsAndOptions('MH001','DT001')
select * from ChiTietDeThi join CauHoi on ChiTietDeThi.MaCauHoi = CauHoi.MaCauHoi
GO
CREATE PROC sp_ThemCauHoi @maCauHoi char(10), @noiDungVanBan nvarchar(MAX), @mucDo nvarchar(150), @maMonHoc char(10)
AS
BEGIN
	INSERT INTO CauHoi VALUES (@maCauHoi, @noiDungVanBan, @mucDo, @maMonHoc);
END;

GO

CREATE PROC sp_ThemLuaChon @maLuaChon char(10), @maCauHoi char(10), @dapAnA nvarchar(MAX), 
						   @dapAnB nvarchar(MAX), @dapAnC nvarchar(MAX), @dapAnD nvarchar(MAX), @dapAnDung char(2)
AS
BEGIN
	INSERT INTO LuaChon VALUES (@maLuaChon, @maCauHoi, @dapAnA, @dapAnB, @dapAnC, @dapAnD, @dapAnDung)
END;

GO
-- OOP
EXEC sp_ThemCauHoi 'CH001', N'Lập trình hướng đối tượng là:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH002', N'Đặc điểm cơ bản của lập trình hướng đối tượng thể hiện ở:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH003', N'OOP là viết tắt của:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH004', N'Hãy chọn câu trả lời đúng:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH005', N'Chọn câu sai:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH006', N'Tính đóng gói là:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH007', N'Tính kế thừa:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH008', N'Sự đóng gói:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH009', N'Sự trừu tượng:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH010', N'Sự kế thừa:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH011', N'Tính đa hình:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH012', N'Trong lớp kế thừa. Lớp con có thuật ngữ tiếng Anh là:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH013', N'Trong lớp kế thừa. Lớp cha có thuật ngữ tiếng Anh là: ', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH014', N'Lớp đối tượng là:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH015', N'Sau khi khai báo và xây dựng thành công lớp đối tượng Sinh viên. Khi đó đối tượng Sinh viên còn được gọi là:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH016', N'Muốn lập trình hướng đối tượng , bạn cần phải phân tích chương trình, bài toán thành các:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH017', N'Trong các phương án sau, phương án mô tả tính đa hình là:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH018', N'Phương pháp lập trình tuần tự là:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH019', N'Khi khai báo và xây dựng thành công lớp đối tượng , để truy cập vào thành phần của lớp ta phải:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH020', N'Trừu tượng hóa là:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH021', N'Đối tượng là:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH022', N'Khi khai báo và xây dựng một lớp ta cần phải các định rõ thành phần:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH023', N'Chọn câu đúng:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH024', N'Khi khai báo lớp trong các ngôn ngữ lập trình hướng đối tượng phải sử dụng từ khóa:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH025', N'Thành phần private của lớp là thành phần:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH026', N'Thành phần protected của lớp là thành phần:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH027', N'Thành phần public của lớp là thành phần:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH028', N'Hàm thành viên ( phương thức ) của lớp:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH029', N'Trong một chương trình có thể xây dựng tối đa bao nhiêu lớp:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH030', N'Hàm thành viên của lớp khác hàm thông thường là:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH031', N'Thuộc tính của lớp là:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH032', N'Phương thức là gì:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH033', N'Người ta cần quản lí thông tin sinh viên trên máy tính , hãy cho biết các thuộc tính của lớp sinh viên:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH034', N'Cho lớp Điểm trong hệ tọa độ Oxy. Các phương thức có thể có của lớp Điểm là:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH035', N'Lập trình hướng đối tượng:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH036', N'Lời gọi tới hàm thành viên của lớp là:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH037', N'Khi khai báo thành phần thuộc tính và phương thức của lớp , nếu không khai báo từ khóa private, public, hay protected thì mặc định sẽ là:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH038', N'Trong lập trình hướng đối tượng khả năng các hàm có thể trùng tên nhau gọi là gì:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH039', N'Hàm tạo trong ngôn ngữ C#:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH040', N'Hàm hủy trong ngôn ngữ C# có cú pháp:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH041', N'Hàm tạo là:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH042', N'Hàm hủy là:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH043', N'Lời gọi hàm tạo:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH044', N'Một người cần xây dựng lớp Thời gian (Timer) trong máy tính cần hiển thị thông tin như sau: giờ:phút :giây. Vậy các thuộc tính cần xây dựng cho lớp Timer là:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH045', N'Trong kế thừa, có thể:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH046', N'Lời gọi phương thức ảo:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH047', N'Hàm hủy có:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH048', N'Các dạng kế thừa là:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH049', N'Khi nạp chồng các hàm thì điều kiện khác nhau giữa các hàm sẽ là: ', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH050', N'Trong một lớp có thể:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH051', N'Trong một lớp có thể: ', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH052', N'Trong kế thừa có thể kế thừa tối đa:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH053', N'Trong đa kế thừa có thể kế thừa tối đa:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH054', N'Cho lớp A và lớp B , lớp A kế thừa lớp B trong hai lớp đều có phương thức Xuat. Nếu khai báo đối tượng obj thuộc lớp A khi gọi đến phương thức Xuat(obj.Xuat()) là gọi đến phương thức của lớp nào:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH055', N'Trong kế thừa nhiều mức có cho phép:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH056', N'Thành viên tĩnh của lớp là:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH057', N'Khi xây dựng nạp chồng các hàm thì điều kiện khác nhau giữa các hàm là : kiểu dữ liệu trả về của  hàm hoặc kiểu dữ liệu tham số truyền vào các hàm hoặc số lượng tham số khi truyền vào của hàm là khác nhau . Điều kiện này chỉ áp dụng khi:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH058', N'Khai báo phương thức ảo:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH059', N'Một lớp có thể tối đa:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH060', N'Cách khai báo kế thừa trong C# sử dụng từ khóa:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH061', N'Cho lớp tam giác tạo bởi ba điểm A, B , C .  Quan hệ giữa lớp tam giác và lớp điểm:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH062', N'cho lớp đường thẳng tạo bởi 2 điểm A, B . Quan hệ giữa lớp đường thăng và lớp điểm là:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH063', N'Cần xây dựng lớp đường thẳng y = ax + b . Thuộc tính của lớp đường thẳng này được xác định là:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH064', N'Để quản lý các phương tiện giao thông đường bộ người ta xây dựng hệ thống các lớp đối tượng gồm : lớp xe đạp, lớp xe máy , lớp ô tô con , lớp xe tải . Sau quá trình phân tích nhận thấy rằng các lớp đối tượng trên cùng có các đặc điểm như sau : Tải_trọng , loại_động_cơ , Biển số và đều di chuyển từ điểm a đến điểm b . Người ta xây dựng lớp PT_Giao_Thông làm :', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH065', N'Để quản lý các phương tiện giao thông đường bộ người ta xây dựng hệ thống các lớp đối tượng gồm : lớp xe đạp, lớp xe máy , lớp ô tô con , lớp xe tải . Sau quá trình phân tích nhận thấy rằng các lớp đối tượng trên cùng có các đặc điểm như sau : Tải_trọng , loại_động_cơ , Biển số và đều di chuyển từ điểm a đến điểm b . Người ta xây dựng lớp PT_Giao_Thông làm lớp cơ sở cho các đối tượng trên và lớp này gồm các thuộc tính là:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH066', N'Để quản lý các phương tiện giao thông đường bộ người ta xây dựng hệ thống các lớp đối tượng gồm : lớp xe đạp, lớp xe máy , lớp ô tô con , lớp xe tải . Sau quá trình phân tích nhận thấy rằng các lớp đối tượng trên cùng có các đặc điểm như sau : Tải_trọng , loại_động_cơ , Biển số và đều di chuyển từ điểm a đến điểm b . Người ta xây dựng lớp PT_Giao_Thông làm lớp cơ sở cho các đối tượng trên và lớp này gồm các phương thức là: :', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH067', N'Khi đưa các lớp thực thể vào quản lí trong máy tính ta nhận thấy mỗi đối tượng thực thể có vô số thuộc tính nhưng với mỗi bài toán cụ thể ta chỉ xác định các lớp chỉ gồm một số thuộc tính nhất định . cách thức đó gọi là:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH068', N'Vào mỗi kỳ thi người ta cần lập ra danh sách thí sinh dự thi dựa theo danh sách sinh viên đủ điều kiện dự thi của mỗi môn học , để thuận tiện xử lí người ta xây dựng lớp Thí sinh dựa trên lớp sinh viên với đk là đủ đk dự thi các môn học . Mối quan hệ giữa các lớp Sinh viên với thí sinh là:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH069', N'Xây dựng lớp điểm trong hệ tọa độ Oxyz các thuộc tính của lớp:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH070', N'Tính chất kế thừa chỉ ra rằng khi lớp A kế thừa lớp B thì:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH071', N'Để đưa đối tượng trong thực tế vào máy tính ta cần chú trọng đến tính:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH072', N'Xem xét bài toán nhập vào danh sách sinh viên gồm n sinh viên với những thông tin: Họ và tên ,Ngày sinh, Giới tính, Địa chỉ, Lớp và hiển thị thông tin theo ngày sinh tăng dân . Các lớp đối tượng cần xây dựng cho cách bài toán gồm Lớp Sinh viên và lớp danh sách sinh viên . Các thuộc tính của lớp danh sách sinh viên là:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH073', N'Trong c#, ......không được cài đặt phần thân của:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH074', N'Hãy cho biết trong các ví dụ sau ví dụ nào có thể hiện sự kế thừa:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH075', N'Chọn phát biểu đúng trong các phát biểu sau:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH076', N'Cần in danh sách thí sinh dự thi theo phòng gồm các thông tin: SBD, Họ và tên, Ngày sinh , Giới tính , Phòng thi,  Giờ thi. Người ta xây dựng hai lớp đối tượng là lớp đối tượng Thí sinh và , lớp đối tượng Danh sách thí sinh theo phòng . Thuộc tính của lớp Danh sách thí sinh có thể là:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH077', N'Từ khóa nào sau đây được dùng khi lớp con muốn cài lại phương thức được thừa kế từ lớp cha :', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH078', N'Xử lí ngoại lệ được thực thi trong câu lệnh:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH079', N'Trong C#, ........không được cài đặt phần thân của:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH080', N'Chọn phương án tương ứng với phát biểu sai:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH081', N'Thông thường khi xây dựng lớp trong C#, với mỗi khai báo thuộc tính của lớp ta đều xây dựng thêm hai phương thức set và get dùng để:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH082', N'Cấu trúc thông thường của lớp trong C# là:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH083', N'khi khai báo các thành phần thuộc tính của lớp trong C#, đầu mỗi câu lệnh khai báo ta thường khai báo :', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH084', N'Xem xét bài toán nhập vào danh sách sinh viên gồm n sinh viên với những thông tin: Họ và tên ,Ngày sinh, Giới tính, Địa chỉ, Lớp và hiển thị thông tin theo ngày sinh tăng dân . Các lớp đối tượng cần xây dựng cho cách bài toán gồm:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH085', N'Cần in danh sách thí sinh dự thi theo phòng gồm các thông tin: SBD, Họ và tên, Ngày sinh , Giới tính , Phòng thi,  Giờ thi. Người ta xây dựng hai lớp đối tượng là lớp đối tượng Thí sinh và , lớp đối tượng Danh sách thí sinh theo phòng . Thuộc tính của lớp thí sinh có thể là:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH086', N'Xây dựng lớp Hinh_hoc là lớp cơ sở cho các lớp Hinh_Vuong, Hinh_tron, Hinh_cn, Hinh_tamgiac. Nhận thấy các lớp này đều có phương thức tính D_Tich( diẹn tích ). Tuy nhiên cách tính diện tích của các phương thức D_Tich ứng với các đối tượng của các lớp dẫn xuất là khác nhau . Điều này thể hiện tính:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH087', N'Để xóa đi một chuỗi con ta sử dụng phương thức nào:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH088', N'Khi khai báo , xây dựng lớp các phương thức thường được khai báo trong phạm vi public để:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH089', N'Phương thức (method) nào cho phép cắt bỏ khoảng trắng thừa hai bên chuỗi:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH090', N'Mối quan hệ giữa lớp Môn học và Lớp Sinh viên là:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH091', N'Khi khai báo , xây dựng lớp các thành phần được đặt trong phạm vi protected nhằm mục đích:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH092', N'Chọn phát biểu đúng trong các phát biểu sau:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH093', N'CLR là viết tắt của:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH094', N'Cần in danh sách thí sinh dự thi theo phòng gồm các thông tin: SBD, Họ và tên, Ngày sinh , Giới tính , Phòng thi,  Giờ thi. Người ta xây dựng hai lớp đối tượng là lớp đối tượng Thí sinh và , lớp đối tượng Danh sách thí sinh theo phòng . Phương thức cần thiết theo yêu cầu của bài toán cần phải xây dựng cho lớp thí sinh là:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH095', N'Câu lệnh nào dùng để khai báo thủ tục khởi tạo cho class điem :', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH096', N'Một biến được khai báo bên trong một phương thức được gọi là biến?:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH097', N'Anh chị hãy cho biết khi muốn bỏ chú thích cho 1 đoạn chương trình ta nhấn ?:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH098', N'Để chú thích trong C# ta dùng ?:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH099', N'Các Trường Đại học A, B, C đều in giấy báo nhập học cho sinh viên trúng tuyển. Tuy nhiên, giấy báo nhập học của các trường này có thể có cấu trúc, nội dung, hình thức khác nhau. Đây là ví dụ về:', N'Dễ', 'MH001';
EXEC sp_ThemCauHoi 'CH100', N'.net framework nằm ở tầng trên của hệ điều hành (bất kỳ hệ điều hành không chỉ là windows).net framework bao gồm :', N'Dễ', 'MH001';

-- ĐÁP ÁN OOP

EXEC sp_ThemLuaChon 'LC001','CH001', N'Lập trình hướng đối tượng là phương pháp lập trình cơ bản gần với mã máy.', N'Lập trình hướng đối tượng là phương pháp đặt trọng tâm vào các đối tượng , nó không cho phép dữ liệu đặt một cách tự do trong hệ thống ; dữ liệu đươc gói với các hàm thành phần', N'Lập trình hướng đối tượng là phương pháp mới của lập trình máy tính , chia chương trình thành các hàm ; quan tâm đến chức năng của hệ thống.', N'Lập trình hướng đối tượng là phương pháp đặt trọng tâm vào các chức năng , cấu trúc chương trình được xây dựng theo cách tiếp cận hướng chức năng.', 'B';
EXEC sp_ThemLuaChon 'LC002','CH002', N'Tính đóng gói , tính kế thừa , tính đa hình, tính đặc biệt hóa . ', N'Tính đóng gói , tính trừu tượng . ', N'Tính chia nhỏ , tính kế thừa.', N'Tính đóng gói , tính kế thừa , tính đa hình , tính trừu tượng.', 'D';
EXEC sp_ThemLuaChon 'LC003','CH003', N'Object Oriented Programming.', N'Object Oriented Proccessing.', N'Open Object Programming.', N'Object Open Programming.', 'A';
EXEC sp_ThemLuaChon 'LC004','CH004', N'Ngôn ngữ lập trình C, C++, C# là ngôn ngữ lập trình cấu trúc.', N'Ngôn ngữ lập trình C# , C++ là ngôn ngữ lập trình hướng đối tượng .', N'Ngôn ngữ lập trình pascal, C là ngôn ngữ lập trình cấu trúc.', N'Ngôn ngữ lập trình C++, Java là ngôn ngữ lập trình cấu trúc.', 'C';
EXEC sp_ThemLuaChon 'LC005','CH005', N'C++ là ngôn ngữ lập trình cấu trúc.', N'Ngôn ngữ C++ , Java là ngôn ngữ lập trình hướng đối tượng .', N'Ngôn ngữ Pascal là ngôn ngữ lập trình hướng đối tượng.', N'C, Pascal là ngôn ngữ lập trình cấu trúc.', 'C';
EXEC sp_ThemLuaChon 'LC006','CH006', N'Cơ chế chia chương trình thành các hàm và thủ tục thực hiện các chức năng riêng rẽ .', N'Cơ chế cho thấy một hàm có thể có nhiều thể hiện khác nhau ở từng thời điểm .', N'Cơ chế ràng buộc dữ liệu và thao tác trên dữ liệu đó thành một thể thống nhất , tránh được các tác động bất ngờ từ bên ngoài . Thể thống nhất này gọi là đối tượng .', N'Cơ chế không cho phép các thành phần khác truy cập đến bên trong nó.', 'C';
EXEC sp_ThemLuaChon 'LC007','CH007', N'Khả năng sử dụng lại các hàm đã xây dựng.', N'Khả năng xây dựng các lớp mới từ các lớp cũ , lớp mới được gọi là lớp dẫn xuất , lớp cũ được gọi là lớp cơ sở.', N'Khả năng sử dụng lại các kiểu dữ liệu đã xây dựng .', N'Tất cả đều đúng.', 'B';
EXEC sp_ThemLuaChon 'LC008','CH008', N'Polymorphism.', N'Abstraction', N'Encapsulation.', N'Inheritance.', 'C';
EXEC sp_ThemLuaChon 'LC009','CH009', N'Encapsulation.', N'Polymorphism.', N'Inheritance.', N'Abstraction.', 'D';
EXEC sp_ThemLuaChon 'LC010','CH010', N'Abstraction.', N'Encapsulation.', N'Polymorphism.', N'Inheritance.', 'D';
EXEC sp_ThemLuaChon 'LC011','CH011', N'Inheritance.', N'Abstraction.', N'Polymorphism. ', N'Encapsulation.', 'C';
EXEC sp_ThemLuaChon 'LC012','CH012', N'Inheritance Class.', N'Object Class.', N'Derived Class.', N'Base Class.', 'C';
EXEC sp_ThemLuaChon 'LC013','CH013', N'Base Class .', N'Derived Class.', N'Object Class.', N'Inheritance Class.', 'A';
EXEC sp_ThemLuaChon 'LC014','CH014', N'Một thể hiện cụ thể cho các đối tượng .', N'Tập các phần tử cùng loại.', N'Tập các giá trị cũng loại.', N'Một thiết kế hay mẫu cho các đối tượng cũng kiểu .', 'D';
EXEC sp_ThemLuaChon 'LC015','CH015', N'Kiểu dữ liệu cơ bản.', N'Lớp đối tượng cơ sở.', N'Kiểu dữ liệu trừu tượng.', N'Đối tượng.', 'C';
EXEC sp_ThemLuaChon 'LC016','CH016', N'Các module', N'Hàm , thủ tục', N'Các thông điệp.', N'Các đối tượng từ đó xây dựng các lớp đối tượng tương ứng.', 'D';
EXEC sp_ThemLuaChon 'LC017','CH017 ', N'Lớp Điểm, Hình tròn cùng có hàm tạo , hàm hủy.', N'Lớp Hình vuông kế thừa lớp Hình chữ nhật.', N'Lớp hình tròn kế thừa lớp điểm .', N'Các lớp Điểm, hình tròn , Hình vuông, hình chữ nhật... đều có phương thức Vẽ.', 'D';
EXEC sp_ThemLuaChon 'LC018','CH018', N'Phương pháp lập trình với cách liệt kê các lệnh tiếp theo.', N'Phương pháp xây dựng chương trình ứng dụng theo quan điểm dựa trên các cấu trúc dữ liệu trừu tượng, các thể hiện cụ thể của cấu trúc và quan hệ giữa chúng .', N'Phương pháp lập trình với việc cấu trúc hóa dữ liệu và cấu trúc hóa chương tình để tránh các lệnh nhảy .', N'Phương pháp lập trình được cấu trúc nghiêm ngặt với cấu trúc dạng module.', 'A';
EXEC sp_ThemLuaChon 'LC019','CH019', N'Chỉ có thể truy cập thông qua tên đối tượng của lớp .', N'Truy cập thông qua tên lớp hay tên đối tượng của lớp.', N'Chỉ có thể truy cập thông qua tên lớp .', N'Không thể truy cập vào được .', 'B';
EXEC sp_ThemLuaChon 'LC020','CH020', N'Phương pháp quan tâm đến mọi chi tiết của đối tượng.', N'Phương pháp chỉ quan tâm đến những chi tiết cần thiết ( chi tiết chính ) và bỏ qua những chi tiết không cần thiết.', N'Không có phương án chính xác.', N'Phương pháp thay thế những chi tiết chính bằng những chi tiết tương tự.', 'B';
EXEC sp_ThemLuaChon 'LC021','CH021', N'Một thực thể cụ thể trong thế giới thực .', N'Một lớp vật chất trong thế giới thực .', N'Một vật chất trong thế giới thực.', N'Một mẫu hay một thiết kế cho mọi lớp đối tượng.', 'A';
EXEC sp_ThemLuaChon 'LC022','CH022', N'Vô số thành phần.', N'Thuộc tính ( dữ liệu ) và phương thức ( hành vi ) của lớp .', N'Dữ liệu và đối tượng của lớp .', N'Khái niệm và đối tượng của lớp. ', 'B';
EXEC sp_ThemLuaChon 'LC023','CH023', N'Tại chương trình chính chỉ có thể truy cập đến thành phần public của lớp .', N'Tại chương trình chính chỉ có thể truy cập đến thành phần private của lớp. ', N'Tại chương trình chính chỉ có thể truy cập đến bất kì thành phần nào của lớp.', N'Tại chương trình chính không thể truy cập đến bất kì thành phần nào của lớp.', 'A';
EXEC sp_ThemLuaChon 'LC024','CH024', N'File.', N'Record.', N'Object.', N'Class', 'D';
EXEC sp_ThemLuaChon 'LC025','CH025', N'Cho phép truy xuất từ bên ngoài lớp.', N'Không cho phép truy xuất từ bên ngoài của lớp nhưng cho phép lớp kế thừa truy xuất tới.', N'Không cho phép truy xuất từ bên ngoài của lớp chỉ có các phương thức bên trong lớp mới có thể truy xuất được.', N'Cho phép truy xuất từ bên ngoài lớp và cho phép kế thừa', 'C';
EXEC sp_ThemLuaChon 'LC026','CH026', N' Cho phép truy xuất từ bên ngoài lớp.', N'Không cho phép truy xuất từ bên ngoài của lớp nhưng cho phép lớp kế thừa truy xuất tới.', N'Không cho phép truy xuất từ bên ngoài của lớp chỉ có các phương thức bên trong lớp mới có thể truy xuất được.', N'Cho phép truy xuất từ bên ngoài lớp và cho phép kế thừa.', 'B';
EXEC sp_ThemLuaChon 'LC027','CH027', N'Cho phép truy xuất từ bên ngoài lớp .', N'Không cho phép truy xuất từ bên ngoài của lớp nhưng cho phép lớp kế thừa truy xuất tới.', N'Không cho phép truy xuất từ bên ngoài của lớp chỉ có các phương thức bên trong lớp mới có thể truy xuất được.', N'Cho phép truy xuất từ bên trong và  ngoài lớp và cho phép kế thừa.', 'D';
EXEC sp_ThemLuaChon 'LC028','CH028', N'Tất cả các hàm ( hàm trả về giá trị và không trả về giá trị ) được khai báo bên trong lớp .', N'Tất cả các hàm ( hàm và thủ tục ) được sử dụng trong lớp.', N'Tất cả những hàm ( hàm và thủ tục ) được khai báo và xây dựng bên trong các lớp mô tả các dữ liệu của đối tượng .', N'Tất cả những hàm ( hàm và thủ tục ) trong chương trình có lớp. ', 'A';
EXEC sp_ThemLuaChon 'LC029','CH029', N'1 lớp duy nhất', N'3 lớp ', N'10 lớp', N'Vô số tùy theo bộ nhớ.', 'D';
EXEC sp_ThemLuaChon 'LC030','CH030', N'Hàm thành viên của lớp phải được khai báo bên trong lớp và được gọi nhờ tên đối tượng hay tên lớp còn hàm thông thường thì không .', N'Hàm thành viên của lớp thì phải được khai báo và xây dựng bên trong lớp còn hàm thông thường thì không .', N'Hàm thành viên của lớp thì phải khai báo bên trong lớp với từ khóa friends và xây dựng bên ngoài lớp.', N'Hàm thành viên của lớp và hàm thông thường không có gì khác gì nhau', 'A';
EXEC sp_ThemLuaChon 'LC031','CH031', N'Hành vi của đối tượng.', N'những chức năng của đối tượng', N'Dữ liệu trình bày các đặc điểm của một đối tượng.', N'Liên quan tới những thứ mà đối tượng có thể làm. Một phương thức đáp ứng một chức năng tác động lên dữ liệu của đối tượng.', 'C';
EXEC sp_ThemLuaChon 'LC032','CH032', N'Dữ liệu trình bày các đặc điểm của một đối tượng.', N'Liên quan tới những thứ mà đối tượng có thể làm. Một phương thức đáp ứng một chức năng tác động lên dữ liệu của đối tượng. ', N'Những chức năng của đối tượng', N'Tất cả đều đúng. ', 'B';
EXEC sp_ThemLuaChon 'LC033','CH033', N'Họ tên , ngày sinh , giới tính , địa chỉ, số cmt, quê quán , nhóm máu , màu mắt , màu da , cân nặng ', N'Họ tên , ngày sinh , giới tính , đại chỉ , cmt, quê quán', N'Họ tên, ngày sinh , giới tính , địa chỉ, số cmt, quê quán , lớp học , khóa học , khoa quản lí', N'Tính điểm trung bình , xét kết quả học tập, xếp loại.', 'C';
EXEC sp_ThemLuaChon 'LC034','CH034', N'Tung độ, cao độ.', N'Dịch chuyển, Thiết lập tọa độ', N'Tung độ, hoành độ', N'Tung độ, hoành độ , cao độ', 'B';
EXEC sp_ThemLuaChon 'LC035','CH035', N'Dữ liệu được che giấu và không thể được truy xuất từ các hàm bên ngoài', N'Nhấn mạnh trên dữ liệu hơn là thủ tục ', N'Tất cả đều đúng', N'Các chương trình được chia thành các đối tượng ', 'C';
EXEC sp_ThemLuaChon 'LC036','CH036', N'Tên_lớp.Tên_hàm_thành_viên.', N'Tên_đối_tượng.Tên_hàm_thành_viên.', N'Tên_lớp:Tên_hàm_thành_viên', N'Không có phương án đúng', 'B';
EXEC sp_ThemLuaChon 'LC037','CH037', N'Chương trình sẽ lỗi và yêu cầu phải khai báo 1 trong 3 từ khóa', N'Private', N'Public', N'Protected', 'B';
EXEC sp_ThemLuaChon 'LC038','CH038', N'Không được phép xây dựng các hàm trùng tên nhau trong cùng một chương trình.', N'Sự chồng hàm (override) nhưng chỉ các hàm thông thường mới được phép trùng nhau.', N'Sự chồng hàm (override).', N'Sự chồng hàm ( override ) nhưng chỉ những hàm thành viên của lớp mới được phép trùng nhau', 'C';
EXEC sp_ThemLuaChon 'LC039','CH039', N'Có đối hoặc không có đối ', N'Tất cả đều đúng ', N'Tự động được gọi tới khi khai báo đối tượng của lớp', N'Có tên trùng với tên lớp', 'B';
EXEC sp_ThemLuaChon 'LC040','CH040', N'~Tên_lớp {//nội dung }', N'Done {//nội dung}', N'Destructor Tên_hàm{//nội dung} ', N'Tên_lớp{//nội dung } ', 'A';
EXEC sp_ThemLuaChon 'LC042','CH042', N'Hàm hủy là hàm dùng để khởi tạo giá trị ban đầu cho các thành phần thuộc tính bên trong lớp ', N'Hàm hủy dùng để hủy ( giải phóng ) bộ nhớ cho các thành phần thuộc tính bên trong lớp ', N'Hàm hủy là hàm dùng để giải phóng toàn bộ các biến của chương trình.', N'Tất cả đều đúng . ', 'B';
EXEC sp_ThemLuaChon 'LC041','CH041', N'hàm nằm bên ngoài lớp dùng để khởi tạo bộ nhớ cho đối tượng.', N'hàm thành viên của lớp dùng để khởi tạo bộ nhớ và giá trị ban đầu cho các thuộc tính trong lớp. ', N'hàm dùng để khởi tạo bộ nhớ cho đối tượng của lớp. ', N'dùng để huỷ bộ nhớ cho đối tượng.', 'B';
EXEC sp_ThemLuaChon 'LC043','CH043', N'Gọi như hàm thành viên thông thường ( Tên đối tượng.Tên_hàm)', N'Tất cả đều sai ', N'Gọi bằng cách : Tên_lớp .Tên_hàm_tạo().', N'Không cần gọi tới hàm tạo vì ngay khi khai báo đối tượng sẽ tự gọi tới hàm tạo.', 'D';
EXEC sp_ThemLuaChon 'LC044','CH044', N'Giờ, Phút, Giây', N'Giờ ', N'Phút ', N'Giây', 'A';
EXEC sp_ThemLuaChon 'LC045','CH045', N'Kế thừa tất cả các phương thức thuộc tính khai báo trong phần protected ,  public , và không kế thừa hàm tạo, hàm hủy. ', N'Kế thừa tất cả các phương thức thuộc tính khai báo trong phần protected ,  public bao gồm hàm tạo, hàm hủy.', N'Kế thừa tất cả các phương thức thuộc tính khai báo trong phần protected ,  public , private và không kế thừa hàm tạo, hàm hủy.', N'Kế thừa tất cả các phương thức thuộc tính khai báo trong phần protected, public , private bao gồm hàm tạo, hàm hủy.', 'A';
EXEC sp_ThemLuaChon 'LC046','CH046', N'Phải gọi thông qua con trỏ đối tượng', N'Không thể gọi phương thức ảo', N'Gọi như phương thức thông thường', N'Gọi kèm từ khóa virtual', 'C';
EXEC sp_ThemLuaChon 'LC047','CH047', N'Ba loại', N'Hai loại', N'Bốn loại', N'Một loại', 'D';
EXEC sp_ThemLuaChon 'LC048','CH048', N'Private, public', N'Private, public, protected', N'Private , protected', N'Protected , public', 'B';
EXEC sp_ThemLuaChon 'LC049','CH049', N'Số lượng tham số truyền vào các hàm (3) ', N'Kiểu dữ liệu của tham số truyền vào của hàm (2)', N'Hoặc (1) hoặc (2) hoặc (3)', N'Kiểu dữ liệu trả về hàm (1)', 'C';
EXEC sp_ThemLuaChon 'LC050','CH050', N'Hai hàm dựng', N'Một hàm dựng', N'Tất cả đều sai', N'Nhiều hàm dựng ( tạo ) , các hàm dựng khác nhau về tham đối', 'D';
EXEC sp_ThemLuaChon 'LC051','CH051', N'Có thể chứa vô số hàm hủy tùy theo bộ nhớ', N'Có thể chứa được ba hàm hủy', N'Duy nhất một hàm hủy', N'Chứa tối đa hai hàm hủy', 'C';
EXEC sp_ThemLuaChon 'LC052','CH052', N'Hai mức', N'Vô số tùy theo bộ nhớ', N'Một mức', N'Ba mức', 'B';
EXEC sp_ThemLuaChon 'LC053','CH053', N'Vô số lớp tùy theo bộ nhớ', N'Hai lớp', N'Một lớp', N'Ba lớp ', 'C';
EXEC sp_ThemLuaChon 'LC054','CH054', N'Gọi đến cả hai phương thức', N'Lớp B', N'Lớp A', N'Lỗi không thể các định được.', 'C';
EXEC sp_ThemLuaChon 'LC055','CH055', N'Cho phép rùng tên phương thức còn không cho phép trùng tên thuộc tính', N'Cho phép trùng tên cả phương thức lẫn thuộc tính', N'Không cho phép trùng tên phươg thức vầ thuộc tính', N'Cho phép trùng tên thuộc tính còn không cho phép trùng tên phương thức ', 'B';
EXEC sp_ThemLuaChon 'LC056','CH056', N'Được cấp phát bộ nhớ ngay cả khi lớp chưa có đối tượng cụ thể nào.', N'Là thành viên dùng chung cho tất cả các đối tượng của lớp, không của riêng đối tượng nào?', N'Là thành viên của lớp được khai báo với từ khóa static ở trước', N'Tất cả đều đúng', 'D';
EXEC sp_ThemLuaChon 'LC057','CH057', N'Các hàm này cùng được xây dựng trong một lớp', N'Các hàm cùng được xây dựng trong 1 chương trình', N'Các hàm này được xây dựng trong các lớp khác nhau', N'Các hàm này được xây dựng trong các lớp kế thừa.', 'A';
EXEC sp_ThemLuaChon 'LC058','CH058', N'Giống khai báo phương thức thường nhưng đứng đầu là từ khóa virtual', N'Giống khai báo phương thức thường nhưng không cần xây dựng nội dung', N'Tất cả đều sai', N'Giống khai báo phương thức thường nhưng phải được xây dựng bên trong lớp', 'A';
EXEC sp_ThemLuaChon 'LC059','CH059', N'Một phương thức ảo', N'Vô số phương thức ảo', N'Ba phương thức ảo', N'Hai phương thức ảo.', 'B';
EXEC sp_ThemLuaChon 'LC060','CH060', N'Sử dụng dấu :', N'new', N'base', N'extends', 'A';
EXEC sp_ThemLuaChon 'LC061','CH061', N'Tam giác là lớp cha của lớp điểm', N'Tam giác là lớp con của lớp điểm', N'Điểm là lớp bao của lớp tam giác', N'Tam giác là lớp bao của lớp điểm  ', 'D';
EXEC sp_ThemLuaChon 'LC062','CH062', N'Đường thẳng là lớp con của lớp điểm', N'Điểm là lớp bao của lớp đường thẳng', N'Đường thẳng là lớp cha của lớp điểm', N'Đường thẳng là lớp bao của lớp điểm', 'D';
EXEC sp_ThemLuaChon 'LC063','CH063', N'Các hệ số x,y ', N'Cách hệ số a, b, x,y', N'Các hệ số a, x, b', N'Các hệ số a, b', 'D';
EXEC sp_ThemLuaChon 'LC064','CH064', N'Lớp cơ sở cho các lớp  đối tượng trên', N'Lớp dẫn xuất cho các lớp đối tượng trên', N'Lớp bao của các lớp đối tượng trên', N'Lớp thành viên của các lớp đối tượng trên ', 'A';
EXEC sp_ThemLuaChon 'LC065','CH065', N'Tải_trọng,  Loại_động_cơ , Loại_phương _tiện , biển_số', N'Tải_trọng,  Loại_động_cơ, Di_chuyển', N'Tải_trọng,  Loại_động_cơ ,  biển_số', N'Tải_trọng, Loại_đọng_cơ , Loại_phương _tiện ,Biển_ số, Di _chuyển', 'C';
EXEC sp_ThemLuaChon 'LC066','CH066', N'Loại_phương _tiện , Di_chuyển', N'Tải_trọng,  Loại_động_cơ, Loại_phương_tiện, Biển_số', N'Tải_trọng, Loại_đọng_cơ , Loại_phương _tiện ,Biển_ số, Di _chuyển', N'Di_chuyển', 'D';
EXEC sp_ThemLuaChon 'LC067','CH067', N'Sự trừu tượng hóa chức năng', N'Sự trừu tượng hóa dữ liệu', N'Tính kế thừa', N'Tính đa hình', 'B';
EXEC sp_ThemLuaChon 'LC068','CH068', N'Lớp Thí sinh là trường hợp tổng quát của lớp Sinh viên', N'Lớp Sinh viên là trường hợp đặc biệt hóa của lớp Thí sinh ', N'Lớp Thí sinh là trường hợp đặc biệt hóa của lớp Sinh viên', N'Không có phương án đúng', 'C';
EXEC sp_ThemLuaChon 'LC069','CH069', N'Tung độ , hoành độ , cao độ , dịch chuyển', N'Dịch chuyển', N'Không có phương án nào đúng', N'Tung độ, hoành độ , cao độ', 'D';
EXEC sp_ThemLuaChon 'LC070','CH070', N'Lớp A sẽ có toàn bộ những thành phần thuộc protected và public của lớp B', N'Lớp A sẽ có toàn bộ những thành phần thuộc protected và public của lớp B', N'Lớp B sẽ có toàn bộ những thành phần thuộc protected và public của lớp A', N'Lớp B sẽ có toàn bộ những thành phần thuộc protected và public của lớp A', 'B';
EXEC sp_ThemLuaChon 'LC071','CH071', N'Trừu tượng dữ liệu và trừu tượng chức năng', N'Bao gói', N'Bao gói', N'Kế thừa', 'A';
EXEC sp_ThemLuaChon 'LC072','CH072', N'Số sinh viên (n), Họ và tên , Ngày sinh, Giới tính , Đại chỉ ,Lớp', N'Số sinh viên (n), Họ và tên , Ngày sinh', N'Số sinh viên (n), Họ và tên , Ngày sinh', N'Số sinh viên (n), Họ và tên , Ngày sinh', 'B';
EXEC sp_ThemLuaChon 'LC073','CH073', N'struct', N'class', N'phương thức',N'interface', 'D';
EXEC sp_ThemLuaChon 'LC074','CH074', N'Tất cả các phương án đều đúng', N'Lớp Điểm và lớp điểm màu', N'Lớp xe ô tô và lớp Xe', N'Lớp lớp Người và Giáo Viên', 'A';
EXEC sp_ThemLuaChon 'LC075','CH075', N'Tất cả đều đúng', N'Mỗi đối tượng sau khi khai báo sẽ được cấp phát một vùng nhớ riêng để chứa các thuộc tính của chúng', N'Một lớp ( sau khi định nghĩa ) có thể xem như 1 kiểu đối tượng và có thể dùng để khai thác các biến, mảng đối tượng', N'Thuộc tính của lớp có thể có kiểu của chính lớp đó', 'A';
EXEC sp_ThemLuaChon 'LC076','CH076', N'Tất cả các phương án gộp lại', N'SBD,Họ và tên ,Ngày sinh , Giới tính , Phòng thi , giờ thi', N'Mảng SBD, Mảng Họ và tên , Mảng Ngày sinh , Mảng giới tính , Mảng Phòng thi, mảng giờ thi', N'Số thí sinh, Mảng các thí sinh', 'D';
EXEC sp_ThemLuaChon 'LC077','CH077', N'abstract', N'override', N'virtual',N'new', 'B';
EXEC sp_ThemLuaChon 'LC078','CH078', N'catch', N'try', N'try/catch', N'các câu trên đều sai', 'C';
EXEC sp_ThemLuaChon 'LC079','CH079', N'phương thức', N'class', N'phương thức trừ tượng. ( được khai báo với từ khóa absstract )', N'struct', 'C';
EXEC sp_ThemLuaChon 'LC080','CH080', N'Hàm destructor dùng để hủy vùng nhớ đã cấp cho con trỏ this', N'Một lớp luôn luôn có hàm destructor', N'Hàm destructor có thể là 1 hàm ảo', N'Các án trên đều không đúng', 'B';
EXEC sp_ThemLuaChon 'LC081','CH081', N'Thiết lập và lấy giá tị của thuộc tính đó', N'Tằng cường bảo mật dữ liệu của thuộc tính', N'Đây là cấu trúc yêu cầu của C# khi khai báo thuộc tính của lớp', N'Để nhập và xuất giá trị thuộc tính đó.', 'A';
EXEC sp_ThemLuaChon 'LC082','CH082', N'Khai báo các thuộc tính và các phương thức thiết lập , lấy giá trị của thuộc tính ; Khai báo và xây dựng các phương thức của lớp', N'Khai báo các trường dữ liệu cần dùng ; khai báo các thuộc tính; khai báo và xây dựng các phương thức của lớp', N'Khai báo các trường dữ liệu cần dùng ; khai báo các thuộc tính và phương thức thiệt lập , lấy giá trị của thuôc tính ; khai báo và xây dựng các phương thức của lớp', N'Khai báo các trường dữ liệu cần dùng ; khai báo các thuộc tính ; khai báo các phương thức của lớp', 'C';
EXEC sp_ThemLuaChon 'LC083','CH083', N'Từ khóa Properties đi đầu', N'Từ khóa Region đi đầu', N'Phạm vi của thuộc tính là private hay public hay protected', N'Khai báo kiểu dữ liệu của thuộc tính', 'C';
EXEC sp_ThemLuaChon 'LC084','CH084', N'Tất cả đều sai', N'Lớp sinh viên', N'Lớp danh sách sinh viên', N'Lớp sinh viên và lớp danh sách sinh viên ', 'D';
EXEC sp_ThemLuaChon 'LC085','CH085', N'Tất cả các phương án gộp lại', N'SBD,Họ và tên, Ngày sinh , Giới tính, phòng thi, giờ thi', N'Số thí sinh, mảng các thí sinh', N'Mảng SBD, mảng Họ và tên , mảng Ngày sinh , Mảng giới tính , Mảng Phòng thi , Mảng giờ thi', 'B';
EXEC sp_ThemLuaChon 'LC086','CH086', N'Đóng gói', N'Trừu tượng', N'Đa hình', N'Ảo của phương thức', 'C';
EXEC sp_ThemLuaChon 'LC087','CH087', N'Remove()', N'Tất cả đều sai', N'Reset()', N'Clear()', 'A';
EXEC sp_ThemLuaChon 'LC088','CH088', N'Tương tác với các lớp hay môi trường bên ngoài', N'Tương tác với các thuộc tính bên trong lớp', N'Thể hiện rõ tính chất đa hình', N'Thể hiện tính bao gói dữ liệu', 'A';
EXEC sp_ThemLuaChon 'LC089','CH089', N'Clear()', N'Trim()', N'Tất cả đều đúng', N'ResetText()', 'B';
EXEC sp_ThemLuaChon 'LC090','CH090', N'Lớp Môn học là lớp dẫn xuất của lớp Sinh viên', N'Lớp Môn học là lớp đối tượng thành phần của lớp Sinh viên', N'Lớp Môn học là lớp cơ sở cho lớp Sinh viên', N'Lớp Môn học là lớp bao của lớp Sinh viên', 'B';
EXEC sp_ThemLuaChon 'LC091','CH091', N'Chỉ cho phép  kế thừa nhưng ngay bên trong lớp đó cũng không truy cập được', N'Cho phép kế thừa nhưng không cho phép tương tác trực tiếp bên ngoài lớp', N'Tất cả đều sai', N'Cho phép kế thừa và cho phép tương tác trực tiếp từ bên ngoài lớp', 'B';
EXEC sp_ThemLuaChon 'LC092','CH092', N'Tất cả đều đúng', N'Một lớp ( sau khi định nghĩa ) có thể xem như một kiểu đối tượng và có thể dùng đề khai báo các biến, mảng đối tượng', N'Thuộc tính của lớp có thể có kiểu của chính lớp đó', N'Mỗi đối tượng sau khi khai báo sẽ được cấp phát một vùng nhớ riêng để chứa các thuộc tính của chúng', 'A';
EXEC sp_ThemLuaChon 'LC093','CH093', N'Cả 3 đều sai', N'Common specification language', N'Common language runtime ', N'Common language specification', 'C';
EXEC sp_ThemLuaChon 'LC094','CH094', N'Phương thức hiện thị thông tin từng thí sinh', N'Không có phương án đúng', N'Phương thức nhập và hiển thị thông tin từng thí sinh', N'Phương thức hiển thị , phương thức  khởi tạo , phương thức nhập', 'C';
EXEC sp_ThemLuaChon 'LC095','CH095', N'Tất cả câu trên đều sai', N'public diem (){}', N'public diem{}', N'public string diem(){}', 'B';
EXEC sp_ThemLuaChon 'LC096','CH096', N'Tĩnh', N'Cục bộ', N'Tất cả đều sai', N'Toàn cục', 'B';
EXEC sp_ThemLuaChon 'LC097','CH097', N'Ctrl + K , ctrl + U -> Bỏ chú thích', N'Ctrl + K , Ctrl + C -> Xuất hiện chú thích', N'Ctrl + Space ', N'Ctrl + K , Ctrl+F', 'A';
EXEC sp_ThemLuaChon 'LC098','CH098', N'Cả a và b', N'//', N' ', N'\\ ', 'B';
EXEC sp_ThemLuaChon 'LC099','CH099', N'Phương thức ảo.', N'Đóng gói.', N'Đa hình', N'Trừu tượng.', 'C';
EXEC sp_ThemLuaChon 'LC100','CH100', N'Bốn ngôn ngữ chính thức : C#, vb.net, c++, và jscript.net', N'Bộ thư viện framwork class libraly-FCL', N'Tất cả đều đúng', N'Common language runtime-CLR , nền tảng hướng đối tượng cho phát triển ứng dụng windows và web mà các ngôn ngữ có thể chia sẽ ứng dụng.', 'C';




-- MMT

EXEC sp_ThemCauHoi 'CH101', N'Thiết bị hub thông thường nằm ở tầng nào của mô hình OSI?', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH102', N'Thiết bị Switch thông thường nằm ở tầng nào của mô hình OSI?', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH103', N'Thiết bị Bridge nằm ở tầng nào của mô hình OSI?', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH104', N'Thiết bị Repeater nằm ở tầng nào của mô hình OSI?', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH105', N'Thiết bị Router thông thường nằm ở tầng nào của mô hình OSI?', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH106', N'Thiết bị Hub có bao nhiêu collision domain?', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH107', N'Thiết bị Switch có bao nhiêu collision domain?', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH108', N'Thiết bị Switch có bao nhiêu Broadcast domain?', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH109', N'Thiết bị Hub có bao nhiêu Broadcast domain?', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH110', N'Thiết bị Router có bao nhiêu collision domain ?', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH111', N'Thiết bị router có bao nhiêu Broadcast domain?', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH112', N'Cáp UTP có thể kết nối tối đa bao nhiêu mét?', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH113', N'Cáp quang có thể kết nối tối đa bao nhiêu mét ?', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH114', N'Để nối Router và máy tính ta phải bấm cáp kiểu nào?', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH115', N'Thiết bị Repeater xử lý ở:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH116', N'Phát biểu nào sau đây là đúng nhất cho Switch:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH117', N'Chọn phát biểu ĐÚNG về switch và hub:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH118', N'Cáp UTP được sử dụng với đầu nối là: ', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH119', N'Khoảng cách tối đa cho cáp UTP là:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH120', N'Khi sử dụng mạng máy tính ta sẽ được các lợi ích:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH121', N'K  thuật dùng để nối kết nhiều máy tính với nhau trong phạm vi một văn phòng gọi là:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH122', N'Mạng Internet l  sự ph t triển của:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH123', N'Kiến trúc một mạng LAN có thể là:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH124', N'Phát biểu nào sau đây mô tả đúng nhất cho cấu hình Star:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH125', N'Mô tả nào thích hợp cho mạng Bus:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH126', N'Môi trường truyền tin thông thường trong mạng máy tính là:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH127', N'Việc nhiều các gói tin bị đụng độ trên mạng sẽ làm cho:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH128', N'K  thuật dùng để truy cập đường truyền trong mạng Ethernet là:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH129', N'K  thuật dùng để truy cập đường truyền trong mạng Ring là:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH130', N'Cho biết đặc điểm của mạng Ethernet 100BaseTX:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH131', N'Đơn vị của “băng thông l ”:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH132', N'Định nghĩa giao thức (protocol):', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH133', N'Trong chồng giao thức TCP/IP, ở tầng Transport có những giao thức nào:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH134', N'Giao thức FTP sử dụng cổng dịch vụ số:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH135', N'Giao thức SMTP sử dụng cổng dịch vụ số:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH136', N'Giao thức POP3 sử dụng cổng dịch vụ số:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH137', N'Để kết nối hai HUB với nhau ta sử dụng kiểu bấm cáp:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH138', N'Trên server datacenter (HĐH Windows 2003) có chia sẻ một thư mục dùng chung đặt tên là software. Lệnh để ánh xạ thư mục trên thành ổ đĩa X:\ cục bộ trên máy là:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH139', N'Trong mô hình mạng hình sao (star model), nếu hub xử lý trung tâm bị hỏng thì:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH140', N'Trong mô hình mạng kiểu bus, nếu một máy tính bị hỏng thì:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH141', N'Trong mô hình mạng kiểu vòng (Ring Model), nếu có một máy tính bị hỏng, các máy tính còn lại không thể truy cập đến nhau.', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH142', N'Nhiệm vụ nào dưới đây không phải là của tầng mạng (Network Layer):      A. Định địa chỉ logic.', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH143', N'Phát biểu nào dưới đây là đúng:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH144', N'Subnet mask trong một cổng seria của router là 11111000. Số thập phân của nó là:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH145', N'Số thập phân 231 được đổi sang nhị  phân là số nào sau đây:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH146', N'số thập phân 172 được đổi sang nhị  phân là số nào sau đây:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH147', N'Những địa chỉ nào sau đây được chọn cho những host trong subnet 192.168.15.19/28?', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH148', N'Bạn có một địa chỉ lớp C, và bạn cần 10 subnets. Bạn muốn mình có nhiều địa chỉ cho mỗi mạng. Vậy bạn chọn subnet mask nào sau đây:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH149', N'Địa chỉ IP nào sau đây đặt được cho PC:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH150', N'Phát biểu nào sau đây là đúng:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH151', N'Trong Mail Server thường sử dụng các giao thức nào sau đây:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH152', N'Dịch vụ nào sau đây được yêu cầu khi quản trị AD:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH153', N'DC viết tắt của từ nào?', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH154', N'Dịch vụ DNS Server có chức năng chính là gì?', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH155', N'Record MX dùng làm gì?', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH156', N'Kiểu truyền thông multicast trong mô hình Điểm - Nhiều Điểm là kiểu truyền thông mà:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH157', N'7 tầng của mô hình OSI lần lượt là:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH158', N'Bất cứ một hệ thống truyền thông trên Internet nào, muốn truyền thông tin được cần phải cài đặt đủ 7 tầng của mô hình OSI: ', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH159', N'Tầng Vật Lý (Physical Layer) làm nhiệm vụ:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH160', N'Tốc độ truyền dữ liệu được tính theo đơn vị:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH161', N'Phát biểu nào dưới đây về tầng Datalink là sai:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH162', N'Phát biểu nào dưới đây là sai về tầng mạng (Network Layer):', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH163', N'Giao thức IP là giao thức họat động ở tầng:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH164', N'Phát biểu nào dưới đây là đúng:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH165', N'Địa chỉ IP (Version 4) là:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH166', N'Phát biểu nào sau đây về giao thức TCP là sai :', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH167', N'Phát biểu nào sau đây về TCP là đúng :', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH168', N'Dịch vụ hướng nối (Connection Oriented) yêu cầu Client và Server phải "bắt tay" trước khi truyền dữ liệu thực sự.', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH169', N'UDP cung cấp dịch vụ truyền tin cậy hơn TCP.', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH170', N'Phát biểu nào sau đây về UDP là sai:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH171', N'Đơn vị dữ liệu (BPDU) tại tầng liên kết (data link) gọi là:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH172', N'Đơn vị dữ liệu (BPDU) tại tầng mạng (network) gọi là:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH173', N'Đơn vị dữ liệu (BPDU) tại tầng  vận chuyển (transport) gọi là:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH174', N'Tầng nào trong mô hình OSI có chức năng định tuyến giữa các mạng:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH175', N'Chọn các tầng trong mô hình tham chiếu OSI:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH176', N'Chọn các tầng trong bộ giao thức TCP/IP:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH177', N'Các giao thức nào nằm ở tầng Transport:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH178', N'Các giao thức nào nằm ở tầng network của mô hình OSI:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH179', N'Địa chỉ vật lý gồm bao nhiêu bit:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH180', N'Địa chỉ IPv4 gồm bao nhiêu bit:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH181', N'UDP là giao thức :', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH182', N'Đánh dấu các câu đúng về cổng TCP::', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH183', N'Đánh dấu các câu đúng về địa chỉ IP', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH184', N'Địa chỉ nào là địa chỉ broadcast trong subnet 200.200.200.176, subnet mask: 255.255.255.240:', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH185', N'Nguyên nhân cơ bản nào dẫn đến sự  ra đời của mạng máy tính?', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH186', N'Ý nghĩa cơ bản nhất của mạng máy tính là gì?', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH187', N'Thuật ngữ viết tắt bằng tiếng Anh của mạngcục bộ là gì?', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH188', N'Thuật ngữ viết tắt bằng tiếng Anh của mạng diện rộng là gì?', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH189', N'Thuật ngữ viết tắt bằng tiếng Anh của mạng thành phố là gì?', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH190', N'Thuật ngữ viết tắt bằng tiếng Anh của mạngtoàn cục là gì?', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH191', N'Thuật ngữ LAN (mạng cục bộ) là viết tắt của cụm từ nào?', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH192', N'Thuật ngữ WAN (mạng diện rộng) là viết tắt của cụm từ nào?', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH193', N'Thuật ngữ MAN (mạng thành phố) là viết tắt của cụm từ nào?', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH194', N'Thuật ngữ GAN (mạng toàn cục) là viết tắt của cụm từ nào?', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH195', N'Các kiểu mạng LAN, MAN, WAN, GAN được phân biệt với nhau bởi tiêu chí phân loại nào?', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH196', N'Mục đích chính của việc xây dựng LAN là gì?', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH197', N'Mục đích chính của việc xây dựng WAN là gì?', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH198', N'Mục đích chính của việc xây dựng MAN là gì?', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH199', N'Mục đích chính của việc xây dựng GAN là gì?', N'Dễ', 'MH002';
EXEC sp_ThemCauHoi 'CH200', N'Mạng Internet là mạng thuộc loại mạng nào?', N'Dễ', 'MH002';

-- Đáp án MMT

EXEC sp_ThemLuaChon 'LC101','CH101', N'Tầng 1', N'Tầng 2', N'Tầng 3', N'Tất cả đều sai', 'A';
EXEC sp_ThemLuaChon 'LC102','CH102', N'Tầng 1', N'Tầng 2', N'Tầng 3.', N'Tất cả đều sai', 'B';
EXEC sp_ThemLuaChon 'LC103','CH103', N'Tầng 1', N'Tầng 2', N'Tầng 3', N'Tất cả đều sai', 'B';
EXEC sp_ThemLuaChon 'LC104','CH104', N'Tầng 1', N'Tầng 2', N'Tầng 3', N'Tất cả đều sai', 'A';
EXEC sp_ThemLuaChon 'LC105','CH105', N'Tầng 1', N'Tầng 2', N'Từ tầng 3 trở lên', N'Tất cả đều sai', 'C';
EXEC sp_ThemLuaChon 'LC106','CH106', N'1', N'2', N'3', N'4', 'A';
EXEC sp_ThemLuaChon 'LC107','CH107', N'1 collision', N' 2 collision', N'1 collision/1port', N'tất cả đều đúng', 'A';
EXEC sp_ThemLuaChon 'LC108','CH108', N'1', N'2', N'3', N'Tất cả đều đúng', 'C';
EXEC sp_ThemLuaChon 'LC109','CH109', N'1', N'2', N'3', N'Tất cả đều đúng', 'D';
EXEC sp_ThemLuaChon 'LC110','CH110', N'1', N'2', N'3', N'Tất cả đều đúng', 'A';
EXEC sp_ThemLuaChon 'LC111','CH111', N'1 broadcast/ 1port', N'2', N'3', N'4', 'B';
EXEC sp_ThemLuaChon 'LC112','CH112', N'10', N'20', N'100', N'200', 'C';
EXEC sp_ThemLuaChon 'LC113','CH113', N'1000', N'2000', N'lớn hơn 1000', N'Tất cả đều sai', 'B';
EXEC sp_ThemLuaChon 'LC114','CH114', N'Thảng', N'Chéo', N'Kiểu nào cũng được', N'Tất cả đều sai', 'A';
EXEC sp_ThemLuaChon 'LC115','CH115', N'Tầng 1 : Vật lý', N'Tầng 2: Data Link', N'Tầng 3 : Network', N'Tầng 4 trở lên', 'A';
EXEC sp_ThemLuaChon 'LC116','CH116', N'Tầng 1', N'Tầng 2', N'Tầng 3', N'Tất cả đều sai', 'A';
EXEC sp_ThemLuaChon 'LC117','CH117', N'Tầng 1', N'Tầng 2', N'Tầng 3', N'Tất cả đều sai', 'A';
EXEC sp_ThemLuaChon 'LC118','CH118', N'Tầng 1', N'Tầng 2', N'Tầng 3', N'Tất cả đều sai', 'A';
EXEC sp_ThemLuaChon 'LC119','CH119', N'Tầng 1', N'Tầng 2', N'Tầng 3', N'Tất cả đều sai', 'A';
EXEC sp_ThemLuaChon 'LC120','CH120', N'Tầng 1', N'Tầng 2', N'Tầng 3', N'Tất cả đều sai', 'A';
EXEC sp_ThemLuaChon 'LC121','CH121', N'Tầng 1', N'Tầng 2', N'Tầng 3', N'Tất cả đều sai', 'A';
EXEC sp_ThemLuaChon 'LC122','CH122', N'Tầng 1', N'Tầng 2', N'Tầng 3', N'Tất cả đều sai', 'A';
EXEC sp_ThemLuaChon 'LC123','CH123', N'Tầng 1', N'Tầng 2', N'Tầng 3', N'Tất cả đều sai', 'A';
EXEC sp_ThemLuaChon 'LC124','CH124', N'Tầng 1', N'Tầng 2', N'Tầng 3', N'Tất cả đều sai', 'A';
EXEC sp_ThemLuaChon 'LC125','CH125', N'Tầng 1', N'Tầng 2', N'Tầng 3', N'Tất cả đều sai', 'A';
EXEC sp_ThemLuaChon 'LC126','CH126', N'Tầng 1', N'Tầng 2', N'Tầng 3', N'Tất cả đều sai', 'A';
EXEC sp_ThemLuaChon 'LC127','CH127', N'Tầng 1', N'Tầng 2', N'Tầng 3', N'Tất cả đều sai', 'A';
EXEC sp_ThemLuaChon 'LC128','CH128', N'Tầng 1', N'Tầng 2', N'Tầng 3', N'Tất cả đều sai', 'A';
EXEC sp_ThemLuaChon 'LC129','CH129', N'Tầng 1', N'Tầng 2', N'Tầng 3', N'Tất cả đều sai', 'A';
EXEC sp_ThemLuaChon 'LC130','CH130', N'Tầng 1', N'Tầng 2', N'Tầng 3', N'Tất cả đều sai', 'A';
EXEC sp_ThemLuaChon 'LC131','CH131', N'Tầng 1', N'Tầng 2', N'Tầng 3', N'Tất cả đều sai', 'A';
EXEC sp_ThemLuaChon 'LC132','CH132', N'Tầng 1', N'Tầng 2', N'Tầng 3', N'Tất cả đều sai', 'A';
EXEC sp_ThemLuaChon 'LC133','CH133', N'Tầng 1', N'Tầng 2', N'Tầng 3', N'Tất cả đều sai', 'A';
EXEC sp_ThemLuaChon 'LC134','CH134', N'Tầng 1', N'Tầng 2', N'Tầng 3', N'Tất cả đều sai', 'A';
EXEC sp_ThemLuaChon 'LC135','CH135', N'Tầng 1', N'Tầng 2', N'Tầng 3', N'Tất cả đều sai', 'A';
EXEC sp_ThemLuaChon 'LC136','CH136', N'Tầng 1', N'Tầng 2', N'Tầng 3', N'Tất cả đều sai', 'A';
EXEC sp_ThemLuaChon 'LC137','CH137', N'Tầng 1', N'Tầng 2', N'Tầng 3', N'Tất cả đều sai', 'A';
EXEC sp_ThemLuaChon 'LC138','CH138', N'Tầng 1', N'Tầng 2', N'Tầng 3', N'Tất cả đều sai', 'A';
EXEC sp_ThemLuaChon 'LC139','CH139', N'Tầng 1', N'Tầng 2', N'Tầng 3', N'Tất cả đều sai', 'A';
EXEC sp_ThemLuaChon 'LC140','CH140', N'Tầng 1', N'Tầng 2', N'Tầng 3', N'Tất cả đều sai', 'A';
EXEC sp_ThemLuaChon 'LC141','CH141', N'Tầng 1', N'Tầng 2', N'Tầng 3', N'Tất cả đều sai', 'A';

