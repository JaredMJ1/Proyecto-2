function ProductViewController() {

    this.tblProductsId = 'tblProducts';
    this.service = 'Product';
    this.API_ControllerName = "Product";
    var ca = new ControlActions();

    this.InitView = function () {

        this.LoadTable();

        $("#btnCreate").click(function () {
            var vc = new ProductViewController();
            vc.Create();
        });

        $("#btnUpdate").click(function () {
            var vc = new ProductViewController();
            vc.Update();
        });

        $("#btnDelete").click(function () {
            var vc = new ProductViewController();
            vc.Delete();
        });
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

        productDTO.name = $("#txtName").val();
        productDTO.description = $("#txtDescription").val();
        productDTO.category = $("#txtCategory").val();
        productDTO.quantity = parseInt($("#txtQuantity").val());
        productDTO.price = parseFloat($("#txtPrice").val());
        productDTO.status = $("#txtStatus").val();

        var ca = new ControlActions();
        var urlEndPoint = this.API_ControllerName;

        ca.PostToAPI(urlEndPoint, productDTO, function () {

            $("#tblProducts").DataTable().ajax.reload();

            alert("Producto creado correctamente");
        });
    }

    this.Update = function () {

        var productDTO = {};

        productDTO.id = $("#txtId").val();
        productDTO.name = $("#txtName").val();
        productDTO.description = $("#txtDescription").val();
        productDTO.category = $("#txtCategory").val();
        productDTO.quantity = parseInt($("#txtQuantity").val());
        productDTO.price = parseFloat($("#txtPrice").val());
        productDTO.status = $("#txtStatus").val();

        var ca = new ControlActions();
        var urlEndPoint = this.API_ControllerName;

        ca.PutToAPI(urlEndPoint, productDTO, function () {

            $("#tblProducts").DataTable().ajax.reload();

            alert("Producto actualizado");
        });
    }

    this.Delete = function () {

        var id = $("#txtId").val();

        if (id == "" || id == 0) {
            alert("Seleccione un producto primero");
            return;
        }

        var ca = new ControlActions();
        var urlEndPoint = this.API_ControllerName + "/" + id;

        ca.DeleteToAPI(urlEndPoint, null, function () {

            alert("Producto eliminado");

            $("#tblProducts").DataTable().ajax.reload();

            $("#txtId").val("");
            $("#txtName").val("");
            $("#txtDescription").val("");
            $("#txtCategory").val("");
            $("#txtQuantity").val("");
            $("#txtPrice").val("");
            $("#txtStatus").val("");

        });
    }
}

$(document).ready(function () {

    var vc = new ProductViewController();
    vc.InitView();

});