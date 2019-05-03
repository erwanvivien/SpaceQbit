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
	$("#gifP").attr("src", "image/logofreeze.jpg");
},7000);

setTimeout(function () {
	$("#gifC").attr("src", "image/logofreeze.jpg");
}, 7000);


window.onscroll = function() {myFunction()};

var navbar = document.getElementById("navbar");
var sticky = navbar.offsetTop;

function myFunction() {
  if (window.pageYOffset >= sticky) {
    navbar.classList.add("sticky")
  } else {
    navbar.classList.remove("sticky");
  }
}



const docStyle = document.documentElement.style
const aElem = document.querySelector('a')
const boundingClientRect = aElem.getBoundingClientRect()

aElem.onmousemove = function(e) {

    const x = e.clientX - boundingClientRect.left
    const y = e.clientY - boundingClientRect.top

    const xc = boundingClientRect.width/2
    const yc = boundingClientRect.height/2

    const dx = x - xc
    const dy = y - yc

    docStyle.setProperty('--rx', `${ dy/-1 }deg`)
    docStyle.setProperty('--ry', `${ dx/10 }deg`)

}

aElem.onmouseleave = function(e) {

    docStyle.setProperty('--ty', '0')
    docStyle.setProperty('--rx', '0')
    docStyle.setProperty('--ry', '0')

}

aElem.onmousedown = function(e) {

    docStyle.setProperty('--tz', '-25px')

}

document.body.onmouseup = function(e) {

    docStyle.setProperty('--tz', '-12px')

}
