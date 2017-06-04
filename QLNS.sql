create database QLNS

create table PhongBan(
	IDPhongBan int identity not null,
	TenPhongBan nvarchar(50) null
	primary key(IDPhongBan)
)

--tạo bảng bằng cấp
create table BangCap(
	IDBangCap int identity not null,
	TenBangCap nvarchar(50) null,
	primary key(IDBangCap)
)
-- tạo bảng dự án
create table DuAn(
	IDDuAn int identity not null,
	TenDuAn nvarchar(50) null,
	primary key(IDDuAn)
)
--tạo bảng chức vụ
create table ChucVu(
	IDChucVu int identity not null,
	TenChucVu nvarchar(50) null,
	primary key(IDChucVu)
)
--tạo bảng nhân viên
create table NhanVien(
	IDNhanVien int identity not null,
	IDPhongBan int null,
	IDBangCap int null,
	HoTen nvarchar(30) null,
	NgaySinh date null,
	GioiTinh nvarchar(10),
	NgayVaoLam date null,
	primary key(IDNhanVien),
	foreign key(IDPhongBan) references PhongBan(IDPhongBan),
	foreign key (IDBangCap) references BangCap(IDBangCap)
)
alter table NhanVien add IDTinh int null
alter table NhanVien add IDThanhPho int null
alter table NhanVien add IDPhuong int null
alter table NhanVien add IDPho int null
alter table NhanVien add IDSoNha int null
alter table NhanVien add foreign key(IDTinh) references Tinh(IDTinh)
alter table NhanVien add foreign key(IDThanhPho) references ThanhPho(IDThanhPho)
alter table NhanVien add foreign key(IDPhuong) references Phuong(IDPhuong)
alter table NhanVien add foreign key(IDPho) references Pho(IDPho)
alter table NhanVien add foreign key(IDSoNha) references SoNha(IDSoNha)
--tạo bảng lương 
create table Luong(
	IDLuong int identity not null,
	HeSoLuong float null,
	primary key (IDLuong)
)
--tạo bảng chi tiết lương
create table ChiTietLuong(
	IDChiTiet int identity not null, 
	IDLuong int null,
	IDNhanVien int null,
	primary key(IDChiTiet),
	foreign key(IDLuong) references Luong(IDLuong),
	foreign key(IDNhanVien) references NhanVien(IDNhanVien)
)
alter table ChiTietLuong add NgayTangLuong date null
--tạo bảng tỉnh 
create table Tinh(
	IDTinh int identity not null,
	TenTinh nvarchar(20) null
	primary key(IDTinh)
)
-- tạo bảng thành phố
create table ThanhPho(
	IDThanhPho int identity,
	IDTinh int not null,
	TenThanhPho  nvarchar(20) null,
	primary key(IDThanhPho),
	foreign key(IDTinh) references Tinh(IDTinh)
)

--tạo bảng Phường
create table Phuong(
	IDPhuong int identity, 
	IDThanhPho int not null,
	TenPhuong nvarchar(20) null,
	primary key (IDPhuong),
	foreign key(IDThanhPho) references  ThanhPho(IDThanhPho)
)
--tạo bảng phố
create table Pho(
	IDPho int identity,
	IDPhuong int not null,
	TenPho nvarchar(20) null,
	primary key(IDPho),
	foreign key(IDPhuong) references Phuong(IDPhuong)
)
--tạo bảng số nhà 
create table SoNha(
	IDSoNha int identity,
	IDPho int null, 
	TenSoNha int null,
	primary key(IDSoNha),
	foreign key (IDPho) references Pho(IDPho)
)

--tạo bảng nhân viên và dự án
create table NhanVienVaDuAn(
	IDNhanVien int not null,
	IDDuAn int not null,
	primary key(IDNhanVien, IDDuAn),
	foreign key (IDNhanVien) references NhanVien(IDNhanVien),
	foreign key (IDDuAn) references DuAn(IDDuAn)
)
alter table NhanVienVaDuAn add NgayThamGia date null
alter table NhanVienVaDuAn add SoGioLam float null
--tạo bảng nhân viên và chức vụ
create table NhanVienVaChucVu(
	IDNhanVien int not null,
	IDChucVu int not null,
	primary key(IDNhanVien, IDChucVu),
	foreign key (IDNhanVien) references NhanVien(IDNhanVien),
	foreign key (IDChucVu) references ChucVu(IDChucVu)
)
alter table NhanVienVaChucVu add NgayNhanChuc date null

