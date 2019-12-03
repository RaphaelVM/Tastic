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