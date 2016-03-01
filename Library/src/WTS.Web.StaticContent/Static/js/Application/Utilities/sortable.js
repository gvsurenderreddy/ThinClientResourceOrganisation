define(["jquery", "jquery_sortable", "event", "resources"], function ($, $ortable, event, resources) {




    return {
        init: function () {

            var item_selector = resources.reorder_item_selector;


            var adjustment;
            $("section.sortable").sortable({
                //MAKE ONLY ITEMS WITH SPECIFIED CSS DRAGABLE
                itemSelector: item_selector,
                //MAKE LINK NOT ADDRESS BLOCK DRAGABLE
                handle: '.reorder-report:not([disabled])',

                // NOT WORKING AS EXPECTED
                /*onMousedown: function($item, event, _super) {
                    event.preventDefault();
                    $("body").addClass("dragging");
                    $item.addClass("dragged_editor_mode");
                },*/

                onDragStart: function ($item, container, _super) {
                    // GIVE THE ADDRESS EDITOR LOOK AND FEEL
                    $item.addClass("dragged_editor_mode");
                    // SET HEIGHT AND WIDTH OF THE DRAGABLE ITEM
                    $item.css({
                        height: $item.height() + 30,
                        width: $item.width()
                    });
                    // POSITION ABSOLUTLY
                    $item.addClass("dragged");
                    // ADD EDITOR STYLEING
                    $("body").addClass("dragging");

                    // GET OFFSET POSITION OF MOUSE AND RE-POSITION DRAGABLE ITEM
                    var offset = $item.offset(),
                        pointer = container.rootGroup.pointer;
                    adjustment = {
                        left: pointer.left - offset.left,
                        top: pointer.top - offset.top
                    };
                    _super($item, container);
                },

                onDrag: function ($item, position) {
                    //RE-POSITION SORTABLE ITEM USING OFFSET POSITION
                    $item.css({
                        left: position.left - adjustment.left,
                        top: position.top - adjustment.top
                    });
                },

                onDrop: function ($item, container, _super) {
                    $item.addClass("dropped");
                    // RE POSITION RELATIVLY IN DOM
                    $item.removeClass("dragged").removeAttr("style");
                    // GET ITEM ANDNEW POSITION
                    var obj = {};

                    $item.closest("section.doneSortable").find(item_selector).each(function (index, element) {
                        if ($item.attr("id") == $(element).attr("id")) {

                            obj.id = $item.attr("id");
                            obj.index = index + 1;
                            return;
                        }
                    });

                    event.trigger(resources.sortable_dropped_event, $item[0], { new_index: obj.index });
                }
            }).addClass("doneSortable").removeClass("sortable");;

        }
    };


});