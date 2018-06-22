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
	avatar varchar(100),
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
select * from fg_news_view where type=2

--评论表
--drop table fg_news_commend
create table fg_news_commend(
	id int primary key identity,
	user_id int,
	name nvarchar(100),
	avatar nvarchar(100),
	cont nvarchar(max),
	isPN int,		--产品/新闻 1,2
	news_id int,
	isHide int,
	time datetime default getdate()
)
insert into fg_news_commend values(1,'123','123','cont',1,1,1,getdate())
select * from fg_news_commend



/*
select * from fg_news where title like '%news%'
*/