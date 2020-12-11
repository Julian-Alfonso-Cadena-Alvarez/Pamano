


function validacion() {

    var telefono = document.getElementById('telefono').value;
    
    if (telefono == null || telefono.length == 0 || /^\s+$/.test(telefono) || !/^.{8,11}$/.test(telefono)) {
        alert('ERROR: El telefono no debe ir vacío o no debe tener menos de 4 caracteres y mas de 12 caracteres');
        return false;
    }
};