require(["jquery"], function ($) {
    ///<Summary>
    ///The colour picker's interactions are wired up here.
    ///We hijack its behaviour on click and supply the selected value to the field
    ///</Summary>

    $(document).on('click', '.ColourPicker-Toggle', function () {
        var $me = $(this);
        var $area = $me.closest(".ColourPicker-Wrapper");

        $area.find('.ColourPicker-Palette').show();
    });

    $(document).on('click', '.ColourPicker-Palette-Close', function () {
        var $me = $(this);
        var $area = $me.closest(".ColourPicker-Wrapper");

        $area.find('.ColourPicker-Palette').hide();
    });


    $(document).on('click', ".ColourPicker-Wrapper [data-colour-value]", function () {
        var $me = $(this);
        var colour = $me.attr("data-colour-value");
        var rgb_array = colour.split(",");

        var R = rgb_array[0].split("(")[1];
        var G = rgb_array[1];
        var B = rgb_array[2].split(")")[0];

        var $area = $me.closest(".ColourPicker-Wrapper");
        $area.find('.colour-value-r').val(R);
        $area.find('.colour-value-g').val(G);
        $area.find('.colour-value-b').val(B);

        $area.find(".current-colour-value").css("background-color", colour);


        $area.find('.ColourPicker-Palette').hide();
    });


});