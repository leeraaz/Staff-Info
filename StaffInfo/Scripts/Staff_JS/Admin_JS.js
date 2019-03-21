//for Staff or Index page
var dataTable;
$(document).ready(function () {
    dataTable = $('#staffTable').DataTable({
        "ajax": {
            "url": "/Staff/GetData",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "FIRST_NAME" },
            { "data": "LAST_NAME" },
            { "data": "PLACE_NAME" },
            { "data": "BRANCH_NAME" },
            { "data": "DEPARTMENT_NAME" },
            { "data": "POSITION" },
            { "data": "EXTENSION_NUM" },
            {
                "data": "STAFF_ID", "render": function (data) {
                    return "<a class='btn btn-outline-dark btn-sm' onclick=StaffForm('/Staff/StaffRegister?STAFF_ID=" + data + "')><i class='fa fa-pencil'></i> Edit</a><a class='btn btn-outline-dark btn-sm' style='margin-left:5px' onclick=Delete(" + data + ")><i class='fa fa-trash'></i> Delete</a>";
                },
                "orderable": false,
                "searchable": false,
                "width": "150px"
            },
            {
                "data": "STAFF_ID", "render": function (data) {
                    return "<a class='btn btn-outline-dark btn-sm' onclick=PopupForm('/Staff/AddExtension?staffID=" + data + "')><i class='fa fa-pencil'></i>Add Extension</a>";
                },
                "orderable": false,
                "searchable": false,
                "width": "150px"
            },
        ]
    });
});

