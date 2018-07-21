function ListStation() {
    stat = document.getElementById('stat');
    var list = document.getElementsByClassName('station list-group-item list-group-item-action');
    for (i = 0; i < list.length; i++) {
        if (list[i].innerHTML.toUpperCase().latinize().indexOf(stat.value.toUpperCase().latinize()) > -1) {
            list[i].style.display = "block";
        }
        else {
            list[i].style.display = "none";
        }
    }}