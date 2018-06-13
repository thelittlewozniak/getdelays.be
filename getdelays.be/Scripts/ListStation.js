function ListStation() {
    stat = document.getElementById('stat');
    console.log(stat.value);
    var list = document.getElementsByClassName('station');
    for (i = 0; i < list.length; i++) {
        if (list[i].innerHTML.indexOf(stat.value) > -1) {
            list[i].style.display = "";
        } else {
            list[i].style.display = "none";
        }
    }}