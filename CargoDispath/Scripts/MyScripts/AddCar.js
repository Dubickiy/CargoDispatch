var usedAu1 = userId;
"use strict";
$(function () {
    ShowAllVehicle();
    showAllUserCar();
    $("#form3").submit(function (e) {
        e.preventDefault();
        AddVehicle();

    });
    $("#tb6").on("click", "#infoCar", function () {
        var i = $(this).closest('tr').attr('data-id');
        console.log(i);
        window.location.href = "/Search/SearchCarInfo?id=" + i;


    });
    $("#search1").click(function () {
        SearchCar();
    });
    $("#fromcountry1").change(function () {
        var country = "";
        $("#fromcountry1 option:selected").each(function () {
            country += $(this).text();
            $("#fromregion1").empty();
            $("#fromregion1").append('<option disabled selected>Область');
        });
        getRegion(country, "fromcountry1");

    });
    $("#fromregionsearch").change(function () {
        var region = "";
        $("#fromregionsearch option:selected").each(function () {
            region += $(this).text();

        });
        deleteMarkers();
        geocodeCountry(geocode, map1, this.value);
    });
    $("#tocountry1").change(function () {
        var country = "";
        $("#tocountry1 option:selected").each(function () {
            country += $(this).text();
            $("#toregion1").empty();
            $("#toregion1").append('<option disabled selected>Область');
        });
        getRegion(country, "tocountry1");


    });
    $("#fromcountrysearch1").change(function () {
        var country = "";
        $("#fromcountrysearch1 option:selected").each(function () {
            country += $(this).text();
            $("#fromregionsearch1").empty();
            $("#fromregionsearch1").append('<option disabled selected>Область');
        });
        getRegion(country, "fromcountrysearch1");
        deleteMarkers();
        geocodeCountry(geocode, map1, this.value);


    });
    $("#tocountrysearch1").change(function () {
        var country = "";
        $("#tocountrysearch1 option:selected").each(function () {
            country += $(this).text();
            $("#toregion1search1").empty();
            $("#toregion1search1toregionsearch1").append('<option disabled selected>Область');
        });
        getRegion(country, "tocountrysearch1");

    });
    $("#fromregionsearch1").change(function () {
        var region = "";
        $("#fromregionsearch1 option:selected").each(function () {
            region += $(this).text();

        });
        deleteMarkers();
        geocodeCountry(geocode, map1, this.value);
    });
    $("#fromcitysearch1").keyup(function () {
        //alert(this.value);
        deleteMarkers();
        geocodeCity(geocode, map1, this.value);
    });
    var dateFormat = "mm/dd/yy";
    var from4 = $("#dp7")
        .datepicker({
            minDate: 0
        })
        .on("change", function () {
            to4.datepicker("option", "minDate", getDate(this));
        });
    var to4 = $("#dp8").datepicker({
        minDate: 0
    })
          .on("change", function () {
              from4.datepicker("option", "maxDate", getDate(this));
          });
    function getDate(element) {
        var date;
        try {
            date = $.datepicker.parseDate(dateFormat, element.value);
            console.log("Date is" + date);
        } catch (error) {
            date = null;
        }

        return date;
    }
    $("#tb9").on("click", "#delete", function () {
        var i = $(this).closest('tr').attr('data-id');
        console.log(i);
        removeUserCar(i);
    });
});
function AddVehicle() {
    var checkbox;
    if ($("#electron2").is(":checked")) {
        checkbox = true;

    }
    else {
        checkbox = false;
    }
    var vehicle = {
        Name: $('#name').val(),
        FromCountry: $('#fromcountry1').val(),
        FromRegion: $("#fromregion1").val(),
        FromCity: $('#fromcity1').val(),
        ToCountry: $('#tocountry1').val(),
        ToRegion: $('#toregion1').val(),
        ToCity: $('#tocity1').val(),
        DateOfSending: $('#dp7').val() + ' - ' + $('#dp8').val(),
        Weight: $('#weight2').val(),
        Volume: $('#volume2').val(),
        VehicleType: $('#cars1').val(),
        isElectronic: checkbox,
        LoadingType: $('#loading2').val(),
        CarType: $('#car2').val()
    };
    $.ajax({
        url: '/api/usercar/AddCar',
        type: 'POST',
        data: JSON.stringify(vehicle),
        contentType: "application/json;charset=utf-8",
        success: function (response) {
            if (usedAu1 == "false") {
                window.location.href = "/Account/Login?ReturnUrl=/LocateCar/LocateCar&errorMessage=Пожалуйста, войдите в систему для того, чтобы разместить объявление";
            }
            else {
                toastr.success("Объявление добавлено");
                //SuccessCarAlert();
                //var load = setTimeout(function () {
                //    $("#alertSuccessCar").empty();
                //    $("#alertSuccessCar").hide();
                //}, 3000);
            }
            
        }
    });
}
function SuccessCarAlert() {
    $("#alertSuccessCar").empty();
    $("#alertSuccessCar").hide();
    $("#alertSuccessCar").addClass("alert-success");
    $("#alertSuccessCar").addClass("text-center");
    $("#alertSuccessCar").append('<i class="fa fa-check-circle fa-lg" aria-hidden="true"></i>'
            + '<strong class="text-center"> Груз добавлен</strong>'
           + '<p>Перейти:<a href="/UserCargo/AllUserCars" class="alert-link">Мои авто</a></p>');
    //$("#alertSuccessCargo").append("   <strong>Машина добавлена</strong>");
    $("#alertSuccessCar").show();
}
function ShowAllVehicle() {
    var table = $("#tb5");
    $.ajax({
        url: "/api/usercars/GetAll",
        type: "GET",
        success: function (response) {
            $.each(response, function (key, item) {
                var from = item.FromCity + "," + item.FromRegion;
                var to = item.ToCity + "," + item.ToRegion;
                var checked;
                var btnDelete = '<span id="delete" class="glyphicon glyphicon-remove glyphicon-remove-entry"></span>';
                if (item.IsElectronic == true) {
                    checked = '<input type="checkbox" checked="true" disabled>'

                }
                else {
                    checked = '<input type="checkbox" disabled>'
                }
                table.append('<tr  data-id=' + item.Id + ">" + '<td >' + from + "</td>" + '<td  >' + to + "</td><td>"
                    + item.CarType + "</td><td>"
                    + item.Weight + "</td><td>"
                    + item.Volume + "</td><td>"
                    + item.DateOfSending + "</td><td>"
                    + item.LoadingType + "</td><td>"
                    + checked + "</td></tr>"
            );
            });
        }
    });
}
function showAllUserCar() {
    var table = $("#tb9");
    $.ajax({
        url: "/api/usercars/GetUserAll",
        type: "GET",
        success: function (response) {
            $.each(response, function (key, item) {
                var from = item.FromCity + "," + item.FromRegion;
                var to = item.ToCity + "," + item.ToRegion;
                var checked;
                var btnDelete = '<span id="delete" class="glyphicon glyphicon-remove glyphicon-remove-entry"></span>';
                if (item.IsElectronic == true) {
                    checked = '<input type="checkbox" checked="true" disabled>'

                }
                else {
                    checked = '<input type="checkbox" disabled>'
                }
                table.append('<tr  data-id=' + item.Id + ">" + '<td >' + from + "</td>" + '<td  >' + to + "</td><td>"
                    + item.CarType + "</td><td>"
                    + item.Weight + "</td><td>"
                    + item.Volume + "</td><td>"
                    + item.DateOfSending + "</td><td>"
                    + item.LoadingType + "</td><td>"
                    + checked + "</td><td>"
                    + btnDelete + "</td></tr>"
            );
            });
        }
    });
}
function removeUserCar(id) {
    var tableContent = $("td");
    $.ajax({
        url: "/api/usercar/Delete/" + id,
        type: "DELETE",
        success: function () {
            tableContent.remove();
            showAllUserCar();
        }
    });
}
function SearchCar() {
    var table = $("#tb6");
    var tableContent = $("#tb6 td");
    tableContent.remove();
    var fromcountry = $("#fromcountrysearch1").val();
    var fromregion = $("#fromregionsearch1").val();
    var fromcity = $("#fromcitysearch1").val();
    var tocountry = $("#tocountrysearch1").val();
    var toregion = $("#toregionsearch1").val();
    var tocity = $("#tocitysearch1").val();
    var cartype = $("#car3").val();
    var loadingtype = $("#loading3").val();
    var dp = $("#dp9").val();
    var dp1 = $("#dp10").val();
    var DateofLoading;
    if (dp != "" && dp1 != "") {
        DateofLoading = dp + " - " + dp1;

    }
    else {
        DateofLoading = "";
    }

    var checkbox;
    if ($("#electron3").is(":checked")) {
        checkbox = true;

    }
    else {
        checkbox = false;
    }
    $.ajax({
        url: "/api/usercar/Find",
        type: "GET",
        data: {
            'fromcountry': fromcountry,
            'fromregion': fromregion,
            'fromcity': fromcity,
            'tocountry': tocountry,
            'toregion': toregion,
            'tocity': tocity,
            'cartype': cartype,
            'loadingtype': loadingtype,
            'isElectronic': checkbox,
            'time': DateofLoading,



        },
        success: function (response) {
            $.each(response, function (key, item) {
                var car = item.FromCountry + "," + item.FromRegion + "," + item.FromCity;
                var from = item.FromCity + "," + item.FromRegion;
                var to = item.ToCity + "," + item.ToRegion;
                var checked;
                if (item.IsElectronic == true) {
                    checked = '<input type="checkbox" checked="true" disabled>'

                }
                else {
                    checked = '<input type="checkbox" disabled>'
                }
                table.append('<tr id="infoCar" data-id=' + item.Id + ">" + '<td >' + from + "</td>" + '<td  >' + to + "</td><td>"
                     + item.CarType + "</td><td>"
                     + item.Weight + "</td><td>"
                     + item.Volume + "</td><td>"
                     + item.DateOfSending + "</td><td>"
                     + item.LoadingType + "</td><td>"
                     + checked + "</td><td id='btn'>"
                     + "Телефон:" + item.PhoneNumber
                     + "<br/>Пользователь:" + item.UserName
                     + "<br/>Адрес:" + item.UserAdress
                     + "</td></tr>"
             );
                geocodeCountry(geocode, map1, car);
            });
        }
    });
}