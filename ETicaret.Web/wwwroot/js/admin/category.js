
let Categories = [];

function GetCategories()
{
    Get("Category/AllCategories", (data) =>
    {
        var arr = data;

        $(`#selectTopCategories`).empty();
        $.each(arr, function(i, item)
        {
            $(`#selectTopCategories`).append($(`<option>`,
            {
                value: item.id,
                text: item.name

            }));
        });
    });
}

function GetCategoryList() {
    Get("Category/CategoryList", (data) => {
        var html = `<table class="table table-hover">` +
            `<tr><th style="width:50px">Sıra</th><th>Kategori Adı</th><th>Üst Kategori Adı</th><th>Aktif</th><th></th></tr>`;

        var arr = data;
        Categories = arr;

        for (var i = 0; i < arr.length; i++) {
            html += `<tr>`;
            html += `<td>${arr[i].place}</td>`;
            html += `<td>${arr[i].categoryName}</td><td>${arr[i].topCategoryName}</td>`;
            html += `<td>${arr[i].active}</td>`;
            html += `<td><button type="button" class="btn btn-danger text-light" onclick='DeleteCategory(${arr[i].id})'>Sil <i class="bi bi-trash3"></i></button>&nbsp;&nbsp;<button type="button" class="btn btn-success text-light" onclick='EditCategory(${arr[i].id},"${arr[i].categoryName}",${arr[i].topCategoryId},${arr[i].active},${arr[i].place})'>Düzenle <i class="bi bi-pencil"></i></button></td>`;
            html += `</tr>`
        }
        html += `</table>`;

        $("#divCategories").html(html);
    });
}
let selectedCategoryId = 0;

function NewCategory() {
    selectedCategoryId = 0;
    $("#inputCategoryName").val("");
    $("#categoryModal").modal("show");
}

function SaveCategory() {
    var category = {
        Id: selectedCategoryId,
        Name: $("#inputCategoryName").val(),
        TopCategoryId: $("#selectTopCategories").find(":selected").val(),
        Active: $("#inputAktifMi").is(":checked"),
        Place:$("#inputPlace").val()
    };
    Post("Category/AddCategories", category, (data) => {
        GetCategories();
        GetCategoryList();
        $("#categoryModal").modal("hide");
    });
}

function DeleteCategory(id) {
    Delete(`Category/Delete?id=${id}`, (data) => {
        GetCategories();
        GetCategoryList();
    });
}

function EditCategory(id, name, topCategoryId, active, place) {
    selectedCategoryId = id;
    $("#inputCategoryName").val(name);
    document.getElementById('selectTopCategories').value = topCategoryId;
    if (active) {
        document.getElementById("inputAktifMi").setAttribute("checked", "");
    }
    $("#inputPlace").val(place);

    $("#categoryModal").modal("show");
}

$(document).ready(function () {
    GetCategories();
    GetCategoryList();
});