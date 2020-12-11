function validacion() {

    var cantidad = document.getElementById('CantidadDeProducto').value;
    var precio = document.getElementById('PrecioDelProducto').value;
    var carac = document.getElementById('CaracteristicasDelProducto').value;

    if (cantidad == null) {

        alert('ERROR: Debes Poner un valor a la cantidad del producto');
        return false;
    }

    if (carac == null) {

        alert('ERROR: Debes Poner un valor a la cantidad del producto');
        return false;
    }
    if (cantidad.length > 4) {

        alert('ERROR: Es una cantidad my grande, verifica la cantidad');
        return false;
    }
    if (carac.length > 31) {

        alert('ERROR: El tamaño de las caracteristicas del producto es muy grande');
        return false;
    }
    if (carac.length < 4) {

        alert('ERROR: El tamaño de las caracteristicas del producto es muy pequeña');
        return false;
    }
    if (/^\s.+$/.test(precio)) {

        alert('ERROR: Verifica el precio, formato inadecuado1');
        return false;
    }
    if (/^\s+$/.test(carac)) {

        alert('ERROR: Verifica las caracteristicas, formato inadecuado');
        return false;
    }
    if (carac === "") {

        alert('ERROR: Verifica las caracteristicas, formato inadecuado');
        return false;
    }
}
