function getbyID(EmpID) {
    
    $('#Name').css('border-color', 'lightgrey');
    $('#Email').css('border-color', 'lightgrey');
    $('#PhoneNo').css('border-color', 'lightgrey');
    $('#Department').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Home/getbyID/" + EmpID,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#Id').val(result.id);
            $('#Name').val(result.name);
            $('#Email').val(result.email);
            $('#PhoneNo').val(result.phoneNo);
            $('#Department').val(result.department);

            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}


function Update() {
    debugger;
    var emp = {
        Id: $('#Id').val(),
        Name: $('#Name').val(),
        Email: $('#Email').val(),
        PhoneNo: $('#PhoneNo').val(),
        Department: $('#Department').val(),
    };
    $.ajax({
        url: "/Home/Update",
        data: emp,
        type: "POST",
        success: function (result) {           
            ClosePopup();            
            location.reload();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function ResetFormControl() {
    $('#Id').val("");
    $('#Name').val("");
    $('#Email').val("");
    $('#PhoneNo').val("");
    $('#Department').val("");
}

function ClosePopup() {
    ResetFormControl();
    $('#myModal').modal('hide');
}

