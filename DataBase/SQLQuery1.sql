use db_forcomp
--��Ѷ
--drop table fg_news
create table fg_news(
	id int primary key identity,
	title varchar(100),
	zhaiyao varchar(255),
	cont varchar(max),
	img varchar(255),
	sort int,
	click int,
	is_msg tinyint,
	is_hide tinyint,
	time datetime default getdate()
)
insert into fg_news values('title','zhaiyao','����','img',0,123,1,0,getdate())
select * from fg_news order by sort,time desc

--��Ʒ��Ŀ
--drop table fg_pro_category
create table fg_pro_category(
	id int primary key identity,
	title varchar(100),
	img varchar(max),	--ͼƬ
	img2 varchar(max),	--ѡ��ͼƬ
	parent_id int,
	sort int,
	is_sys tinyint
)
insert into fg_pro_category values('title','','',1,0,1)
select * from fg_pro_category

select count(1) from fg_article_category

--�û���
--drop table fg_user
create table fg_user(
	id int primary key identity,
	avatar varchar(200),
	nickname varchar(100),
	openid varchar(50),
	unionid varchar(50),
	point int,
	img varchar(100),
	level int,
	parent_id int,
	phone varchar(20),
	email varchar(32),
	sex int,
	area varchar(100),
	status int,
	reg_time datetime,
	login_time datetime
)
select * from fg_user

--���,����
--drop table fg_news_view
create table fg_news_view(
	id int primary key identity,
	user_id int,
	isPN int,		--��Ʒ/���� 1,2
	type int,		--���/�����ղ� 1,2
	news_id int,	--����id
	time datetime default getdate()
)
select * from fg_news_view
--delete  from fg_news_view where id=53 user_id=0 or news_id=0

--���۱�
--drop table fg_news_commend
create table fg_news_commend(
	id int primary key identity,
	user_id int,
	name nvarchar(100),
	avatar nvarchar(200),
	cont nvarchar(max),
	isPN int,		--��Ʒ/���� 1,2
	news_id int,
	isHide int,
	time datetime default getdate()
)
insert into fg_news_commend values(1,'123','123','cont',1,1,1,getdate())
select * from fg_news_commend

--��Ʒ��
--drop table fg_product
create table fg_product(
	id int primary key identity,
	category int,
	title nvarchar(100),
	img nvarchar(200),
	cont nvarchar(max),

	lat nvarchar(30),			--γ��
	lon nvarchar(30),			--����
	city nvarchar(50),		--����
	addr nvarchar(200),		--��ϸ��ַ
	sort int,
	user_id int,		--�ͻ�����
	status int,			--��Ʒ״̬ 1����ˣ�2���ͨ����3���ʧ��
	pass_time datetime,
	add_time datetime default getdate()
)
select * from fg_product
--alter table fg_product add sort int

/*
select * from fg_news where title like '%news%'
*/
use db_forcomp

select * from fg_product where city='�Ϻ���'
select distinct(city) from fg_product 


select * from fg_news_commend where news_id in(select id from fg_product where user_id=1) and isPN=1 order by time desc

SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY ) as row_number, * from [fg_product]) AS T WHERE row_number between 1 and 13

select * from fg_product
select * from fg_news
select * from fg_news_view where type=1 and isPN=2 and user_id=1

--����
--drop table fg_point
create table fg_point(
	id int primary key identity,
	user_id int,
	value int,
	remark nvarchar(100),
	add_time datetime
)
select * from fg_point

--drop table fg_user_pm
create table fg_user_pm(
	id int primary key identity,
	user_id int,
	name varchar(100),
	sex int,
	origin nvarchar(100),		--����
	phone nvarchar(100),
	comName nvarchar(100),		--��˾��
	job nvarchar(100),			--��λ
	year int,					--��ְ���
	jobImg nvarchar(max),		--������Ƭ
	img nvarchar(max),			--������
	status int,					--1����� 2���ͨ�� 3��˲�ͨ��
	add_time datetime,
	pass_time datetime
)
select * from fg_user_pm

select getdate()
