var geocode;
var markers = [];
var photos = new Array();
//var Countries = new Array();
//var Countries1 = new Array();
var Regions = new Array();
var Regions1 = new Array();
var map1, autocomplete;
//var Countries = [
//    name:"Украина",
//]

"use strict";
$(function () {
    getCountries();
    getLoadingTypes();
    getCarTypes();
    getVehicleTypes();
    showAllUserCargos();
    showAllCargos();
    getAllCars();
    var dateObj = new Date();
    var month = dateObj.getUTCMonth() + 1;
    var day = dateObj.getUTCDate();
    var tmday = dateObj.getUTCDate() + 1;
    var year = dateObj.getUTCFullYear();
    var today = day + "/" + month + "/" + year;
    var tommorowday = tmday + "/" + month + "/" + year;
    $("#cars").change(function () {
        var carType = $("#car1");
        var loading = $("#loading1");
        var car = "";
        $("#cars option:selected").each(function () {
            car += $(this).text();
            //carType.empty();
            //loading.empty();
        });
        getCarInfo(car);
    });
    $("#cars1").change(function () {
        var carType = $("#car1");
        var loading = $("#loading1");
        var car = "";
        $("#cars1 option:selected").each(function () {
            car += $(this).text();
            //carType.empty();
            //loading.empty();
        });
        getCarInfo(car);
    });
    $("#fromcountry").change(function () {
        var country = "";
        $("#fromcountry option:selected").each(function () {
            country += $(this).text();
            $("#fromregion").empty();
            $("#fromregion").append('<option disabled selected>Область');
        });
        getRegion(country, "fromcountry");



    });
    $("#tocountry").change(function () {
        var country = "";
        $("#tocountry option:selected").each(function () {
            country += $(this).text();
            $("#toregion").empty();
            $("#toregion").append('<option disabled selected>Область');
        });
        getRegion(country, "tocountry");

    });
    $("#fromcountrysearch").change(function () {
        var country = "";
        $("#fromcountrysearch option:selected").each(function () {
            country += $(this).text();
            $("#fromregionsearch").empty();
            $("#fromregionsearch").append('<option disabled selected>Область');
        });
        getRegion(country, "fromcountrysearch");
        deleteMarkers();
        geocodeCountry(geocode, map1, this.value);
    });
    $("#fromregionsearch").change(function () {
        var region = "";
        $("#fromregionsearch option:selected").each(function () {
            region += $(this).text();

        });
        deleteMarkers();
        geocodeCountry(geocode, map1, this.value);
    });
    $("#tocountrysearch").change(function () {
        var country = "";
        $("#tocountrysearch option:selected").each(function () {
            country += $(this).text();
            $("#toregionsearch").empty();
            $("#toregionsearch").append('<option disabled selected>Область');
        });
        getRegion(country, "tocountrysearch");
    });

    $('.nav li').each(function () {
        if (this.getElementsByTagName("a")[0].href == location.href) {
            this.className = "active";
        }
    });

    $("#fromcitysearch").keyup(function () {
        //alert(this.value);
        deleteMarkers();
        geocodeCity(geocode, map1, this.value);
    });

    var dateFormat = "mm/dd/yy";
    var from = $("#dp")
            .datepicker({
                minDate: 0
            })
            .on("change", function () {
                to.datepicker("option", "minDate", getDate(this));
            });
    var to = $("#dp1").datepicker({
        minDate: 0
    })
          .on("change", function () {
              from.datepicker("option", "maxDate", getDate(this));
          });
    var from1 = $("#dp3")
        .datepicker({
            minDate: 0
        })
        .on("change", function () {
            to1.datepicker("option", "minDate", getDate(this));
        });
    var to1 = $("#dp4").datepicker({
        minDate: 0
    })
          .on("change", function () {
              from1.datepicker("option", "maxDate", getDate(this));
          });
    var from3 = $("#dp9")
        .datepicker({
            minDate: 0
        })
        .on("change", function () {
            to3.datepicker("option", "minDate", getDate(this));
        });
    var to3 = $("#dp10").datepicker({
        minDate: 0
    })
          .on("change", function () {
              from3.datepicker("option", "maxDate", getDate(this));
          });
    $('#dp5').datepicker();
    $('#dp6').datepicker();
    $("#dp").attr("placeholder", today);
    $("#dp1").attr("placeholder", tommorowday);
    $("#dp3").attr("placeholder", today);
    $("#dp4").attr("placeholder", tommorowday);
    $("#dp5").attr("placeholder", today);
    $("#dp6").attr("placeholder", today);
    $("#dp7").attr("placeholder", today);
    $("#dp8").attr("placeholder", tommorowday);
    $("#dp9").attr("placeholder", today);
    $("#dp10").attr("placeholder", tommorowday);
    $("#tb3").on("click", "#delete", function () {
        var i = $(this).closest('tr').attr('data-id');
        console.log(i);
        removeCargo(i);
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
    $("#form1").submit(function (e) {
        e.preventDefault();
        AddCargo();
    });
    //$("#form2").submit(function (e) {
    //    e.preventDefault();
    //    searchCargo();
    //});
    $('#reset').click(function () {
        $("#ckb1").prop("disabled", true);
        $("#ckb2").prop("disabled", true);
        $("#ckb3").prop("disabled", true);
        $("#ckb4").prop("disabled", true);
        console.log("Done");
    });
    $('#rate').change(function () {
        $('.radio-button').prop('disabled', !this.checked);
    });
    $("#tb2").on("click", "#infoCargo", function () {
        var i = $(this).closest('tr').attr('data-id');
        console.log(i);
        window.location.href = "/Search/SearchCargoInfo?id=" + i;


    });
    $("#tb4").on("click", "#deletecar1", function () {
        console.log("Clicked");
        var i = $(this).closest('tr').attr('data-id');
        removeCar(i);
    });

    $("#tb4").on("click", "#getPhoto", function () {
        var i = $(this).closest('tr').attr('data-id');
        getPhoto(i);
        $('#myModal').on('shown.bs.modal', function () {

            console.log(i);
        })
    });
    $("#tb4").on("click", "#TechPhoto", function () {
        var i = $(this).closest('tr').attr('data-id');
        getTechPhoto(i);
        $('#myModal').on('shown.bs.modal', function () {

            console.log(i);
        })
    });
    $("#deletePhoto").on("click", function () {
        var i = $(this).attr('data-content');
        console.log(i)
    })
    $("#search").click(function () {
        searchCargo();
    });
    $("#fromregionsearch").click(function () {
        $("#fromcitysearch").val('');
    });
});

function setCargoInfo(id) {
    $.ajax({
        url: "/Search/SearchCargoInfo",
        type: "GET",
        data:{'id':id},
        success: function (response) {
            window.location.href = "/Search/SearchCargoInfo"
        }
    });
}
function getCargo(cargos) {
    cargo = cargos;
    alert(cargo);
}
function AddCargo() {
    var dateObj = new Date();
    var month = dateObj.getUTCMonth() + 1;
    var day = dateObj.getUTCDate();
    var tmday = dateObj.getUTCDate() + 1;
    var year = dateObj.getUTCFullYear();
    var today = day + "/" + month + "/" + year;
    var tommorowday = tmday + "/" + month + "/" + year;
    var table = $("#tb1 tr");
    var checkbox;
    if ($("#electron").is(":checked")) {
        checkbox = true;

    }
    else {
        checkbox = false;
    }
    table.remove();
    var cargo = {
        Name: $('#name').val(),
        FromCountry: $('#fromcountry').val(),
        FromRegion: $("#fromregion").val(),
        FromCity: $('#fromcity').val(),
        ToCountry: $('#tocountry').val(),
        ToRegion: $('#toregion').val(),
        ToCity: $('#tocity').val(),
        TimeOfNeccessaryLoading: $('#dp').val() + ' - ' + $('#dp1').val(),
        Weight: $('#weight').val(),
        Volume: $('#volume').val(),
        Price: $('#price').val(),
        IsElectronic: checkbox,
        LoadingType: $('#loading').val(),
        CarType: $('#car').val()
    };
    $.ajax({
        url: '/api/cargo/AddCargo',
        type: 'POST',
        data: JSON.stringify(cargo),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            //showInTable(data.id);
            SuccessAlert();
            var load = setTimeout(function () {
                $("#alertSuccessCargo").empty();
                $("#alertSuccessCargo").hide();
            }, 3000);

        }
    });
}
function SuccessAlert() {
    $("#alertSuccessCargo").empty();
    $("#alertSuccessCargo").hide();
    $("#alertSuccessCargo").addClass("alert-success");
    $("#alertSuccessCargo").append('<i class="fa fa-check-circle fa-lg" aria-hidden="true"></i><strong class="text-center" style="padding-left:15%"> Груз добавлен</strong>');
    //$("#alertSuccessCargo").append("   <strong>Машина добавлена</strong>");
    $("#alertSuccessCargo").show();
}
function getAllCars() {
    var table = $("#tb4");
    var cars = $("#cars");
    $.ajax({
        url: "/api/car/GetAll",
        type: "GET",
        success: function (response) {
            $.each(response, function (key, item) {

                var hasTrailer;
                if (item.hasTrailer == true) {
                    hasTrailer = 'Есть'

                }
                else {
                    hasTrailer = 'Нет'
                }
                var btnDelete = '<span id="deletecar1" class="glyphicon glyphicon-remove glyphicon-remove-entry"></span>';
                var linkCarPhoto = '<span data-toggle="modal" data-target="#myModal"><a id="getPhoto" style="cursor:pointer">Посмотреть</a></span>';
                var linkTechPhoto = '<span data-toggle="modal" data-target="#myModal"><a id="TechPhoto" style="cursor:pointer">Посмотреть</a></span>';
                table.append("<tr data-id=" + item.Id + ">" + "<td>" + item.Name + "</td><td>"
                    + item.Type + "</td><td>"
                    + item.Body + "</td><td>"
                    + linkTechPhoto + "</td><td>"
                    + linkCarPhoto + "</td><td>"
                    + hasTrailer + "</td><td>"
                    + item.Volume + "</td><td>"
                    + item.LoadingType + "</td><td>"
                    + btnDelete + "</td></tr>"
            );
            });
            $.each(response, function (key, item) {
                cars.append(
                    $('<option/>', {
                        value: item.Name,
                        html: item.Name
                    })
                    )
                $("#cars1").append(
                    $('<option/>', {
                        value: item.Name,
                        html: item.Name
                    })
                    )
            });
        }
    });
}
function removeCar(id) {
    var tableContent = $("td");
    $.ajax({
        url: "/api/car/Delete/" + id,
        type: "DELETE",
        data: { 'id': id },
        success: function () {
            tableContent.remove();
            getAllCars();
        }
    });
}
function removeCargo(id) {
    var tableContent = $("td");
    $.ajax({
        url: "/api/cargo/Delete/" + id,
        type: "DELETE",
        success: function (data) {
            tableContent.remove();
            showAllUserCargos();
        }
    });
}

function getCountries() {
    $.ajax({
        url: "/LocateCargo/GetCountries",
        type: "GET",
        success: function (response) {
            $.each(response, function (key, item) {
                $('#fromcountry').append(
                    $('<option/>', {
                        value: item.Name,
                        html: item.Name
                    })

                    )
                $('#fromcountry1').append(
                    $('<option/>', {
                        value: item.Name,
                        html: item.Name
                    })

                    )
                $('#tocountry').append(
                    $('<option/>', {
                        value: item.Name,
                        html: item.Name
                    })

                    )
                $('#tocountry1').append(
                     $('<option/>', {
                         value: item.Name,
                         html: item.Name
                     })
                        )
                $('#fromcountrysearch').append(
                $('<option/>', {
                    value: item.Name,
                    html: item.Name
                })
                    )
                $('#tocountrysearch').append(
                $('<option/>', {
                    value: item.Name,
                    html: item.Name
                })
                )
                $('#fromcountrysearch1').append(
                $('<option/>', {
                    value: item.Name,
                    html: item.Name
                })
                    )
                $('#tocountrysearch1').append(
                $('<option/>', {
                    value: item.Name,
                    html: item.Name
                })
                )
            });
        }
    });
}
function getRegion(id, section) {
    $.ajax({
        url: "/LocateCargo/GetRegions",
        type: "GET",
        data: {
            'id': id
        },
        success: function (response) {
            $.each(response, function (key, item) {
                if (section == "fromcountry") {
                    $('#fromregion').append(
                  $('<option/>', {
                      value: item.Name,
                      html: item.Name
                  })
                  )
                }
                if (section == "fromcountry1") {
                    $('#fromregion1').append(
                 $('<option/>', {
                     value: item.Name,
                     html: item.Name
                 })
                 )
                }
                if (section == "tocountry1") {
                    $('#toregion1').append(
                                       $('<option/>', {
                                           value: item.Name,
                                           html: item.Name
                                       })
                                        )
                }
                if (section == "tocountry") {
                    $('#toregion').append(
                                        $('<option/>', {
                                            value: item.Name,
                                            html: item.Name
                                        })
                                         )
                }
                if (section == "fromcountrysearch") {
                    $('#fromregionsearch').append(
                $('<option/>', {
                    value: item.Name,
                    html: item.Name
                })
                )
                }
                if (section == "tocountrysearch") {
                    $('#toregionsearch').append(
                $('<option/>', {
                    value: item.Name,
                    html: item.Name
                })
                )
                }
                if (section == "fromcountrysearch1") {
                    $('#fromregionsearch1').append(
                $('<option/>', {
                    value: item.Name,
                    html: item.Name
                })
                )
                }
                if (section == "tocountrysearch1") {
                    $('#toregionsearch1').append(
                $('<option/>', {
                    value: item.Name,
                    html: item.Name
                })
                )
                }

            });
        }
    });
}
function getLoadingTypes() {
    var loading = $("#loading");
    var loading1 = $("#loading1");
    var loading2 = $("#loading2");
    $.ajax({
        url: "/LocateCargo/GetLoadingTypes",
        type: "GET",
        success: function (response) {
            loading.empty();
            loading2.empty();
            $.each(response, function (key, item) {
                loading.append(
                    $('<option/>', {
                        value: item.Name,
                        html: item.Name
                    })
                    )
                loading1.append(
                  $('<option/>', {
                      value: item.Name,
                      html: item.Name
                  })
                  )
                loading2.append(
                  $('<option/>', {
                      value: item.Name,
                      html: item.Name
                  })
                  )
                $("#loading3").append(
                  $('<option/>', {
                      value: item.Name,
                      html: item.Name
                  })
                  )
            });
        }
    });
}
function getCarTypes() {
    var car = $("#car");
    var car1 = $("#car1");
    var carbody = $("#mycarbody");
    $.ajax({
        url: "/LocateCargo/GetCarTypes",
        type: "GET",
        success: function (response) {
            car.empty();
            //car1.empty();
            carbody.empty();
            $.each(response, function (key, item) {
                car.append(
                    $('<option/>', {
                        value: item.Name,
                        html: item.Name
                    })
                    )
                car1.append(
                   $('<option/>', {
                       value: item.Name,
                       html: item.Name
                   })
                   )

                carbody.append(
                  $('<option/>', {
                      value: item.Name,
                      html: item.Name
                  })
                  )
                $("#car3").append(
                  $('<option/>', {
                      value: item.Name,
                      html: item.Name
                  })
                  )
            });
        }
    });

}
function getVehicleTypes() {
    var vehicle = $("#mycartype");
    $.ajax({
        url: "/MyCars/GetVehicleTypes",
        type: "GET",
        success: function (response) {
            vehicle.empty();
            vehicle.append('<option disabled selected>');
            $.each(response, function (key, item) {
                vehicle.append(
                    $('<option/>', {
                        value: item.Name,
                        html: item.Name
                    })
                    )
                $("#car2").append(
                    $('<option/>', {
                        value: item.Name,
                        html: item.Name
                    })
                    )

            });


        }
    });
}
function showAllUserCargos() {
    var table = $("#tb3");
    var dateObj = new Date();
    var month = dateObj.getUTCMonth() + 1;
    var day = dateObj.getUTCDate();
    var tmday = dateObj.getUTCDate() + 1;
    var year = dateObj.getUTCFullYear();
    var today = day + "/" + month + "/" + year;
    $.ajax({
        url: "/api/cargo/GetUserAll",
        type: "GET",
        success: function (response) {
            $.each(response, function (key, item) {

                var checked;
                var btnDelete = '<span id="delete" class="glyphicon glyphicon-remove glyphicon-remove-entry"></span>';
                if (item.IsElectronic == true) {
                    checked = '<input type="checkbox" checked="true" disabled>'

                }
                else {
                    checked = '<input type="checkbox" disabled>'
                }
                table.append('<tr  data-id=' + item.Id + ">" + '<td >' + item.Id + "</td>" + '<td  >' + item.TimeOfNeccessaryLoading + "</td><td>"
                    + item.carTypes + "</td><td>"
                    + item.FromRegion + ',' + '<p>' + item.FromCity + '</p>' + "</td><td>"
                    + item.ToRegion + ',' + '<p>' + item.ToCity + '</p>' + "</td><td>"
                    + item.Name + "</td><td>"
                    + item.Weight + "</td><td>"
                    + item.Volume + "</td><td>"
                    + item.LoadingType + "</td><td>"
                    + item.Price + "</td><td>"
                    + today + "</td><td>"
                    + checked + "</td><td id='btn'>"
                    + btnDelete + "</td></tr>"
            );
            });
        }
    });
}
function showAllCargos() {
    var table = $("#tb7");
    var dateObj = new Date();
    var month = dateObj.getUTCMonth() + 1;
    var day = dateObj.getUTCDate();
    var tmday = dateObj.getUTCDate() + 1;
    var year = dateObj.getUTCFullYear();
    var today = day + "/" + month + "/" + year;
    $.ajax({
        url: "/api/cargo/GetAll",
        type: "GET",
        success: function (response) {
            $.each(response, function (key, item) {

                var checked;
                var btnDelete = '<span id="delete" class="glyphicon glyphicon-remove glyphicon-remove-entry"></span>';
                if (item.IsElectronic == true) {
                    checked = '<input type="checkbox" checked="true" disabled>'

                }
                else {
                    checked = '<input type="checkbox" disabled>'
                }
                table.append('<tr  data-id=' + item.Id + ">" + '<td >' + item.Id + "</td>" + '<td  >' + item.TimeOfNeccessaryLoading + "</td><td>"
                    + item.carTypes + "</td><td>"
                    + item.FromRegion + ',' + '<p>' + item.FromCity + '</p>' + "</td><td>"
                    + item.ToRegion + ',' + '<p>' + item.ToCity + '</p>' + "</td><td>"
                    + item.Name + "</td><td>"
                    + item.Weight + "</td><td>"
                    + item.Volume + "</td><td>"
                    + item.LoadingType + "</td><td>"
                    + item.Price + "</td><td>"
                    + today + "</td><td>"
                    + checked + "</td></tr>"
            );
            });
        }
    });
}
function searchCargo() {
    var dateObj = new Date();
    var month = dateObj.getUTCMonth() + 1;
    var day = dateObj.getUTCDate();
    var tmday = dateObj.getUTCDate() + 1;
    var year = dateObj.getUTCFullYear();
    var today = day + "/" + month + "/" + year;
    var table = $("#tb2");
    var tableContent = $("#tb2 td");
    tableContent.remove();
    var checkbox;
    if ($("#electron1").is(":checked")) {
        checkbox = true;

    }
    else {
        checkbox = false;
    }
    if ($("#dp3").val() != "" && $("#dp4").val() != "") {
        DateofLoading = $("#dp3").val() + " - " + $("#dp4").val();

    }
    else {
        DateofLoading = "";
    }

    var search = {
        FromCountry: $('#fromcountrysearch').val(),
        FromRegion: $("#fromregionsearch").val(),
        FromCity: $('#fromcitysearch').val(),
        ToCountry: $('#tocountrysearch').val(),
        ToRegion: $('#toregionsearch').val(),
        ToCity: $('#tocitysearch').val(),
        TimeOfNeccessaryLoading: DateofLoading,
        Weight: $('#weight1').val(),
        Volume: $('#volume1').val(),
        IsElectronic: checkbox,
        LoadingType: $('#loading1').val(),
        CarType: $('#car1').val()
    };
    $.ajax({
        type: "GET",
        data: search,
        url: "/api/cargo/Find/",
        contentType: "application/json;charset=utf-8",
        success: function (response) {
            $.each(response, function (key, item) {
                var checked;
                if (item.IsElectronic == true) {
                    checked = '<input type="checkbox" checked="true" disabled>'

                }
                else {
                    checked = '<input type="checkbox" disabled>'
                }
                table.append('<tr id="infoCargo" data-id=' + item.Id + '>' + "<td>" + item.TimeOfNeccessaryLoading + "</td><td>"
                    + item.CarType+ "</td><td>"
                    + item.FromRegion + ',' + '<p>' + item.FromCity + '</p>' + "</td><td>"
                    + item.ToRegion + ',' + '<p>' + item.ToCity + '</p>' + "</td><td>"
                    + item.Name + "</td><td>"
                    + item.Weight + "</td><td>"
                    + item.Volume + "</td><td>"
                    + item.LoadingType + "</td><td>"
                    + item.Price + "</td><td>"
                    + today + "</td><td>"
                    + checked + "</td></tr>"
            );
            });
        }
    });
}
function initAuto() {
    /*
        autocomplete = new google.maps.places.Autocomplete((document.getElementById('autocomplete')),
        { types: ['geocode'] });
        autocomplete.addListener('place_changed');
    */


    map1 = new google.maps.Map(document.getElementById('canvas1'), {
        zoom: 5,
        center: { lat: -34.397, lng: 150.644 }

    });

    geocode = new google.maps.Geocoder();
}
function geocodeCity(geocoder, resultsMap, address) {
    geocoder.geocode({ 'address': address }, function (results, status) {
        if (status === google.maps.GeocoderStatus.OK) {
            resultsMap.setCenter(results[0].geometry.location);
            resultsMap.setZoom(8);
            var marker = new google.maps.Marker({
                map: resultsMap,
                position: results[0].geometry.location,


            });
            markers.push(marker);

        } else {
            //alert('Geocode was not successful for the following reason: ' + status);
        }

    });
}
function geocodeCountry(geocoder, resultsMap, address) {
    geocoder.geocode({ 'address': address }, function (results, status) {
        if (status === google.maps.GeocoderStatus.OK) {
            resultsMap.setCenter(results[0].geometry.location);
            var marker = new google.maps.Marker({
                map: resultsMap,
                position: results[0].geometry.location,

            });
            markers.push(marker);
        } else {
            //alert('Geocode was not successful for the following reason: ' + status);
        }

    });
}
function clearMarkers() {
    setMapOnAll(null);
}
function setMapOnAll(map1) {
    for (var i = 0; i < markers.length; i++) {
        markers[i].setMap(map1);
    }
}
function deleteMarkers() {
    clearMarkers();
    markers = [];
}
function getCarPhoto(input) {
    var chosen = $("#chosen2");
    if (input.files && input.files[0]) {
        if ('files' in input) {
            if (input.files.length == 0) {
                chosen1.text("Select one or more files.");
            } else {
                for (var i = 0; i < input.files.length; i++) {
                    var file = input.files[i];
                    if ('name' in file) {
                        chosen.append('<br/>' + file.name + '<span data-recognizer="' + input.files[i] + '" id="deletePhoto" onclick="deleteSelectedPhoto()" class="glyphicon glyphicon-remove glyphicon-remove-entry" style="margin-left:5px;"></span><br/>');


                    }

                }
            }
        }
    }
}
function getPassportPhoto(input) {
    var chosen = $("#chosen1");
    var photos = new Array();
    if (input.files && input.files[0]) {
        if ('files' in input) {
            if (input.files.length == 0) {
                chosen.text("Select one or more files.");
            } else {
                for (var i = 0; i < input.files.length; i++) {
                    var file = input.files[i];
                    photos.push(file);
                    console.log(photos);
                    //if ('name' in file) {
                    //    chosen.append('<br/>' + file.name + '<span data-content="' + file.name+'" onclick="deleteSelectedPhoto()" class="glyphicon glyphicon-remove glyphicon-remove-entry" style="margin-left:5px;"></span><br/>');


                    //}

                }
                for (var i = 0; i < photos.length; i++) {
                    console.log(photos[i].name);
                    chosen.append('<br/>' + photos[i].name + '<span data-recognizer="' + photos[i].name + '" id="deletePhoto" onclick="deleteSelectedPhoto()" class="glyphicon glyphicon-remove glyphicon-remove-entry" style="margin-left:5px;"></span><br/>');
                }
            }
        }
    }
}
function deleteSelectedPhoto() {
    var i = $("#deletePhoto").attr('data-recognizer');
    console.log("Content are " + i);
    var file = $("#inp1").val(i);
    file.val("");
    //photo.hide(); 
}
function getCar() {
    var cars = $("#cars");
    var car = $("#car1");
    var loading = $("#loading1");
    $.ajax({
        url: "/Cargo/GetCar",
        type: "GET",

        success: function (response) {
            cars.empty();
            $.each(response, function (key, item) {
                cars.append(
                    $('<option/>', {
                        value: item.Name,
                        html: item.Name
                    })
                    )
                $('#cars1').append(
                    $('<option/>', {
                        value: item.Name,
                        html: item.Name
                    })
                    )

            });
        }
    });
}
function getCarInfo(vehicle) {
    var car = $("#car1");
    var car1 = $("#car2");
    var loading = $("#loading1");
    var loading1 = $("#loading2");
    var volume = $("#volume1");
    var weight = $("#weight1");
    var volume1 = $("#volume2");
    var weight1 = $("#weight2");
    $.ajax({
        url: "/MyCars/GetCarInfo",
        type: "GET",
        data: {
            'name': vehicle
        },
        success: function (response) {
            $.each(response, function (key, item) {
               loading1.val(item.LoadingType);
               car1.val(item.Type);
                loading.val(item.LoadingType);
                car.val(item.Body);
                volume.val(item.Volume);
                weight.val(item.Weight);
                volume1.val(item.Volume);
                weight1.val(item.Weight);
            });
        }
    });
}
function getPhoto(id) {
    $('.carousel-inner').empty();

    $.ajax({
        url: "/MyCars/GetPhoto",
        type: "GET",
        data: {
            'id': id
        },
        success: function (response) {
                for (var i = 0 ; i < response.length ; i++) {
                    if (response[i].Name == "CarPhoto") {
                        $('<div class="item"><img src="' + 'data:image/png;base64,' + response[i].Value + '"><div class="carousel-caption"></div>   </div>').appendTo('.carousel-inner');
                        $('<li data-target="#carousel-example-generic" data-slide-to="' + i + '"></li>').appendTo('.carousel-indicators')
                        $('.item').first().addClass('active');
                        $('.carousel-indicators > li').first().addClass('active');
                        $('#carousel-example-generic').carousel();
                    }
                    else {
                       
                    }
                    //$('<div class="item"><img src="' +'data:image/png;base64,' + response[i].Value + '"><div class="carousel-caption"></div>   </div>').appendTo('.carousel-inner');
                    //$('<li data-target="#carousel-example-generic" data-slide-to="' + i + '"></li>').appendTo('.carousel-indicators')
                   
                }
               
            }

            
        
    })
}
function getTechPhoto(id) {
    $('.carousel-inner').empty();

    $.ajax({
        url: "/MyCars/GetPhoto",
        type: "GET",
        data: {
            'id': id
        },
        success: function (response) {
            for (var i = 0 ; i < response.length ; i++) {
                if (response[i].Name == "TechPhoto") {
                    $('<div class="item"><img class="img-responsive" src="' + 'data:image/png;base64,' + response[i].Value + '"><div class="carousel-caption"></div>   </div>').appendTo('.carousel-inner');
                    $('<li data-target="#carousel-example-generic" data-slide-to="' + i + '"></li>').appendTo('.carousel-indicators')
                }
            }
            $('.item').first().addClass('active');
            $('.carousel-indicators > li').first().addClass('active');
            $('#carousel-example-generic').carousel();
        }
    })
}
