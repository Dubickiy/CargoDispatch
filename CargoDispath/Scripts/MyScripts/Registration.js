$(function () {
    $("#registration").submit(function (e) {
        e.preventDefault();
        
        var user = {
            Name: $("#userName").val(),
            Surname: $("#userSurname").val(),
            Email: $("#userMail").val(),
            Password: $("#userPass").val(),
            ConfirmPassword: $("#userPassConfirm").val()
        };
        sessionStorage.setItem("user", JSON.stringify(user));
        $.ajax({
            url: "/Account/Register",
            data: JSON.stringify(user),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            success: function () {
                sessionStorage.clear();
            },
            error: function () {
                var userObject = JSON.parse(sessionStorage.getItem("user"));
                $("#userName").val(userObject.Name);
                $("#userSurname").val(userObject.Surname);
            }
           
        });
    });
})