--thêm bằng cấp
alter proc bangCap_them
	 @ten nvarchar(50)
as
	begin
		insert into BangCap( TenBangCap) values (@ten)
	end
-- sửa bằng cấp
create proc bangCap_sua
	@ma int, @ten nvarchar(50)
as
	begin
		update BangCap
		set TenBangCap=@ten
		where IDBangCap=@ma
	end
-- xóa bằng cấp
create proc bangCap_xoa
	@ma int
as
	begin
		if @ma in (select IDBangCap from NhanVien)
				print N'không thể xóa , nhân viên đang có bằng cấp này!'
			else
				begin
					delete from BangCap
					where IDBangCap=@ma
				end
	end
--thêm phòng ban
create proc phongBan_them
	 @ten nvarchar(50)
as
	begin
		insert into PhongBan( TenPhongBan) values (@ten)
	end
--sửa phòng ban
create proc phongBan_sua
	@ma int, @ten nvarchar(50)
as
	begin
		update PhongBan
		set TenPhongBan=@ten
		where IDPhongBan=@ma
	end
	--xóa phòng ban
	create proc phongBan_xoa
	@ma int
as
	begin
		if @ma in (select IDPhongBan from NhanVien)
				print N'không thể xóa , nhân viên đang có bằng cấp này!'
			else
				begin
					delete from PhongBan
					where IDPhongBan=@ma
				end
	end
	--thêm dự án
create proc duAn_them
	 @ten nvarchar(50)
as
	begin
		insert into DuAn( TenDuAn) values (@ten)
	end
--sửa dự án
create proc duAn_sua
	@ma int, @ten nvarchar(50)
as
	begin
		update DuAn
		set TenDuAn=@ten
		where IDDuAn=@ma
	end
	--xóa dự án
	create proc duAn_xoa
	@ma int
as
	begin
		if @ma in (select IDDuAn from NhanVienVaDuAn)
				print N'không thể xóa , Dự án đang có nhân viên!'
			else
				begin
					delete from DuAn
					where IDDuAn =@ma
				end
	end
		--thêm chức vụ
create proc chucVu_them
	 @ten nvarchar(50)
as
	begin
		insert into ChucVu( TenChucVu) values (@ten)
	end
--sửa chức vụ
create proc chucVu_sua
	@ma int, @ten nvarchar(50)
as
	begin
		update ChucVu
		set TenChucVu=@ten
		where IDChucVu=@ma
	end
	--xóa chức vụ
	create proc chuvVu_xoa
	@ma int
as
	begin
		if @ma in (select IDChucVu from NhanVienVaChucVu)
				print N'không thể xóa , Chức vụ đang có nhân viên giữ!'
			else
				begin
					delete from ChucVu
					where IDChucVu =@ma
				end
	end

--thêm nhân viên
alter proc nhanVien_them
	 @mapb int, @mabc int,@ten nvarchar(30), @ns date, @gt nvarchar(10), @ngayvl date,@idtinh int, @idthanhpho int , @idphuong int, @idpho int, @idsonha int
as
	begin
		insert into NhanVien(IDPhongBan,IDBangCap,HoTen,NgaySinh,GioiTinh,NgayVaoLam,IDTinh,IDThanhPho,IDPhuong,IDPho,IDSoNha) values (@mapb,@mabc,@ten,@ns,@gt,@ngayvl,@idtinh,@idthanhpho,@idphuong,@idpho,@idsonha)
	end
--sửa nhân viên
alter proc nhanVien_sua
	 @manv int,@mapb int, @mabc int,@ten nvarchar(30), @ns date, @gt nvarchar(10), @ngayvl date,@idtinh int, @idthanhpho int , @idphuong int, @idpho int, @idsonha int
as
	begin
		update NhanVien
		set IDPhongBan=@mapb,IDBangCap=@mabc,HoTen=@ten,NgaySinh=@ns, GioiTinh=@gt,NgayVaoLam=@ngayvl,IDTinh=@idtinh,IDThanhPho=@idthanhpho,IDPhuong=@idphuong,IDPho=@idpho,IDSoNha=@idsonha
		where IDNhanVien =@manv
	end
	--xóa nhân viên
	create proc nhanVien_xoa
	@ma int
