function Validate() {
    var email = ValidateEmail();
    var password = ValidatePassword();
    if (email && password) {
        return true;
    }
    return false;
}
function ValidatePassword() {
    var inputText = document.loginform.Password;
    if (inputText.value == "") {
        $('#Password').attr("class", "input-group has-error");
        return false;
    } else {
        $('#Password').attr("class", "input-group has-success");
        return true;
    }
}
function ValidateEmail() {
    var inputText = document.loginform.Email;
    var mailformat = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    if (inputText.value.match(mailformat)) {
        $('#Email').attr("class", "input-group has-success");
        return true;
    } else {
        $('#Email').attr("class", "input-group has-error");
        return false;
    }

}