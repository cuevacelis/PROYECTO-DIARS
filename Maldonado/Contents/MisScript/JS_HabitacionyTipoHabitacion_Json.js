$(document).ready(function () {
    $('#TipoHabitacion').change(function () {
        $('#Habitacion').empty();
        seleccionarElemento();
    });
});

function seleccionarElemento() {
        $.ajax({
            type: "POST",
            url: '@Url.Action("TraerDatosTipoHabitacion")',
            dataType: 'json',
            data: { idHabitacion: $('#TipoHabitacion').val() },
            success: function (listarHabitacion) {
                $.each(listarHabitacion, function (i, dato) {
                    $('#Habitacion').append('<option value ="' + dato.idHabitacion + '">' + dato.numeroHabitacion + '</option>');
                })
            }
        });
    }
    