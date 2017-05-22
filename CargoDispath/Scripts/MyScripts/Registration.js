$(function () {
    //$('#editing').click(function () {
    //    console.log("Done1");
    //    $('#myModal1').on('shown.bs.modal', function () {
    //        console.log("Done");
    //    });
    //    console.log("Done3");
    //})
    $("#editing").on("click", function () {
        console.log("Done1");
        $('#myModalEdit').modal('show');
        //$('#myModalEdit').on('shown.bs.modal', function () {
        //    console.log("Done");
        //});
    });
    $("#editForm").click(function (e) {
        e.preventDefault();
       // $('#myModalEdit').modal('hide');
        $.post("/Account/EditUser").then(function (user) {
            if (user != null) {
                console.log(user);
                $('#myModalEdit').modal('hide');
            }
        });
    });
});