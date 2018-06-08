use db_forcomp
drop table fg_news
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
insert into fg_news values('title','zhaiyao','ÄÚÈİ','img',0,123,1,0,getdate())
select * from fg_news