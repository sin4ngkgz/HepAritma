

function GetRoles() {
    Get("Role/AllRoles", (data) => {
        var html = `<table class="table table-hover">` +
            `<tr><th style="width:50px">Id</th><th>Rol Adı</th><th></th></tr>`;

        var arr = data;

        for (var i = 0; i < arr.length; i++) {
            html += `<tr>`;
            html += `<td>${arr[i].id}</td><td>${arr[i].name}</td>`;
            html += `<td><button type="button" class="btn btn-danger text-light" onclick='DeleteRole(${arr[i].id})'>Sil <i class="bi bi-trash3"></i></button>&nbsp;&nbsp;<button type="button" class="btn btn-success me-3 text-light" onclick='EditRole("${arr[i].id}","${arr[i].name}")'>Düzenle <i class="bi bi-pencil"></i></button></td>`;
            html += `</tr>`
        }
        html += `</table>`;

        $("#divRoles").html(html);
    });
}

let selectedRoleId = 0;

function NewRole() {
    let selectedRoleId = 0;
    $("#inputRoleName").val("");
    $("#rolModal").modal("show");
}

function SaveRole() {
    var role = {
        Id: selectedRoleId,
        Name: $("#inputRoleName").val()
    };
    Post("Role/Add", role, (data) => {
        GetRoles();
        $("#rolModal").modal("hide");
    });
}


function DeleteRole(id) {
    Delete(`Role/Delete?id=${id}`, (data) => {
        GetRoles();
    });
}

function EditRole(id,name) {
    selectedRoleId = id;
    $("#inputRoleName").val(name);
    $("#rolModal").modal("show");
}


$(document).ready(function () {
    GetRoles();
});