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

function ValidateReg() {
    var email = ValidateRegEmail();
    var password = ValidateRegPass();
    var firstname = IsEmpty("#namevalidation", document.registerform.FirstName);
    var lastname = IsEmpty("#lastnamevalidation", document.registerform.LastName);
    var birthdate = IsEmpty("#birthdatevalidation", document.registerform.BirthDate);
    var birthplace = IsEmpty("#birthplacevalidation", document.registerform.BirthPlace);
    var zipcode = IsEmpty("#zipcodevalidation", document.registerform.ZipCode);
    var telnr = IsEmpty("#telnrvalidation", document.registerform.TelNr);
    var mobilenr = IsEmpty("#mobilenrvalidation", document.registerform.MobileNr);
    var sex = IsEmpty("#sexvalidation", document.registerform.Sex);
    var street = IsEmpty("#streetvalidation", document.registerform.Street);
    if (email && password && firstname && lastname && birthplace && birthdate && zipcode && telnr && mobilenr && sex) {
        return true;
    }
    return false;
}

function ValidateRegEmail() {
    var inputText = document.registerform.Email;
    var mailformat = /^\w+([\.-]?\w+)*@@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    if (inputText.value.match(mailformat)) {
        $('#emailValidation').attr("class", "col-md-10 has-success");
        return true;
    } else {
        $('#emailValidation').attr("class", "col-md-10 has-error");
        return false;
    }
}

function ValidateRegPass() {
    var inputText = document.registerform.PassWord;
    var inputText2 = document.registerform.CheckPass;
    if (inputText.value == "") {
        $('#Passwordvalidation').attr("class", "col-md-10 has-error");
        return false;
    } else if (inputText2.value == "") {
        $('#CheckpassValidation').attr("class", "col-md-10 has-error");
        return false;
    } else if (inputText.value == inputText2.value) {
        $('#Passwordvalidation').attr("class", "col-md-10 has-success");
        $('#CheckpassValidation').attr("class", "col-md-10 has-success");
        return true;
    } else {
        $('#Passwordvalidation').attr("class", "col-md-10 has-error");
        $('#CheckpassValidation').attr("class", "col-md-10 has-error");
        return false;
    }
}

function IsEmpty(id, text) {
    if (text.value == "") {
        $(id).attr("class", "col-md-10 has-error");
        return false;
    } else {
        $(id).attr("class", "col-md-10 has-success");
        return true;
    }
}