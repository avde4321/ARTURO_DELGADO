$(document).ready(function () {
    var table = $('#TblDetalle').DataTable({
        responsive: true,
        pageLength: 5,
        lengthMenu: [5, 15, 25, 50, 100]
    });
    new $.fn.dataTable.FixedHeader(table);
});

function validaNumero(evento) {//permite digitar solo numeros
    var key = evento.keyCode || evento.which;
    var tecla = String.fromCharCode(key).toLowerCase();
    var letras = "1234567890";
    var especiales = [8, 37, 39];

    tecla_especial = false;
    for (var i in especiales) {
        if (key == especiales[i]) {
            tecla_especial = true;
            break;
        }
    }

    if (letras.indexOf(tecla) == -1 && !tecla_especial) {
        return false;
    }
}

function validarLetras(evento) {//permite digitar solo letras
    //---------------------------------------------------------------------------------------//  
    var key = evento.keyCode || evento.which;
    var tecla = String.fromCharCode(key).toLowerCase();
    var letras = " áéíóúabcdefghijklmnñopqrstuvwxyzÁÉÍÓÚABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
    var punto = ".";
    var especiales = [8, 37, 39, 46];

    tecla_especial = false;
    for (var i in especiales) {
        if (key == especiales[i]) {
            tecla_especial = true;
            break;
        }
    }

    if (letras.indexOf(tecla) == -1 && !tecla_especial) {
        return false;
    }
}

function GetDetalle() {

    $.ajax({
        url: '/Detalle/listDetalles/',
        type: 'Get',
        dataType: "html",
        async: false,
        data: {

        },
        success: function (data) {
            $('#TblDetalle').html(data);
        },
        error: function (data) {
            alert(data);
        }
    });
}

GetDetalle();

function InserDetalle() {
    var Personas = {
        
        Descripcion: $('#txtDescripcion').val(),
        FechaCreacion: $('#txtFechaCreacion').val(),
        FechaVencimiento: $('#txtFechaVencimiento').val(),
        Completada: $('#txtCompletada').val()
    };

    var validation = valida();

    if (validation === 'OK') {
        $.ajax({
            url: '/Detalle/InsertDetalle/',
            type: 'Post',
            dataType: "json",
            async: false,
            data: {
                detalle
            },
            success: function (data) {
                if (data.code === 0) {
                    Swal.fire("DETALLE", data.data, "success");
                    setTimeout(() => {
                        location.reload();
                    }, '3000');
                }
                else {
                    Swal.fire("DETALLE", data.data, "warning");
                }

            },
            error: function (data) {
                alert(data);
            }
        });
    }
    else
        Swal.fire("PERSONAS", validation, "warning");
}

function valida() {
    if ($('#txtDescripcion').val() === '') { return 'Campo Obligatorio' }
    else if ($('#txtFechaCreacion').val() === '') { return 'Campo Obligatorio' }
    else if ($('#ddlFechaVencimiento').val() === '') { return 'Campo Obligatorio' }
    else if ($('#txtCompletada').val() === '') { return 'Campo Obligatorio' }
    else { return 'OK' }
}

function AddDetalle() {
    $('#ModalAddDetalle').show();
}

function ClosuModal() {
    CleanModal();
    $('#ModalAddDetalle').hide();
}

function CleanModal() {
    $('#txtDescripcion').val('');
    $('#txtFechaCreacion').val('');
    $('#txtFechaVencimiento').val('');
    $('#txtCompletada').val('');
}