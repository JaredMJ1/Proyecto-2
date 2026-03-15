
function UserViewController() {

    this.ViewName = "Users";
    this.API_ControllerName = "User";

    this.InitView = function () {
        this.LoadTable();

        $('#btnCreate').click(function () {
            var vc = new UserViewController();
            vc.Create();
        });

        $('#btnUpdate').click(function () {
            var vc = new UserViewController();
            vc.Update();
        });

        $('#btnDelete').click(function () {
            var vc = new UserViewController();
            vc.Delete();
        });
    }

    this.LoadTable = function () {

        var ca = new ControlActions();
        var endPoint = this.API_ControllerName + "/RetrieveAll";
        var urlService = ca.GetUrlApiService(endPoint);

        var columns = [];

        columns[0] = { "data": "id" };
        columns[1] = { "data": "name" };
        columns[2] = { "data": "lastname" };
        columns[3] = { "data": "birthday" };
        columns[4] = { "data": "status" };
        columns[5] = { "data": "createdAt" };

        $("#tblUsers").DataTable({
            "ajax": {
                url: urlService,
                "dataSrc": ""
            },
            "columns": columns
        });

        $('#tblUsers tbody').on('click', 'tr', function () {

            var row = $(this).closest("tr");
            var userDTO = $('#tblUsers').DataTable().row(row).data();

            $('#txtId').val(userDTO.id);
            $('#txtName').val(userDTO.name);
            $('#txtLastName').val(userDTO.lastname);
            $('#txtEmail').val(userDTO.email);
            $('#txtPhone').val(userDTO.phone);
            $('#txtStatus').val(userDTO.status);

            if (userDTO.birthday) {
                var onlyDate = userDTO.birthday.split("T");
                $('#txtBirthDate').val(onlyDate[0]);
            } else {
                $('#txtBirthDate').val("");
            }
        });
    }

    this.Create = function () {

        var userDTO = {};

        userDTO.id = 0;
        userDTO.created = "2026-01-01";
        userDTO.updated = "2026-01-01";

        userDTO.name = $("#txtName").val();
        userDTO.lastname = $("#txtLastName").val();
        userDTO.email = $("#txtEmail").val();
        userDTO.phone = $("#txtPhone").val();
        userDTO.status = $("#txtStatus").val();
        userDTO.birthday = $("#txtBirthDate").val();
        userDTO.passwordHash = $("#txtPwd").val();

        var ca = new ControlActions();
        var urlEndPoint = this.API_ControllerName + "/Create";

        ca.PostToAPI(urlEndPoint, userDTO, function () {
            $("#tblUsers").DataTable().ajax.reload();
        });
    }

    this.Update = function () {

        var userDTO = {};

        userDTO.created = "2026-01-01";
        userDTO.updated = "2026-01-01";

        userDTO.id = $("#txtId").val();
        userDTO.name = $("#txtName").val();
        userDTO.lastname = $("#txtLastName").val();
        userDTO.email = $("#txtEmail").val();
        userDTO.phone = $("#txtPhone").val();
        userDTO.status = $("#txtStatus").val();
        userDTO.birthday = $("#txtBirthDate").val();
        userDTO.passwordHash = $("#txtPwd").val();

        var ca = new ControlActions();
        var urlEndPoint = this.API_ControllerName + "/Update";

        ca.PutToAPI(urlEndPoint, userDTO, function () {
            $("#tblUsers").DataTable().ajax.reload();
        });
    }

    this.Delete = function () {

        var userDTO = {};

        userDTO.created = "2026-01-01";
        userDTO.updated = "2026-01-01";

        userDTO.id = $("#txtId").val();
        userDTO.name = $("#txtName").val();
        userDTO.lastname = $("#txtLastName").val();
        userDTO.email = $("#txtEmail").val();
        userDTO.phone = $("#txtPhone").val();
        userDTO.status = $("#txtStatus").val();
        userDTO.birthday = $("#txtBirthDate").val();
        userDTO.passwordHash = $("#txtPwd").val();

        var ca = new ControlActions();
        var urlEndPoint = this.API_ControllerName + "/Delete";

        ca.DeleteToAPI(urlEndPoint, userDTO, function () {
            $("#tblUsers").DataTable().ajax.reload();
        });
    }
}

$(document).ready(function () {
    var vc = new UserViewController();
    vc.InitView();
});