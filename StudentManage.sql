

use master 
go
--�������ݿ�
if exists(select * from sysdatabases where name='StudentManage')
drop database StudentManage
go
create database StudentManage
go 
use StudentManage
go 
--����ѧ����
if exists(select * from sysobjects where name='Student')
drop table Student
create table Student
(
Id int primary key identity(1,1),
firstName varchar(50) not null default '',
lastName varchar(50) not null default '',
email varchar(50) not null default '',
age int not null default 0
)