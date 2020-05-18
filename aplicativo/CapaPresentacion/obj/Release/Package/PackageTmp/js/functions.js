$(function () {
    $(document).ready(function () {
        /* Act on the event */

        tot = $('#Contenido_total').val();
        lis = $('#Contenido_listados').val();
        fal = $('#Contenido_faltantes').val();

        console.log(lis);

        if (fal > 0) {
            document.getElementById("Contenido_agregar_dispositivo").disabled = false;
        }
        if (lis == tot & tot > 0) {
            $('#Contenido_guardar').removeAttr('disabled');
        }
        if (lis > 0) {
            document.getElementById("Contenido_eliminar_dispositivo").disabled = false;
        }
    });
    //Funcion para validar solo numeros
    $('#Contenido_cant_medidores').on('input', function () {
        this.value = this.value.replace(/[^0-9]/g, '');
        if (this.value > 0) {
            document.getElementById("Contenido_agregar_dispositivo").disabled = false;
        } else {
            document.getElementById("Contenido_agregar_dispositivo").disabled = true;
        }
    });
    //Funcion para habilitar boton
    $('#Menu_doc_entrada').keypress(function (event) {
        document.getElementById("Contenido_habilitar_grupo").disabled = false;
        document.getElementById("Menu_Individual").disabled = true;
        document.getElementById("Menu_Unico").disabled = true;
    });
    //Activa o desactiva checkbox
    $('#Menu_Individual').click(function (event) {
        console.log('Leyo click');
        if ($('#Menu_Individual').is(':checked')) {
            document.getElementById("Menu_Unico").checked = false;
        }
    });
    //Activa o desactiva checkbox
    $('#Menu_Unico').click(function (event) {
        console.log('Leyo click');
        if ($('#Menu_Unico').is(':checked')) {
            document.getElementById("Menu_Individual").checked = false;
        }
    });
    //Limpia campos
    $('#Contenido_cancelar').click(function (event) {
        $("#Contenido_marca").val('Seleccione...');
        $("#Contenido_modelo").val('Seleccione...');
        $("#Contenido_zona").val('GLOBAL');
        $("#Contenido_codigos").val('Seleccione...');
        $("#Contenido_serial").val('');
        $("#Contenido_energia").val('0');
        $("#Contenido_fase").val('0');
        $("#Contenido_nombreGrupo").val('');
        document.getElementById("Contenido_agregar_dispositivo").disabled = false;
    });
    //Validar campos
    $('#Contenido_actualizarSerial').click(function (event) {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>$('#modalSerial').modal('show');</script>");
        console.log('Entro actualizar serial');
    });
    //Valida eliminar
    $('#Contenido_eliminar_dispositivo').click(function (event) {
        $('#Contenido_elimina').val('1');
    });
    //Cambia eliminar
    $('#Contenido_agregar_dispositivo').click(function (event) {
        $('#Contenido_elimina').val('0');
        $('#Contenido_redirecciona').val('0');
    });
    //Cambia redireccionar
    $('#Menu_creacion_btn').click(function (event) {
        $('#Contenido_redirecciona').val('1');
    });
    $('#Menu_cargar_btn').click(function (event) {
        $('#Contenido_redirecciona').val('1');
    });
    $('#Menu_consultar_btn').click(function (event) {
        $('#Contenido_redirecciona').val('1');
    });
});