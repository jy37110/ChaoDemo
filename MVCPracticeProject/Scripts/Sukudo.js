var selected;
var selectedId;
var undoId;
var timer;
var time;
var score;
var difficulty;

$(document).ready(function() {
    init();
    $(".region").hover(function () {
        var id = $(this).attr("id");
        var val = $(this).get(0).innerHTML;
        if(document.getElementById(id).innerHTML !== "") showRelevant(val);
    }, function () {
        var id = $(this).attr("id");
        var val = $(this).get(0).innerHTML;
        if (document.getElementById(id).innerHTML !== "") cleanRelevant(val);
    });
});

function reset() {
    init();
}

function showRelevant(val) {
    for (var i = 0; i < 9; i++) {
        for (var j = 0; j < 9; j++) {
            var id = i + "," + j;
            if (document.getElementById(id).innerHTML === val) {
                document.getElementById(id).style.color = "black";
                document.getElementById(id).style.fontSize = "27px";
                document.getElementById(id).style.fontWeight = "bold";
            }
        }
    }
}

function cleanRelevant(val) {
    for (var i = 0; i < 9; i++) {
        for (var j = 0; j < 9; j++) {
            var id = i + "," + j;
            if (document.getElementById(id).innerHTML === val) {
                document.getElementById(id).style.color = "white";
                document.getElementById(id).style.fontSize = "20px";
                document.getElementById(id).style.fontWeight = "normal";
            }
        }
    }
}

function undo() {
    if (undoId.length > 0 && score >= 500) {
        document.getElementById(undoId.pop()).innerHTML = "";
        if (selectedId !== null) document.getElementById(selectedId).innerHTML = "";
        selectedId = null;
        selected = false;
        score = score - 500;
        document.getElementById("gameScore").innerHTML = "Score: " + score;
    } else if (undoId.length <= 0) {
        displayMsg("You have nothing to undo.");
    } else {
        displayMsg("You will need to spend 500 score to perform a undo option.");
    }
}

function gameover() {
    alert("Game Over!");
    init();
}

function win() {
    var msg =
        "Congratulations! you win the game! \n" +
            "Your final score is: " +
            score +
            "\nThe time you have spend is: " +
            time +
            "\nThanks for playing!";
    alert(msg);
    init();
}

function init() {
    for (var i = 0; i < 9; i++) {
        for (var k = 0; k < 9; k++) {
            var id = i.toString() + "," + k.toString();
            document.getElementById(id).innerHTML = "";
            document.getElementById(id).disabled = true;
        }
        document.getElementById(i).disabled = true;
    }
    document.getElementById("dropdownMenu1").disabled = false;
    document.getElementById("startBtn").disabled = false;
    cleanErrMsg();
    stopTimer();
    initTimer();
    score = 0;
    difficulty = null;
    undoId = new Array();
    selected = false;
    selectedId = null;
    document.getElementById("gameScore").innerHTML = "Score: " + score;
    document.getElementById("selectedVal").innerHTML =  "";
}

function startGame() {
    if (document.getElementById("selectedVal").innerHTML === "") {
        displayMsg("Please select difficulty first!");
        return;
    }
    if (document.getElementById("alermMsg").innerHTML !== "") {
        cleanErrMsg();
    }
    if (timer !== null) {
        stopTimer(timer);
    }
    startTimer();
    var boardArr;
    if (difficulty === "Easy") {
        boardArr = getEasyBoard();
    } else if (difficulty === "Normal") {
        boardArr = getNormalBoard();
    } else if (difficulty === "Hard") {
        boardArr = getHardBoard();
    }

    for (var p = 0; p < 9; p++) {
        for (var k = 0; k < 9; k++) {
            var id = p.toString() + "," + k.toString();
            if (boardArr[p][k] === 0) document.getElementById(id).innerHTML = "";
            else document.getElementById(id).innerHTML = boardArr[p][k];
            document.getElementById(id).disabled = false;
        }
        document.getElementById(p).disabled = false;
    }
    document.getElementById("dropdownMenu1").disabled = true;
    document.getElementById("startBtn").disabled = true;
}

function difficultySelected(val) {
    difficulty = val;
    document.getElementById("selectedVal").innerHTML = "Current: " + val;
}

function selectTarget(val, id) {
    if (selected && document.getElementById(id).innerHTML === "") {
        document.getElementById(selectedId).innerHTML = "";
        selectedId = id;
        selected = true;
        document.getElementById(id).innerHTML = "?";
    } else if (document.getElementById(id).innerHTML === "") {
        selectedId = id;
        document.getElementById(id).innerHTML = "?";
        selected = true;
    } else if (selected && document.getElementById(id).innerHTML !== "") {
        document.getElementById(selectedId).innerHTML = "";
        selected = false;
        selectedId = null;
    }
}

function changeValue(val) {
    if (selected) {
        cleanErrMsg();
        document.getElementById(selectedId).innerHTML = val;
        selected = false;
        undoId.push(selectedId);
        selectedId = null;
        if (difficulty === "Easy") {
            score += 100;
        } else if (difficulty === "Normal") {
            score += 200;
        } else if (difficulty === "Hard") {
            score += 300;
        }
        document.getElementById("gameScore").innerHTML = "Score: " + score;
        var boardStr = getBoardStr();
        verifyBoard(boardStr);
    }
}


function verifyBoard(boardStr) {
    var xmlhttp;
    if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
        xmlhttp = new XMLHttpRequest();
    }
    else {// code for IE6, IE5
        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }
    xmlhttp.onreadystatechange = function () {
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
            var stateCode = xmlhttp.responseText.replace(/\s+/g,"");
            if (stateCode === "2") {
                gameover();
            } else if (stateCode === "3") {
                win();
            }
        }
    }
    xmlhttp.open("GET", "/Games/SukudoCheckBoard?boardValue=" + boardStr, true);
    xmlhttp.send();
}

function getBoardStr() {
    var boardString = "";
    for (var i = 0; i < 9; i++) {
        for (var k = 0; k < 9; k++) {
            var id = i.toString() + "," + k.toString();
            if (document.getElementById(id).innerHTML === "") {
                if (i === 8 && k === 8) boardString += "0";
                else boardString += "0,";
            }
            else boardString += document.getElementById(id).innerHTML + ",";
        }
    }
    return boardString;
}

function startTimer() {
    var startTime = new Date().getTime();
    timer = setInterval(function () {
        var now = new Date().getTime();
        var distance = now - startTime;
        var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
        var seconds = Math.floor((distance % (1000 * 60)) / 1000);
        if (minutes < 10) minutes = "0" + minutes;
        if (seconds < 10) seconds = "0" + seconds;
        time = minutes + ":" + seconds;
        document.getElementById("gameTime").innerHTML = "Time: " + time;
    }, 1000);
}

function stopTimer() {
    if(timer != null) clearInterval(timer);
}

function initTimer() {
    timer = null;
    time = "00:00";
    document.getElementById("gameTime").innerHTML = "Time: " + time;
}

function displayMsg(msg) {
    $("#alermMsg").html("<div id='alerm' class='alert alert-warning'>" +
        "<a href='#' class='close' data-dismiss='alert'>" +
        "&times;" +
        "</a>" +
        msg +
        "</div>");
}

function cleanErrMsg() {
    document.getElementById("alermMsg").innerHTML = "";
}
