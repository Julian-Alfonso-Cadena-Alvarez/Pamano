function validacion() {

    var idproducto = document.getElementById('IdProducto').value;
    var cantida = document.getElementById('CantidadDeProducto').value;
    var precio = document.getElementsByName('PrecioDelProducto').value;
    var carac = document.getElementById('CaracteristicasDelProducto').value;

    if (idproducto == null) {

        alert('ERROR: Debes Poner un valor en el capo del producto');
        return false;
    }
    
    if (idproducto.length > 12) {

        alert('ERROR: Debes Poner un valor mas pequeño al Id producto');
        return false;
    }
    
    if (idproducto.length < 3) {

        alert('ERROR: Debes Poner un valor mas grande al Id producto');
        return false;
    }

    if (cantida == null) {

        alert('ERROR: Debes Poner un valor a la cantidad del producto');
        return false;
    }
    if (cantida.length > 4) {

        alert('ERROR: Es una cantidad my grande, verifica la cantidad');
        return false;
    }

    if (carac == null) {

        alert('ERROR: Debes Poner un valor a la cantidad del producto');
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