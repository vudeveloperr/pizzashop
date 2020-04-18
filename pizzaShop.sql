create database PizzaShop

create table tblUser(
	userid int primary key identity,
	username nvarchar(250) not null,
	email varchar(250) not null,
	passworduser varchar(50) not null,
	gioitinh nvarchar(5) ,
	tuoi int,
	isadmin bit
);

go
create table tblpayment(
	payid int primary key identity,
	email nvarchar(250),
	kieuthanhtoan nvarchar(250),
	tennganhang nvarchar(250),
	sotien float,

);

go 
create table tblfood(
	mamon int primary key identity, 
	tenmon nvarchar(250),
	gia float,
	img VARBINARY(MAX),
	tenloai nvarchar(250),
	mota nvarchar(250),
	size nvarchar(250),
	donvitinh nvarchar(250)
);

go
create table tblorder(
	mahoadon int primary key identity,
	tongtien float,
	soluong int,
	thoigiandat DateTime,
	thoigiannhan Datetime,
	ghichu nvarchar(250),
	DiaChi nvarchar(250),
	hotennguoinhan nvarchar(250),
	sdtnguoinhan int,
	mamon int  references tblfood(mamon),
);


create proc select_accountuser as
begin
	select * from tblUser
	where tblUser.isadmin=0
end

create proc account_register(@username nvarchar(250), @email varchar(250) , @passworduser varchar(50), @gioitinh nvarchar(5) ,@tuoi int)as
begin
	insert into tblUser(username,email,passworduser,gioitinh,tuoi,isadmin)
	values(@username,@email,@passworduser,@gioitinh,@tuoi,0);
end

account_register 'van vu','vanvu@gmail.com','vu12345','nam','20'
