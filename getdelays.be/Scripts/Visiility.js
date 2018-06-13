function ChangeVisibility(id)
{
    var linki = document.getElementById("linkInfo");
    console.log(linki);
    node = document.getElementById(id);
    if (node.style.visibility == "hidden" || node.style.visibility=="") {
        node.style.visibility = "visible";
        node.style.height = "auto";
        linki.innerText = "Hidden";
    }
    else {
        node.style.visibility = "hidden";
        node.style.height = "0";
        linki.innerText = "See more...";
    }
}
function Display(name,bool)
{
    var node = document.getElementsByClassName(name);
    if (bool == '0') {
        var link = document.getElementById("arr");
        if (link.innerText != "Hidden") {
            link.innerText = "Hidden";
        }
        else {
            link.innerText = "See more...";
        }
    }
    if (bool == '1') {
        var link = document.getElementById("dep");
        if (link.innerText != "Hidden") {
            link.innerText = "Hidden";
        }
        else {
            link.innerText = "See more...";
        }
    }
    for (var i = 0; i < 34; i++) {
        if (node[i].style.display == "none" || node[i].style.display=="") {
            node[i].style.display = "table-row";
        }
        else {
            node[i].style.display = "none";
        }
    }
}