//********************************************************************
//Проблема:
//https://github.com/select2/select2/issues/1246#issuecomment-71710835
//https://stackoverflow.com/questions/19787982/select2-plugin-and-jquery-ui-modal-dialogs
//********************************************************************

// Костыль чтобы работал поиск в select2, расположенном в диалоге*******
//источник: https://github.com/select2/select2/issues/1246#issuecomment-71710835
if ($.ui && $.ui.dialog && $.ui.dialog.prototype._allowInteraction) {
    var ui_dialog_interaction = $.ui.dialog.prototype._allowInteraction;
    $.ui.dialog.prototype._allowInteraction = function (e) {
        if ($(e.target).closest('.select2-dropdown').length) return true;
        return ui_dialog_interaction.apply(this, arguments);
    };
}
// конец костыля********************************************************