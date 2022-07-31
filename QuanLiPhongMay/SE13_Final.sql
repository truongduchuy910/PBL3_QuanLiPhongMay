create database SE13
use SE13
GO
create table Rooms
(
	roomID int primary key not null,
	roomName nvarchar(100)
)
GO
create table Computers
(
	pcID int not null,
	roomID int not null,
	pcAvailable bit default('1') not null,					--1: Tốt || 0: Hỏng
	lastUpdate datetime,
	primary key(pcID,roomID)										--YYYY-MM-DD : H.....
)
GO
create table Schedules
(
	day_ date not null,										--Ngày tháng năm
	roomID int not null,								
	shiftName nvarchar(100)	not null,						--name(Shift)
	userID nvarchar(100) not null
	--Cả 4 là khoá chính
)
GO
create table Users
(	
	userID nvarchar(100) primary key not null,
	passWords nvarchar(1000) not null,
	name nvarchar(100) not null, 
	roles nvarchar(100) not null --Quản lí || Giảng viên
)
GO
create table Shifts
(	
	shiftName nvarchar(100) primary key not null,			--Tên tiết
	descriptions nvarchar(200)								--Mô tả
)
GO
create table Reports
(
	reportID int identity primary key,
	display nvarchar(1000) not null,
	userID nvarchar(100) not null,
	isChecked bit default(0) --1: Đã check || 0: Chưa check 
)
GO
alter table Schedules
add
	constraint PK_Schedule
	primary key(day_, roomID,shiftName,userID)
go
alter table Computers
add
	constraint fk_Computer_Room
	foreign key(roomID)
	references Rooms(roomID)
go
alter table Schedules
add
	constraint fk_Schedules_Room
	foreign key(roomID)
	references Rooms(roomID),
	constraint fk_Schedules_Shifts
	foreign key (shiftName)
	references Shifts(shiftName),
	constraint Shedules_User
	foreign key (userID)
	references Users(userID)
GO
alter table Reports
add
	constraint fk_Report_User
	foreign key(userID)
	references Users(userID)
GO
Insert into Shifts values
('C1','7h-7h50'),
('C2','8h-8h50'),
('C3','9h-9h50'),
('C4','10h-10h50'),
('C5','11hh-11h50'),
('C6','12h30-13h20'),
('C7','13h30-14h20'),
('C8','14h30-15h20'),
('C9','15h30-16h20'),
('C10','16h30-17h20')

Insert into Users(userID,passWords,name, roles) values('cuongtruek','cung6ama','Nguyễn Lê Tuấn Cương','Giảng viên')
Insert into Users(userID,passWords,name, roles) values('vomuoi','123456','Võ Mười','Quản lí')

Insert into Reports(display,userID,isChecked) values('Phòng 3: máy 1, máy 2, máy 3','cuongtruek',1)
Insert into Reports(display,userID,isChecked) values('Phòng 2: máy 1, máy 2, máy 3','cuongtruek',0)
Insert into Reports(display,userID,isChecked) values('Phòng 5: máy 1, máy 2, máy 3','cuongtruek',1)


Insert into Rooms values
(1,'Phòng 1'),
(2,'Phòng 2'),
(3,'Phòng 3'),
(4,'Phòng 4'),
(5,'Phòng 5'),
(6,'Phòng 6'),
(7,'Phòng 7'),
(8,'Phòng 8'),
(9,'Phòng 9'),
(10,'Phòng 10')

Insert into Computers(pcID,roomID) values
(1,1),(2,1),(3,1),(4,1),(5,1),
(1,2),(2,2),(3,2),(4,2),(5,2),
(1,3),(2,3),(3,3),(4,3),(5,3),
(1,4),(2,4),(3,4),(4,4),(5,4),
(1,5),(2,5),(3,5),(4,5),(5,5),
(1,6),(2,6),(3,6),(4,6),(5,6),
(1,7),(2,7),(3,7),(4,7),(5,7),
(1,8),(2,8),(3,8),(4,8),(5,8),
(1,9),(2,9),(3,9),(4,9),(5,9),
(1,10),(2,10),(3,10),(4,10),(5,10)

Insert into Schedules values('2020/06/02',1,'C1','cuongtruek'),('2020/06/03',1,'C1','cuongtruek')

Create PROC USP_Login
@userID nvarchar(100), @passWords nvarchar(1000)
AS
Begin
	Select * from Users Where userID = @userID AND passWords = @passWords
End
Update Reports Set isChecked = 1 Where;