as
	begin
		if @ma in (select IDNhanVien from NhanVienVaDuAn)
				print N'không thể xóa , Nhân viên đang tham gia dự án!'
			else
				begin
					delete from NhanVien
					where IDNhanVien =@ma
				end
	end


	--hiển thị nhân viên lên datagridview
	create proc hienThiNhanVien
	as
		begin
			select a.IDNhanVien,a.HoTen,b.TenPhongBan,c.TenBangCap,a.NgaySinh,a.GioiTinh,a.NgayVaoLam,d.TenTinh,e.TenThanhPho,f.TenPhuong,g.TenPho,h.TenSoNha
			from NhanVien a 
			inner join PhongBan b 
			on a.IDPhongBan=b.IDPhongBan 
			inner join BangCap c
			on a.IDBangCap=c.IDBangCap
			inner join Tinh d
			on a.IDTinh=d.IDTinh
			inner join ThanhPho e
			on a.IDThanhPho=e.IDThanhPho
			inner join Phuong f
			on a.IDPhuong=f.IDPhuong
			inner join Pho g
			on a.IDPho=g.IDPho
			inner join SoNha h
			on a.IDSoNha=h.IDSoNha
		end
	--thêm nhân viên và chức vụ
	create proc nhanVienVaChucVu_them
	@manv int, @macv int, @ngaync date
	as
		begin
			insert into NhanVienVaChucVu(IDNhanVien,IDChucVu,NgayNhanChuc) values(@manv, @macv,@ngaync)
		end
--sửa nhân viên và chức vụ
alter proc nhanVienVaChucVu_sua
	@mact int, @ngaync date
	as
		begin
			update NhanVienVaChucVu
			set NgayNhanChuc=@ngaync
			where IDChiTiet=@mact
		end
	--xóa nhân viên và chức vụ
	alter proc nhanVienVaChucVu_xoa
	@mact int
	as
		begin
			delete from NhanVienVaChucVu
			where IDChiTiet=@mact
		end
	--thêm nhân viên và dự án
	create proc nhanVienVaDuAn_them
		@manv int, @mada int, @ngaytg date, @giolam int 
	as 
		begin 
			insert into NhanVienVaDuAn(IDNhanVien,IDDuAn,NgayThamGia,SoGioLam) values(@manv,@mada,@ngaytg,@giolam)
		end
		--sửa nhân viên và dự án
		create proc nhanVienVaDuAn_sua
		@mact int, @ngaytg date, @giolam int
		as
			begin
				update NhanVienVaDuAn
				set NgayThamGia=@ngaytg,SoGioLam=@giolam
				where IDChiTiet=@mact
			end
	--xóa nhân viên và dự án
		create proc nhanVienVaDuAn_xoa
		@mact int
		as
			begin
				delete from NhanVienVaDuAn
				where IDChiTiet=@mact
			end
-- thống kê phòng ban có những nhân viên nào
create proc ThongKeNhanVien
	@mapb int 
as
	begin 
		select IDNhanVien, HoTen,GioiTinh,NgaySinh,QueQuan
		from NhanVien 
		where IDPhongBan=@mapb
	end
	-- thống kê dự án có những nhân viên nào
create proc ThongKeNhanVien1
	@mada int 
as
	begin 
		select b.IDNhanVien,b.HoTen,b.GioiTinh,b.NgaySinh,b.QueQuan
		from NhanVienVaDuAn a
		left join NhanVien b
		on a.IDNhanVien= b.IDNhanVien
		where a.IDDuAn=@mada
 	end
	--hiển thị các huyện theo tỉnh
	create proc HuyenTheoTinh
	@ma int
	as
		begin
			select * from ThanhPho
			where IDTinh = @ma
		end
	-- hiển thị xã theo huyện
	create proc XaTheoHuyen
	@ma int 
	as 
		begin
			select * from Phuong
			where IDThanhPho=@ma
		end
-- hiển thị thôn theo xã
create proc ThonTheoXa
@ma int 
as
	begin
		select * from Pho
		where IDPhuong=@ma
	end
--hiển thị số nhà theo phố
alter proc SoNhaTheoPho
@ma int 
as 
	begin 
		select * from SoNha
		where IDPho= @ma
	end
--thêm tỉnh
alter proc tinh_them
	 @ten nvarchar(20)
as
	begin
		insert into Tinh( TenTinh) values (@ten)
	end
-- sửa tỉnh
create proc tinh_sua
	@ma int, @ten nvarchar(20)
as
	begin
		update Tinh
		set TenTinh=@ten
		where IDTinh=@ma
	end
-- xóa tỉnh
create proc tinh_xoa
	@ma int
as
	begin
		if @ma in (select IDTinh from ThanhPho)
				print N'không thể xóa ,tỉnh đang chứa huyện'
			else
				begin
					delete from Tinh
					where IDTinh=@ma
				end
	end
