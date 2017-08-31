
var itemNameList = new Array();
var itemQuantityList = new Array();
var itemPriceList = new Array();
var itemList = new Array(itemQuantityList, itemNameList, itemPriceList);
var totalPrice = 0;

$(document).ready(function () {
    $("#placeOrderBtn").hover(function () {
        var id = $(this).attr("id");
        document.getElementById("placeOrderBtn").innerHTML = "Place my order »»";
    }, function () {
        var id = $(this).attr("id");
        document.getElementById("placeOrderBtn").innerHTML = "Place my order »";
    });
});

function addItem(value) {
    var name = document.getElementById("n" + value).innerHTML;
    var price = Number($.trim(document.getElementById("p" + value).innerHTML));
    if (itemList[0].length > 0) {
        var hasRepeatedItem = false;
        for (var i = 0; i < itemList[0].length; i++) {
            if (itemList[1][i] === name) {
                hasRepeatedItem = true;
                itemList[0][i]++;
                itemList[2][i] = itemList[2][i] + price;
                totalPrice += price;
            }
        }
        if (!hasRepeatedItem) {
            itemList[0].push(1);
            itemList[1].push(name);
            itemList[2].push(price);
            totalPrice += price;
        }
    } else {
        itemList[0].push(1);
        itemList[1].push(name);
        itemList[2].push(price);
        totalPrice += price;
    }
    refreshPage();
}

function refreshPage() {
    $("#orderItem").empty();
    if (itemList[0].length > 0) {
        for (var i = 0; i < itemList[0].length; i++) {
            $("#orderItem").prepend("<tr class='eachOrderItem'>" +
                "<td class='quantity'>" + itemList[0][i] + "x" + "</td>" +
                "<td class='myName'>" + itemList[1][i] + "</td>" +
                "<td class='myPrice' id='" + "order" + i + "'>" + itemList[2][i] + ".00</td>" +
                "<td><button class='btn btn-success removeBtn' type='button' onclick='removeItem(this.value)' value=" + i + ">-</button>" +
                "</tr>");
        }
    }
    document.getElementById("totalPrice").innerHTML = "$" + totalPrice + ".00";
}

function removeItem(index) {
    totalPrice -= itemList[2][index];
    itemList[0].splice(index, 1);
    itemList[1].splice(index, 1);
    itemList[2].splice(index, 1);
    refreshPage();
}

function postOrders() {
    if (itemList[0].length > 0) {
        var postData = {
            names: itemList[1],
            price: itemList[2],
            quantity: itemList[0]
        };
        $.ajax({
            type: "POST",
            url: "/FoodOrder/SaveOrderItems",
            data: postData,
            success: function() {
                window.location.href = "/FoodOrder/OrderInfo";
            },
            dataType: "json",
            traditional: true
        });
    } else {
        alert("Nothing in your order");
    }
}

function setHoverEvent() {
    $(".eachOrderItem").hover(function () {
        var id = $(this).attr("id");
        var val = $(this).get(0).innerHTML;

    }, function () {
        var id = $(this).attr("id");
        var val = $(this).get(0).innerHTML;
    });
}