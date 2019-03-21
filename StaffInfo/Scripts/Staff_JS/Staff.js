
$(document).ready(function () {
    $("#Branch_Department_Code").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Staff/AutoCompleteBD?brDp=" + request.term,
                type: "POST",
                dataType: "json",
                //data: { branchName: request.term },
                success: function (data) {
                    var sta = $.map(data.data, function (item) {
                        return { "label": item.Branch_Department_Code, "value": item.Branch_Department_Code };
                    });
                    response(sta)
                }
            })
        },
        messages: {
            noResults: "", results: function (result) { }
        }
    });
})

$(document).ready(function () {
    $("#Job_Code").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Staff/AutoCompleteJob?jobName=" + request.term,
                type: "POST",
                dataType: "json",
                //data: { branchName: request.term },
                success: function (data) {
                    var sta = $.map(data.data, function (item) {
                        return { "label": item.Position, "value": item.Job_Title_Code };
                    });
                    response(sta)
                }
            })
        },
        messages: {
            noResults: "", results: function (result) { }
        }
    });
})

$(document).ready(function () {
    $("#Temporary_Address").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Staff/AutoCompleteAddress?addName=" + request.term,
                type: "POST",
                dataType: "json",
                //data: { branchName: request.term },
                success: function (data) {
                    var sta = $.map(data.data, function (item) {
                        return { "label": item.Place_Name, "value": item.Address_Code };
                    });
                    response(sta)
                }
            })
        },
        messages: {
            noResults: "", results: function (result) { }
        }
    });
})

$(document).ready(function () {
    $("#Permanent_Address").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Staff/AutoCompleteAddress?addName=" + request.term,
                type: "POST",
                dataType: "json",
                //data: { branchName: request.term },
                success: function (data) {
                    var sta = $.map(data.data, function (item) {
                        return { "label": item.Place_Name, "value": item.Address_Code };
                    });
                    response(sta)
                }
            })
        },
        messages: {
            noResults: "", results: function (result) { }
        }
    });
})

function StaffRegister(form) {
    $.validator.unobtrusive.parse(form);
    if ($(form).valid()) {
        $.ajax({
            type: "POST",
            url: form.action,
            data: $(form).serialize(),
            success: function (data) {
                if (data.success) {
                    $.notify(data.message, {
                        globalPosition: "top center",
                        className: "success"
                    })
                }
            }
        })
        return false;
    }
    return false;
}

//for admin purpose
$(document).ready(function () {
    $("#Address_Code").autocomplete({
        source: function (request, response) {
            debugger;
            $.ajax({
                url: "/Admin/AddressAutoComplete?addressAdd=" + request.term,
                type: "POST",
                dataType: "json",
                //data: { branchName: request.term },
                success: function (data) {
                    var sta = $.map(data.data, function (item) {
                        return { "label": item.Place_Name, "value": item.Address_Code };
                    });
                    response(sta)
                }
            })
        },
        messages: {
            noResults: "No match found.", results: function (result) { }
        }
    });
})


function PopupForm(url) {
    var formDiv = $('<div/>');
    $.get(url)
    .done(function (response) {
        formDiv.html(response);

        Popup = formDiv.dialog({
            autoOpen: true,
            resizable: true,
            title: 'Add Extension Number',
            height: 300,
            width: 500,
            close: function () {
                Popup.dialog('destroy').remove();
                dataTable.ajax.reload();
            }
        });
    });
}

function StaffForm(url) {
    var formDiv = $('<div/>');
    $.get(url)
    .done(function (response) {
        formDiv.html(response);

        FromPopup = formDiv.dialog({
            autoOpen: true,
            resizable: true,
            title: 'Staff Add and Edit Form',
            height: 570,
            width: 900,
            close: function () {
                FromPopup.dialog('destroy').remove();
                dataTable.ajax.reload();
            }
        });
    });
}

//for adding extension number
function ExtensionAdd(form) {
    $.validator.unobtrusive.parse(form);
    if ($(form).valid()) {
        $.ajax({
            type: "POST",
            url: form.action,
            data: $(form).serialize(),
            success: function (data) {
                if (data.success) {
                    $.notify(data.message, {
                        globalPosition: "top center",
                        className: "success"
                    })
                }
            }
        })
        return false;
    }
    return false;
}

//for adding deparment
function AddDepartment(form) {
    $.validator.unobtrusive.parse(form);
    if ($(form).valid()) {
        $.ajax({
            type: "POST",
            url: form.action,
            data: $(form).serialize(),
            success: function (data) {
                if (data.success) {
                    $.notify(data.message, {
                        globalPosition: "top center",
                        className: "success"
                    })
                }
            }
        })
        return false;
    }
    return false;
}

//for adding jod details
function AddJob(form) {
    $.validator.unobtrusive.parse(form);
    if ($(form).valid()) {
        $.ajax({
            type: "POST",
            url: form.action,
            data: $(form).serialize(),
            success: function (data) {
                if (data.success) {
                    $.notify(data.message, {
                        globalPosition: "top center",
                        className: "success"
                    })
                }
            }
        })
        return false;
    }
    return false;
}

//for adding address details
function AddressSave(form) {
    $.validator.unobtrusive.parse(form);
    if ($(form).valid()) {
        $.ajax({
            type: "POST",
            url: form.action,
            data: $(form).serialize(),
            success: function (data) {
                if (data.success) {
                    $.notify(data.message, {
                        globalPosition: "top center",
                        className: "success"
                    })
                }
            }
        })
        return false;
    }
    return false;
}

//for adding branch details
function AddBranch(form) {
$.validator.unobtrusive.parse(form);
if ($(form).valid()) {
    $.ajax({
        type: "POST",
        url: form.action,
        data: $(form).serialize(),
        success: function (data) {
            if (data.success) {
                $.notify(data.message, {
                    globalPosition: "top center",
                    className: "success"
                })
            }
        }
    })
    return false;
}
return false;
}