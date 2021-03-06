use db_forcomp
--资讯
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
insert into fg_news values('title','zhaiyao','内容','img',0,123,1,0,getdate())
select * from fg_news order by sort,time desc

--产品栏目
--drop table fg_pro_category
create table fg_pro_category(
	id int primary key identity,
	title varchar(100),
	img varchar(max),	--图片
	img2 varchar(max),	--选中图片
	parent_id int,
	sort int,
	is_sys tinyint
)
insert into fg_pro_category values('title','','',1,0,1)
select * from fg_pro_category

select count(1) from fg_article_category

--用户表
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
--alter table fg_user add amount decimal(10,3)
select * from fg_user

--浏览,点赞
--drop table fg_news_view
create table fg_news_view(
	id int primary key identity,
	user_id int,
	isPN int,		--产品/新闻 1,2
	type int,		--浏览/点赞收藏 1,2
	news_id int,	--所属id
	time datetime default getdate()
)
select * from fg_news_view
--delete  from fg_news_view where id=53 user_id=0 or news_id=0

--评论表
--drop table fg_news_commend
create table fg_news_commend(
	id int primary key identity,
	user_id int,
	name nvarchar(100),
	avatar nvarchar(200),
	cont nvarchar(max),
	isPN int,		--产品/新闻 1,2
	news_id int,
	isHide int,
	time datetime default getdate()
)
insert into fg_news_commend values(1,'123','123','cont',1,1,1,getdate())
select * from fg_news_commend

--产品表
--drop table fg_product
create table fg_product(
	id int primary key identity,
	category int,
	title nvarchar(100),
	img nvarchar(200),
	cont nvarchar(max),

	lat nvarchar(30),			--纬度
	lon nvarchar(30),			--经度
	city nvarchar(50),		--城市
	addr nvarchar(200),		--详细地址
	sort int,
	user_id int,		--客户经理
	status int,			--产品状态 1待审核，2审核通过，3审核失败
	pass_time datetime,
	add_time datetime default getdate()
)
select * from fg_product
select distinct(city) from  fg_product 
--alter table fg_product add sort int 

/*
select * from fg_news where title like '%news%'
*/
use db_forcomp

select * from fg_product where city='上海市'
select distinct(city) from fg_product 


select * from fg_news_commend where news_id in(select id from fg_product where user_id=1) and isPN=1 order by time desc

SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY ) as row_number, * from [fg_product]) AS T WHERE row_number between 1 and 13

select * from fg_product
select * from fg_news
select * from fg_news_view where type=1 and isPN=2 and user_id=1

--积分
--drop table fg_point
create table fg_point(
	id int primary key identity,
	user_id int,
	value int,
	remark nvarchar(100),
	add_time datetime
)
select * from fg_point

--产品经理申请表
--drop table fg_user_pm
create table fg_user_pm(
	id int primary key identity,
	user_id int,
	name varchar(100),
	sex int,
	origin nvarchar(100),		--籍贯
	phone nvarchar(100),
	comName nvarchar(100),		--公司名
	job nvarchar(100),			--岗位
	year int,					--入职年份
	jobImg nvarchar(max),		--工牌照片
	img nvarchar(max),			--生活照
	status int,					--1待审核 2审核通过 3审核不通过
	add_time datetime,
	pass_time datetime
)
select * from fg_user_pm

select getdate()

--签到表
--drop table fg_user_sign
create table fg_user_sign(
	id int primary key identity,
	user_id int,
	time datetime,
	day int
)
insert into fg_user_sign values(1,GETDATE(),1)
select * from fg_user_sign
select * from fg_point
select * from fg_user_sign where DateDiff(dd,time,getdate())=1


--分享表(群)
--drop table fg_share_log
create table fg_share_log(
	id int primary key identity,
	user_id int,
	time datetime
)
select * from fg_share_log

--drop table fg_call_pm
create table fg_call_pm(
	id int primary key identity,
	user_id int,
	call_id int,
	time datetime
)
select * from fg_call_pm

--评价表
--drop table fg_assess
create table fg_assess(
	id int primary key identity,
	user_id int,
	pm_id int,
	value int,
	remark nvarchar(max),
	time datetime
)
select * from fg_assess where user_id=1 and pm_id=1

select avg(value) as val,count(1) as call from fg_assess where pm_id=2

--金额变化表
--drop table fg_amount
create table fg_amount(
	id int primary key identity,
	user_id int,
	type int,
	amount decimal(10,3),
	remark nvarchar(max),
	time datetime
)
select * from fg_user
select * from fg_amount
