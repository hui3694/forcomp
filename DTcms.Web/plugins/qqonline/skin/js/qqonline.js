;!function(window, undefined){
	"use strict";
	var ready = {
		getPath: function(){
			var js = document.scripts,
				script = js[js.length - 1],
				jsPath = script.src;
			if(script.getAttribute('merge')){
				return;
			}
			return jsPath.substring(0, jsPath.lastIndexOf('/skin/') + 1);
		}()
	};
	var config = {
		vesion: "1.0.2",
		path : ready.getPath
	};
	//程序运行
	(function run() {
		//载入css
		var head = $('head')[0],
			id = 'qqonline_css',
			timeout = 0,
			link = document.createElement('link');
		link.rel = 'stylesheet';
		link.href = config.path + 'skin/css/qqonline.css';
		link.id = id;
		if(!$('#'+ id)[0]){
		  head.appendChild(link);
		}
		//异步加载
		$.ajax({ 
			type: "POST",
			dataType: "json",
			cache:true,
			url: config.path+'tools/ajax.ashx',
			success: function(data) {
				if(data.status==1)
				{
					var	$pannel = $('<div>').addClass('qqonline qqonline_skin'+data.skin+' qqonline_w'+data.position).appendTo('body');
					$pannel.html('<div class="qqonline_hd"><i title="关闭"></i></div><div class="qqonline_bd"></div><div class="qqonline_fd"></div>');
					$pannel.find(".qqonline_hd i").on("click", function(){
						$pannel.hide();
					});
					if (!jQuery.isEmptyObject(data.list))
					{
						var name,qq,img,url,color,html;
						html = '<ul>';
						for(var i=0;i<data.list.length;i++){
							name = data.list[i].n || "QQ客服";
							qq = data.list[i].q;
							img = data.list[i].i;
							/*url = data.list[i].u || 'http://wpa.qq.com/msgrd?v=3&amp;uin='+qq+'&amp;site=qq&amp;menu=yes';*/
							url = data.list[i].u || 'tencent://message/?uin='+qq+'&Site=hexun.com/ngdao&Menu=yes ';
							color = data.list[i].c || '';
							html +='<li><a target="_blank" href="javascript:;" onclick="window.location.href=\''+url+'\'" title="'+name+'"><i><img src="'+config.path+'skin/qqface/'+img+'" /></i>';
							if (color !== undefined && color !== ''){
								html +='<span style="color:'+color+'">'+name+'</span>';
							}else{
								html +='<span>'+name+'</span>';
							}
							html +='</a></li>';
						}
						html += '</ul>';
						$pannel.find('.qqonline_bd').append('<div class="qqonline_list">'+html+'</div>');
					}
					if (data.code !== undefined && data.code !== '')
					{
						$pannel.find('.qqonline_bd').append('<div class="qqonline_code"><img src='+data.code+' /></div>');
					}
					if (data.remark !== undefined && data.remark !== '')
					{
						$pannel.find('.qqonline_bd').append('<div class="qqonline_remark">'+data.remark+'</div>');
					}
				}
			}
		});
	})();
}(window);