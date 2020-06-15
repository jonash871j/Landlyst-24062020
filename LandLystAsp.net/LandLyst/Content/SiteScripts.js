function NavBarFunc(height, opacity, top) {
    document.getElementById("NavMenu").style.height = height;
    document.getElementById("NavMenu").style.opacity = opacity;
    document.getElementById("NavMenu").style.top = top;
}

function twoChecks(checkNr, ElementID1, ElementID2) {
    var Element1 = document.getElementById(ElementID1);
    var Element2 = document.getElementById(ElementID2);
    if (Element1.checked == true && Element2.checked == true) {
        if (checkNr == 0) {
            Element2.checked = false;
        }
        else if (checkNr == 1) {
            Element1.checked = false;
        }
    }
}

function VeiwBox(boxNr, ElementID1, ElementID2) {
    var Element1 = document.getElementById(ElementID1);
    var Element2 = document.getElementById(ElementID2);
    if (boxNr == 0) {
        Element1.style.display = "block";
        Element2.style.display = "none";
    }
    else if (boxNr == 1) {
        Element1.style.display = "none";
        Element2.style.display = "block";
    }

}