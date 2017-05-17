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
	QueQuan nvarchar(100),
	NgayVaoLam date null,
	primary key(IDNhanVien),
	foreign key(IDPhongBan) references PhongBan(IDPhongBan),
	foreign key (IDBangCap) references BangCap(IDBangCap)
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
create proc nhanVien_them
	 @mapb int, @mabc int,@ten nvarchar(30), @ns date, @gt nvarchar(10), @qq nvarchar(100), @ngayvl date
as
	begin
		insert into NhanVien(IDPhongBan,IDBangCap,HoTen,NgaySinh,GioiTinh,QueQuan,NgayVaoLam) values (@mapb,@mabc,@ten,@ns,@gt,@qq,@ngayvl)
	end
--sửa nhân viên
create proc nhanVien_sua
	@manv int, @mapb int, @mabc int,@ten nvarchar(30), @ns date, @gt nvarchar(10), @qq nvarchar(100), @ngayvl date
as
	begin
		update NhanVien
		set IDPhongBan=@mapb,IDBangCap=@mabc,HoTen=@ten,NgaySinh=@ns, GioiTinh=@gt, QueQuan=@qq,NgayVaoLam=@ngayvl
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