
go
----------------------------------Quận----------------------------------
-----Thêm-----
create proc themQuan
@tenQuan nvarchar(50),
@chuTich nvarchar(50),
@sdt varchar(15)
as
begin 
	insert into tblQuan values (@tenQuan, @chuTich, @sdt)
end

go
-------Sửa--------
create proc SuaQuan
@maQuan int,
@tenquan nvarchar(50),
@chutich nvarchar(50),
@sdt varchar(15)
as
begin
	update tblQuan set tenQuan = @tenquan, chuTich= @chutich, sdt = @sdt
	where maQuan = @maQuan
end
go
------------Xóa----------
create proc XoaQuan
@maQuan int
as
begin
	delete from tblQuan
	where maQuan = @maQuan
end
go
---------Tìm kiếm
create proc timkiemtheotenquan
@tenquan nvarchar(50)
as
	select * from tblQuan where tenQuan like N'%'+ @tenquan+'%'
go


----------------------------------Phường----------------------------------
-----Thêm-----
create proc themPhuong
@maQuan int,
@tenPhuong nvarchar(50),
@chuTich nvarchar(50),
@sdt varchar(15)
as
begin 
	insert into tblPhuong values (@maQuan, @tenPhuong, @chuTich, @sdt)
end

go
-------Sửa--------
create proc SuaPhuong
@maPhuong int,
@maQuan int,
@tenPhuong nvarchar(50),
@chutich nvarchar(50),
@sdt varchar(15)
as
begin
	update tblPhuong set maQuan = @maQuan, tenPhuong = @tenPhuong, chuTich= @chutich, sdt = @sdt
	where maPhuong = @maPhuong
end
go
------------Xóa----------
alter proc XoaPhuong
@maPhuong int
as
begin
	delete from tblPhuong
	where maPhuong = @maPhuong
end
go
---------Tìm kiếm
create proc timkiemtheotenphuong
@tenPhuong nvarchar(50)
as
	select * from tblPhuong where tenPhuong like N'%'+ @tenPhuong+'%'
go
exec timkiemtheotenphuong 'y'
select * from tblPhuong
go
----------------------------------Tổ----------------------------------
-----Thêm-----
create proc themTo
@maPhuong int,
@tenTo nvarchar(50),
@cbca nvarchar(50),
@toTruong nvarchar(50),
@sdt varchar(15)
as
begin 
	insert into tblTo values (@maPhuong, @tenTo, @cbca, @toTruong, @sdt)
end

go
-------Sửa--------
create proc SuaTo
@maTo int,
@maPhuong int,
@tenTo nvarchar(50),
@cbca nvarchar(50),
@toTruong nvarchar(50),
@sdt varchar(15)
as
begin
	update tblTo set maPhuong = @maPhuong, tenTo = @tento, canBoCongAn = @cbca ,  toTruong= @toTruong, sdtToTruong = @sdt
	where maTo = @maTo
end
go
------------Xóa----------
create proc XoaTo
@maTo int
as
begin
	delete from tblTo
	where maTo = @maTo
end
go

---------Tìm kiếm
create proc timkiemtheotento
@tento nvarchar(50)
as
	select * from tblTo where tenTo like N'%'+ @tento+'%'
go
exec timkiemtheotento '1'
go


----------------------------------Hộ gia đình----------------------------------
-----Thêm-----
create proc themHoGiaDinh
@maTo int,
@hoTen nvarchar(50),
@sdt varchar(15),
@gioiTinh nvarchar(10),
@ngaySinh date,
@soNha nvarchar(50)
as
begin 
	insert into tblHoGiaDinh values (@maTo, @hoTen, @sdt, @gioiTinh, @ngaySinh, @soNha)
end

go
-------Sửa--------
create proc SuaHoGiaDinh
@maHoGiaDinh int,
@maTo int,
@hoTen nvarchar(50),
@sdt varchar(15),
@gioiTinh nvarchar(10),
@ngaySinh date,
@soNha nvarchar(50)
as
begin
	update tblHoGiaDinh set maTo = @maTo, hoTen = @hoTen,  sdt = @sdt, gioiTinh = @gioiTinh, ngaysinh = @ngaySinh, soNha = @soNha
	where maHoGiaDinh = @maHoGiaDinh
end
go
------------Xóa----------
create proc XoaHoGiaDinh
@maHoGiaDinh int
as
begin
	delete from tblHoGiaDinh
	where maHoGiaDinh = @maHoGiaDinh
end
go
---------Tìm kiếm
create proc timkiemtheotenchuho
@hoten nvarchar(50)
as
	select * from tblHoGiaDinh where hoTen like N'%'+ @hoten+'%'
go



----------------------------------Thân nhân----------------------------------
-----Thêm-----
create proc themThanNhan
@maHoGiaDinh int,
@hoten nvarchar(50),
@gioiTinh nvarchar(10),
@ngaySinh date,
@quanHeVoiChuHo nvarchar(50)
as
begin 
	insert into tblThanNhan values (@maHoGiaDinh, @hoten, @gioiTinh, @ngaySinh, @quanHeVoiChuHo)
end

go
-------Sửa--------
create proc SuaThanNhan
@maThanNhan int,
@maHoGiaDinh int,
@hoten nvarchar(50),
@gioiTinh nvarchar(10),
@ngaySinh date,
@quanHeVoiChuHo nvarchar(50)
as
begin
	update tblThanNhan set maHoGiaDinh = @maHoGiaDinh, hoTen = @hoten,
	gioiTinh = @gioiTinh, ngaySinh = @ngaySinh, quanHeVoiChuHo = @quanHeVoiChuHo
	where  maThanNhan = @maThanNhan
end
go
------------Xóa----------
create proc XoaThanNhan
@maThanNhan int
as
begin
	delete from tblThanNhan
	where maThanNhan = @maThanNhan
end
go
---------Tìm kiếm
alter proc timkiemtheotenthanhan
@hoTen nvarchar(50)
as
	select * from tblThanNhan where hoTen like N'%'+ @hoTen+'%'
go
select *from tblThanNhan 
exec timkiemtheotenthanhan 'a'

