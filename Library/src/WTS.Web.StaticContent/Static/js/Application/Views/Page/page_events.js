/*
    This is a facade over the HTML that provides the user with access to the actions that
    can be performed and events that the user can hook up to.

    The idea comes from the Humble Dialog design pattern by Michael Feathers.  The Page
    object represents the Humble Dialog aspect of the pattern.  The humble Dialog is
    a contains no process intelligence it just knows how to perform actions
    e.g. show some contents in a pop-up dialog.

    Notes -

    It may be worth replacing the homebrew event system with a more
    robust library based implementation such as js-signal
    (http://millermedeiros.github.io/js-signals/).

*/
define(["console", "jquery", "underscore", "page_api", "event", "global", "resources", "random"], function (console, $, _, page_api, event, window, resources, random) {
    console.log("page_events");

    //Setup the world
    var events = {
        save_editor: {
            handlers: [],
            bind: function () {
                var handlers = this.handlers;

                event.listen("click", ".generic-save-edits,.generic-remove-entity", function (target) {
                    //If it is located within a details list then don't execute
                    //There is a handler for save_details_list_editor
                    //We are only doing this because as at the current state of our architecture,
                    //we haven't uniquely marked our components in a way that we can target them directly
                    if (!$(target).closest(".report-wrapper")[0]) {
                        var this_submit_button = target;
                        random.generate_dom_id_for_element(this_submit_button);

                        var $this_submit_button = $(this_submit_button);


                        var the_button_id = $this_submit_button.attr("id");

                        var editor_context = $this_submit_button.closest("form");

                        editor_context.attr("action", $this_submit_button.attr("formaction"));
                        var editor_id = editor_context.attr("id");

                        _.each(handlers, function (handler) {
                            //In order not to break the existing implementation
                            //I have added an exra parameter to pass the button that trigerred the event.
                            //We need to overhaul the events system anyway, and so that is 
                            //why I have not moified this to point where it breaks anything.
                            handler(editor_id, page_api, the_button_id);
                        });
                    }
                });
            }
        },
        cancel_editor: {
            handlers: [],
            bind: function () {
                var handlers = this.handlers;

                event.listen("click", ".generic-cancel-edits", function (target) {
                    //If it is located within a details list then don't execute
                    //There is a handler for save_details_list_editor
                    //We are only doing this because as at the current state of our architecture,
                    //we haven't uniquely marked our components in a way that we can target them directly
                    if (!$(target).closest(".report-wrapper")[0]) {
                        var this_button = target;
                        var editor_context = $(this_button).closest("form");

                        var editor_id = editor_context.attr("id");

                        _.each(handlers, function (handler) {
                            handler(editor_id, page_api);
                        });
                    }
                });
            }
        },
        drill_into_entry: {
            handlers: [],
            bind: function () {
                var handlers = this.handlers;

                event.listen("click", "tbody > tr", function (target) {
                    var row = $(target);
                    var row_details = {
                        entry_id: row.attr("id"),
                        details_url: row.attr("data-details-url"),
                    };

                    _.each(handlers, function (handler) {
                        handler(row_details, page_api);
                    });
                });
            }
        },
        edit_entity: {
            handlers: [],
            bind: function () {
                var handlers = this.handlers;

                event.listen("touchstart click", ".report .generic-edit-report", function (target) {
                    //If it is located within a details list then don't execute
                    //There is a handler for save_details_list_editor
                    //We are only doing this because as at the current state of our architecture,
                    //we haven't uniquely marked our components in a way that we can target them directly
                    if (!$(target).closest(".report-wrapper")[0]) {
                        var edit_button = $(target);
                        var report = edit_button.closest(".report");

                        var edit_report_details = {
                            id: report.attr("id"),
                            editor_url: edit_button.attr("href"),
                        };

                        _.each(handlers, function (handler) {
                            handler(edit_report_details, page_api);
                        });
                    }
                });
            }
        },
        remove_entity: {
            handlers: [],
            bind: function () {
                var handlers = this.handlers;

                event.listen("click", ".report .generic-remove-entity_another", function (target) {
                    var remove_button = $(target);
                    var report = remove_button.closest(".report");

                    var details = {
                        report_id: report.attr("id"),
                        action_url: remove_button.attr("href")
                    };

                    _.each(handlers, function (handler) {
                        handler(details, page_api);
                    });
                });
            }
        },
        //Details List Events
        save_details_list_editor: {
            handlers: [],
            bind: function () {
                var handlers = this.handlers;

                event.listen("click", ".report-wrapper .generic-save-edits", function (target) {
                    var this_submit_button = target;
                    var editor_context = $(this_submit_button).closest("form");

                    editor_context.attr("action", $(this_submit_button).attr("formaction"));
                    var editor_id = editor_context.attr("id");

                    _.each(handlers, function (handler) {
                        handler(editor_id, page_api);
                    });
                });
            }
        },
        cancel_details_list_editor: {
            handlers: [],
            bind: function () {
                var handlers = this.handlers;

                event.listen("click", ".report-wrapper .generic-cancel-edits", function (target) {
                    var this_button = target;
                    var editor_context = $(this_button).closest("form");

                    var editor_id = editor_context.attr("id");

                    _.each(handlers, function (handler) {
                        handler(editor_id, page_api);
                    });
                });
            }
        },
        new_details_list_entry: {
            handlers: [],
            bind: function () {
                var handlers = this.handlers;

                event.listen("click", ".details-list-header .generic-new-entry", function (target) {
                    var new_button = $(target);
                    var report = new_button.closest(".details-list-header");

                    var new_report_details = {
                        id: report.attr("id"),
                        editor_url: new_button.attr("href"),
                    };

                    _.each(handlers, function (handler) {
                        handler(new_report_details, page_api);
                    });
                });
            }
        },
        //NOTE: THIS IS FUNDAMENTALLY DIFFERENT FROM [Edit Details List Entry]
        edit_details_list_collection: {
            handlers: [],
            bind: function () {
                var handlers = this.handlers;

                event.listen("click", ".details-list-header .generic-edit-list", function (target) {
                    var edit_button = $(target);
                    var header = edit_button.closest(".details-list-header");

                    var details = {
                        id: header.attr("id"),
                        editor_url: edit_button.attr("href"),
                    };

                    _.each(handlers, function (handler) {
                        handler(details, page_api);
                    });
                });
            }
        },
        edit_details_list_entry: {
            handlers: [],
            bind: function () {
                var handlers = this.handlers;

                event.listen("click", ".report-wrapper .report .generic-edit-report", function (target) {
                    var edit_button = $(target);
                    var report = edit_button.closest(".report");

                    var edit_report_details = {
                        id: report.attr("id"),
                        editor_url: edit_button.attr("href"),
                    };

                    _.each(handlers, function (handler) {
                        handler(edit_report_details, page_api);
                    });
                });
            }
        },
        remove_details_list_entry: {
            handlers: [],
            bind: function () {
                var handlers = this.handlers;

                event.listen("click", ".report .generic-remove-entity", function (target) {
                    var remove_button = $(target);
                    var report = remove_button.closest(".report");

                    var details = {
                        report_id: report.attr("id"),
                        action_url: remove_button.attr("href"),
                    };

                    _.each(handlers, function (handler) {
                        handler(details, page_api);
                    });
                });
            }
        },
        //Event that fires when you click on the reorder action link
        reorder_details_list_entry: {
            handlers: [],
            bind: function () {
                var handlers = this.handlers;

                event.listen('click', ".report .generic-reorder-entity", function (target) {
                    var $anchor = $(target);
                    var $report = $anchor.closest(".report");

                    var obj = {};
                    $report.closest("section.doneSortable").find(resources.reorder_item_selector).each(function (index, element) {
                        if ($report.attr("id") == $(element).attr("id")) {
                            obj.id = $report.attr("id");
                            obj.new_index = index + 1;
                            return;
                        }
                    });

                    var action_data = { priority: obj.new_index };

                    var details = {
                        id: $report.attr("id"),
                        action_data: action_data,
                        editor_url: $anchor.attr("href")
                    };

                    _.each(handlers, function (handler) {
                        handler(details, page_api);
                    });
                }, false);
            }
        },
        //Event that fires after you have dragged and dropped a report via the reorder action link
        drop_details_list_entry: {
            handlers: [],
            bind: function () {
                var handlers = this.handlers;

                event.listen(resources.sortable_dropped_event, ".report", function (target, event_data) {
                    var report = $(target);

                    var action_data = { priority: event_data.new_index };

                    var details = {
                        id: report.attr("id"),
                        action_data: action_data,
                        editor_url: report.find(".generic-reorder-entity").attr("href")
                    };

                    _.each(handlers, function (handler) {
                        handler(details, page_api);
                    });
                }, false);
            }
        },
        select_file_for_upload: {
            handlers: [],
            bind: function () {
                var handlers = this.handlers;

                event.listen("change", "input[type=file]", function (target) {
                    //Get the editor id
                    var editor_context = $(target).closest("form");

                    var editor_id = editor_context.attr("id");

                    //Now get the file
                    var reader,
                        file;

                    file = target.files[0];

                    if (!!file.type.match(/image.*/)) {
                        if (window.FileReader) {
                            reader = new window.FileReader();
                            reader.onloadend = function (e) {
                                var details = {
                                    file_data: e.target.result,
                                    editor_id: editor_id
                                };

                                _.each(handlers, function (handler) {
                                    handler(details, page_api);
                                });
                            };
                            reader.readAsDataURL(file);
                        }
                    }
                });
            }
        }
    };

    //Initialiser
    _.each(events, function (event_object) {
        event_object.bind();
    });

    //return object
    //Todo: DO - We need an on_leave event handler based on the discussion I had with Paul
    //about how we want to clear forms that are left regardless of how they are left.
    return {
        on_save_edits: function (handler) {
            events.save_editor.handlers.push(handler);
        },
        on_drill_into_entry: function (handler) {
            events.drill_into_entry.handlers.push(handler);
        },
        on_cancel_edits: function (handler) {
            events.cancel_editor.handlers.push(handler);
        },
        on_edit_entity: function (handler) {
            events.edit_entity.handlers.push(handler);
        },
        on_remove_entity: function (handler) {
            events.remove_entity.handlers.push(handler);
        },
        on_select_file_for_upload: function (handler) {
            events.select_file_for_upload.handlers.push(handler);
        },
        //Details List specific events
        on_save_details_list_edits: function (handler) {
            events.save_details_list_editor.handlers.push(handler);
        },
        on_cancel_details_list_edits: function (handler) {
            events.cancel_details_list_editor.handlers.push(handler);
        },
        on_new_details_list_entry: function (handler) {
            events.new_details_list_entry.handlers.push(handler);
        },
        //NOTE: THIS IS FUNDAMENTALLY DIFFERENT FROM [Edit Details List Entry]
        on_edit_details_list_collection: function (handler) {
            events.edit_details_list_collection.handlers.push(handler);
        },
        on_edit_details_list_entry: function (handler) {
            events.edit_details_list_entry.handlers.push(handler);
        },
        on_remove_details_list_entry: function (handler) {
            events.remove_details_list_entry.handlers.push(handler);
        },
        on_reorder_details_list_entry: function (handler) {
            events.reorder_details_list_entry.handlers.push(handler);
        },
        on_drop_details_list_entry: function (handler) {
            events.drop_details_list_entry.handlers.push(handler);
        }
    };
});