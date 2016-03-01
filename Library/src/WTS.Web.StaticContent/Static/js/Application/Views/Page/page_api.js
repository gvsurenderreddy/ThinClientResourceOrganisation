define(["console",
        "jquery",
        "controller",
        "presenter",
        "dom",
        "global",
        "modal",
        "guard",
        "persistent_storage",
        "string_extensions",
        "page_resources"],
    function (console,
        $,
        controller,
        presenter,
        dom,
        window,
        modal,
        guard,
        persistent_storage,
        string,
        page_resources) {
        console.log("page_api");

        var page_api = function () { };

        // Messages types
        var is_warning_message = "warning";
        var is_confirmation_message = "confirm";

        ///<Summary>
        ///Private methods
        ///</Summary>
        var show_notification_message = function (type, message) {

            guard.is_not_null_or_undefined(type, "type is null or undefined");
            guard.is_not_null_or_undefined(message, "message is null or undefined");

            var notification_body = "",
                notification_icon = "";

            if (type == is_confirmation_message) {
                notification_body = "notification-confirm";
                notification_icon = "notification-confirm-icon";
            } else if (type == is_warning_message) {
                notification_body = "notification-warning";
                notification_icon = "notification-warning-icon";
            }

            //Add the css classes
            $("#notifications").addClass(notification_body);
            $("#notification-icon").addClass(notification_icon);
            $("#notifications").append(string.format("<p>{0}</p>", message));
        };

        var navigate_to = function (url) {
            window.location.href = url;
        };

        var previous_page = function () {
            window.history.back();
        };


        // Disables all the views action.
        page_api.prototype.disable_view_actions = function () {
            $(".action").each(function () {
                dom.disableAction(this);
            });
        };

        // Enables all the view actions
        page_api.prototype.enable_view_actions = function () {
            $(".action").each(function () {
                dom.enableAction(this);
            });
        };

        // Disables all the views action.
        page_api.prototype.disable_view_actions_for = function (context_id) {
            $(string.format("#{0} .action, #{0} [data-action]", context_id)).each(function () {
                dom.disableAction(this);
            });
        };

        // Enables all the view actions
        page_api.prototype.enable_view_actions_for = function (context_id) {
            $(string.format("#{0} .action, #{0} [data-action]", context_id)).each(function () {
                dom.enableAction(this);
            });
        };

        // submits the editor save action via ajax and then calls either the 
        // on_success or on_error handler based on the HttpStauts code
        // of the response.
        page_api.prototype.submit_edits = function (options) {

            var $editor_context = $("#" + options.editor_id);


            var formData;

            try {
                formData = new window.FormData($editor_context.get(0));
                guard.is_not_null_or_undefined(formData, "FormData is not supported");
            } catch (e) {
                //Browser doesn't support formdata
                formData = $editor_context.serialize();
                //axe Global FormData
                window.FormData = undefined;
            }


            // to do: abstract this into a command module
            controller.submit_data({
                submit_url: $editor_context.attr("action"),
                submit_data: formData,
                on_success: options.on_success,
                on_error: options.on_error
            });
        };

        //Submits arbitrary data to a controller.
        page_api.prototype.submit_request = function (options) {

            // to do: abstract this into a command module
            controller.submit_data({
                submit_url: options.url,
                submit_data: options.data,
                on_success: options.on_success,
                on_error: options.on_error
            });
        };


        // Clears any messages that are currently displayed. 
        page_api.prototype.clear_all_messages = function (context) {
            //Clear previous errors if any
            $("#notifications").removeClass().empty();
            $("#notifications").append('<div id="notification-icon">');
            $("#notification-icon").removeClass();
            context = context || "body";
            var $context = $(context);
            $(".editor-input-error").removeClass("editor-input-error");
            $context.find("label.editor-label-error").empty().closest(".editor-label-errorwrapper").addClass("hidden").next(".editor-label-hoverhelp").removeClass("hidden");
        };

        // to do: (Refactoring) The common parts of the display confirmation and warning message should be extracted into a function
        // to do: (Refactoring) I think the confirm and waring messages should do exactly the same thing except the class that is
        //                      applied to the notification element.
        // to do: With field level warning we need to add add a style to the input control. 

        // Displays the messages as confirmation messages. It puts the messages in 
        // the standard field and page notification elements and sets them to the 
        // confirmation style.
        page_api.prototype.display_confirmation_messages = function (messages) {
            if (messages) {
                //loop and append the messages
                $.each(messages, function (index, object) {
                    show_notification_message(is_confirmation_message, object.message);
                });
            }
        };

        // Displays the messages as confirmation messages. It puts the messages in 
        // the standard field and page notification elements and sets them to the 
        // confirmation style.
        page_api.prototype.display_error_messages = function (messages, editor_id) {
            if (messages) {
                //Loop and append the error messages
                $.each(messages, function (index, object) {
                    if (object.field_name !== null && editor_id) {

                        var $editor = $("#" + editor_id);

                        var field = $editor.find(string.format("[name='{0}']", object.field_name));
                        if (field.length) {//or if (field[0])
                            field.addClass("editor-input-error");

                            var field_id = field.attr("id");

                            $editor.find(string.format("label[for='{0}'].editor-label-error", field_id)).append(object.message + "</br>")
                                    .closest(".editor-label-errorwrapper")
                                    .removeClass("hidden")
                                    .next(".editor-label-hoverhelp")
                                    .addClass("hidden");
                        }
                    } else {
                        show_notification_message(is_warning_message, object.message);
                    }
                });
            }
        };

        // Remove the specified editor from the page.
        page_api.prototype.remove_editor = function (editor_id) {
            $("#" + editor_id).remove();
        };

        // will perform a full page refresh
        page_api.prototype.navigate_to = function (url) {
            navigate_to(url);
        };


        page_api.prototype.persist_confirmation_notifications = function (messages) {
            persist_notifications(messages, is_confirmation_message);
        };

        page_api.prototype.persist_warning_notifications = function (messages) {

            persist_notifications(messages, is_warning_message);
        };

        var persist_notifications = function (messages, notification_type) {
            if (messages) {
                $.each(messages, function (index, object) {
                    persistent_storage.set("notification.message", object.message);
                    persistent_storage.set("notification.type", notification_type);
                });
            }
        };

        page_api.prototype.navigate_to_previous_page = function () {
            previous_page();
        };


        page_api.prototype.show_persisted_notifications = function () {
            //get the messages
            var notification_type = persistent_storage.get("notification.type");
            var notification_message = persistent_storage.get("notification.message");


            if (notification_type && notification_message) {

                show_notification_message(notification_type, notification_message);

                //clear the messages
                persistent_storage.clear("notification.message");
                persistent_storage.clear("notification.type");
            }

        };

        page_api.prototype.reload_report = function (details) {
            var report_context = $("#" + details.report_id);
            var presenter_url = report_context.attr("data-report-presenter");

            presenter.get_view({
                url: presenter_url,
                data: null,
                on_success: function (content) {
                    var editor = $(content);
                    report_context.replaceWith(editor);
                    details.on_success();
                },
                on_error: function () {
                    //show_notification_message("warning", "An error occured, please try again later");
                    navigate_to("/Error");
                }
            });
        };


        page_api.prototype.replace_report_with_editor = function (edit_report_details) {
            var report_context = $("#" + edit_report_details.id);
            var edit_report_action = edit_report_details.editor_url;
            var action_data = edit_report_details.action_data || null;
            presenter.get_view({
                url: edit_report_action,
                data: action_data,
                on_success: function (content) {
                    var editor = $(content);
                    editor.attr("data-report-presenter", report_context.attr("data-report-presenter"));
                    report_context.replaceWith(editor);
                },
                on_error: function () {
                    //show_notification_message("warning", "An error occured, please try again later");
                    navigate_to("/Error");
                }
            });
        };

        page_api.prototype.replace_details_list_with_editor = function (details) {
            var details_list_context = $("#" + details.id).closest(".report-wrapper");
            var action_url = details.editor_url;

            presenter.get_view({
                url: action_url,
                on_success: function (content) {
                    var editor = $(content);

                    details_list_context.replaceWith(editor);
                },
                on_error: function () {
                    //show_notification_message("warning", "An error occured, please try again later");
                    navigate_to("/Error");
                }
            });
        };

        page_api.prototype.append_editor_to_report = function (new_report_details) {
            var report_context = $("#" + new_report_details.id);
            var new_report_action = new_report_details.editor_url;

            presenter.get_view({
                url: new_report_action,
                on_success: function (content) {
                    var editor = $(content);
                    report_context.after(editor);
                },
                on_error: function () {
                    //show_notification_message("warning", "An error occured, please try again later");
                    navigate_to("/Error");
                }
            });
        };


        page_api.prototype.refresh_page = function (params) {
            if (params) {
                var current_url = window.location.href.split("?")[0];
                var query_string = $.param(params);

                current_url = current_url + "?" + query_string;
                navigate_to(current_url);

            } else {
                window.location.reload(true);
            }
        };

        page_api.prototype.refresh_current_route = function (params) {
            require(["route_builder"], function (route_builder) {

                var route_name = page_resources.current_route_name();
                var route_params = page_resources.current_route_params();

                $.extend(true, route_params, params);

                var url = route_builder.route_url(route_name, route_params);

                navigate_to(url);
            });
        };

        // displays the content returned from the url in modal 
        page_api.prototype.display_editor_in_modal = function (remove_report_details) {

            var report_context = $("#" + remove_report_details.id);
            var remove_report_action = remove_report_details.editor_url || report_context.find(".action.new-report").attr("href");

            presenter.get_view({
                url: remove_report_action,
                on_success: function (content) {
                    var editor = $(content);
                    editor.attr("data-report-id", report_context.attr("id"));
                    modal.showMessage(content);
                },
                on_error: function () {
                    navigate_to("/Error");
                }
            });
        };

        page_api.prototype.show_image_preview = function (image_details) {
            var img = $("#" + image_details.editor_id).find("img")[0];
            img.src = image_details.file_data;
        };

        var get_data_to_determine_destination = function (options) {

            var action_element = $("#" + options.action_id);

            var params = page_resources.current_route_params();

            var route_id = action_element.attr("data-destination-route");

            //Update route params with freshest data response from the server
            if (route_id && action_element.is("[data-post-exists]")) {
                params = options.response;
            }

            return {
                button: action_element[0],
                route_params: params,
                route_id: route_id
            };
        };


        page_api.prototype.get_known_destination_for_command = function (options) {
            require(["workflow_repository"], function (workflow_repository) {

                var data = get_data_to_determine_destination(options);

                var url;

                try {
                    if (data.route_id) {
                        url = workflow_repository.get_url_for_route(data.route_id, data.route_params);
                    } else {
                        url = workflow_repository.get_destination_for_action(data.button, data.route_params);
                    }

                    options.on_success(url);

                } catch (e) {
                    options.on_error();
                }

            });

        };

        page_api.prototype.get_known_error_destination_for_command = function (options) {

            require(["workflow_repository"], function (workflow_repository) {
                var data = get_data_to_determine_destination(options);

                var url;
                try {
                    url = workflow_repository.get_error_destination_for_action(data.button, data.route_params);
                    options.on_success(url);
                } catch (e) {
                    options.on_error();
                }

            });

        };


        //Closes the modal popup
        page_api.prototype.close_modal = function () {
            modal.close();
        };


        return new page_api();
    });
