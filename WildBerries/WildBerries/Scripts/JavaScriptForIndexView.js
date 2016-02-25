$(function () {
    $("#CoinsHolder").load("/Home/Coins");
    $("#DrinksHolder").load("/Home/Drinks");

    $("#balanceForm").validate({
        rules: {
            balance: {
                number: true,                
            }
        },
        messages: {
            balance: {
                number: "Допускаются только цифры"
            }
        }
    });

    $("#balance").change(function () {
        if ($("#balanceForm").validate()) {
            var currentBalance = $("#balance").val();
            activateDrinks(currentBalance);
        } else {
            activateDrinks(0);
        }
    });
});

function selectCoin(sender) {
    //if ($(sender).hasClass("btn-success"))
        $("div.coin").each(function (ind, el) {
            $(el).removeClass("btn-warning");
            if ($(el).attr("data-blocked") == 1)
                $(el).addClass("btn-danger");
            else $(el).addClass("btn-success");
        });

        if ($(sender).attr("data-blocked") == 1)
            $(sender).removeClass("btn-danger");
        else $(sender).removeClass("btn-success");

        $(sender).addClass("btn-warning");

        if ($(sender).attr("data-blocked") == 1){
            $("#addCoin").attr("disabled", true);
            $("#addCoin").addClass("btn-danger");
            $("#addCoin").removeClass("btn-success");
        }
        else {
            $("#addCoin").attr("disabled", false);
            $("#addCoin").removeClass("btn-danger");
            $("#addCoin").addClass("btn-success");
        }
}

function addSelectedCoin() {
    var nominal = Number($("div.coin.btn-warning").attr("data-nominal"));
    var currentBalance = Number($("#balance").val());
    var newBalance = currentBalance+nominal;
    if (newBalance > 0)
        $("#balance").removeClass("alert-danger");
    $("#balance").val(newBalance);

    activateDrinks(newBalance);
}

function selectDrink(sender) {    
    $("div.drink").each(function (ind, el) {
        $(el).removeClass("btn-warning");
        if ($(el).attr("data-enough-money") == 0)
            $(el).addClass("btn-danger");
        else $(el).addClass("btn-success");
    });

    if ($(sender).attr("data-enough-money") == 0)
        $(sender).removeClass("btn-danger");
    else $(sender).removeClass("btn-success");

    $(sender).addClass("btn-warning");

    if ($(sender).attr("data-enough-money") == 0) {
        $("#buyDrink").attr("disabled", true);
        $("#buyDrink").addClass("btn-danger");
        $("#buyDrink").removeClass("btn-success");
    }
    else {
        $("#buyDrink").attr("disabled", false);
        $("#buyDrink").removeClass("btn-danger");
        $("#buyDrink").addClass("btn-success");
    }
}

function buyDrink() {
    //<input class="alert-danger" value=0 id="balance">
    var drinkPrice = Number($('div.drink.btn-warning').attr("data-price"));
    var currentBalance = Number($("#balance").val());
    var newBalance = currentBalance - drinkPrice;

    $("#balance").val(newBalance);
    if (newBalance == 0) {
        $("#balance").addClass("alert-danger");
    }
    
    var drinkId = $('div.drink.btn-warning').attr("data-id");
    var drinkQuantity = 1;
    $("#DrinksHolder").load('/Home/BuyDrink', { Id: drinkId, Quantity: drinkQuantity }, function () {
        activateDrinks(newBalance);
    });
    activateDrinks(newBalance);
}

function activateDrinks(newBalance) {
    $("div.drink").each(function (ind, el) {
        if (newBalance == 0 || $(el).attr("data-price") > newBalance) {
            $(el).addClass("btn-danger");
            $(el).removeClass("btn-success");
            $(el).attr("data-enough-money", 0);
        } else
        {
            $(el).removeClass("btn-danger");
            $(el).addClass("btn-success");
            $(el).attr("data-enough-money", 1);
        }
    });

    $("#buyDrink").attr("disabled", true);
}

function getChange() {
    $("#balance").val(0);
    $("#balance").addClass("alert-danger");

    activateDrinks(0);
}