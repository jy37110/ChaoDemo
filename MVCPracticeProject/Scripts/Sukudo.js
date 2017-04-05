var selected = false;
var selectedId = null;
var undoId = new Array();
var timer;

window.onload = init;


function undo() {
    if (undoId.length > 0) {
        document.getElementById(undoId.pop()).innerHTML = "";
        document.getElementById(selectedId).innerHTML = "";
        selectedId = null;
        selected = false;
    }
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
}

function startGame() {
    if (document.getElementById("selectedVal").innerHTML === "") {
        document.getElementById("alermMsg").innerHTML = "Select Difficulty to Start!";
        return;
    }
    if (document.getElementById("alermMsg").innerHTML !== "") {
        document.getElementById("alermMsg").innerHTML = "";
    }

    timer = startTimer();
    var boardArr = new Array();
    for (var i = 0; i < 9; i++) {
        boardArr[i] = new Array();
        for (var j = 0; j < 9; j++) {
            boardArr[i][j] = 0;
        }
    }
    boardArr[0][4] = 9;
    boardArr[0][5] = 3;
    boardArr[0][6] = 6;
    boardArr[0][7] = 1;

    boardArr[1][3] = 7;
    boardArr[1][4] = 5;
    boardArr[1][5] = 2;
    boardArr[1][8] = 9;

    boardArr[2][3] = 8;
    boardArr[2][5] = 6;
    boardArr[2][7] = 2;

    boardArr[3][1] = 4;
    boardArr[3][2] = 1;
    boardArr[3][3] = 2;
    boardArr[3][4] = 8;
    boardArr[3][7] = 7;

    boardArr[4][1] = 2;
    boardArr[4][2] = 8;
    boardArr[4][3] = 6;
    boardArr[4][7] = 5;

    boardArr[5][1] = 9;
    boardArr[5][2] = 6;
    boardArr[5][3] = 1;
    boardArr[5][7] = 3;

    boardArr[6][1] = 1;
    boardArr[6][3] = 5;
    boardArr[6][5] = 7;
    boardArr[6][6] = 8;
    boardArr[6][7] = 4;

    boardArr[7][0] = 4;
    boardArr[7][1] = 5;
    boardArr[7][3] = 3;
    boardArr[7][6] = 1;

    boardArr[8][1] = 3;
    boardArr[8][2] = 2;
    boardArr[8][3] = 9;
    boardArr[8][4] = 4;
    boardArr[8][6] = 7;

    for (var p = 0; p < 9; p++) {
        for (var k = 0; k < 9; k++) {
            var id = p.toString() + "," + k.toString();
            if (boardArr[p][k] === 0) document.getElementById(id).innerHTML = "";
            else document.getElementById(id).innerHTML = boardArr[p][k];
            document.getElementById(id).disabled = false;
        }
        document.getElementById(p).disabled = false;
    }
}

function difficultySelected(val) {
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
        document.getElementById(selectedId).innerHTML = val;
        selected = false;
        undoId.push(selectedId);
        selectedId = null;
    }
}

function startTimer() {
    var startTime = new Date().getTime();
    var timeVar = setInterval(function () {
        var now = new Date().getTime();
        var distance = now - startTime;
        var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
        var seconds = Math.floor((distance % (1000 * 60)) / 1000);
        if (minutes < 10) minutes = "0" + minutes;
        if (seconds < 10) seconds = "0" + seconds;
        document.getElementById("gameTime").innerHTML = "Time: " + minutes + ":" + seconds;
    }, 1000);
    return timeVar;
}

function stopTimer(timeVar) {
    clearInterval(timeVar);
}

function initTimer() {
    document.getElementById("gameTime").innerHTML = "Time: 00:00";
}

function displayMsg(msg) {
    document.getElementById("alermMsg")
}