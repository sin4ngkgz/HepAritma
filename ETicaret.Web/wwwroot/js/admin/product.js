
function GetProducts() {
    Get("Product/AllProducts", (data) => {
        var html = `<table class="table table-hover">` +
            `<tr><th style="width:50px">Id</th><th>Ürün Adı</th><th>Ürün Açıklaması</th><th>Ürün Başlığı</th><th>Ürün Fiyatı</th><th></th></tr>`;

        var arr = data;

        for (var i = 0; i < arr.length; i++) {
                html += `<tr>`;
                html += `<td>${arr[i].id}</td><td>${arr[i].name}</td>`;
                html += `<td>${arr[i].description}</td>`;
                html += `<td>${arr[i].title}</td>`;
                html += `<td>${arr[i].price}</td>`;
            html += `<td><button type="button" class="btn btn-danger text-light" onclick='ProductDelete(${arr[i].id})'>Sil <i class="bi bi-trash3"></i></button>&nbsp;&nbsp;<button type="button" class="btn btn-success text-light" onclick='EditProduct(${arr[i].id},"${arr[i].name}","${arr[i].description}","${arr[i].title}","${arr[i].price}")'>Düzenle <i class="bi bi-pencil"></i></button></td>`;
                html += `</tr>`
        }
        html += `</table>`;

        $("#divProducts").html(html);
    });
}

let selectedProductId = 0;

function NewProduct() {
    let selectedProductId = 0;
    $("#inputProductName").val("");
    $("#inputProductDescription").val("");
    $("#inputProductTitle").val("");
    $("#inputProductPrice").val("");
    $("#productModal").modal("show");
}

function SaveProduct() {
    var product = {
        Id: selectedProductId,
        Name: $("#inputProductName").val(),
        Description: $("#inputDescription").val(),
        Title: $("#inputTitle").val(),
        Price: $("#inputPrice").val()
    };
    Post("Product/Add", product, (data) => {
        GetProducts();
        $("#productModal").modal("hide");
    });
}


function ProductDelete(id) {
    Delete(`Product/Delete?id=${id}`, (data) => {
        GetProducts();
    });
}

function EditProduct(id, name, description, title, price) {
    selectedProductId = id;
    $("#inputProductName").val(name);
    $("#inputDescription").val(description);
    $("#inputTitle").val(title);
    $("#inputPrice").val(price);
    $("#productModal").modal("show");
}

$(document).ready(function () {
    GetProducts();
});