


function validacion(){
   
    var contraseña1 = document.getElementById('contraseña1').value;
    var contraseña2 = document.getElementById('contraseña2').value;
    var confirmar = document.getElementById('confirmar').value;
      

    if(contraseña1 == null || contraseña1.length == 0 || /^\s+$/.test(contraseña1) || !/^.{4,12}$/.test(contraseña1) ){
        alert('ERROR: El campo Contraseña no debe ir vacío o no debe tener menos de 4 caracteres y mas de 12 caracteres');
        return false;
    }

  if(contraseña1 == contraseña2){
      alert('ERROR: La nueva contraseña no puede ser igual a la anterior');
      return false;
  }

    if(contraseña2 == null || contraseña2.length == 0 || /^\s+$/.test(contraseña2) || !/^.{4,12}$/.test(contraseña2) ){
        alert('ERROR: El campo Contraseña no debe ir vacío o no debe tener menos de 4 caracteres y mas de 12 caracteres');
        return false;
    }


    if(confirmar == null || confirmar.length == 0 || /^\s+$/.test(confirmar) || /^.{4,12}$/.test(confirmar)  ){
        alert('ERROR: El campo Confirmar Contraseña no debe ir vacío o no debe tener menos de 4 caracteres y mas de 12 caracteres');
        return false;
    }

    if(confirmar != contraseña2){
        alert('ERROR: La nueva contraseña no coincide con la confirmacion');
        return false;
    }
};