--thêm thành phố
alter proc thanhPho_them
	 @ten nvarchar(20), @tinh nvarchar(20)
as
	begin
		insert into ThanhPho( TenThanhPho,IDTinh) values (@ten,@tinh)
	end
-- sửa thành phố
alter proc thanhPho_sua
	@ma int, @ten nvarchar(20), @tinh nvarchar(20)
as
	begin
		update ThanhPho
		set TenThanhPho=@ten,IDTinh=@tinh
		where IDThanhPho=@ma
	end
-- xóa thành phố
alter proc thanhPho_xoa
	@ma int
as
	begin
		if @ma in (select IDThanhPho from Phuong)
				print N'không thể xóa ,thành phố đang chứa phường'
			else
				begin
					delete from ThanhPho
					where IDThanhPho=@ma
				end
	end
--thêm phường
create proc phuong_them
	 @ten nvarchar(20), @thanhPho nvarchar(20)
as
	begin
		insert into Phuong( TenPhuong,IDThanhPho) values (@ten,@thanhPho)
	end
-- sửa phường
create proc phuong_sua
	@ma int, @ten nvarchar(20), @thanhPho nvarchar(20)
as
	begin
		update Phuong
		set TenPhuong=@ten,IDThanhPho=@thanhPho
		where IDPhuong=@ma
	end
-- xóa phường
create proc phuong_xoa
	@ma int
as
	begin
		if @ma in (select IDPhuong from Pho)
				print N'không thể xóa ,thành phố đang chứa phường'
			else
				begin
					delete from Phuong
					where IDPhuong=@ma
				end
	end
--thêm phố
create proc pho_them
	 @ten nvarchar(20), @phuong nvarchar(20)
as
	begin
		insert into Pho( TenPho,IDPhuong) values (@ten,@phuong)
	end
-- sửa phố
create proc pho_sua
	@ma int, @ten nvarchar(20), @phuong nvarchar(20)
as
	begin
		update Pho
		set TenPho=@ten,IDPhuong=@phuong
		where IDPho=@ma
	end
-- xóa phố
create proc pho_xoa
	@ma int
as
	begin
		if @ma in (select IDPho from SoNha)
				print N'không thể xóa , phố đang chứa số nhà'
			else
				begin
					delete from Pho
					where IDPho=@ma
				end
	end
--thêm số nhà
create proc soNha_them
	 @ten int, @pho nvarchar(20)
as
	begin
		insert into SoNha( TenSoNha,IDPho) values (@ten,@pho)
	end
-- sửa số nhà
create proc soNha_sua
	@ma int, @ten int, @pho nvarchar(20)
as
	begin
		update SoNha
		set TenSoNha=@ten,IDPho=@pho
		where IDSoNha=@ma
	end
-- xóa số nhà
create proc soNha_xoa
	@ma int
as
	begin
		if @ma in (select IDSoNha from NhanVien)
				print N'không thể xóa , nhân viên đang có số nhà này'
			else
				begin
					delete from SoNha
					where IDSoNha=@ma
				end
	end
--thêm hệ số lương
create proc luong_them
	  @hesoluong float
as
	begin
		insert into Luong( HeSoLuong) values (@hesoluong)
	end
-- sửa hệ số lương
create proc luong_sua
	@ma int, @hesoluong float
as
	begin
		update Luong
		set HeSoLuong=@hesoluong
		where IDLuong=@ma
	end
-- xóa hệ số lương
create proc luong_xoa
	@ma int
as
	begin
		if @ma in (select IDLuong from ChiTietLuong)
				print N'không thể xóa , hệ số lương đang được dùng'
			else
				begin
					delete from Luong
					where IDLuong=@ma
				end
	end
--thêm chi tiết lương
create proc chitietluong_them
	  @maluong int, @manv int, @ngaytangluong date
as
	begin
		insert into ChiTietLuong( IDLuong,IDNhanVien,NgayTangLuong) values (@maluong,@manv,@ngaytangluong)
	end
-- sửa chi tiết lương
create proc chitietluong_sua
	@ma int, @maluong int, @manv int, @ngaytangluong date
as
	begin
		update ChiTietLuong
		set IDLuong=@maluong,IDNhanVien=@manv,NgayTangLuong=@ngaytangluong
		where IDChiTiet=@ma
	end
-- xóa chi tiết lương
create proc chitietluong_xoa
	@ma int
as
	begin
		delete from ChiTietLuong
		where IDChiTiet=@ma			
	end