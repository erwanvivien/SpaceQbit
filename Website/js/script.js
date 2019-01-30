$(function() {
	$(".appear").each(function(index, element) {
		var elem = $(this);
		appearUpdate(elem, parseInt(elem.attr("duration")));
	});
});

var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

function appearUpdate(elem, ticks) {
	if(typeof($.data(elem, "text")) == "undefined")
	{
		$.data(elem, "text", elem.html());
	}
	var s = "";
	var l = $.data(elem, "text").length;
	var progress = (ticks / parseFloat(elem.attr("duration"))) * l;
	for(var i = 0; i < l; i++) {
		s += l - i <= progress && $.data(elem, "text").charAt(i) != " " ? possible.charAt(Math.floor(Math.random() * possible.length)) : $.data(elem, "text").charAt(i);
	}
	if(ticks > 0)
	{
		ticks--;
		elem.html(s);
		setTimeout(function() { appearUpdate(elem, ticks) }, parseInt(elem.attr("update")));
	}
	else
		elem.html($.data(elem, "text"));
}

function troll() {
  alert("Eh bah non je t'ai trollé!!!");
}

setTimeout(function () {
	$("#gif").attr("src", "images/logofreeze.jpg");
},7000);
