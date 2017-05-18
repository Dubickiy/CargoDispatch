$(function () {
    var mycartype = $("#mycartype");
    var vehicle = "";
    var trailernumber = $("#trailernumber");
    var trailerlabel = $("#trailerlabel");
    $("#mycartype").change(function () {
        $("#mycartype option:selected").each(function () {
            vehicle = "";
            vehicle += $(this).text();
            if (vehicle == "Грузовик") {
                $('#cb1').attr("checked", false);
                console.log("Done");
                trailernumber.prop("disabled", true);
                trailerlabel.prop("disabled", true);
                $("#inp3").prop("disabled", true);
            }
        });
    });
    $('#cb1').change(function () {
        if (vehicle == "Грузовик") {
            vehicle = "Сцепка";
            mycartype.val(vehicle);
            trailernumber.prop("disabled", false);
            trailerlabel.prop("disabled", false);
            $("#inp3").prop("disabled", false);
            vehicle = "";
        }
        if (vehicle == "Полуприцеп") {
            console.log('Полуприцеп');
            vehicle = "Грузовик";
            mycartype.val(vehicle);
            trailernumber.prop("disabled", true);
            trailerlabel.prop("disabled", true);
            $("#inp3").prop("disabled", true);
            vehicle = "";
        }
        if (vehicle == "") {
            vehicle = "Сцепка";
            mycartype.val("Сцепка");
            trailernumber.prop("disabled", false);
            trailerlabel.prop("disabled", false);
            $("#inp3").prop("disabled", false);
            vehicle = "";
        }
    });



});