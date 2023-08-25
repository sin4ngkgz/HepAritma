
function GetUsers() {
    Get("User/ActiveUsers", (data) => {
        var html = `<table class="table table-hover">` +
            `<tr><th style="width:50px">Id</th><th>Rol Id</th><th>Ad</th><th>Soyad</th><th>Rol Adı</th><th>Email</th><th>Telefon Numarası</th><th>Adres</th><th></th></tr>`;

        var arr = data;

        for (var i = 0; i < arr.length; i++) {
            html += `<tr>`;
            html += `<td>${arr[i].userId}</td><td>${arr[i].roleId}</td>`;
            html += `<td>${arr[i].firstName}</td><td>${arr[i].lastName}</td>`;
            html += `<td>${arr[i].role}</td><td>${arr[i].email}</td><td>${arr[i].phoneNumber}</td><td><button type="button" class="btn btn-secondary font-size-small text-center text-light" onclick="GetAddressListByUserId(${arr[i].userId})"">Adresler</button></td>`;
            html += `<td><button type="button" class="btn btn-danger text-light" onclick='DeleteUser(${arr[i].userId})'>Sil <i class="bi bi-trash3"></i></button></td>`;
            html += `</tr>`
        }
        html += `</table>`;

        $("#divUsers").html(html);
    });
}

let selectedUserId = 0;
let selectedAddressId = 0;
let selectedAddressUserId;

function GetAddressListByUserId(id) {
    Get(`Address/AddressListByUserId?id=${id}`, (data) => {
        var html = `<table class="table table-striped table-hover ">` +
            `<tr><th>Ad</th><th>Soyad</th><th>Adres Başlığı</th><th>Adres Bilgileri</th><th>Şehir Adı</th><th>İlçe Adı</th><th>Ülke Adı</th><th>Posta Kodu</th><th style="width:250px"></th></tr>`;

        var arr = data;

        for (var i = 0; i < arr.length; i++) {
            html += `<tr>`;
            html += `<td>${arr[i].ad}</td><td>${arr[i].soyad}</td><td>${arr[i].adresBasligi}</td><td>${arr[i].adresBilgileri}</td><td>${arr[i].sehirAdi}</td><td>${arr[i].ilceAdi}</td><td>${arr[i].ulkeAdi}</td><td>${arr[i].postaKodu}</td>`;
            html += `<td><button type="button" class="btn btn-warning me-3 text-dark" onclick='EditAddress(${arr[i].id},${arr[i].userId},"${arr[i].ad}","${arr[i].soyad}","${arr[i].adresBasligi}","${arr[i].adresBilgileri}",${arr[i].sehirId},${arr[i].ilceId},${arr[i].ulkeId},"${arr[i].postaKodu}")'>Düzenle <i class="bi bi-pencil"></i></button><button type="button" class="btn btn-danger text-dark" onclick="DeleteAddress(${arr[i].id})">Sil <i class="bi bi-trash3"></i></button></td>`;
            html += `</tr>`
        }
        html += `</table>`;

        selectedAddressUserId = id;
        $("#divAddressList").html(html);
        $("#addressModal").modal("show");
    })
}

function GetSelectBox() {
    Get("Address/GetCities", (data) => {
        var arr = data;

        $('#selectCity').empty();
        $.each(arr, function (i, item) {
            $('#selectCity').append($('<option>', {
                value: item.id,
                text: item.name
            }));
        });
    });

    Get("Address/GetDistricts", (data) => {
        var arr = data;

        $('#selectDistrict').empty();
        $.each(arr, function (i, item) {
            $('#selectDistrict').append($('<option>', {
                value: item.id,
                text: item.name
            }));
        });
    });

    Get("Address/GetCountries", (data) => {
        var arr = data;

        $('#selectCountry').empty();
        $.each(arr, function (i, item) {
            $('#selectCountry').append($('<option>', {
                value: item.id,
                text: item.name
            }));
        });
    });
}

function SignUp() {
    let selectedUserId = 0;
    $("#inputFirstName").val("");
    $("#inputLastName").val("");
    $("#inputPhoneNumber").val("");
    $("#inputEmail").val("");
    $("#inputPassword").val("");
    $("#userModal").modal("show");
}

function SaveUser() {
    var user = {
        Id: selectedUserId,
        Name: $("#inputUserName").val()
    };
    Post("User/SignUp", user, (data) => {
        GetUsers();
        $("#userModal").modal("hide");
    });
}


function DeleteUser(id) {
    Delete(`User/Delete?id=${id}`, (data) => {
        GetUsers();
    });
}


function DeleteAddress(id) {
    Delete(`Address/Delete?id=${id}`, (data) => {
        GetAddressListById();
    });
}

function EditAddress(id, userId, ad, soyad, adresAdi, adresAciklamasi, sehirId, ilceId, ulkeId, postaKodu) {
    selectedAddressId = id;
    selectedAddressUserId = userId;
    $("#inputFirstName").val(ad);
    $("#inputLastName").val(soyad);
    $("#inputAddressName").val(adresAdi);
    $("#inputDescription").val(adresAciklamasi);
    document.getElementById('selectCity').value = sehirId;
    document.getElementById('selectDistrict').value = ilceId;
    document.getElementById('selectCountry').value = ulkeId;
    $("#inputZipCode").val(postaKodu);
    $("#addressEditModal").modal("show");
}
function SaveAddress() {
    var address = {
        Id: selectedAddressId,
        UserId: selectedAddressUserId,
        FirstName: $("#inputFirstName").val(),
        LastName: $("#inputLastName").val(),
        AddressName: $("#inputAddressName").val(),
        Description: $("#inputDescription").val(),
        CountryId: $("#selectCountry").find(":selected").val(),
        CityId: $("#selectCity").find(":selected").val(),
        DistrictId: $("#selectDistrict").find(":selected").val(),
        ZipCode: $("#inputZipCode").val()
    };

    Post("Address/Add", address, (data) => {
        GetSelectBox();
        $("#addressEditModal").modal("hide");
        GetAddressListByUserId(selectedAddressUserId);
    })
}

function NewAddress() {
    selectedAddressId = 0;
    $("#inputAddressName").val("");
    $("#inputFirstName").val("");
    $("#inputLastName").val("");
    $("#inputDescription").val("");
    $("#inputZipCode").val("");
    $("#addressEditModal").modal("show");
}


$(document).ready(function () {
    GetUsers();
    GetSelectBox();
    
});