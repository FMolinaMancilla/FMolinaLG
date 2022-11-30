$(document).ready(function () {
    GetAll();
    EstadoGetAll();
    $('#btnAgregar').click(function () {
        $('#Formulario').modal('show');
    });
});


function GetAll() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:16942/api/Empleado/GetAll',
        success: function (result) {
            $('#TableEmpleado tbody').empty();
            $.each(result, function (i, empleado) {
                var filas =
                    '<tr>' +
                    '<td class="text-center">' +
                    '<a class="btn btn-warning glyphicon glyphicon-edit" href="#" onclick="GetById(' + empleado.IdEmpleado + ')">' + '</a>' +
                    '</td>' +
                    "<td class='text-center'>" + empleado.IdEmpleado + "</td>" +
                    "<td class='text-center'>" + empleado.NumeroNomina + "</td>" +
                    "<td class='text-center'>" + empleado.Nombre + "</td>" +
                    "<td class='text-center'>" + empleado.ApellidoPaterno + "</td>" +
                    "<td class='text-center'>" + empleado.ApellidoMaterno + "</td>" +
                    "<td class='text-center'>" + empleado.Estado.IdEstado + "</td>"
                    + '<td class="text-center"> <button class="btn btn-danger" id="btnEliminar"><span class="glyphicon glyphicon-trash" style="color:#FFFFFF"></span></button></td>'
                    + '</tr>';
                $("#TableEmpleado tbody").append(filas);
            });
        },
        error: function (result) {
            alert('Error en la consulta. ' + result.responseJSON.result);
        }
    });
};

function EstadoGetAll() {
    $("#ddlEstados").empty();
    $.ajax({
        type: 'GET',
        url: 'http://localhost:16942/api/Estado/GetAll',
        success: function (result) {
            $("#ddlEstados").append('<option value="' + 0 + '">' + 'Seleccione una opcion' + '</option>');
            $.each(result, function (i, estado) {
                $("#ddlEstados").append('<option value="'
                    + estado.IdEstado + '">'
                    + estado.Nombre + '</option>');
            });
        }
    });
};

//function Guardar() {

//    var empleado = $('#txtIdEmpleado').val();
//    if (txtIdEmpleado == "") {
//        Add(empleado);
//    }
//    else {
//        Update(empleado);
//    }
//}


//function Add(empleado) {

//    var empleado = {
//        IdEmpleado: 0,
//        NumeroNomina: $('txtNumeroNomina').val(),
//        Nombre: $('txtNombre').val(),
//        ApellidoPaterno: $('txtApellidoPaterno').val(),
//        ApellidoMaterno: $('txtApellidoMaterno').val(),
//        Estado: {
//            IdEstado: $('#ddlEstados').val(0)
//        }
//    } 


function Add(empleado) {

    $.support.cors = true;
    $.ajax({
        type: 'POST',
/*        crossDomain: true,*/
        url: 'http://localhost:16942/api/Empleado/Add',
        dataType: 'json',
        data: JSON.stringify(empleado),
        contentType: 'application/json; charset=utf-8',
 /*       data: empleado,*/
        success: function (result) {
            $('#myModal').modal();
            $('#ModalUpdate').modal('hide');
            GetAll();
        },
        //error: function (result) {
        //    alert('Error' + result.responseJSON.ErrorMessage);
        //}
    });
};


function Update(empleado) {
    $.ajax({
        type: 'POST',
        url: 'http://localhost:16942/api/Empleado/Update',
        dataType: 'json',
        data;
    })
}

function Modal() {
    var mostrar = $('#ModalUpdate').modal('show');
    IniciarEmpleado();

}

function Actualizar() {
    var empleado = {
        IdEmpleado: $('#txtIdEmpleado').val(),
        NumeroNomina: $('#txtNumeroNomina').val(),
        Nombre: $('#txtNombre').val(),
        ApellidoPaterno: $('#txtApellidoPaterno').val(),
        ApellidoMaterno: $('#txtApellidoMaterno').val(),
        Estado: {
            IdEstado: $('#ddlEstados').val()
        }
    }

    if (empleado.IdEmpleado == '') {
        Add(empleado);

    }
    else {
        Update(empleado);
    }
}

function IniciarEmpleado() {

    var empleado = {
        IdEmpleado: $('#txtIdEmpleado').val(''),
        NumeroNomina: $('#txtNumeroNomina').val(''),
        Nombre: $('#txtNombre').val(''),
        ApellidoPaterno: $('#txtApellidoPaterno').val(''),
        ApellidoMaterno: $('#txtApellidoMaterno').val(''),
        Estado: {
            IdEstado: $('#ddlEstados').val(0)
        }
    }
}