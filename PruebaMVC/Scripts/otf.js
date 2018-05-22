$(function () {
    var createAutoComplete = function () {
        var $input = $(this);

        var options = {
            source: $input.attr("data-otf-autocomplete")
        };

        $input.autocomplete(options);
    };

    $("input[data-otf-autocomplete]").each(createAutoComplete);
});
