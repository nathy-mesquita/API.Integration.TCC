var changeFavicon = function () {
    var favicon = undefined;
    var nodeList = document.getElementsByTagName("link");
    for (var i = 0; i < nodeList.length; i++) {
        if (nodeList[i].getAttribute("rel") === "icon" || nodeList[i].getAttribute("rel") === "shortcut icon") {
            favicon = nodeList[i];
            favicon["href"] = "https://unicarioca.edu.br/sites/default/files/logo_unicariocadigital_vertical_2021-1.png";
        }
    }
    return favicon;
};
changeFavicon();