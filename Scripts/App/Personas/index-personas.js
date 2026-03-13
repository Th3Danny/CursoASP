$(document).ready(function () {
    // Obtenemos las URLs desde los atributos de datos del contenedor principal o elementos específicos
    const suggestionsUrl = $("#personaSearch").data("url");
    const sliderActionUrl = $("#formSlider").attr("action");

    // --- Autocompletado ---
    $("#personaSearch").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: suggestionsUrl,
                type: "GET",
                dataType: "json",
                data: { term: request.term },
                success: function (data) {
                    response(data);
                }
            });
        },
        minLength: 1
    });

    // --- Slider de Edad ---
    let minimoInicial = 20;
    let maximoInicial = 35;
    let minimoAnterior = minimoInicial;
    let maximoAnterior = maximoInicial;

    $("#slider-range").slider({
        range: true,
        min: 1,
        max: 100,
        values: [minimoInicial, maximoInicial],
        slide: function (event, ui) {
            let min = ui.values[0];
            let max = ui.values[1];
            $("#edades").val(min + " - " + max + " años");
        },
        change: function (event, ui) {
            let min = ui.values[0];
            let max = ui.values[1];

            if (min !== minimoAnterior || max !== maximoAnterior) {
                minimoAnterior = min;
                maximoAnterior = max;
                enviarFormularioSlider(min, max);
            }
        }
    });

    // Mostrar valores iniciales
    $("#edades").val($("#slider-range").slider("values", 0) + " - " + $("#slider-range").slider("values", 1) + " años");

    function enviarFormularioSlider(min, max) {
        $("#min").val(min);
        $("#max").val(max);
        $("#formSlider").submit();
    }
});
