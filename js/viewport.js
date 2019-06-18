function sideNav(val){

	 if(val=="close"){
	    document.getElementById("sidenav").style.width = "0";
	    document.getElementById("main").style.marginLeft = "0";
	    document.getElementById("button-collapse").setAttribute("onclick", "sideNav('open')");
	 }else if(val=="open"){
	 	document.getElementById("sidenav").style.width = "240px";
        document.getElementById("main").style.marginLeft = "240px";
        document.getElementById("button-collapse").setAttribute("onclick", "sideNav('close')");
	 }

}
function dropdown() {
    document.getElementById("myDropdown").classList.toggle("show");
}


// Close the dropdown menu if the user clicks outside of it
window.onclick = function(event) {
  if (!event.target.matches('.dropbtn')) {

    var dropdowns = document.getElementsByClassName("dropdown-content");
    var i;
    for (i = 0; i < dropdowns.length; i++) {
      var openDropdown = dropdowns[i];
      if (openDropdown.classList.contains('show')) {
        openDropdown.classList.remove('show');
      }
    }
  }
}