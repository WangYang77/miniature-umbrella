use master
go
if exists (select * from sys.databases where name='Test')
drop database Test
go

create database Test 
go

use Test
go

--(任务表)
create table Task 
(
	TaskID int primary key identity(1,1) not null, 
	name varchar(20) not null  , 
	passward int not null, 
	isdelete int check(isdelete=0 or isdelete=1) default(0),
	sex char(2) not null,
	tim datetime default(getdate()),
	age int not null, 
)
go

insert into Task values('张三',123456,default,'男',default,18)
insert into Task values('李四',123,default,'男',default,20)
insert into Task values('王五',456,default,'女',default,19)
insert into Task values('赵六',789,default,'男',default,21)




if exists (select * from sys.procedures where name='Tasksel')
drop proc Tasksel
go

create proc Tasksel
as
	select * from Task 
go

exec Tasksel

select * from Task where name='张三'  AND passward='123456' and  isdelete=0

select  sex,COUNT(sex) as Tcount from Task  group by sex
select * from
(select ROW_NUMBER() over(order by TaskID) as rows,Name from Task) U
where rows between 1 and 3;



if exists (select * from sys.procedures where name='Tasksel')
drop proc Tasksel
go

create proc PRO_Paging
--从第几条数据开始显示
@beginPos int,
--显示到第几条数据结束
@endPos int
as
 BEGIN
	with A as( 
	select  row_number() over(order by TaskID) as rowNumber,* from Task
	) 
	select * from A where A.rowNumber between @beginPos and @endPos 
	END
go   

exec    PRO_Paging    2,4


