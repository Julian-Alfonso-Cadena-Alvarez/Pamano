


function validacion() {

    var correo = document.getElementById('Email').value;
    var correo1 = document.getElementById('NewEmail').value;

    if (correo1 == null || correo1.length == 0 || /^\s+$/.test(correo1) || !/^{8,25}$/.test(correo1)) {
        alert('ERROR: El telefono no debe ir vacío o no debe tener menos de 4 caracteres y mas de 12 caracteres');
        return false;
    }
    if (correo1 == correo) {
        alert('Error: No puedes poner el mismo correo')
        return false;
    }
}