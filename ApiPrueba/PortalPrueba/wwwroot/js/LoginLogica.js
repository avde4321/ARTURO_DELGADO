//Logica de pantalla login

function menu() {
    document.getElementById('btn_Menu').style.display = "none";
}

menu();

var prueba;

function registrar() {
    var nombre = $('#txt_name').val();
    var apellido = $('#txt_lastname').val();
    var email = $('#txt_email').val();
    var clave = $('#txt_password').val();
}

function logoneo() {
    var user = $('#txt_email1').val();
    var pass = $('#txt_password1').val();

    var resval = ValidaCamp(user, pass);

    if (resval === 'OK') {
        $.ajax({
            url: '/Login/Logoneo/',
            type: 'get',
            dataType: "json",
            async: false,
            data: {
                usuario: user, clave: pass
            },
            success: function (data) {
                prueba = data.code;
                if (data.code === 0) {
                    window.location.href = "/Detalle/Index";
                }
                else
                    Swal.fire("LOGIN", data.data, "warning");
            },
            error: function (data) {
                alert(data);
            }
        });
    }
    else
        Swal.fire("LOGIN", resval, "warning");
}

function ValidaCamp(use, pass) {
    if (use === '')
        return 'El Usuario es oblicatorio'
    else if (pass === '')
        return 'La Clave es oblicatorio'
    else
        return 'OK'
}