
function UserViewController() {

    this.ViewName = "Users";

    this.API_ControllerName = "User";

    this.InitView = function () {
        this.LoadTable();
    }

    this.LoadTable = function () {

        var ca = new ControlActions();
        var endPoint = this.API_ControllerName + "/RetrieveALL";

        var urlService = ca.GetUrlApiService(endPoint);

        var columns = [];

        columns[0] = { "data": "id" };
        columns[1] = { "data": "name" };
        columns[2] = { "data": "lastname" };
        columns[3] = { "data": "birthday" };
        columns[4] = { "data": "status" };
        columns[5] = { "data": "createdAt" };

        $("#tblUsers").dataTable({
            "ajax": {
                url: urlService,
                "dataSrc": ""
            },
            "columns": columns
        });

    }
}

$(document).ready(function () {
    var vc = new UserViewController();
    vc.InitView();
})