


function validacion(){
    var nombres = document.getElementById('nombres').value;
    var apellidos = document.getElementById('apellidos').value;
    var telefono = document.getElementById('telefono').value;
    var correo = document.getElementById('correo').value;;
    var cmbSelector = document.getElementById('selector').selectedIndex;
    var marca = document.getElementById('marca').value;
    var empresa = document.getElementById('empresa').value;
    var direccionem = document.getElementById('direccionem').value;
    var cedula = document.getElementById('Cedula').value;

    if (cedula == null || cedula.length < 6 || /^\s+$/.test(cedula) || !/^[a-zA-ZÀ-ÿ\s]{1,40}$/.test(cedula))
    {
        alert('ERROR: El campo Documento de Identidad no puede ir vacio o con caracteres diferentes a numeros');
        return false;

    }

    if(nombres == null || nombres.length == 0 || /^\s+$/.test(nombres) || !/^[a-zA-ZÀ-ÿ\s]{1,40}$/.test(nombres) ){
        alert('ERROR: El campo Nombres no debe ir vacío o con valores numericos');
        return false;
      }

    if(apellidos == null || apellidos.length == 0 || /^\s+$/.test(apellidos) || !/^[a-zA-ZÀ-ÿ\s]{1,40}$/.test(apellidos) ){
        alert('ERROR: El campo Apellidos no debe ir vacío o con valores numericos');
        return false;
    }

  

    if(telefono == null || telefono.length == 0 || /^\s+$/.test(telefono) || !/^\d{5,11}$/.test(telefono) ){
        alert('ERROR: El campo Telefono no debe ir vacío o con letras');
        return false;
    }

    if(correo == null || correo.length == 0 || /^\s+$/.test(correo) || !/^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$/.test(correo) ){
        alert('ERROR: El campo Correo no debe ir vacío');
        return false;
    }

    

    if(cmbSelector == null || cmbSelector == 0){
        alert('ERROR: Debe seleccionar tipo de producto');
        return false;
    }

    if(marca == null || marca.length == 0 || /^\s+$/.test(marca) || !/^[a-zA-ZÀ-ÿ\s]{1,40}$/.test(marca) ){
        alert('ERROR: El campo Marca no debe ir vacío o con valores numericos');
        return false;
      }

      if(empresa == null || empresa.length == 0 || /^\s+$/.test(empresa) || !/^[a-zA-ZÀ-ÿ\s]{1,40}$/.test(empresa) ){
        alert('ERROR: El campo Empresa no debe ir vacio');
        return false;
      }

      if(direccionem == null || direccionem.length == 0 || /^\s+$/.test(direccionem) ){
        alert('ERROR: El campo Direccion no debe ir vacio');
        return false;
      }
};