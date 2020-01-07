﻿// Hamburger menu funcs
function openNav() {
    document.getElementById("mySidenav").style.width = "250px";
}

function closeNav() {
    document.getElementById("mySidenav").style.width = "0";
}

// Check if the 2 inputs match eachother, if so the user can continue if not the register button is disabled.
function checkPass() {
    // Wait a very small amount of time so the value can properly be taken.
    setTimeout(function () {
        var pass = document.getElementById("txtWachtwoord");
        var passHerh = document.getElementById("txtWachtwoordHerh");

        var passErr = document.getElementById("passERR");
        var lblPass = document.getElementById("lblPass");
        var btnRegister = document.getElementById("btnRegister");

        if (pass.value == passHerh.value) {
            if (!passErr.classList.contains("invisible-cust")) {
                passErr.classList.add("invisible-cust");

                passHerh.style.borderColor = "transparent";

                btnRegister.disabled = false;
            }
        } else {
            if (passErr.classList.contains("invisible-cust")) {
                passErr.classList.remove("invisible-cust");

                lblPass.innerHTML = "Wachtwoorden komen niet overeen.";
                lblPass.classList.add("alert");
                lblPass.classList.add("alert-danger");
                passHerh.style.borderColor = "red";

                btnRegister.disabled = true;
            }
        }
    }, 20);
}

// product page
if (window.location.pathname == "/products.aspx") {
    // wait 25 miliseconds for the page to render
    setTimeout(function () {
        switch (window.location.search) {
            case "?all":
                document.getElementById("btnAlles").style.fontWeight = "bold";
                break;
            case "?broodjes":
                document.getElementById("btnBroodjes").style.fontWeight = "bold";
                break;
            case "?soepen":
                document.getElementById("btnSoepen").style.fontWeight = "bold";
                break;
            case "?snacks":
                document.getElementById("btnSnacks").style.fontWeight = "bold";
                break;
            case "?dranken":
                document.getElementById("btnDranken").style.fontWeight = "bold";
                break;
            default:
                break;
        }
    }, 25);
}

function addToCart(pID) {
    var data = { pID };

    $.ajax({
        type: 'POST',
        url: 'products.aspx/addToCart',
        data: JSON.stringify(data),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (data) {
            document.getElementById("itemsAmount").innerText = data.d;
            document.getElementById("itemsAmount").style.backgroundColor = "#0e83f3";

            setTimeout(function () {
                document.getElementById("itemsAmount").style.backgroundColor = "transparent";
            }, 2000);
        },
        error: function (data, success, error) {
            alert("Error: " + error + " || " + "Data: " + data + " || " + "Success: " + success);
            console.log(data);
            console.log(success);
            console.log(error);
        }
    });
}

function changeAmount(sciID) {

    if (document.getElementById(sciID).value < 1) {
        // TODO: change this alert to a regular error message
        alert("Aantal kan niet onder de 1 zijn");

        document.getElementById(sciID).value = 1;
    } else {
        var amount = document.getElementById(sciID).value;
        var data = { sciID, amount };

        $.ajax({
            type: 'POST',
            url: 'cart.aspx/updateAmount',
            data: JSON.stringify(data),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (data) {
                console.log(data);
            },
            error: function (data, success, error) {
                alert("Error: " + error + " || " + "Data: " + data + " || " + "Success: " + success);
                console.log(data);
                console.log(success);
                console.log(error);
            }
        });
    }
}

function removeItem(sciID) {
    var data = { sciID };

    $.ajax({
        type: 'POST',
        url: 'cart.aspx/removeItem',
        data: JSON.stringify(data),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (data) {
            document.getElementById("itemsAmount").innerHTML = data.d;

            document.getElementById("item_" + data.d).remove();

            if (document.getElementById("cartContainer").children.length == 0) {
                document.getElementById("cartContainer").innerHTML =
                    "<div class=\"products-product-container\" id=\"noproducts\">" +
                        "<div class=\"product d-flex flex-row bd-highlight align-items-center\">" +
                            "<span class=\"noProducts\">" +
                                "Er zitten geen producten in de winkelwagen" +
                            "</span>" +
                        "</div>" +
                    "</div>";
            }
        },
        error: function (data, success, error) {
            alert("Error: " + error + " || " + "Data: " + data + " || " + "Success: " + success);
            console.log(data);
            console.log(success);
            console.log(error);
        }
    });
}

function retractWallet(walletAmount) {
    setTimeout(function () { 

        if (document.getElementById("useWallet").checked) {
            var totalAmount = /([€ ]+)(.+)/.exec(document.getElementById("subtotalAmount").innerHTML)[2].replace(",", ".");
            var payFullWithWallet = false;

            if (walletAmount < totalAmount) {
                var newAmount = totalAmount - walletAmount;
            } else if (walletAmount == totalAmount) {
                var newAmount = 0.00;
                payFullWithWallet = true;
            } else if (walletAmount > totalAmount) {
                var newAmount = 0.00;
                payFullWithWallet = true;
            }

            if (payFullWithWallet) {
                document.getElementById("paymentMethod").style.display = "none";
            } else {
                document.getElementById("paymentMethod").style.display = "block";
            }

            document.getElementById("totalAmount").innerHTML = "Totaal: &euro; " + newAmount.toFixed(2).toString().replace(".", ",");
        } else {
            if (document.getElementById("paymentMethod").style.display == "none") {
                document.getElementById("paymentMethod").style.display = "block";
            }

            document.getElementById("totalAmount").innerHTML = document.getElementById("subtotalAmount").innerHTML.replace("Subtotaal: ", "Totaal: ");
        }
    }, 20);
}

function payOrder() {
    var useWallet = document.getElementById("useWallet").checked;
    var data = { useWallet };
    $.ajax({
        type: 'POST',
        url: 'payment.aspx/createOrder',
        data: JSON.stringify(data),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (data) {

        },
        error: function (data, success, error) {
            alert("Error: " + error + " || " + "Data: " + data + " || " + "Success: " + success);
            console.log(data);
            console.log(success);
            console.log(error);
        }
    });
}

function removeFirstItem() {
    // When you choose a different option that "Kies een methode" remove that option
    if (document.getElementById("paymentMethod").options[0].value == "Kies een methode") {
        if (document.getElementById("paymentMethod").value != "Kies een methode") {
            document.getElementById("paymentMethod").options.remove(0);
        }
    }
}