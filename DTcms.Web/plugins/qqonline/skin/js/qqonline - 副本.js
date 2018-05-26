var currentSrc = function(){
	var a=document.scripts,b;
	for(var i=a.length;i>0;i--){
		if(a[i-1].src.indexOf("qqonline.js")>-1){
			b = a[i-1].src;
			b = b.substring(0, b.lastIndexOf('/js/') + 1);
			break;
		}
	}
};
var onlineService = function(){
	var p = currentSrc();
	var f = document.createElement('link');
	f.type = "text/css";
	f.rel = "stylesheet";
	f.setAttribute("href", p+'css/qqonline.css'); 
	document.getElementsByTagName('head')[0].appendChild(f);
	//异步加载
	$.ajax({ 
		type: "POST",
		dataType: "json",
		cache:true,
		url: p.substring(0, p.lastIndexOf('/skin/') + 1)+'tools/ajax.ashx',
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
						html +='<li><a target="_blank" href="javascript:;" onclick="window.location.href=\''+url+'\'" title="'+name+'"><i><img src="'+p+'qqface/'+img+'" /></i>';
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
};
$(function(){
	onlineService();
});