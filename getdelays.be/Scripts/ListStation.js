function ListStation() {
    stat = document.getElementById('stat');
    var list = document.getElementsByClassName('station');
    for (i = 0; i < list.length; i++) {
        if (list[i].innerHTML.toUpperCase().latinize().indexOf(stat.value.toUpperCase().latinize()) > -1) {
            list[i].style.display = "";
        } else {
            list[i].style.display = "none";
        }
    }}