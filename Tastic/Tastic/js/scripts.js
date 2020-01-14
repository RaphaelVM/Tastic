// Hamburger menu funcs
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

        if (pass.value == passHerh.value) { // Passwords match let the user register
            if (!passErr.classList.contains("invisible-cust")) {
                passErr.classList.add("invisible-cust");

                passHerh.style.borderColor = "transparent";

                btnRegister.disabled = false;
            }
        } else { // Passwords don't match don't let the user register
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

// Make a webrequest to add the product to the shoppingcart
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

// Make a webrequest to change the amount of an item
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

// Make a webrequest to remove the item from the shoppingcart
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

            // Also remove the element in which it resided
            document.getElementById("item_" + data.d).remove();

            // When there are no more items in the cart show the standard "no items"
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

// When a user wants to pay and wants to use the wallet we have to update some html, do that here
function retractWallet(walletAmount) {
    setTimeout(function () { 

        if (document.getElementById("useWallet").checked) {
            var totalAmount = /([€ ]+)(.+)/.exec(document.getElementById("subtotalAmount").innerHTML)[2].replace(",", ".");
            var payFullWithWallet = false;

            // the amount in the wallet is lower than the amount which is in the cart
            if (walletAmount < totalAmount) {
                // Remove the wallet amount from the total amount
                var newAmount = totalAmount - walletAmount;
            } else if (walletAmount == totalAmount) { // The wallet amount and the total amount are equal
                // Set the total amount to 0 and payFullWithWallet to 1
                var newAmount = 0.00;
                payFullWithWallet = true;
            } else if (walletAmount > totalAmount) { // The wallet amount is bigger
                // Set the total amount to 0 and payFullWithWallet to 1
                var newAmount = 0.00;
                payFullWithWallet = true;
            }

            // When the total amount of the order can be paid with what's in the wallet we don't need to show the payment method
            if (payFullWithWallet) {
                document.getElementById("paymentMethod").style.display = "none";
            } else {
                document.getElementById("paymentMethod").style.display = "block";
            }

            // Change the text of the total amount to the new total amount
            document.getElementById("totalAmount").innerHTML = "Totaal: &euro; " + newAmount.toFixed(2).toString().replace(".", ",");
        } else {
            // Is the user not paying with his/her wallet then show the paymentmethod dropdown incase it was hidden before
            if (document.getElementById("paymentMethod").style.display == "none") {
                document.getElementById("paymentMethod").style.display = "block";
            }

            // Total = subtotal
            document.getElementById("totalAmount").innerHTML = document.getElementById("subtotalAmount").innerHTML.replace("Subtotaal: ", "Totaal: ");
        }
    }, 20);
}

// Create a webrequest for the payment of the order
function payOrder() {

    var walletAmountPaid =
        document.getElementById("subtotalAmount").innerHTML.replace("Subtotaal: €", "").replace(",", ".") - document.getElementById("totalAmount").innerHTML.replace("Totaal: €", "").replace(",", ".");

    var useWallet = document.getElementById("useWallet").checked;
    // Create a JSON string with the data we need the C# code to have
    var data = { "useWallet" : useWallet, "walletAmountPaid" : walletAmountPaid };
    $.ajax({
        type: 'POST',
        url: 'payment.aspx/createOrder',
        data: JSON.stringify(data),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (data) {
            // If the data == true then show an alert and redirect to the products.aspx page
            if (data) {
                alert("Order is aangemaakt.");

                location.href = "products.aspx";
            } else { // Something messed up so show an alert that something went wrong
                alert("Er is iets fout gegaan bij het maken van het order, probeer het opnieuw.");
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

// Not _really_ needed but it's nice
function removeFirstItem() {
    // When you choose a different option that "Kies een methode" remove that option
    if (document.getElementById("paymentMethod").options[0].value == "Kies een methode") {
        if (document.getElementById("paymentMethod").value != "Kies een methode") {
            document.getElementById("paymentMethod").options.remove(0);
        }
    }
}

// redirect to editpage
function editUser(uID) {
    location.href = "edituser.aspx?uid=" + uID;
}

function updateUser(uID) {

    var firstName = document.getElementById("txtFirstname").value;
    var lastName = document.getElementById("txtLastname").value;
    var sex = document.getElementById("ddlGeslacht").value;
    var walletAmount = document.getElementById("txtWalletAmount").value;
    var company = document.getElementById("ddlCompanies").value;
    var role = document.getElementById("ddlRoles").value; 

    // Create a JSON string with the data we need the C# code to have
    var data = { "uid": uID, "firstname": firstName, "lastname": lastName, "sex": sex, "walletamount": walletAmount, "companyid": company, "roleid": role };

    console.log(data);
    $.ajax({
        type: 'POST',
        url: 'edituser.aspx/adminEditUser',
        data: JSON.stringify(data),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (data) {
            if (data) {

                var updateUserERRPar = document.getElementById("updateUserERRPar");

                updateUserERRPar.style.display = "block";
                updateUserERRPar.style.marginTop = "10%";
                updateUserERRPar.classList.add("alert");
                updateUserERRPar.classList.add("alert-success");

                document.getElementById("lblUpdateUserERR").innerHTML =
                    "De user is aangepast, u wordt binnen 5 seconden naar de users pagina gebracht.";

                setTimeout(function () {
                    location.href = "users.aspx";
                }, 5000);
            } else {
                var updateUserERRPar = document.getElementById("updateUserERRPar");

                updateUserERRPar.style.display = "block";
                updateUserERRPar.classList.add("alert");
                updateUserERRPar.classList.add("alert-error");

                document.getElementById("lblUpdateUserERR").innerHTML =
                    "Er is iets fout gegaan met het invoeren van de user gegevens, probeer het opnieuw.";
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