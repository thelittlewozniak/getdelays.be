function ListStationFrom() {
    stat = document.getElementById('statFrom');
    console.log(stat.value);
    var list = document.getElementsByClassName('stationFrom');
    for (i = 0; i < list.length; i++) {
        if (list[i].innerHTML.indexOf(stat.value) > -1) {
            list[i].style.display = "";
        } else {
            list[i].style.display = "none";
        }
    }
}
function ListStationTo() {
    stat = document.getElementById('statTo');
    console.log(stat.value);
    var list = document.getElementsByClassName('stationTo');
    for (i = 0; i < list.length; i++) {
        if (list[i].innerHTML.indexOf(stat.value) > -1) {
            list[i].style.display = "";
        } else {
            list[i].style.display = "none";
        }
    }
}
function SelectStation(name, sens) {
    if (sens == "from") {
        statfrom = document.getElementById('statFrom');
        statfrom.value = name;
        var list = document.getElementsByClassName('stationFrom');
        for (i = 0; i < list.length; i++) {
            list[i].style.display = "none";
        }
    }
    if (sens == "to") {
        statto = document.getElementById('statTo');
        statto.value = name;
        var list = document.getElementsByClassName('stationTo');
        for (i = 0; i < list.length; i++) {
            list[i].style.display = "none";
        }

    }
}