﻿$(document).ready(function () {

    /* Funções do filtro de dados */

    $("#escolhaLocal").change(function (event) {
        if ($("#escolhaLocal").text != "Escolha Uma Opção") {
            local();
            $("#qtdPessoas").focus();
        } else { local();}
    });

    $("#qtdPessoas").keypress(function (event) {
        if (event.keyCode === 13) {
            pessoas();
            $("#transporte").focus();
        }
    });

    $("#transporte").change(function () {
        if ($("#transporte").val() > 0) {
            $("#contentTipoPasseio").removeClass("ocultar");
            $("#contentTipoPasseio").addClass("mostrar");
        } else {
            $("#contentTipoPasseio").removeClass("mostrar");
            $("#contentTipoPasseio").addClass("ocultar");

            $("#contentData").removeClass("mostrar");
            $("#contentData").addClass("ocultar");

            $("#contentSubmit").removeClass("mostrar");
            $("#contentSubmit").addClass("ocultar");

        }
    });

    $("#tipoPasseio").change(function () {
        if ($("#tipoPasseio").val() > 0) {
            $("#contentData").removeClass("ocultar");
            $("#contentData").addClass("mostrar");

        } else {
            $("#contentData").removeClass("mostrar");
            $("#contentData").addClass("ocultar");

            $("#contentSubmit").removeClass("mostrar");
            $("#contentSubmit").addClass("ocultar");
            
        }
    });

    $("#data").change(function () {

         dataEscolhida = new Date($("#data").val());

        if ( dataEscolhida != "") {
            $("#contentSubmit").removeClass("ocultar");
            $("#contentSubmit").addClass("mostrar");
        } else {
            $("#contentSubmit").removeClass("mostrar");
            $("#contentSubmit").addClass("ocultar");
        }
    })

    function local() {
        if ($("#escolhaLocal").val() == 0) {

            $("#escolhaLocal").parent().find('.text-white').remove();
            $("#escolhaLocal").parent().find("#escolhaLocal").after('<div class="text-white">* escolha um Lugar valido</div>')

            $("#contentPessoas").removeClass("mostrar");
            $("#contentTransporte").removeClass("mostrar");
            $("#contentTipoPasseio").removeClass("mostrar");
            $("#contentData").removeClass("mostrar");
            $("#contentSubmit").removeClass("mostrar");

            $("#contentPessoas").addClass("ocultar");
            $("#contentTransporte").addClass("ocultar");
            $("#contentTipoPasseio").addClass("ocultar");
            $("#contentData").addClass("ocultar");
            $("#contentSubmit").addClass("ocultar");

            $("#itinerarios").css({ "display": "none" });
            $("#guias").css({ "display": "none" });
            $("#mapContainer").fadeIn();

        }
        else {
            $("#escolhaLocal").parent().find('.text-white').remove();
            $("#contentPessoas").addClass("mostrar");


            /* API */

            const local = $("#escolhaLocal option:selected").text() + ", Sp Brazil";

            var geocodingParams = {
                searchText: local
            };
            geocoder.geocode(geocodingParams, onResult);

            /*-----*/
        }
    }

    function pessoas() {
        if ($("#qtdPessoas").val() <= 0) {
            $("#qtdPessoas").parent().find('.text-white').remove();
            $("#qtdPessoas").parent().find("#qtdPessoas").after('<div class="text-white">* quantidade Invalida </div>')

            $("#contentTransporte").removeClass("mostrar");
            $("#contentTipoPasseio").removeClass("mostrar");
            $("#contentData").removeClass("mostrar");
            $("#contentSubmit").removeClass("mostrar");

            $("#contentTransporte").addClass("ocultar");
            $("#contentTipoPasseio").addClass("ocultar");
            $("#contentData").addClass("ocultar");
            $("#contentSubmit").addClass("ocultar");

            $("#itinerarios").css({ "display": "none" });
            $("#mapContainer").fadeIn();
        }
        else {
            $("#qtdPessoas").parent().find('.text-white').remove();
            $("#contentTransporte").addClass("mostrar");
        }
    }

    $(".tituloGuia .fas").on('click', function () {
        $("#itinerarios").fadeIn();
        $("#guias").css({ "display": "none" });
    });
    // BOTAO VOLTAR DO GUIA PARA O ITINERARIO
    
    /*-----------------------------------------------------------------*/

    /* API HERE MAPS */

    var platform = new H.service.Platform({
        'apikey': 'qy2EUkFz4iTpW0WfGvAYA1kaganJjd52UfQDbEzOKb4',
        'app_code': 'peuqmjdjvoegIPIXAfTj'
    });

    var defaultLayers = platform.createDefaultLayers();

    var map = new H.Map(document.getElementById('mapContainer'),
        defaultLayers.vector.normal.map,
        {
            center: { lat: 52.5, lng: 13.4 }

        });

    var geocodingParams = {
        searchText: 'Guaratinguetá'
    };


    var onResult = function (result) {
        var locations = result.Response.View[0].Result,
            position,
            marker;

        for (i = 0; i < locations.length; i++) {
            position = {
                lat: locations[i].Location.DisplayPosition.Latitude,
                lng: locations[i].Location.DisplayPosition.Longitude
            };

            map.setCenter(position);
            map.setZoom(15);

            marker = new H.map.Marker(position);
            map.addObject(marker);
        }
    };

    var geocoder = platform.getGeocodingService();

    geocoder.geocode(geocodingParams, onResult);

    /*-----------------------------------------------------------------*/

    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
    var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl)
    })
});