define(["global", "jquery"], function (window, $) {
    var document = window.document;

    var random_string = function (length, chars) {
        var mask = '';
        if (chars.indexOf('a') > -1) mask += 'abcdefghijklmnopqrstuvwxyz';
        if (chars.indexOf('A') > -1) mask += 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';
        if (chars.indexOf('#') > -1) mask += '0123456789';
        if (chars.indexOf('!') > -1) mask += '~`!@#$%^&*()_+-={}[]:";\'<>?,./|\\';
        var result = '';
        for (var i = length; i > 0; --i) result += mask[Math.round(Math.random() * (mask.length - 1))];
        return result;
    };

    //How to use
    //console.log(random_string(16, 'aA'));
    //console.log(random_string(32, '#aA'));
    //console.log(random_string(64, '#A!'));



    return {
        safely_generate_dom_id: function () {

            var generated_id;

            do {

                generated_id = random_string(16, 'a');

            } while (document.getElementById(generated_id))


            return generated_id;
        },
        generate_dom_id_for_element: function (element) {
            var $element = $(element);

            if (!$element.attr("id")) {
                $element.attr("id", this.safely_generate_dom_id());
            }
        }
    };
});