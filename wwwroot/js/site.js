







function validForm() {
    let userRoleName = $('#UserRoleName').val();
    let userRolePhone = $('#UserRolePhone').val();
    let userRoleEmail = $('#UserRoleEmail').val();
    let createdBy = $('#CreatedBy').val();
    let dateCreated = $('#DateCreated').val();
    let updatedBy = $('#UpdatedBy').val();
    let dateLastUpdated = $('#DateLastUpdated').val();


    if (userRoleName == "") {
        alert("UserRoleName is required");
        return false;
    }
    if (userRolePhone == "") {
        alert("UserRolePhone is required");
        return false;
    }
    if (userRoleEmail == "") {
        alert("UserRoleEmail is required");
        return false;
    }
    if (createdBy == "") {
        alert("CreatedBy is required");
        return false;
    }
    if (dateCreated == "") {
        alert("DateCreated is required");
        return false;
    }
    if (updatedBy == "") {
        alert("UpdatedBy is required");
        return false;
    }
    if (dateLastUpdated == "") {
        alert("DateLastUpdated is required");
        return false;
    }
    return true;
}

function userValidForm() {
    let firstName = $('#FirstName').val();
    let lastName = $('#LastName').val();
    let phone = $('#Phone').val();
    let email = $('#Email').val();
    let password = $('#Password').val();
    let CreatedBy = $('#CreatedBy').val();
    let DateCreated = $('#DateCreated').val();
    let UpdatedBy = $('#UpdatedBy').val();
    let DateLastUpdated = $('#DateLastUpdated').val();


    if (firstName == "") {
        alert("FirstName is required");
        return false;
    }
    if (lastName == "") {
        alert("LastName is required");
        return false;
    }
    if (phone == "") {
        alert("Phone is required");
        return false;
    }
    if (email == "") {
        alert("Email is required");
        return false;
    }
    if (password == "") {
        alert("Password is required");
        return false;
    }
    if (CreatedBy == "") {
        alert("CreatedBy is required");
        return false;
    }
    if (DateCreated == "") {
        alert("DateCreated is required");
        return false;
    }
    if (UpdatedBy == "") {
        alert("UpdatedBy is required");
        return false;
    }
    if (DateLastUpdated == "") {
        alert("DateLastUpdated is required");
        return false;
    }
    return true;
}


function ConfirmDelete() {
    return confirm("Are you sure you want to delete?");
}




function hideTable() {
    $("table").hide(1000);
    //$("table").fadeOut(1000);
}


function showTable() {
    $("table").show(2500);
    //$("table").fadeIn(2500);
}


//function Form() {
//    let providerName = document.getElementById('name').value;
//    let providerArea = document.getElementById('area').value;
//    let providerPhone = document.getElementById('phone').value;

//    if (providerName == "") {
//        alert("Provider name is required");
//        return false;
//    }
//    if (providerArea == "") {
//        alert("Provider area is required");
//        return false;
//    }
//    if (providerPhone == "") {
//        alert("Provider phone number is required");
//        return false;
//    }

//    return true;
//}




//function deleteWarning(ID) {
//    if (confirm('are you sure you want to delete this?'))
//    {
//        window.location.href = "/User/deleteUser?UserId=" + ID;
//    }
//    else {
//        window.location.href = "/User/UserList";
//    }
//}