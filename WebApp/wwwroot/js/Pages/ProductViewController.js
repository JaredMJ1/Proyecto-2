function ProductViewController() {

    this.tblProductsId = 'tblProducts';
    this.service = 'Product';
    this.API_ControllerName = "Product";
    var ca = new ControlActions();

    this.InitView = function () {
        this.LoadTable();
    }

    this.LoadTable = function () {

        $("#" + this.tblProductsId).DataTable({
            ajax: {
                url: ca.GetUrlApiService(this.service + "/RetrieveAll"),
                dataSrc: ''
            },
            columns: [
                { data: 'id' },
                { data: 'name' },
                { data: 'category' },
                { data: 'quantity' },
                { data: 'price' },
                { data: 'status' },
                { data: 'createdAt' }
            ]
        });

        $('#tblProducts tbody').on('click', 'tr', function () {

            var row = $(this).closest("tr");
            var productDTO = $('#tblProducts').DataTable().row(row).data();

            $('#txtId').val(productDTO.id);
            $('#txtName').val(productDTO.name);
            $('#txtDescription').val(productDTO.description);
            $('#txtCategory').val(productDTO.category);
            $('#txtQuantity').val(productDTO.quantity);
            $('#txtPrice').val(productDTO.price);
            $('#txtStatus').val(productDTO.status);
        });
    }

    this.Create = function () {

        var productDTO = {};

        productDTO.id = 0;
        productDTO.created = "2026-01-01";
        productDTO.updated = "2026-01-01";

        productDTO.name = $("#txtName").val();
        productDTO.description = $("#txtDescription").val();
        productDTO.category = $("#txtCategory").val();
        productDTO.quantity = $("#txtQuantity").val();
        productDTO.price = $("#txtPrice").val();
        productDTO.status = $("#txtStatus").val();

        var ca = new ControlActions();
        var urlEndPoint = this.API_ControllerName + "/Create";

        ca.PostToAPI(urlEndPoint, productDTO, function () {
            $("#tblProducts").DataTable().ajax.reload();
        });
    }

    this.Update = function () {

        var productDTO = {};

        productDTO.created = "2026-01-01";
        productDTO.updated = "2026-01-01";

        productDTO.id = $("#txtId").val();
        productDTO.name = $("#txtName").val();
        productDTO.description = $("#txtDescription").val();
        productDTO.category = $("#txtCategory").val();
        productDTO.quantity = $("#txtQuantity").val();
        productDTO.price = $("#txtPrice").val();
        productDTO.status = $("#txtStatus").val();

        var ca = new ControlActions();
        var urlEndPoint = this.API_ControllerName + "/Update";

        ca.PutToAPI(urlEndPoint, productDTO, function () {
            $("#tblProducts").DataTable().ajax.reload();
        });
    }

    this.Delete = function () {

        var productDTO = {};

        productDTO.created = "2026-01-01";
        productDTO.updated = "2026-01-01";

        productDTO.id = $("#txtId").val();
        productDTO.name = $("#txtName").val();
        productDTO.description = $("#txtDescription").val();
        productDTO.category = $("#txtCategory").val();
        productDTO.quantity = $("#txtQuantity").val();
        productDTO.price = $("#txtPrice").val();
        productDTO.status = $("#txtStatus").val();

        var ca = new ControlActions();
        var urlEndPoint = this.API_ControllerName + "/Delete";

        ca.DeleteToAPI(urlEndPoint, productDTO, function () {
            $("#tblProducts").DataTable().ajax.reload();
        });
    }
}

$(document).ready(function () {

    var vc = new ProductViewController();
    vc.InitView();

});