use db_forcomp
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
insert into fg_news values('title','zhaiyao','ÄÚÈÝ','img',0,123,1,0,getdate())
select * from fg_news order by sort,time desc

--drop table fg_pro_category
create table fg_pro_category(
	id int primary key identity,
	title varchar(100),
	img varchar(max),	--Í¼Æ¬
	img2 varchar(max),	--Ñ¡ÖÐÍ¼Æ¬
	parent_id int,
	sort int,
	is_sys tinyint
)
insert into fg_pro_category values('title','','',1,0,1)
select * from fg_pro_category

select count(1) from fg_article_category