function Delete(staffID) {
    if (confirm('Are you sure you want to delete this staff record?')) {

        $.ajax({
            type: "POST",
            url: "/Staff/DeleteData?staffID=" + staffID,
            success: function (data) {
                if (data.success) {
                    dataTable.ajax.reload();
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


//for Branch Page
var dtTable, FromPopup;

    $(document).ready(function () {
        dtTable = $("#branchTable").DataTable({
            "ajax": {
                "url": "/Admin/GetBranch",
                "type": "GET",
                "datatype": "Json"
            },
            "columns": [
                { "data": "BRANCH_NAME" },
                { "data": "PLACE_NAME" },
                { "data": "PRIMARY_NUMBER" },
                { "data": "SECONDARY_NUMBER" },
                {
                    "data": "BRANCH_CODE", "render": function (data) {
                        return "<a class='btn btn-outline-dark btn-sm' onclick=BranchForm('/Admin/AddBranch?branchCode=" + data + "')><i class='fa fa-pencil'></i> Edit</a><a class='btn btn-outline-dark btn-sm' style='margin-left:5px' onclick=BranchDelete('" + data + "')><i class='fa fa-trash'></i> Delete</a>";
                    },
                    "orderable": false,
                    "searchable":false,
                    "width":"150px"
                }
            ],
        });
        return false;
    });

function BranchForm(url) {
    var formDiv = $('<div/>');
    $.get(url)
    .done(function (response) {
        formDiv.html(response);

        FromPopup = formDiv.dialog({
            autoOpen: true,
            resizable: true,
            title: 'Branch Operation',
            height: 380,
            width: 500,
            close: function () {
                FromPopup.dialog('destroy').remove();
                dtTable.ajax.reload();
            }
        });
    });
    return false;
}

function BranchDelete(brCode) {
    if (confirm('Are you sure you want to delete this staff record?')) {
        $.ajax({
            type: "POST",
            url: "/Admin/DeleteBranch?brCode=" + brCode,
            success: function (data) {
                if (data.success) {
                    dtTable.ajax.reload();
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

//for address page
    var datatableAdd, popUp;
        $(document).ready(function () {
            datatableAdd = $("#addressTable").DataTable({
                "ajax": {
                    "url": "/Admin/GetAddress",
                    "type": "GET",
                    "datatype": "json"
                },
                "columns": [
                    { "data": "Place_name" },
                    { "data": "Mun_VDC" },
                    { "data": "Ward_No" },
                    {"data":"Address_Code" , "render" : function (data) {
                        return "<a class='btn btn-outline-dark btn-sm' onclick=AddressForm('/Admin/AddAddress?addressCode=" + data + "')><i class='fa fa-pencil'></i> Edit</a><a class='btn btn-outline-dark btn-sm' style='margin-left:5px' onclick=DeleteAdd('" + data + "')><i class='fa fa-trash'></i> Delete</a>";
                        },
                        "orderable": false,
                        "searchable":false,
                        "width":"150px"
                    }
                ]
            });
        });

        function DeleteAdd(addCode) {
            if (confirm('Are you sure you want to delete this address record?')) {
                $.ajax({
                    type: "POST",
                    url: "/Admin/DeleteAddress?addCode=" + addCode,
                    success: function (data) {
                        if (data.success) {
                            datatableAdd.ajax.reload();
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

        function AddressForm(url) {
            var fromDiv = $('<div/>');
            $.get(url)
            .done(function (response) {
                fromDiv.html(response);

                popUp = fromDiv.dialog({
                    autoOpen: true,
                    resizeable: true,
                    title: 'Address Form',
                    height: 320,
                    width: 400,
                    close: function () {
                        popUp.dialog('destroy').remove();
                        datatableAdd.ajax.reload();
                    }
                })
            })
        }

//for department page
        var formDiv ,dataTableDept;
        $(document).ready(function () {
            dataTableDept = $("#deptTable").DataTable({
                "ajax": {
                    "url": "/Admin/GetDepartment",
                    "type": "GET",
                    "datatype": "Json"
                },
                "columns": [
                    { "data": "Department_Name" },
                    { "data": "Primary_Number" },
                    { "data": "Secondary_Number" },
                    {"data":"Department_ID" , "render" : function (data) {
                        return "<a class='btn btn-outline-dark btn-sm' onclick=PopupForm('/Admin/AddDepartment?deptID=" + data + "')><i class='fa fa-pencil'></i> Edit</a><a class='btn btn-outline-dark btn-sm' style='margin-left:5px' onclick=DeleteDept('" + data + "')><i class='fa fa-trash'></i> Delete</a>";
                    },
                        "orderable": false,
                        "searchable":false,
                        "width":"150px"
                    }

                ],
                "language": {

                    "emptyTable" : "No data found, Please click on <b>Add New</b> Button"
                }
            });
            return false;
        });

        function DeleteDept(deptID) {
            if (confirm('Are you sure you want to delete this staff record?')) {

                $.ajax({
                    type: "POST",
                    url: "/Admin/DeleteData?deptID=" + deptID,
                    success: function (data) {
                        if (data.success) {
                            dataTableDept.ajax.reload();
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

        function PopupForm(url) {
            fromDiv = $('<div/>');
            $.get(url)
            .done(function (response) {
                fromDiv.html(response);

                popUp = fromDiv.dialog({
                    autoOpen: true,
                    resizeable: true,
                    title: 'Deparment Form',
                    height: 320,
                    width: 400,
                    close: function () {
                        popUp.dialog('destroy').remove();
                        dataTableDept.ajax.reload();
                    }
                })
            })
        }

//for job title
        var dataTableJob;
        $(document).ready(function () {
            dataTableJob = $('#jobTable').DataTable({
                "ajax": {
                    "url": "/Admin/GetJob",
                    "type": "GET",
                    "datatype": "json"
                },
                "columns": [
                    { "data": "Position" },
                    { "data": "Minimum_Salary" },
                    { "data": "Maximum_Salary" },
                    { "data": "Actual_Salary" },
                    {
                        "data": "Job_Title_Code", "render": function (data) {
                            return "<a class='btn btn-outline-dark btn-sm' onclick=PopupForm('/Admin/AddJobTitle?jobCode=" + data + "')><i class='fa fa-pencil'></i> Edit</a><a class='btn btn-outline-dark btn-sm' style='margin-left:5px' onclick=DeleteJo('" + data + "')><i class='fa fa-trash'></i> Delete</a>";
                        },
                        "orderable": false,
                        "searchable":false,
                        "width":"150px"
                    },
                ]
            });
        });

        function DeleteJo(jobID) {
            if (confirm('Are you sure you want to deleted this?')) {

                $.ajax({
                    type: "POST",
                    url: "/Admin/DeleteJob?jobID=" + jobID,
                    success: function (data) {
                        if (data.success) {
                            dataTableJob.ajax.reload();
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

        function PopupForm(url) {
            var formDiv = $('<div/>');
            $.get(url)
            .done(function (response) {
                formDiv.html(response);

                Popup = formDiv.dialog({
                    autoOpen: true,
                    resizable: true,
                    title: 'Add Extension Number',
                    height: 370,
                    width: 400,
                    close: function () {
                        Popup.dialog('destroy').remove();
                        dataTableJob.ajax.reload();
                    }
                });
            });
        }