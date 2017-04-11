"use strict";
$(function () {
    ShowAllVehicle();
    $("#form3").submit(function (e) {
        e.preventDefault();
        AddVehicle();

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
            SuccessAlert();
            var load = setTimeout(function () {
                $("#alertSuccessCar").empty();
                $("#alertSuccessCar").hide();
            }, 3000);
        }
    });
}
function SuccessAlert() {
    $("#alertSuccessCargo").addClass("alert-success");
    $("#alertSuccessCargo").addClass("glyphicon glyphicon-ok");
    $("#alertSuccessCargo").append("   Груз добавлен");
    $("#alertSuccessCargo").show();
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
                    + checked + "</td><td id='btn'>"
            );
            });
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
                var from = item.FromCity + "," + item.FromRegion;
                var to = item.ToCity + "," + item.ToRegion;
                var checked;
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
                     + checked + "</td><td id='btn'>"
             );
            });
        }
    });
}