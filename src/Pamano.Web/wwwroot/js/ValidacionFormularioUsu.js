$(document).ready(function () {

    // =================================================================
    // FORM VALIDATION FEEDBACK ICONS
    // =================================================================
    var faIcon = {
        valid: 'fas fa-check-circle fa-lg text-success',
        invalid: 'fas fa-times-circle fa-lg text-danger',
        validating: 'fas fa-redo'
    }
    // =================================================================

    // =================================================================
    // Validación de Creación de Objetivo
    // =================================================================
    $('#CrearUsuarioForm')
        .on('init.field.bv', function (e, data) {
            // $(e.target)  --> The field element
            // data.bv      --> The BootstrapValidator instance
            // data.field   --> The field name
            // data.element --> The field element
            var $parent = data.element.parents('.form-group'),
                $icon = $parent.find('.form-control-feedback[data-bv-icon-for="' + data.field + '"]'),
                $label = $parent.find('label');

            // Place the icon right after the label
            $icon.insertAfter($label);
        })
        .bootstrapValidator({
            message: 'Este valor no es válido.',
            feedbackIcons: faIcon,
            fields: {
                "IdUsuario": {
                    //message: 'The username is not valid',
                    validators: {
                        notEmpty: {
                            message: 'El numero de identificacioin es obligatorio.'
                        },
                        stringLength: {
                            min: 6,
                            max: 11,
                            message: 'El Numero de identificaicon debe tener entre 6 y 11 caracteres de largo.'
                        },
                    },
                },
                "PrimerNombre": {
                    //message: 'The username is not valid',
                    validators: {
                        notEmpty: {
                            message: 'El Primer nombre es obligatoria.'
                        },
                    },
                    stringLength: {
                        min: 3,
                        max: 11,
                        message: 'El nombre es demaciado largo.'
                    },
                },
                "SegundoNombre": {
                    //message: 'The username is not valid',
                    validators: {
                        notEmpty: {
                            message: 'El segundo nombre es obligatoria.'
                        },
                    },
                    stringLength: {
                        min: 3,
                        max: 11,
                        message: 'El nombre es demaciado largo.'
                    },
                },
                "PrimerApellido": {
                    //message: 'The username is not valid',
                    validators: {
                        notEmpty: {
                            message: 'El primer apellido es obligatoria.'
                        },
                    },
                    stringLength: {
                        min: 3,
                        max: 11,
                        message: 'El apellido es demaciado largo.'
                    },
                },
                "SegundoApellido": {
                    //message: 'The username is not valid',
                    validators: {
                        notEmpty: {
                            message: 'El primer apellido es obligatoria.'
                        },
                    },
                    stringLength: {
                        min: 3,
                        max: 11,
                        message: 'El apellido es demaciado largo.'
                    },
                },
                "Telefono": {
                    //message: 'The username is not valid',
                    validators: {
                        notEmpty: {
                            message: 'El telefono es obligatoria.'
                        },
                    },
                    stringLength: {
                        min: 7,
                        max: 11,
                        message: 'El numero telefonico demaciado largo.'
                    },
                },
            },
            })
            .on('error.validator.bv', function (e, data) {
            // $(e.target)    --> The field element
            // data.bv        --> The BootstrapValidator instance
            // data.field     --> The field name
            // data.element   --> The field element
            // data.validator --> The current validator name

            data.element
                .data('bv.messages')
                // Hide all the messages
                .find('.help-block[data-bv-for="' + data.field + '"]').hide()
                // Show only message associated with current validator
                .filter('[data-bv-validator="' + data.validator + '"]').show();
        });


});